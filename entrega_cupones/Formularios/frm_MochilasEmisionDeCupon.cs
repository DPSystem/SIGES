using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using entrega_cupones.Clases;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;

namespace entrega_cupones.Formularios
{
  public partial class frm_MochilasEmisionDeCupon : Form
  {
    public double _cuil;
    public string _cuilStr; // Variable global que almacena el cuil que viene del form de busqueda
    public int _UsuarioID = 0;
    public string _NroSocio = "";
    public string _nroDNI = "";
    public string _ApeNom = "";
    public string _Empresa = "";
    List<MdlBenef> _Beneficiarios = new List<MdlBenef>();
    public frm_MochilasEmisionDeCupon()
    {
      InitializeComponent();
    }

    private void frm_MochilasEmisionDeCupon_Load(object sender, EventArgs e)
    {

      this.Text = "Mochilas " + DateTime.Now.Date.Year.ToString() + " - Emision de Cupones";

      dgv_Beneficiarios.AutoGenerateColumns = false;

      MostrarDatosDelSocio();
      MostrarBeneficiarios();
      CargarCbxMochilas();

      cbx_Localidad.SelectedIndex = _UsuarioID == 21 ? 1 : 0;  // 21 es petico

    }

    private void MostrarDatosDelSocio()
    {
      picbox_FotoSocio.Image = mtdConvertirImagen.ByteArrayToImage(mtdSocios.get_foto_titular_binary(_cuil).ToArray());
      txt_NroSocio.Text = _NroSocio;
      txt_DNI.Text = _nroDNI;
      txt_Nombre.Text = _ApeNom;
      txt_RazonSocial.Text = _Empresa;
    }

    private void MostrarBeneficiarios()
    {
      dgv_Beneficiarios.DataSource = _Beneficiarios = mtdSocios.GetBeneficiarios(_cuil).ToList();
    }

    private void MarcarNoCorresponde()
    {


    }
    private void CargarCbxMochilas()
    {
      cbx_Mochilas.DisplayMember = "Descripcion";
      cbx_Mochilas.ValueMember = "Id";
      cbx_Mochilas.DataSource = MtdMochilas.GetMochilas();
    }



    private void btn_GuardarCupon_Click(object sender, EventArgs e)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        eventos_cupones insert = new eventos_cupones();

        if (context.eventos_cupones.Where(x => x.eventcupon_evento_id == 5).Count() > 0)
        {
          insert.event_cupon_nro = context.eventos_cupones.Where(x => x.eventcupon_evento_id == 5).Max(x => x.event_cupon_nro) + 1;
        }
        else
        {
          insert.event_cupon_nro = 1;
        }

        //insert.TurnoId = GetTurno(cuilSocio, Termas);
        insert.eventcupon_evento_id = 5;
        insert.eventcupon_maesoc_cuil = _cuil;
        insert.eventcupon_maeflia_codfliar = 0;
        //insert.event_cupon_event_exep_id = ExepcionID;
        insert.event_cupon_fecha = DateTime.Now;
        insert.UsuarioId = _UsuarioID;
        insert.ArticuloID = 0;
        insert.QuienRetiraCupon = "";
        //insert.FondoDeDesempleo = FondoDeDesempleo;
        insert.CuilStr = _cuilStr;
        insert.Reimpresion = 0;

        context.eventos_cupones.InsertOnSubmit(insert);
        context.SubmitChanges();



