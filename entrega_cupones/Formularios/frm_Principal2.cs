using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using entrega_cupones.Clases;
using entrega_cupones.Formularios.Informes;
using entrega_cupones.Formularios.Tesoreria;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;
using Microsoft.Reporting.WebForms;

namespace entrega_cupones.Formularios
{
  public partial class frm_Principal2 : Form
  {
    public int _UserId;
    public int _UserRol;
    public string _RolNombre;
    public string _UserDNI;
    public string _User_Cuil;
    public string _UserNombre;
    public bool _EsSocio;


    int _BuscarPor = 0;
    int _FiltroDeSocio = 0;
    string _CUIT = "0";
    string _CodigoPostal = "0";
    int _NroDeSocio = 0;
    int _Jordada = 0;
    int _CodigoCategoria = 0;
    int _ActivoEnEmpresa = 0;
    int _Jubilados = 0;
    int _IndexDGV_Socios = 0;

    DateTime _FechaDeBaja = Convert.ToDateTime("01-01-1000");

    Func_Utiles fnc = new Func_Utiles();
    Buscadores buscar = new Buscadores();
    convertir_imagen cnvimg = new convertir_imagen();

    List<mdlSocio> _SociosABuscar = new List<mdlSocio>();
    List<mdlSocio> _Encontrados = new List<mdlSocio>();

    public frm_Principal2(int id, string Nombre, string dni, string rol_nombre, int rol_Id)
    {
      InitializeComponent();

      _UserId = id;
      _UserNombre = Nombre;
      _UserDNI = dni;
      _RolNombre = rol_nombre;
      _UserRol = rol_Id;

      GestionarPermisos();
    }

    private void frm_Principal2_Load(object sender, EventArgs e)
    {

      _SociosABuscar = mtdSocios.GetMaeSoc();

      Icon = new Icon("C:\\SEC_Gestion\\Imagen\\icono.ico");

      dgv_MostrarBeneficiario.AutoGenerateColumns = false;
      Dgv_Socios.AutoGenerateColumns = false;
      dgv_MostrarAportes.AutoGenerateColumns = false;

      CargarCategorias();
      CargarLocalidad();
      CargarCategorias();
      CargarCbxEmpresas();

      cbx_NroDeSocio.SelectedIndex = 0;
      cbx_Jornada.SelectedIndex = 0;

      cbx_ActivoEnEmpresa.SelectedIndex = 0;
      cbx_Jubilados.SelectedIndex = 0;

      cbx_Localidad.SelectedIndex = 0;
      cbx_Categoria.SelectedIndex = 0;
      Cbx_FiltrarSocios.SelectedIndex = 0;

      Cbx_Empresa.SelectedIndex = 0;

      lbl_Usuario.Text = _UserNombre;
      lbl_Rol.Text = _RolNombre;

      var foto = buscar.get_titular(_UserDNI);
      if (foto.foto != null)
      {
        roundPictureBox1.Image = cnvimg.ByteArrayToImage(foto.foto.ToArray());
      }
    }

    private void GestionarPermisos()
    {
      //var Allcontrols = this.Controls;

      var ControlsButon = Controls.OfType<Button>().ToList();

      var ControlsButtonsInPanel = this.pnl_Menu2.Controls.OfType<Button>().ToList();

      var ControlsText = this.panel1.Controls.OfType<TextBox>().ToList();

      var ControlCbxInPnl_Creditos = this.panel1.Controls.OfType<ComboBox>().ToList();

      var ControlsButtonsMenu = this.menuStrip1.Items;

      foreach (var objeto in MtdPermisos.GetPermisosDeUsuario(_UserId))
      {
        foreach (var btn in ControlsButon)
        {

          if (objeto.ObjetoNombre == btn.Name)
          {
            btn.Enabled = objeto.ObjetoEstado == 1;
            btn.Visible = true;
          }
        }

        foreach (var cntrl in ControlsText)
        {

          if (objeto.ObjetoNombre == cntrl.Name)
          {
            cntrl.ReadOnly = objeto.ObjetoEstado == 1;
          }
        }

        foreach (var btn2 in ControlsButtonsInPanel)
        {

          if (objeto.ObjetoNombre == btn2.Name)
          {
            btn2.Enabled = objeto.ObjetoEstado == 1;
            btn2.Visible = objeto.ObjetoEstado == 1;
          }
        }

        foreach (var cbx in ControlCbxInPnl_Creditos)
        {

          if (objeto.ObjetoNombre == cbx.Name)
          {
            cbx.Enabled = objeto.ObjetoEstado == 1;
          }
        }

        for (int i = 0; i < ControlsButtonsMenu.Count; i++)
        {
          if (ControlsButtonsMenu[i].Name.Trim() == objeto.ObjetoNombre.Trim())
          {
            menuStrip1.Items[i].Enabled = objeto.ObjetoEstado == 1;
            //objeto.Enabled = objeto.ObjetoEstado == 1;
            //objeto.Visible = true;
          }
        }
      }
    }

