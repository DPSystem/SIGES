using entrega_cupones.Clases;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrega_cupones.Formularios
{
  public partial class frm_DDNiño : Form
  {
    public double _Cuil;
    public int _EventoId;
    public int _EventoAñoId;
    public int _UsuarioId;
    public string _TitularApenom;
    public string _TituDNI;
    public string _RazonSocial;
    public string _NroSocio;
    public int _NroCupon;
    public int _Exepcion;
    public int _SorteoConfig;
    public int _Reimprimir;
    List<MdlPermisos> _Permisos = new List<MdlPermisos>();

    public frm_DDNiño()
    {
      InitializeComponent();
    }

    private void frm_DDNiño_Load(object sender, EventArgs e)
    {
      Dgv_Beneficiarios.AutoGenerateColumns = false;
      Dgv_Beneficiarios.DataSource = MtdBeneficiarios.GetBeneficiarios(_Cuil, _EventoAñoId);
      GestionarPermisos();
    }

    private void GestionarPermisos()
    {
      var ControlsButon = Controls.OfType<Button>().ToList();
      _Permisos = MtdPermisos.GetPermisosDeUsuario(_UsuarioId);

      //foreach (var objeto in _Permisos)//MtdPermisos.GetPermisosDeUsuario(_UsuarioId))
      //{
      //  foreach (var cntrl in ControlsButon)
      //  {
      //    if (objeto.ObjetoNombre == cntrl.Name)
      //    {
      //      cntrl.Enabled = objeto.ObjetoEstado == 1;
      //    }
      //  }
      //}
    }


    private void dgv_Beneficiarios_SelectionChanged(object sender, EventArgs e)
    {
      Picbox_Beneficiario.Image = MtdBeneficiarios.GetFotoBenef(Convert.ToDouble(Dgv_Beneficiarios.CurrentRow.Cells["codigo_fliar"].Value));
      lbl_Parentesco.Text = Dgv_Beneficiarios.CurrentRow.Cells["parentesco"].Value.ToString();

      if (_Permisos.Where(x => x.ObjetoNombre == "btn_Reimprimir" && x.ObjetoEstado == 1).Count() > 0)
      {
        btn_Reimprimir.Enabled = Dgv_Beneficiarios.CurrentRow.Cells["Cupon"].Value == null ? false : true;
      }

      if (_Permisos.Where(x => x.ObjetoNombre == "Btn_Exepcion" && x.ObjetoEstado == 1).Count() > 0)
      {
        Btn_Exepcion.Enabled = Dgv_Beneficiarios.CurrentRow.Cells["Cupon"].Value == null ? true : false;
      }
    }

    private void btn_GenerarCupon_Click(object sender, EventArgs e)
    {
      //try
      //{
        using (var context = new lts_sindicatoDataContext())
        {
          string CodigoFamiliar = Dgv_Beneficiarios.CurrentRow.Cells["codigo_fliar"].Value.ToString();
          var Edades = from a in context.EventosAño where a.Id == _EventoAñoId select a;
          int EdadDesde = (int)Edades.SingleOrDefault().EdadDesde;
          int EdadHasta = (int)Edades.SingleOrDefault().EdadHasta;
          int SorteoEdadDesde = (int)Edades.SingleOrDefault().SorteoEdadDesde;
          int SorteoEdadHasta = (int)Edades.SingleOrDefault().SorteoEdadHasta;
          //int NroCupon = string.IsNullOrEmpty( Dgv_Beneficiarios.CurrentRow.Cells["codigo_fliar"].Value.ToString()) ? ;

          if (MtdEventos.GetCuponGenerado_(_EventoAñoId, CodigoFamiliar) == 0)
          {
            int Edad = (int)Dgv_Beneficiarios.CurrentRow.Cells["Edad"].Value;

            if (Edad >= EdadDesde && Edad <= EdadHasta)
            {
              if (_SorteoConfig == 1) // Esta activa la configuracion del intervalo de edad para el sorteo
              {
                if (Edad >= SorteoEdadDesde && Edad <= SorteoEdadHasta) // Pregunto si la edad esta entre las edades del campo SorteoConfig
                {
                  _NroCupon = MtdEventos.GetUltimoNroDeCupon(_EventoAñoId) + 1;
                }
                else
                {
                  _NroCupon = 0;
                }
              }
              else
              {
                _NroCupon = MtdEventos.GetUltimoNroDeCupon(_EventoAñoId) + 1;
              }

              SetCuponDDN();

            }
            else
            {
              MessageBox.Show("No Corresponde Emitir este cupon. La edad del Beneficiario no es la correcta", "ATENCION");
            }
          }
          else
          {
            MessageBox.Show("El cupon ya fue emitido. Para Reimprimir debe solicitar que lo haga  un usuario con Clave Autorizada a Reimprimir", "ATENCION");
          }
        }
      //}
      //catch (Exception ex)
      //{
      //  MessageBox.Show(ex.Message);
      //  throw;
      //}
    }

    private void SetCuponDDN()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        EventosCupones_ ec = new EventosCupones_();
        ec.FechaGeneracion = DateTime.Now;
        ec.EventoId = _EventoId;
        ec.EventoAnioId = _EventoAñoId;
        ec.NroCupon = _NroCupon;
        ec.CuilTitular = _Cuil.ToString();
        ec.CodigoFamiliar = Dgv_Beneficiarios.CurrentRow.Cells["codigo_fliar"].Value.ToString();
        ec.DniFamiliar = Dgv_Beneficiarios.CurrentRow.Cells["DNI"].Value.ToString();
        ec.UsuarioId = _UsuarioId;
        ec.Estado = 1;
        ec.Exepcion = _Exepcion;
        context.EventosCupones_.InsertOnSubmit(ec);
        context.SubmitChanges();
        ImprimirCuponDDNiño();
        Dgv_Beneficiarios.DataSource = MtdBeneficiarios.GetBeneficiarios(_Cuil, _EventoAñoId);
      }
    }

    private void ImprimirCuponDDNiño()
    {

      using (var context = new lts_sindicatoDataContext())
      {
        try
        {
          //Como el reporte es en Forma Vertical se Gira la Imagen que se pasa al DataTable
          Bitmap Foto = (Bitmap)Picbox_Beneficiario.Image;
          Foto.RotateFlip(RotateFlipType.Rotate270FlipY);

          Bitmap Logo = (Bitmap)Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg");
          Logo.RotateFlip(RotateFlipType.Rotate270FlipNone);

          var EventAño = (from a in context.EventosAño where a.Id == _EventoAñoId select a).FirstOrDefault();
          string R = _Reimprimir == 1 ? " - R" : "";
          reportes frm_reportes = new reportes();
          DS_cupones ds = new DS_cupones();

          DataTable dt = ds.cupon_dia_niño;
          dt.Clear();
          DataRow dr2 = dt.NewRow();
          dr2["titu_apenom"] = _TitularApenom;
          dr2["titu_dni"] = _TituDNI;
          dr2["titu_empresa"] = _RazonSocial;
          dr2["titu_nrosocio"] = _NroSocio;
          dr2["benef_apenom"] = Dgv_Beneficiarios.CurrentRow.Cells["apeynom"].Value.ToString(); //_NroSocio == 0 ? "INVITADA" : "N°: " + GetNroDeCupon().ToString();
          dr2["benef_dni"] = Convert.ToInt32(Dgv_Beneficiarios.CurrentRow.Cells["DNI"].Value).ToString("N0");
          dr2["benef_edad"] = Convert.ToInt32(Dgv_Beneficiarios.CurrentRow.Cells["Edad"].Value);
          dr2["benef_foto"] = mtdConvertirImagen.ImageToByteArray(Foto);//mtdConvertirImagen.ImageToByteArray( Picbox_Beneficiario.Image);
          dr2["event_nrocupon"] = _NroCupon;
          dr2["event_fechaentrega"] = DateTime.Now;
          dr2["logo"] = mtdConvertirImagen.ImageToByteArray(Logo);
          dr2["reimpresion"] = _Reimprimir;

          if (_NroCupon == 0)
          {
            dr2["Linea1"] = "CUPON PARA JUGUETE" + R;
            dr2["Linea2"] = "↑ ↑ ↑ NO VALIDO PARA SORTEO ↑ ↑ ↑";
            dr2["Linea4"] = "DIA DEL NIÑO - " + EventAño.Año.ToString() + R;
          }
          else
          {
            dr2["Linea1"] = "CUPON SORTEO N° " + _NroCupon.ToString() + R;
            dr2["Linea2"] = "↑ ↑ ↑ CUPON PARA LA URNA ↑ ↑ ↑";
            dr2["Linea4"] = "CUPON SORTEO N° " + _NroCupon.ToString() + R;
          }

          dr2["Linea3"] = "↓ ↓ ↓ CUPON PARA EL SOCIO ↓ ↓ ↓";
          dr2["Linea5"] = EventAño.Linea5;
          dr2["Linea6"] = EventAño.Liena6;
          dr2["Linea7"] = EventAño.Linea7;
          dr2["Linea8"] = EventAño.Linea8;
          dr2["Linea9"] = EventAño.Linea9;
          dr2["Linea10"] = EventAño.Linea10;
          dr2["Linea11"] = EventAño.Linea11;
          dr2["Linea12"] = EventAño.Linea12;



          dt.Rows.Add(dr2);

          frm_reportes.dt = dt;
          frm_reportes.dt2 = mtdFilial.Get_DatosFilial();

          frm_reportes.NombreDelReporte = "rpt_CuponDDNiño"; //_NroCupon == 0 ? "rpt_CuponDDNiñoExepcion" : "rpt_CuponDDNiño";
          frm_reportes.Show();

        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    private void btn_Salir_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void Btn_Exepcion_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Esta Totalmente Seguro de Emitir la Exepcion?'' ", "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        _NroCupon = 0;
        _Exepcion = 1;
        SetCuponDDN();
        _Exepcion = 0;
      }
    }

    private void btn_Reimprimir_Click(object sender, EventArgs e)
    {
      _Reimprimir = 1;
      _NroCupon = Convert.ToInt32(Dgv_Beneficiarios.CurrentRow.Cells["Cupon"].Value.ToString());
      ImprimirCuponDDNiño();
      _Reimprimir = 0;
    }
  }
}