        foreach (DataGridViewRow fila in dgv_Beneficiarios.Rows)
        {
          if (Convert.ToInt32(fila.Cells["MochilaId"].Value) > 0 && fila.Cells["Cupon"].Value == null)
          {
            CuponBenefArticulos CuponArticulo = new CuponBenefArticulos();
            CuponArticulo.NroCupon = insert.event_cupon_nro;
            CuponArticulo.Cuil = _cuilStr;
            CuponArticulo.CodigoFliar = Convert.ToInt32(fila.Cells["CodigoFliar"].Value);
            CuponArticulo.ArticuloId = Convert.ToInt32(fila.Cells["MochilaId"].Value);
            CuponArticulo.EventoId = 5;
            CuponArticulo.Estado = 0;
            context.CuponBenefArticulos.InsertOnSubmit(CuponArticulo);
            context.SubmitChanges();
          }
        }
        MostrarBeneficiarios();
      }
    }

    private void btn_Cargar_Click(object sender, EventArgs e)
    {
      string mochila = cbx_Mochilas.GetItemText(cbx_Mochilas.SelectedItem);
      dgv_Beneficiarios.CurrentRow.Cells["Mochila"].Value = mochila;
      dgv_Beneficiarios.CurrentRow.Cells["MochilaId"].Value = cbx_Mochilas.SelectedValue;
      btn_GuardarCupon.Enabled = true;

    }


    private void dgv_Beneficiarios_SelectionChanged(object sender, EventArgs e)
    {
      if (Convert.ToInt32(dgv_Beneficiarios.CurrentRow.Cells["MochilaId"].Value) > 0 && dgv_Beneficiarios.CurrentRow.Cells["Cupon"].Value != null)
      {
        btn_Cargar.Enabled = false;
        btn_Imprimir.Enabled = true;
      }
      else
      {
        btn_Cargar.Enabled = true;
        btn_Imprimir.Enabled = false;
      }

      if (Convert.ToInt32(dgv_Beneficiarios.CurrentRow.Cells["MochilaId"].Value) > 0 && dgv_Beneficiarios.CurrentRow.Cells["Cupon"].Value == null)
      {
        btn_GuardarCupon.Enabled = true;
      }
      else
      {
        btn_GuardarCupon.Enabled = false;
      }

      if (Convert.ToInt32(dgv_Beneficiarios.CurrentRow.Cells["Edad"].Value) < 2 || Convert.ToInt32(dgv_Beneficiarios.CurrentRow.Cells["Edad"].Value) > 20)
      {
        btn_Cargar.Enabled = false;
        btn_GuardarCupon.Enabled = false;
      }
    }

    private void btn_Imprimir_Click(object sender, EventArgs e)
    {
      ImprimirCupon(0);
    }

    private void ImprimirCupon(int Reimpresion)
    {
      int JM = 0, JV = 0, P1M = 0, P1V = 0, P2M = 0, P2V = 0, SM = 0, SV = 0;

      int NroCupon = Convert.ToInt32(dgv_Beneficiarios.CurrentRow.Cells["Cupon"].Value);

      foreach (DataGridViewRow fila in dgv_Beneficiarios.Rows)
      {
        if (NroCupon == Convert.ToInt32(fila.Cells["Cupon"].Value))
        {
          _ = Convert.ToInt32(fila.Cells["MochilaId"].Value) == 1 ? (JM += 1) : (JM += 0);
          _ = Convert.ToInt32(fila.Cells["MochilaId"].Value) == 2 ? (JV += 1) : (JV += 0);
          _ = Convert.ToInt32(fila.Cells["MochilaId"].Value) == 3 ? (P1M += 1) : (P1M += 0);
          _ = Convert.ToInt32(fila.Cells["MochilaId"].Value) == 4 ? (P1V += 1) : (P1V += 0);
          _ = Convert.ToInt32(fila.Cells["MochilaId"].Value) == 5 ? (P2M += 1) : (P2M += 0);
          _ = Convert.ToInt32(fila.Cells["MochilaId"].Value) == 6 ? (P2V += 1) : (P2V += 0);
          _ = Convert.ToInt32(fila.Cells["MochilaId"].Value) == 7 ? (SM += 1) : (SM += 0);
          _ = Convert.ToInt32(fila.Cells["MochilaId"].Value) == 8 ? (SV += 1) : (SV += 0);
        }
      }

      MdlFilial DatosFilial = mtdFilial.Get_DatosFilial2().FirstOrDefault();
      usuarios usr = new usuarios();
      // string TipoDeMochila = string.Empty;
      reportes frm_reportes = new reportes();
      //EventosCupones EvntCpn = new EventosCupones();
      DS_cupones ds = new DS_cupones();


      DataTable dt = ds.cupon_dia_niño;
      dt.Clear();
      DataRow dr = dt.NewRow();
      dr["titu_apenom"] = DatosFilial.SecretearioGeneral;
      dr["titu_dni"] = DatosFilial.SubSecretario;
      //dr["titu_empresa"] = DatosFilial.SecretearioGeneral == "Victor Salto" ? "FECHA DE ENTREGA EL DIA SABADO 26 DE FREBRERO DEL 2022 DE 9 A 21 HS LUGAR: SEDE SINDICAL -SARMIENTO N° 498 - LA BANDA" : "";
      //dr["titu_nrosocio"] = datos.nrosocio;
      dr["titu_foto"] = mtdSocios.get_foto_titular_binary(_cuil).ToArray();
      dr["benef_apenom"] = DatosFilial.Nombre;
      //dr["benef_dni"] = fila.Cells["Dni"].Value;
      //dr["benef_sexo"] = fila.Cells["sexo"].Value;
      //dr["benef_edad"] = fila.Cells["Edad"].Value;
      dr["benef_foto"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg"));
      //dr["event_nrocupon"] = nrocupon;
      //dr["event_fechaentrega"] = DateTime.Now;
      //dr["event_cupon_ID"] = EvntCpn.GetCuponID();
      //dr["reimpresion"] = "0";
      dt.Rows.Add(dr);

      frm_reportes.NombreDelReporte = "entrega_cupones.Reportes.rpt_MochilasEntregaCupones2.rdlc";

      frm_reportes.dt2 = dt;
      frm_reportes.dt = mtdFilial.Get_DatosFilial();
      frm_reportes.Parametro1 = "MOCHILAS " + DateTime.Now.Date.Year.ToString() + " - CUPON DE ENTREGA "; // + NroCupon.ToString(); // Encabezado del cupon
      frm_reportes.Parametro2 = NroCupon.ToString();// + " R" + Reimpresion.ToString(); // Nro de cupon
      frm_reportes.Parametro3 = txt_NroSocio.Text.Trim(); // Nro de Socio
      frm_reportes.Parametro4 = JM.ToString();//edad.Trim();//edad del Beneficiario
      frm_reportes.Parametro5 = JV.ToString(); //dniBeneficiario; //dni del Beneficiario
      frm_reportes.Parametro6 = P1M.ToString(); //apenomBeneficiario; // mombre del beneficiario
      frm_reportes.Parametro7 = txt_RazonSocial.Text.Trim(); // Empresa del titular
      frm_reportes.Parametro8 = P1V.ToString();//TipoDeMochila; // que tipo de mochila lleva primaria/secundaria/Jardin
      frm_reportes.Parametro9 = txt_Nombre.Text.Trim(); // Nombre del Titular
      frm_reportes.Parametro10 = txt_DNI.Text.Trim(); //Dni del titular
      frm_reportes.Parametro11 = usr.ObtenerNombreDeUsuario(_UsuarioID); //Usuario nombre 
      frm_reportes.Parametro12 = DateTime.Now.ToString(); //Fecha
      frm_reportes.Parametro13 = P2M.ToString(); //txt_QuienRetira.Text; //quien retira el Cupon
      frm_reportes.Parametro14 = P2V.ToString(); //chk_FondoDeDesempleo.Checked == true ? "Fdo. Desempleo: SI" : "Fdo. Desempleo: NO";
      frm_reportes.Parametro15 = SM.ToString();//"Turno: " + EvntCpn.GetDiaHoraDelTurno(EvntCpn.ConsultarTurno(Convert.ToString(_cuil)));
      frm_reportes.Parametro16 = SV.ToString();
      frm_reportes.Show();

      //using (var context = new lts_sindicatoDataContext())
      //{
      //  var Impreso = context.eventos_cupones.Where(x => x.event_cupon_nro == NroCupon).FirstOrDefault();
      //  Impreso.Reimpresion = 1;
      //  context.SubmitChanges();

      //}

    }

    private void dgv_Beneficiarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void Btn_Reimprimir_Click(object sender, EventArgs e)
    {
    //  using (var context = new lts_sindicatoDataContext())
    //  {
    //    int reimp = 0;
    //    int NroCupon = Convert.ToInt32(dgv_Beneficiarios.CurrentRow.Cells["Cupon"].Value);
    //    var Impreso = context.eventos_cupones.Where(x => x.event_cupon_nro == NroCupon).FirstOrDefault();
    //    reimp = (int)Impreso.Reimpresion + 1;
    //    Impreso.Reimpresion += 1;
    //    context.SubmitChanges();

    //    ImprimirCupon(reimp);
    //  }
    }
  }
}