    private void CargarLocalidad()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        //var loc = (from a in context.localidades where a.idprovincias == 14 select a).OrderBy(x => x.nombre);
        var loc = (from a in context.localidad where a.MAELOC_CODPROV == "G" select a).OrderBy(x => x.MAELOC_NOMBRE);
        cbx_Localidad.DisplayMember = "MAELOC_NOMBRE";
        cbx_Localidad.ValueMember = "MAELOC_CODLOC";
        cbx_Localidad.DataSource = loc.ToList();
      }
    }

    private void CargarCategorias()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var cat = (from a in context.categorias_empleado select a).OrderBy(x => x.MAECAT_NOMCAT);
        cbx_Categoria.DisplayMember = "MAECAT_NOMCAT";
        cbx_Categoria.ValueMember = "MAECAT_CODCAT";
        cbx_Categoria.DataSource = cat.ToList();
      }
    }

    private void BuscarSocio()
    {
      
      using (var context = new lts_sindicatoDataContext())
      {

        _Encontrados.Clear();
        _Encontrados = mtdSocios.GetSocioBuscado(_SociosABuscar, txt_Busqueda.Text.Trim(), Cbx_FiltrarSocios.SelectedIndex, Convert.ToString(Cbx_Empresa.SelectedValue), cbx_Jornada.SelectedIndex, cbx_NroDeSocio.SelectedIndex, (int)cbx_Categoria.SelectedValue, (int)cbx_Localidad.SelectedValue);

        Dgv_Socios.AutoGenerateColumns = false;
        Dgv_Socios.DataSource = _Encontrados.ToList();

        if (_Encontrados.Count() == 0)
        {
          lbl_SinRegistrosSocios.Visible = true;
          LimpiarCampos();
        }
        else
        {
          lbl_SinRegistrosSocios.Visible = false;
        }
        lbl_CantidadEmpleados.Text = "Empleados: " + _Encontrados.Count().ToString();
        lbl_total_socios.Text = "Socios: " + _Encontrados.Count(x => x.EsSocio == true).ToString();
        lbl_CantidadNOSocios.Text = "NO Socios: " + _Encontrados.Count(x => x.EsSocio == false).ToString();

      }
    }

    private void LimpiarCampos()
    {
      var ControlesPanel = this.Controls.OfType<Panel>().ToList();

      foreach (var paneles in ControlesPanel)
      {
        var panel = paneles.Controls.OfType<TextBox>().ToList();
        foreach (var txt in panel)
        {
          if (txt.Name != "txt_Busqueda" && txt.Name != "txt_CUIT")
          {
            txt.Text = "";
          }
        }
      }
      dgv_MostrarAportes.AutoGenerateColumns = false;
      dgv_MostrarAportes.DataSource = mtdSocios.GetAportes2("0");
      lbl_SinRegistrosAportes.Visible = true;
      dgv_MostrarBeneficiario.AutoGenerateColumns = false;
      dgv_MostrarBeneficiario.DataSource = MtdBeneficiarios.GetBeneficiarios2("0");
      lbl_SinRegistrosBeneficiarios.Visible = true;


      picbox_socio.Image = null;
      picbox_beneficiario.Image = null;
      lbl_Parentesco.Text = "-----";
    }

    //private void BuscarEmpresa()
    //{
    //  frm_buscar_empresa f_busc_emp = new frm_buscar_empresa();
    //  f_busc_emp.PasarDatosFrmPrincipal_ += new frm_buscar_empresa.PasarDatosFrmPrincipal(ejecutar);// .PasarDatosActa(ejecutar);
    //  f_busc_emp.viene_desde = 5;
    //  f_busc_emp.ShowDialog();
    //  //BuscarSocio(txt_Busqueda.Text, Convert.ToDouble(String.IsNullOrEmpty(txt_CUIT.Text) ? "0" : txt_CUIT.Text), chk_VerificarCarencia.Checked);
    //}

    private void MostrarFotoTitular(string CUIL)
    {
      picbox_socio.Image = cnvimg.ByteArrayToImage(mtdSocios.Get_Foto_Titular_BinaryString(CUIL).ToArray());

    }

    private void MostrarDatosTitular2()
    {
      using (var context = new lts_sindicatoDataContext())
      {


        if (_Encontrados.Count() > 0)
        {

          int i = 0;
          i = Dgv_Socios.CurrentRow.Index;
          _EsSocio = _Encontrados[i].EsSocio;

          txt_CUIL.Text = _Encontrados[i].CUIL;
          txt_CUIT2.Text = _Encontrados[i].CUIT;
          txt_EmpresaNombre.Text = _Encontrados[i].RazonSocial;

          switch (_Encontrados[i].EstadoCivil)
          {
            case "C":
              txt_EstadoCivil.Text = "CASADO";
              break;
            case "S":
              txt_EstadoCivil.Text = "SOLTERO";
              break;
            case "D":
              txt_EstadoCivil.Text = "DIVORCIADO";
              break;
            case "V":
              txt_EstadoCivil.Text = "VIUDO";
              break;
            case "B":
              txt_EstadoCivil.Text = "CONCUBINO";
              break;
            case "E":
              txt_EstadoCivil.Text = "SEPARADO";
              break;
            default:
              break;
          };

          txt_Sexo.Text = _Encontrados[i].Sexo == "F" ? "FEMENINO" : "MASCULINO";
          txt_FechaNacimiento.Text = _Encontrados[i].FechaNacimiento.ToString("d");
          txt_Edad.Text = mtdFuncUtiles.calcular_edad(_Encontrados[i].FechaNacimiento).ToString();  //_Encontrados[i].Edad;
          string calle = _Encontrados[i].Calle == null ? "" : _Encontrados[i].Calle.Trim();
          string nrocalle = _Encontrados[i].NroCalle == null ? "" : "Nº " + _Encontrados[i].NroCalle.Trim();
          string barrio = _Encontrados[i].Barrio == null ? "" : "Bº " + _Encontrados[i].Barrio.Trim();
          txt_Domicilio.Text = calle + " " + nrocalle + " " + barrio;
          txt_Localidad.Text = _Encontrados[i].LocalidadString;
          txt_CodigoPostal.Text = (_Encontrados[i].CodigoPostal == null || _Encontrados[i].CodigoPostal == "" ? "No Asignada" : _Encontrados[i].CodigoPostal);
          txt_Telefono.Text = _Encontrados[i].Telefono.Trim() + " // "; // + _Socios[i].te .Trim();
          txt_Categoria.Text = _Encontrados[i].Categoria == 0 ? "No Especifica" : "otra";
          string fbaja = (from a in context.socemp.Where(x => x.SOCEMP_CUIL_STR == _Encontrados[i].CUIL && x.SOCEMP_ULT_EMPRESA == 'S') select a.SOCEMP_FECHABAJA).FirstOrDefault().ToString("d");
          txt_FechaBaja.Text = fbaja == "01/01/1000" ? "" : fbaja;

        }
      }
    }

    private void MostrarAportes3()
    {
      if (Dgv_Socios.Rows.Count > 0)
      {
        dgv_MostrarAportes.AutoGenerateColumns = false;
        dgv_MostrarAportes.DataSource = mtdSocios.GetAportes2(Dgv_Socios.CurrentRow.Cells["CUIL_"].Value.ToString()).ToList();
        lbl_SinRegistrosAportes.Visible = dgv_MostrarAportes.RowCount == 0;
      }
      else
      {
        dgv_MostrarAportes.DataSource = null;// mtdSocios.GetAportes2("0").ToList();
      }

    }

    private bool VerificarCarencia()
    {
      int Fila = dgv_MostrarAportes.Rows.Count;
      DateTime UltimoPeriodoDeclarado = Convert.ToDateTime(dgv_MostrarAportes.Rows[Fila - 1].Cells["periodo"].Value);
      DateTime hoy = DateTime.Now;
      int meses = Convert.ToInt32((hoy - UltimoPeriodoDeclarado).TotalDays) / 30;
      int F = 0;
      int ContadorDeAportes = 0;
      if (meses <= 3)
      {
        switch (meses)
        {
          case 1:
            F = Fila - 1;
            break;
          case 2:
            F = Fila - 2;
            break;
          case 3:
            F = Fila - 3;
            break;
          default:

            break;
        }
      }
      else
      {
        F = 0;
        Fila = 0;
      }
      for (int i = F; i < Fila; i++)
      {
        if (Convert.ToDecimal(dgv_MostrarAportes.Rows[i].Cells["aporte_socio"].Value) > 0)
        {
          ContadorDeAportes += 1;
        }
      }
      return ContadorDeAportes > 0 ? true : false;
    }

    private void MostrarBenef2()
    {
      dgv_MostrarBeneficiario.AutoGenerateColumns = false;
      dgv_MostrarBeneficiario.DataSource = MtdBeneficiarios.GetBeneficiarios2(Dgv_Socios.CurrentRow.Cells["CUIL_"].Value.ToString()).ToList();
      lbl_SinRegistrosBeneficiarios.Visible = dgv_MostrarBeneficiario.Rows.Count == 0;

      if (dgv_MostrarBeneficiario.RowCount == 0)
      {
        picbox_beneficiario.Image = null;

      }
    }

    //private void MostrarDatosEmpresa(double cuit)
    //{
    //  if (_Socios.Count() > 0)
    //  {
    //    //int i = dgv_MostrarSocios.CurrentRow.Index;

    //    txt_EmpresaNombre.Text = _Socios[i].EmpresaNombre;
    //    txt_RazonSocial.Text = _Socios[i].RazonSocial;
    //    txt_CUIT2.Text = _Socios[i].CUIT;
    //    txt_EmpresaTelefono.Text = _Socios[i].EmpresaTelefono;
    //    txt_EmpresaDomicilio.Text = _Socios[i].EmpresaDomicilio;
    //    txt_EmpresaEstudio.Text = _Socios[i].EmpresaContador;
    //    txt_EmpresaEmail.Text = _Socios[i].EmpresaEmail;
    //    txt_EmpresaCodigoPostal.Text = _Socios[i].EmpresaCodigoPostal;
    //    txt_Localidad.Text = _Socios[i].EmpresaLocalidad;
    //  }
    //}

    private void MostrarDatosEmpresa2(double cuit)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var empresa = from a in context.maeemp
                      where a.MAEEMP_CUIT == cuit
                      select new
                      {
                        Nombre = a.MAEEMP_NOMFAN.Trim(),
                        RazonSocial = a.MAEEMP_RAZSOC == null ? "" : a.MAEEMP_RAZSOC.Trim(),
                        CUIT = a.MEEMP_CUIT_STR.ToString(),
                        Telefono = a.MAEEMP_TEL,
                        Domicilio = a.MAEEMP_CALLE.Trim() + " Nº " + a.MAEEMP_NRO.Trim(),
                        Estudio = a.MAEEMP_ESTUDIO_CONTACTO.Trim(),
                        EstudioTelefono = a.MAEEMP_ESTUDIO_TEL.Trim(),
                        EstudioEmail = a.MAEEMP_ESTUDIO_EMAIL.Trim(),
                        CodigoPostal = a.MAEEMP_CODPOS.Trim(),
                        Localidad = fnc.GetLocalidad(Convert.ToInt32(a.MAEEMP_CODLOC)).Trim()
                      };
        if (empresa.Count() > 0)
        {
          var emp = empresa.SingleOrDefault();
          txt_EmpresaNombre.Text = emp.Nombre;
          txt_RazonSocial.Text = emp.RazonSocial;
          txt_CUIT2.Text = emp.CUIT;
          txt_EmpresaTelefono.Text = emp.Telefono;
          txt_EmpresaDomicilio.Text = emp.Domicilio;
          txt_EmpresaEstudio.Text = emp.Estudio;
          txt_EmpresaEmail.Text = emp.EstudioEmail;
          txt_EmpresaCodigoPostal.Text = emp.CodigoPostal;
          txt_Localidad.Text = emp.Localidad;
        }
      }
    }

    private void txt_Busqueda_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        //BuscarSocio(txt_Busqueda.Text, Convert.ToDouble(String.IsNullOrEmpty(txt_CUIT.Text) ? "0" : txt_CUIT.Text), chk_VerificarCarencia.Checked);
        BuscarSocio();
      }
    }

    private void dgv_MostrarBeneficiario_SelectionChanged(object sender, EventArgs e)
    {
      // MostrarFotoBeneficiario(Convert.ToDouble(dgv_MostrarBeneficiario.CurrentRow.Cells["codigo_fliar"].Value));
      picbox_beneficiario.Image = mtdConvertirImagen.ByteArrayToImage(MtdBeneficiarios.GetFotoBenefBinary(Convert.ToDouble(dgv_MostrarBeneficiario.CurrentRow.Cells["codigo_fliar"].Value)).ToArray());
    }

    private void btn_ImprimirAportes_Click(object sender, EventArgs e)
    {
      ImprimirAportes();
    }

    private void ImprimirAportes()
    {
      try
      {
        using (var context = new lts_sindicatoDataContext())
        {
          DS_cupones dscpn = new DS_cupones();
          DataTable dt_impresion_ddjj = dscpn.ddjj_por_empleado;
          dt_impresion_ddjj.Clear();
          foreach (DataGridViewRow fila in dgv_MostrarAportes.Rows)
          {
            DataRow row = dt_impresion_ddjj.NewRow();

            row["periodo"] = Convert.ToDateTime(fila.Cells["periodo"].Value).Date;
            row["ley"] = Convert.ToDecimal(fila.Cells["aporte_ley"].Value);
            row["socio"] = Convert.ToDecimal(fila.Cells["aporte_socio"].Value);
            row["empresa"] = fila.Cells["razons"].Value;
            row["cuit"] = fila.Cells["cuit"].Value;
            // row["dni"] = Convert.ToInt32(txt_DNI.Text.Trim());
            // row["empleado"] = txt_Nombre.Text.Trim();
            row["Sueldo"] = fila.Cells["Sueldo"].Value;
            row["Logo"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.png"));
            dt_impresion_ddjj.Rows.Add(row);
          }
          reportes frm_reportes = new reportes();
          frm_reportes.NombreDelReporte = "rpt_ddjj_por_empleado";
          //frm_reportes.ddjj_por_empleado = dt_impresion_ddjj;
          frm_reportes.dt = dt_impresion_ddjj;
          frm_reportes.Show();
        }
      }
      catch (Exception)
      {
        throw;
      }
    }

    private void cbx_Localidad_SelectedIndexChanged(object sender, EventArgs e)
    {
      //_CodigoPostal = cbx_Localidad.SelectedValue.ToString();
      BuscarSocio();
    }

    private void cbx_NroDeSocio_SelectedIndexChanged(object sender, EventArgs e)
    {
      BuscarSocio();
    }

    private void cbx_Jornada_SelectedIndexChanged(object sender, EventArgs e)
    {
      BuscarSocio();
      //_Jordada = cbx_Jornada.SelectedIndex;
    }

    private void cbx_Categoria_SelectedIndexChanged(object sender, EventArgs e)
    {
      BuscarSocio();
      //_CodigoCategoria = Convert.ToInt32(cbx_Categoria.SelectedValue);
    }

    private void cbx_ActivoEnEmpresa_SelectedIndexChanged_1(object sender, EventArgs e)
    {
      //_ActivoEnEmpresa = cbx_ActivoEnEmpresa.SelectedIndex;
    }

    private void cbx_Jubilados_SelectedIndexChanged_1(object sender, EventArgs e)
    {
      //_Jubilados = cbx_Jubilados.SelectedIndex;
    }

    private void menuCupones_Click(object sender, EventArgs e)
    {

    }

    private void menuQuinchos_Click(object sender, EventArgs e)
    {
      //if (_EsSocio)
      //{
      //  if (!(string.IsNullOrEmpty(txt_NroSocio.Text)))
      //  {
      Frm_Quinchos f_quinchos = new Frm_Quinchos();
      //f_quinchos.txt_DNI.Text = txt_DNI.Text.Trim();
      //f_quinchos.txt_Nombre.Text = txt_Nombre.Text.Trim();
      //f_quinchos.txt_Telefono.Text = txt_Telefono.Text;
      //f_quinchos.txt_NroSocio.Text = txt_NroSocio.Text;
      //f_quinchos.Txt_Comercio.Text = txt_RazonSocial.Text.Trim();
      //f_quinchos.picbox_socio.Image = picbox_socio.Image;
      //f_quinchos._DNI = txt_DNI.Text.Trim();
      //f_quinchos._NroSocio = Convert.ToInt32(txt_NroSocio.Text);
      //f_quinchos._UsuarioId = _UserId;
      //f_quinchos._UsuarioName = _UserNombre;
      //f_quinchos._CUIL = txt_CUIL.Text.Trim();
      //f_quinchos._RazonSocial = txt_RazonSocial.Text.Trim();
      f_quinchos.ShowDialog();
      //  }

      //  //if (string.IsNullOrEmpty(txt_NroSocio.Text))
      //  //{
      //  //  f_quinchos._NroSocio = 0;
      //  //}
      //  else
      //  {
      //    //f_quinchos._NroSocio = Convert.ToInt32(txt_NroSocio.Text);
      //    MessageBox.Show("El empleado no es socio Activo (DebeEmpadronarse) por lo tanto no puede realizar la reserva.......");
      //  }
      //}
      //else
      //{
      //  MessageBox.Show("El empleado no es socio  por lo tanto no puede realizar la reserva.......");
      //}
    }

    private void menu_VerificarDeuda_Click(object sender, EventArgs e)
    {
      VerificarDeuda f_VerificarDeuda = new VerificarDeuda();
      f_VerificarDeuda._UserId = _UserId;
      f_VerificarDeuda.Show();
    }

    private void menuCobros_Click(object sender, EventArgs e)
    {
      frm_CobroDeActas frmCobroDeActa = new frm_CobroDeActas();
      frmCobroDeActa.Show();

    }

    private void menu_RendicionDeCobroDeActa_Click(object sender, EventArgs e)
    {
      frm_CobroDeActas frmCobroDeActa = new frm_CobroDeActas();
      frmCobroDeActa.Show();
    }

    private void menuMochilasEmitirCupon_Click(object sender, EventArgs e)
    {
      if (_EsSocio)
      {
        //frm_Mochilas2 f_mochilas = new frm_Mochilas2();
        //f_mochilas._cuil = Convert.ToDouble(txt_CUIL.Text);
        //f_mochilas.UsuarioID = _UserId;
        //f_mochilas.ShowDialog();

        frm_MochilasEmisionDeCupon f_mochilas = new frm_MochilasEmisionDeCupon();
        f_mochilas._cuil = Convert.ToDouble(txt_CUIL.Text);
        f_mochilas._cuilStr = txt_CUIL.Text;
        f_mochilas._UsuarioID = _UserId;
        //f_mochilas._NroSocio = txt_NroSocio.Text;
        //f_mochilas._nroDNI = txt_DNI.Text;
        //f_mochilas._ApeNom = txt_Nombre.Text;
        f_mochilas._Empresa = txt_RazonSocial.Text;
        f_mochilas.ShowDialog();
      }
      else
      {
        MessageBox.Show("El empleado no es socio Activo por lo tanto no puede emitir un cupon.......");
      }
    }

    private void menuMochilasEntregar_Click(object sender, EventArgs e)
    {
      //frm_EntregarMochila f_EntregaMochila = new frm_EntregarMochila();
      //f_EntregaMochila.UsuarioId = _UserId;
      //f_EntregaMochila.UsuarioNombre = _UserNombre;
      //f_EntregaMochila.ShowDialog();
      frm_EntregarMochila2 f_EntregaMochila = new frm_EntregarMochila2();
      //f_EntregaMochila.UsuarioId = _UserId;
      //f_EntregaMochila.UsuarioNombre = _UserNombre;
      f_EntregaMochila.ShowDialog();
    }

    private void menuMochilasEdades_Click(object sender, EventArgs e)
    {
      frm_edades f_edades = new frm_edades();
      f_edades.Show();
    }

    private void menu_Inspectores_Click(object sender, EventArgs e)
    {

    }

    private void menu_BuscarVerificacionDeuda_Click(object sender, EventArgs e)
    {
      frm_VDBuscar f_VDBuscar = new frm_VDBuscar();
      f_VDBuscar._Usuario = _UserNombre;
      f_VDBuscar._UsuarioId = _UserId;
      f_VDBuscar.Show();
    }

    private void picbox_beneficiario_Click(object sender, EventArgs e)
    {

    }

    private void menu_ListadoActas_Click(object sender, EventArgs e)
    {
      frm_ActaBuscar f_ActasBuscar = new frm_ActaBuscar();
      f_ActasBuscar.Show();
    }

    private void btn_ActivarSocio_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Esta seguro de pasar a ''SOCIO ACTIVO'' ", "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        //socios soc = new socios();
        //soc.ActivarSocio(Convert.ToDouble( lbl_cuil.Text.Trim()));

        //var activar_socio = from a in db_socios.soccen where a.SOCCEN_CUIL == Convert.ToDouble(lbl_cuil.Text) select a;

        using (lts_sindicatoDataContext context = new lts_sindicatoDataContext())
        {
          context.ExecuteCommand("update fotos_.soccen set SOCCEN_ESTADO = 1 where SOCCEN_CUIL = " + Convert.ToDouble(txt_CUIL.Text));
        }

        //if (activar_socio.Count() > 0)
        //{
        //  activar_socio.SingleOrDefault().SOCCEN_ESTADO = 1;
        //  db_socios.SubmitChanges();

        //MessageBox.Show("El Socio " + txt_Nombre.Text.Trim() + " Ya se encuentra activado. Por favor Actualice la Busqueda. ", "¡¡¡ ATENCION !!!");
        //}
      }
    }

    private void menu_Informes_Click(object sender, EventArgs e)
    {
      PorInspector frm_informes = new PorInspector();
      frm_informes.Show();
    }
    private void menuCobranzas_Click(object sender, EventArgs e)
    {

    }

    private void menuSorteoDEC_Click(object sender, EventArgs e)
    {
      //if (_EsSocio)
      //{
      //  if (MessageBox.Show("Esta Seguro de emitir el Cupon de Sorteo?", "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      //  {
      //    MtdSorteos.ControlPreImpresionCuponSorteo(_EsSocio, txt_CUIL.Text.Trim(), txt_DNI.Text, _UserId, txt_Nombre.Text, txt_RazonSocial.Text, txt_NroSocio.Text, mtdConvertirImagen.ImageToByteArray(picbox_socio.Image), "0", "rpt_CuponSorteoDDEDC");
      //  }
      //}
      //else
      //{
      //  MessageBox.Show("El empleado no es socio Activo por lo tanto no puede emitir Numero para el Sorteo .......");
      //}

    }

    private void menuMujer_Click(object sender, EventArgs e)
    {

    }

    private void menuDiaDeLaMujer_Click(object sender, EventArgs e)
    {
      //if (txt_Sexo.Text == "F")
      //{
      frm_DDLM F_ddlm = new frm_DDLM();
      F_ddlm._CuponEmitido = MtdEventos.GetCuponGenerado(3, txt_CUIL.Text.Trim());
      //F_ddlm._NroSocio = txt_NroSocio.Text.Trim() == "" ? 0 : Convert.ToInt32(txt_NroSocio.Text);
      F_ddlm._Cuil = Convert.ToDouble(txt_CUIL.Text);
      F_ddlm._UsuarioID = _UserId;
      F_ddlm._EventoId = 3;
      //F_ddlm.txt_NroSocio.Text = txt_NroSocio.Text.Trim() == "" ? "NO ES SOCIA" : txt_NroSocio.Text;
      //F_ddlm.txt_Empresa.Text = txt_RazonSocial.Text;
      //F_ddlm.txt_Dni.Text = txt_DNI.Text;
      F_ddlm.picbox_socio.Image = picbox_socio.Image;
      //F_ddlm.txt_Nombre.Text = txt_Nombre.Text;
      F_ddlm.Show();
      //}
      //else
      //{
      //  MessageBox.Show("El empleado no es del SEXO FEMENINO, por lo  tanto no puede emitir un cupon del DIA De La MUJER  .......");
      //}
    }

    private void menuDDLM_Click(object sender, EventArgs e) // Dia de la Madre
    {
      if (_EsSocio)
      {
        if (MessageBox.Show("Esta Seguro de emitir el Cupon de Sorteo?", "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          //MtdSorteos.ControlPreImpresionCuponSorteo(_EsSocio, txt_CUIL.Text.Trim(), txt_DNI.Text, _UserId, txt_Nombre.Text, txt_RazonSocial.Text, txt_NroSocio.Text, mtdConvertirImagen.ImageToByteArray(picbox_socio.Image), "0", "rpt_CuponSorteoDDLM");
        }
      }
      else
      {
        MessageBox.Show("El empleado no es socio Activo por lo tanto no puede emitir Numero para el Sorteo .......");
      }
      //if (_EsSocio)
      //{
      //  if (!MtdSorteos.CuponYaEmitido(txt_CUIL.Text.Trim()))
      //  {

      //    double Dni = Convert.ToDouble(txt_DNI.Text);

      //    int NroSorteo = MtdDEC.GetNroSorteo(2, txt_CUIL.Text, _UserId);

      //    MtdSorteos.ImprimirCuponSorteo(NroSorteo, txt_CUIL.Text, txt_Nombre.Text, Dni.ToString("N0"), txt_RazonSocial.Text, txt_NroSocio.Text, mtdConvertirImagen.ImageToByteArray(picbox_socio.Image), "0", "rpt_CuponSorteoDDLM");

      //  }

      //  else
      //  {
      //    if (MessageBox.Show(MtdDEC.CuponEmitidoLeyenda(txt_CUIL.Text.Trim()), "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      //    {

      //      double Dni_ = Convert.ToDouble(txt_DNI.Text);

      //      int NroSorteo_ = MtdDEC.GetNroCuponYaEmitido(txt_CUIL.Text);

      //      MtdSorteos.ImprimirCuponSorteo(NroSorteo_, txt_CUIL.Text, txt_Nombre.Text, Dni_.ToString("N0"), txt_RazonSocial.Text, txt_NroSocio.Text, mtdConvertirImagen.ImageToByteArray(picbox_socio.Image), "1", "rpt_CuponSorteoDDLM");
      //    }
      //  }
      //}
      //else
      //{
      //  MessageBox.Show("La empleada no es socio Activo por lo tanto no puede emitir Numero para el Sorteo .......");
      //}
    }

    private void menu_Futbol_Click(object sender, EventArgs e)
    {
      frm_futbol f_futbol = new frm_futbol();
      f_futbol.Show();
    }

    private void menu_GremialAuditorias_Click(object sender, EventArgs e)
    {

    }

    private void menuMochilas_Click(object sender, EventArgs e)
    {

    }

    private void menuEventos_Click(object sender, EventArgs e)
    {
      frm_Eventos3 f_eventos = new frm_Eventos3();
      f_eventos.Show();

    }

    private void menu_MujerInformes_Click(object sender, EventArgs e)
    {
      //frm_Eventos3 f_Eventos = new frm_Eventos3();
      //f_Eventos.Show();
      List<MdlCuponesEmitidos> CuponesEdad = new List<MdlCuponesEmitidos>();

      var a = MtdEventos.GetCuponesEmitidosPorEdad();
      foreach (var edad in a.GroupBy(x => x.Edad))
      {
        MdlCuponesEmitidos ce = new MdlCuponesEmitidos();
        ce.Edad = edad.Key;
        ce.Cantidad = edad.Count();
        CuponesEdad.Add(ce);
        Console.WriteLine("Edad: " + ce.Edad + "Cantidad: " + ce.Cantidad);
        frm_edades f_edades = new frm_edades();

      };
    }

    private void MenuDiaDelPadre_Click(object sender, EventArgs e)
    {
      if (_EsSocio)
      {
        //MtdSorteos.ControlPreImpresionCuponSorteo(_EsSocio, txt_CUIL.Text.Trim(), txt_DNI.Text, _UserId, txt_Nombre.Text, txt_RazonSocial.Text, txt_NroSocio.Text, mtdConvertirImagen.ImageToByteArray(picbox_socio.Image), "0", "rpt_CuponSorteoDDP");
        frm_DDP F_DDP = new frm_DDP();
        F_DDP._CuponEmitido = MtdEventos.GetCuponGenerado(10, txt_CUIL.Text.Trim());
        //F_DDP._NroSocio = txt_NroSocio.Text.Trim() == "" ? 0 : Convert.ToInt32(txt_NroSocio.Text);
        F_DDP._Cuil = Convert.ToDouble(txt_CUIL.Text);
        F_DDP._UsuarioID = _UserId;
        F_DDP._EventoId = 10;
        //F_DDP.txt_NroSocio.Text = txt_NroSocio.Text.Trim() == "" ? "NO ES SOCIO" : txt_NroSocio.Text;
        F_DDP.txt_Empresa.Text = txt_RazonSocial.Text;
        //F_DDP.txt_Dni.Text = txt_DNI.Text;
        F_DDP.picbox_socio.Image = picbox_socio.Image;
        //F_DDP.txt_Nombre.Text = txt_Nombre.Text;
        //F_DDP._DNI = txt_DNI.Text;
        F_DDP.Show();
      }
      else
      {
        MessageBox.Show("El empleado no es socio Activo por lo tanto no puede emitir Numero para el Sorteo .......");
      }
    }

    private void menuDiaEmpledoComercio_Click(object sender, EventArgs e)
    {
      //if (_EsSocio)
      //{
      Frm_DDEDC_LB F_DDEDC = new Frm_DDEDC_LB();
      F_DDEDC._CuponEmitido = false;//MtdEventos.GetCuponGenerado(3, txt_CUIL.Text.Trim());
      //F_DDEDC._NroSocio = txt_NroSocio.Text.Trim() == "" ? 0 : Convert.ToInt32(txt_NroSocio.Text);
      F_DDEDC._EsSocio = _EsSocio;
      F_DDEDC._Cuil = Convert.ToDouble(txt_CUIL.Text);
      F_DDEDC._UsuarioId = _UserId;
      F_DDEDC._EventoId = 2;
      F_DDEDC._EventoAñoId = 4;
      F_DDEDC._UsuarioNombre = _UserNombre;
      F_DDEDC._Edad = txt_Edad.Text;
      //F_DDEDC.txt_NroSocio.Text = txt_NroSocio.Text.Trim() == "" ? "NO ES SOCIO" : txt_NroSocio.Text;
      F_DDEDC.txt_Empresa.Text = txt_RazonSocial.Text;
      //F_DDEDC.txt_Dni.Text = txt_DNI.Text;
      F_DDEDC.picbox_socio.Image = picbox_socio.Image;
      F_DDEDC._FotoOriginal = picbox_socio.Image;
      //F_DDEDC.txt_Nombre.Text = txt_Nombre.Text;
      F_DDEDC.ShowDialog();
      //}
      //else
      //{
      //  MessageBox.Show("El empleado no es socio Activo por lo tanto no puede emitir Numero para el Sorteo .......");
      //}
    }

    private void MenuDDN_Click(object sender, EventArgs e)
    {
      if (_EsSocio)
      {
        frm_DDNiño f_DDNiño = new frm_DDNiño();

        f_DDNiño._Cuil = Convert.ToDouble(txt_CUIL.Text.Trim());
        f_DDNiño._EventoId = 1;
        f_DDNiño._EventoAñoId = MtdEventos.GetEventoAñoId(1);
        f_DDNiño._UsuarioId = _UserId;
        //f_DDNiño._TitularApenom = txt_Nombre.Text.Trim();
        //f_DDNiño._TituDNI = txt_DNI.Text.Trim();
        f_DDNiño._RazonSocial = txt_RazonSocial.Text.Trim();
        //f_DDNiño._NroSocio = txt_NroSocio.Text.Trim();
        f_DDNiño._Exepcion = 0;
        f_DDNiño._SorteoConfig = mtdFilial.Get_FilialSorteoConfig();
        //f_DDNiño.Lbl_Encabezado.Text = "Grupo Familiar del Socio " + txt_Nombre.Text;
        f_DDNiño.ShowDialog();
      }
      else
      {
        MessageBox.Show("El Empleado no es Socio Activo por lo Tanto no Puede Emitir el Cupon .......", "ATENCION");
      }
    }

    private void MenuDDNTermas_Click(object sender, EventArgs e)
    {

      if (_EsSocio)
      {
        if (txt_CodigoPostal.Text.Trim() != "4220")
        {
          if (MessageBox.Show("El Socio Seleccionado no Tiene Asigando la Localidad de TERMAS. Desea Continuar con la Emision del Cupon  ???", "ATENCION", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {
            CargarFrmDDNTermas();
          }
        }
        else
        {
          CargarFrmDDNTermas();
        }

      }
      else
      {
        MessageBox.Show("El Empleado no es Socio Activo por lo Tanto no Puede Emitir el Cupon .......", "ATENCION");
      }
    }

    private void CargarFrmDDNTermas()
    {
      frm_DDNiño f_DDNiño = new frm_DDNiño();

      f_DDNiño._Cuil = Convert.ToDouble(txt_CUIL.Text.Trim());
      f_DDNiño._EventoId = 11;
      f_DDNiño._EventoAñoId = MtdEventos.GetEventoAñoId(11);
      f_DDNiño._UsuarioId = _UserId;
      //f_DDNiño._TitularApenom = txt_Nombre.Text.Trim();
      //f_DDNiño._TituDNI = txt_DNI.Text.Trim();
      f_DDNiño._RazonSocial = txt_RazonSocial.Text.Trim();
      //f_DDNiño._NroSocio = txt_NroSocio.Text.Trim();
      f_DDNiño._Exepcion = 0;
      f_DDNiño._SorteoConfig = mtdFilial.Get_FilialSorteoConfig();
      //f_DDNiño.Lbl_Encabezado.Text = "Grupo Familiar del Socio " + txt_Nombre.Text;
      f_DDNiño.Text = "Dia del Niño - TERMAS";
      f_DDNiño.ShowDialog();
    }

    private void menuPadron_Click(object sender, EventArgs e)
    {
      Frm_Padron F_Padron = new Frm_Padron();
      F_Padron.ShowDialog();
    }

    private void dgv_MostrarBeneficiario_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void menuAsientos_Click_1(object sender, EventArgs e)
    {
      Frm_PagoAProv F_PagoAProv = new Frm_PagoAProv();
      F_PagoAProv.Show();
    }

    private void Btn_PadronPJ_Click(object sender, EventArgs e)
    {
      Frm_PadronSECPJ F_PadronSECPJ = new Frm_PadronSECPJ();
      F_PadronSECPJ.Show();
    }



    private void Mn_InformeComparativoDDJJCobrosActas_Click(object sender, EventArgs e)
    {
      Frm_InformeComparativoDDJJPagosActas F_Inf1 = new Frm_InformeComparativoDDJJPagosActas();
      F_Inf1.Show();
    }

    private void txt_Busqueda_TextChanged(object sender, EventArgs e)
    {
      BuscarSocio();
    }

    private void Dgv_Socios_SelectionChanged(object sender, EventArgs e)
    {
      MostrarFotoTitular(Dgv_Socios.CurrentRow.Cells["CUIL_"].Value.ToString());
      MostrarBenef2();
      MostrarAportes3();
      MostrarDatosTitular2();
    }

    private void CargarCbxEmpresas()
    {
      Cbx_Empresa.DisplayMember = "MAEEMP_RAZSOC";
      Cbx_Empresa.ValueMember = "MEEMP_CUIT_STR";
      Cbx_Empresa.DataSource = mtdEmpresas.GetListadoEmpresas(); //mtdInspectores.Get_Inspectores();
      Cbx_Empresa.MaxDropDownItems = 10;
      Cbx_Empresa.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }

    private void Cbx_FiltrarSocios_SelectedIndexChanged(object sender, EventArgs e)
    {
      BuscarSocio();
    }

    private void Cbx_Empresa_SelectedIndexChanged(object sender, EventArgs e)
    {
      BuscarSocio();
    }
  }
}
