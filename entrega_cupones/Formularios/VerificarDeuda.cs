using entrega_cupones.Clases;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrega_cupones.Formularios
{
  public partial class VerificarDeuda : Form
  {

    List<EstadoDDJJ> _ddjj = new List<EstadoDDJJ>();
    List<mdlCuadroAmortizacion> _PlanDePago = new List<mdlCuadroAmortizacion>();
    List<mdlDDJJEmpleado> _AporteEstadoSocio = new List<mdlDDJJEmpleado>();
    public List<mdlVDDetalle> _CargaManual = new List<mdlVDDetalle>();

    public int _UserId;
    public int _VDId = 0;
    public bool _Cancelado = true;
    public int _IndexDGV;

    public VerificarDeuda()
    {
      InitializeComponent();
    }

    public void EstadoEmpleado()
    {
      using (var Context = new lts_sindicatoDataContext())
      {
        var ListadoAportes = Context.ddjj.
         Select(row => new mdlDDJJEmpleado
         {
           Cuit = row.CUIT_STR,
           Periodo = (DateTime)row.periodo,
           Apellido = "",
           Nombre = "",
           Dni = row.cuil.ToString(),
           Sueldo = (decimal)(row.impo + row.impoaux),
           AporteLey = (decimal)((row.impo + row.impoaux) * 0.02),
           AporteSocio = (decimal)((row.item2 == true) ? (row.impo + row.impoaux) * 0.02 : 0),
           Jornada = row.jorp == true ? "Parcial" : "Completa",
         }).OrderBy(x => x.Apellido);
        _AporteEstadoSocio.AddRange(ListadoAportes);
      }
    }

    private void VerificarDeuda_Load(object sender, EventArgs e)
    {
      // Maxihogar 30646757327
      // Las Malvinas 30566692887
      Icon = new Icon("C:\\SEC_Gestion\\Imagen\\icono.ico");
      dgv_ddjj.AutoGenerateColumns = false;
      dgv_PlanDePagos.AutoGenerateColumns = false;

      string MesDesde = mtdFuncUtiles.generar_ceros(DateTime.Today.AddYears(-5).Month.ToString(), 2);
      string AñoDesde = DateTime.Today.AddYears(-5).Year.ToString();
      string MesHasta = mtdFuncUtiles.generar_ceros(DateTime.Today.Month.ToString(), 2);
      string AñoHasta = DateTime.Today.Year.ToString();

      msk_Desde.Text = MesDesde + "/" + AñoDesde;
      msk_Hasta.Text = MesHasta + "/" + AñoHasta;
      string fe = DateTime.Today.Date.AddDays(15).ToString();
      msk_Vencimiento.Text = DateTime.Today.Date.AddDays(15).ToString();

      cbx_TipoDeInteres.SelectedIndex = 0;
      Cargar_cbxInspectores();
      //Cargar_cbx_Estcont();

      //EstadoEmpleado();
    }

    private void Cargar_cbxInspectores()
    {
      cbx_Inspectores.DisplayMember = "Nombre";
      cbx_Inspectores.ValueMember = "Id";
      cbx_Inspectores.DataSource = mtdInspectores.Get_Inspectores();
    }

    private void Cargar_cbx_Estcont()
    {
      cbx_EstCont.DisplayMember = "Nombre";
      cbx_EstCont.ValueMember = "Id";
      cbx_EstCont.DataSource = MtdEstCont.GetEstCont();
    }

    private void BuscarEmpresa()
    {
      frm_buscar_empresa formBuscarEmpresa = new frm_buscar_empresa();
      formBuscarEmpresa.viene_desde = 6;
      AddOwnedForm(formBuscarEmpresa);
      formBuscarEmpresa.ShowDialog();

    }

    private void btn_BuscarEmpresa_Click(object sender, EventArgs e)
    {
      BuscarEmpresa();
    }

    private void btn_CalcularDeuda_Click(object sender, EventArgs e)
    {
      CalcularDeuda();
    }

    private void CalcularDeuda()
    {
      _ddjj.Clear();

      _ddjj = mtdEmpresas.ListadoDDJJT(
         txt_CUIT.Text,
         Convert.ToDateTime("01/" + msk_Desde.Text),
         Convert.ToDateTime("01/" + msk_Hasta.Text),
         Convert.ToDateTime(msk_Vencimiento.Text),
         cbx_TipoDeInteres.SelectedIndex,
        Convert.ToDecimal(txt_InteresDiario.Text)
         );



      dgv_ddjj.DataSource = _ddjj;

      PintarPerNoDec();
      CalcularTotales();

      if (_ddjj == null)
      {
        DesactivarBotones();
      }
      else
      {
        ActivarBotones();
        txt_DeudaInicial.Text = txt_Total.Text;
      }
    }

    private void CalcularTotales()
    {
      decimal InteresResarcitorio = 0;
      InteresResarcitorio = Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.Interes), 2);
      //Math.Round(_ddjj.Where(x => x.Acta == "" && x.DiasDeMora > 0 && x.FechaDePago != null).Sum(x => x.Capital), 2);
      txt_Total.Text = Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.Total), 2).ToString("N2");
      txt_Pagado.Text = Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.ImporteDepositado), 2).ToString("N2");
      //txt_Deuda.Text = Math.Round(_ddjj.Where(x => x.Acta == "" && x.DiasDeMora > 0 && x.FechaDePago == null).Sum(x => x.Capital), 2).ToString("N2");
      txt_Deuda.Text = Math.Round(_ddjj.Where(x => x.Acta == "" && x.DiasDeMora >= 0 && x.Capital > 0).Sum(x => x.Capital), 2).ToString("N2");
      //txt_TotalInteres.Text = Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.Interes) + InteresResarcitorio, 2).ToString("N2");
      txt_TotalInteres.Text = InteresResarcitorio.ToString("N2");//Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.Interes) + InteresResarcitorio, 2).ToString("N2");
      txt_PerNoDec.Text = _ddjj.Where(x => x.Acta == "").Count(x => x.PerNoDec == 1).ToString();
      txt_DeudaInicial.Text = txt_Total.Text;
      txt_Anticipo.Text = "";
      txt_DeudaPlan.Text = txt_Total.Text;
      VerPlanDePago();
    }

    private void PintarPerNoDec()
    {
      foreach (DataGridViewRow fila in dgv_ddjj.Rows)
      {
        if (Convert.ToInt32(fila.Cells["PerNoDec"].Value) == 1)
        {
          fila.DefaultCellStyle.BackColor = System.Drawing.Color.PaleVioletRed;
        }
      }
    }

    private void btn_EliminarFila_Click(object sender, EventArgs e)
    {
      EliminarFila();
    }

    private void EliminarFila()
    {
      if (MessageBox.Show("Esta Seguro que desea ELIMINAR el Periodo seleccionado?", "ATENCION", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        int Index = dgv_ddjj.CurrentRow.Index;

        DateTime Periodo = Convert.ToDateTime(dgv_ddjj.CurrentRow.Cells["Periodo"].Value);
        int Rectificacion = Convert.ToInt32(dgv_ddjj.CurrentRow.Cells["Rectificacion"].Value);

        _ddjj.RemoveAll(x => x.Periodo == Periodo &&
        x.Rectificacion == Rectificacion);

        dgv_ddjj.DataSource = _ddjj.ToList();
        dgv_ddjj.CurrentCell = Index == 0 ? dgv_ddjj.Rows[Index].Cells[0] : dgv_ddjj.Rows[Index - 1].Cells[0];
        dgv_ddjj.Rows[0].Selected = false;

        CalcularTotales();
        PintarPerNoDec();
      }
    }

    private void ActivarBotones()
    {
      btn_EliminarFila.Enabled = true;
      btn_CopiarAnterior.Enabled = true;
      btn_CopiarSiguiente.Enabled = true;
      btn_EmitirActa.Enabled = true;
      btn_ConfirmAsignacion.Enabled = true;
    }

    private void DesactivarBotones()
    {
      btn_EliminarFila.Enabled = false;
      btn_CopiarAnterior.Enabled = false;
      btn_CopiarSiguiente.Enabled = false;
      btn_EmitirActa.Enabled = false;
      btn_ConfirmAsignacion.Enabled = false;
    }

    private void btn_CopiarAnterior_Click(object sender, EventArgs e)
    {
      CopiarPeriodo2(Convert.ToDateTime(dgv_ddjj.Rows[dgv_ddjj.CurrentRow.Index - 1].Cells["Periodo"].Value), Convert.ToDateTime(dgv_ddjj.CurrentRow.Cells["Periodo"].Value));
      //CopiarPeriodo2(false, dgv_ddjj.CurrentRow.Index - 1, Convert.ToDateTime(dgv_ddjj.CurrentRow.Cells["Periodo"].Value));
    }

    private void btn_CopiarSiguiente_Click(object sender, EventArgs e)
    {
      CopiarPeriodo2(Convert.ToDateTime(dgv_ddjj.Rows[dgv_ddjj.CurrentRow.Index + 1].Cells["Periodo"].Value), Convert.ToDateTime(dgv_ddjj.CurrentRow.Cells["Periodo"].Value));
      // CopiarPeriodo2(true, dgv_ddjj.CurrentRow.Index + 1, Convert.ToDateTime(dgv_ddjj.CurrentRow.Cells["Periodo"].Value));
    }

    private void CopiarPeriodo2(DateTime CopiarDe_, DateTime ACalcular_)
    {
      var aCalcular = _ddjj.FirstOrDefault(x => x.Periodo == ACalcular_);

      var CopiarDe = _ddjj.FirstOrDefault(x => x.Periodo == CopiarDe_);

      if (CopiarDe_.Month == 12 || CopiarDe_.Month == 6)
      {
        aCalcular.AporteLey = (CopiarDe.AporteLey / 3) * 2;
        aCalcular.AporteSocio = (CopiarDe.AporteSocio / 3) * 2;
        aCalcular.Capital = aCalcular.AporteLey + aCalcular.AporteSocio;
        bool PagoConInteres = aCalcular.ImporteDepositado - aCalcular.Capital > 0;
        aCalcular.Interes = Math.Round(mtdEmpresas.CalcularInteres(null, aCalcular.Periodo, aCalcular.Capital, aCalcular.Capital, Convert.ToDateTime(msk_Vencimiento.Text), cbx_TipoDeInteres.SelectedIndex, Convert.ToDecimal(txt_InteresDiario.Text), PagoConInteres), 2);
        aCalcular.TotalSueldoEmpleados = (CopiarDe.TotalSueldoEmpleados / 3) * 2;
        aCalcular.TotalSueldoSocios = (CopiarDe.TotalSueldoSocios / 3) * 2;
      }
      else
      {
        if (ACalcular_.Month == 6 || ACalcular_.Month == 12)
        {
          aCalcular.AporteLey = CopiarDe.AporteLey + (CopiarDe.AporteLey * Convert.ToDecimal(0.50));
          aCalcular.AporteSocio = CopiarDe.AporteSocio + (CopiarDe.AporteSocio * Convert.ToDecimal(0.50));
          aCalcular.Capital = aCalcular.AporteLey + aCalcular.AporteSocio;
          bool PagoConInteres = aCalcular.ImporteDepositado - CopiarDe.Capital > 0;
          aCalcular.Interes = Math.Round(mtdEmpresas.CalcularInteres(null, aCalcular.Periodo, aCalcular.Capital, aCalcular.Capital, Convert.ToDateTime(msk_Vencimiento.Text), cbx_TipoDeInteres.SelectedIndex, Convert.ToDecimal(txt_InteresDiario.Text), PagoConInteres), 2);
          aCalcular.TotalSueldoEmpleados = CopiarDe.TotalSueldoEmpleados + (CopiarDe.TotalSueldoEmpleados * Convert.ToDecimal(0.50));
          aCalcular.TotalSueldoSocios = CopiarDe.TotalSueldoSocios + (CopiarDe.TotalSueldoSocios * Convert.ToDecimal(0.50));
        }
        else
        {
          aCalcular.AporteLey = CopiarDe.AporteLey;
          aCalcular.AporteSocio = CopiarDe.AporteSocio;
          aCalcular.Capital = aCalcular.AporteLey + CopiarDe.AporteSocio;
          bool PagoConInteres = aCalcular.ImporteDepositado - aCalcular.Capital > 0;
          aCalcular.Interes = Math.Round(mtdEmpresas.CalcularInteres(null, aCalcular.Periodo, aCalcular.Capital, aCalcular.Capital, Convert.ToDateTime(msk_Vencimiento.Text), cbx_TipoDeInteres.SelectedIndex, Convert.ToDecimal(txt_InteresDiario.Text), PagoConInteres), 2);
          aCalcular.TotalSueldoEmpleados = CopiarDe.TotalSueldoEmpleados;
          aCalcular.TotalSueldoSocios = CopiarDe.TotalSueldoSocios;
        }
      }
      aCalcular.Rectificacion = 0;
      aCalcular.FechaDePago = null;
      aCalcular.ImporteDepositado = Convert.ToDecimal(0.00);
      aCalcular.InteresCobrado = Math.Round(Convert.ToDecimal(0.00), 2);
      aCalcular.Socios = CopiarDe.Socios;
      aCalcular.Empleados = CopiarDe.Empleados;
      aCalcular.DiasDeMora = mtdEmpresas.CalcularDias(ACalcular_, Convert.ToDateTime(msk_Vencimiento.Text));
      aCalcular.Total = aCalcular.Interes + aCalcular.Capital;
      aCalcular.PerNoDec = 0;
      dgv_ddjj.DataSource = _ddjj.ToList();

      CalcularTotales();
      PintarPerNoDec();
    }

    private void dgv_ddjj_SelectionChanged(object sender, EventArgs e)
    {
      _IndexDGV = dgv_ddjj.CurrentRow.Index;
      btn_CopiarAnterior.Enabled = dgv_ddjj.CurrentRow.Index == 0 ? false : true;
      btn_CopiarSiguiente.Enabled = dgv_ddjj.CurrentRow.Index == dgv_ddjj.Rows.Count - 1 ? false : true;
      btn_IngresoManual.Enabled = Convert.ToInt32(dgv_ddjj.CurrentRow.Cells["PerNoDec"].Value) == 1 ? true : false;
      _VDId = 0;
      if (dgv_ddjj.CurrentRow.Cells["VerificacionDeuda"].Value != null)
      {
        if (dgv_ddjj.CurrentRow.Cells["VerificacionDeuda"].Value.ToString() != "")
        {
          _VDId = Convert.ToInt32(dgv_ddjj.CurrentRow.Cells["VerificacionDeuda"].Value);
        }
      }
      btn_VerVD.Enabled = _VDId != 0;
      // txt_InspectorAsignado.Text = _VDId > 0 ? mtdInspectores.Get_Inspector(mtdVDInspector.Get_InspectorId(_VDId)).Nombre : "";

    }

    private void btn_ImprimirDeuda_Click(object sender, EventArgs e)
    {
      DS_cupones ds = new DS_cupones();
      DataTable dt_ActasDetalle = ds.ActasDetalle;

      dt_ActasDetalle.Clear();
      int Color = 0; ;
      foreach (var periodo in _ddjj.Where(x => x.Acta == ""))
      {
        Color += 1;
        DataRow row = dt_ActasDetalle.NewRow();
        row["NumeroDeActa"] = 0;
        row["Periodo"] = periodo.Periodo;
        row["CantidadDeEmpleados"] = periodo.Empleados;
        row["CantidadSocios"] = periodo.Socios;
        row["TotalSueldoEmpleados"] = periodo.TotalSueldoEmpleados;
        row["TotalSueldoSocios"] = periodo.TotalSueldoSocios;
        row["TotalAporteEmpleados"] = periodo.AporteLey;
        row["TotalAporteSocios"] = periodo.AporteSocio;
        row["FechaDePago"] = periodo.FechaDePago == null ? "" : periodo.FechaDePago.Value.Date.ToShortDateString();
        row["ImporteDepositado"] = periodo.ImporteDepositado;
        row["DiasDeMora"] = periodo.DiasDeMora;
        row["DeudaGenerada"] = periodo.Capital;
        row["InteresGenerado"] = periodo.Interes;
        row["Total"] = periodo.Total;
        row["Color"] = Color;
        row["Logo"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg"));
        dt_ActasDetalle.Rows.Add(row);
      }

      Empresa empresa = mtdEmpresas.GetEmpresa(txt_CUIT.Text);

      reportes formReporte = new reportes();

      formReporte.dt = dt_ActasDetalle;
      formReporte.dt2 = mtdFilial.Get_DatosFilial();
      formReporte.Parametro1 = empresa.MAEEMP_RAZSOC.Trim();
      formReporte.Parametro2 = empresa.MEEMP_CUIT_STR;
      formReporte.Parametro3 = "-";
      formReporte.Parametro4 = txt_Deuda.Text;//Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.Capital), 2).ToString("N2");
      formReporte.Parametro5 = txt_TotalInteres.Text;//Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.Interes), 2).ToString("N2");
      formReporte.Parametro6 = txt_Total.Text;//Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.Total), 2).ToString("N2");
      formReporte.Parametro8 = " ";
      formReporte.Parametro9 = msk_Vencimiento.Text;
      formReporte.Parametro10 = txt_PerNoDec.Text;
      formReporte.Parametro11 = txt_Domicilio.Text;

      formReporte.NombreDelReporte = "entrega_cupones.Reportes.rpt_VerificacionDeDeuda.rdlc";
      formReporte.Show();
    }

    private void btn_IngresoManual_Click(object sender, EventArgs e)
    {
      PasarDatosIngresoManual();
    }

    private void PasarDatosIngresoManual()
    {
      frm_IngresoManualDDJJ formIngresoManual = new frm_IngresoManualDDJJ();

      formIngresoManual._FechaDeVencimiento = Convert.ToDateTime(msk_Vencimiento.Text);
      formIngresoManual._TipoDeInteres = cbx_TipoDeInteres.SelectedIndex;
      formIngresoManual._TazaInteres = Convert.ToDecimal(txt_InteresDiario.Text);
      //formIngresoManual._TazaInteres = Convert.ToDecimal(txt_Interes.Text);

      formIngresoManual.txt_Periodo.Text = Convert.ToDateTime(dgv_ddjj.CurrentRow.Cells["Periodo"].Value).ToShortDateString();
      formIngresoManual.txt_FechaDePago.Text = msk_Vencimiento.Text;
      //formIngresoManual.txt_Rectificacion.Text = dgv_ddjj.CurrentRow.Cells["Rectificacion"].Value.ToString();
      //formIngresoManual.txt_AporteLey.Text = dgv_ddjj.CurrentRow.Cells["AporteLey"].Value.ToString();
      //formIngresoManual.txt_AporteSocio.Text = dgv_ddjj.CurrentRow.Cells["AporteSocio"].Value.ToString();
      //formIngresoManual.txt_Depositado.Text = dgv_ddjj.CurrentRow.Cells["ImporteDepositado"].Value.ToString();
      formIngresoManual.txt_DiasDeMora.Text = dgv_ddjj.CurrentRow.Cells["DiasDeMora"].Value.ToString();
      //formIngresoManual.txt_CantidadEmpleados.Text = dgv_ddjj.CurrentRow.Cells["Empleados"].Value.ToString();
      //formIngresoManual.txt_CantidadSocios.Text = dgv_ddjj.CurrentRow.Cells["Socios"].Value.ToString();
      //formIngresoManual.txt_TotalAporte.Text = dgv_ddjj.CurrentRow.Cells["Capital"].Value.ToString();
      //formIngresoManual.txt_Intereses.Text = dgv_ddjj.CurrentRow.Cells["Interes"].Value.ToString();
      //formIngresoManual.txt_Total.Text = dgv_ddjj.CurrentRow.Cells["Total"].Value.ToString();

      AddOwnedForm(formIngresoManual);
      formIngresoManual.ShowDialog();

      if (_Cancelado == false)
      {
        GuardarIngresoManual();

      }


      CalcularTotales();

      dgv_ddjj.DataSource = _ddjj.ToList();



      PintarPerNoDec();
      dgv_ddjj.Rows[_IndexDGV].Selected = true;
    }

    private void GuardarIngresoManual()
    {
      DateTime Periodo = Convert.ToDateTime(dgv_ddjj.CurrentRow.Cells["Periodo"].Value);
      var registro = _ddjj.FirstOrDefault(x => x.Periodo == Periodo);

      //registro.Periodo = (DateTime)dgv_ddjj.CurrentRow.Cells["Periodo"].Value;
      //registro.Rectificacion = (int)dgv_ddjj.CurrentRow.Cells["Rectificacion"].Value;
      //registro.AporteLey = (decimal)dgv_ddjj.CurrentRow.Cells["AporteLey"].Value;
      //registro.AporteSocio = (decimal)dgv_ddjj.CurrentRow.Cells["AporteSocio"].Value;
      //registro.ImporteDepositado = (decimal)dgv_ddjj.CurrentRow.Cells["ImporteDepositado"].Value;
      //registro.DiasDeMora = (int)dgv_ddjj.CurrentRow.Cells["DiasDeMora"].Value;
      //registro.Empleados = (int)dgv_ddjj.CurrentRow.Cells["Empleados"].Value;
      //registro.Socios = (int)dgv_ddjj.CurrentRow.Cells["Socios"].Value;
      //registro.Capital = (decimal)dgv_ddjj.CurrentRow.Cells["Capital"].Value;
      //registro.Interes = (decimal)dgv_ddjj.CurrentRow.Cells["Interes"].Value;
      //registro.Total = (decimal)dgv_ddjj.CurrentRow.Cells["Total"].Value;




      foreach (var item in _CargaManual)
      {
        registro.Periodo = (DateTime)item.Periodo; // (DateTime)dgv_ddjj.CurrentRow.Cells["Periodo"].Value;
        registro.Rectificacion = (int)item.Rectificacion;//(int)dgv_ddjj.CurrentRow.Cells["Rectificacion"].Value;
        registro.TotalSueldoEmpleados = (decimal)item.TotalSueldoEmpleados;
        registro.AporteLey = (decimal)item.TotalAporteEmpleados;//dgv_ddjj.CurrentRow.Cells["AporteLey"].Value;
        registro.TotalSueldoSocios = (decimal)item.TotalSueldoSocios;
        registro.AporteSocio = (decimal)item.TotalAporteSocios;//dgv_ddjj.CurrentRow.Cells["AporteSocio"].Value;
        registro.ImporteDepositado = (decimal)item.ImporteDepositado;//dgv_ddjj.CurrentRow.Cells["ImporteDepositado"].Value;
        registro.DiasDeMora = (int)item.DiasDeMora; //dgv_ddjj.CurrentRow.Cells["DiasDeMora"].Value;
        registro.Empleados = (int)item.CantidadEmpleados;//dgv_ddjj.CurrentRow.Cells["Empleados"].Value;
        registro.Socios = (int)item.CantidadSocios;//dgv_ddjj.CurrentRow.Cells["Socios"].Value;
        registro.Capital = (decimal)item.DeudaGenerada;//dgv_ddjj.CurrentRow.Cells["Capital"].Value;
        registro.Interes = (decimal)item.InteresGenerado;//dgv_ddjj.CurrentRow.Cells["Interes"].Value;
        registro.Total = (decimal)item.Total; //dgv_ddjj.CurrentRow.Cells["Total"].Value;
      }
      dgv_ddjj.DataSource = _ddjj;

    }

    private void dgv_ddjj_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void MostrarEmpleados()
    {
      DateTime Periodo = Convert.ToDateTime(dgv_ddjj.CurrentRow.Cells["Periodo"].Value);

      int Rectificacion = Convert.ToInt32(dgv_ddjj.CurrentRow.Cells["Rectificacion"].Value);

      frm_EmpleadoEstadoDDJJ frmEmpleadosDetalle = new frm_EmpleadoEstadoDDJJ();
      frmEmpleadosDetalle.txt_CUIT.Text = txt_CUIT.Text;
      frmEmpleadosDetalle.txt_Empresa.Text = txt_BuscarEmpesa.Text;
      frmEmpleadosDetalle.Periodo = Periodo;
      frmEmpleadosDetalle.Rectificacion = Rectificacion;
      frmEmpleadosDetalle.txt_Periodo.Text = Periodo.ToString("dd/MM/yyyy");

      frmEmpleadosDetalle.Show();
    }

    private void btn_PeriodoDetalle_Click(object sender, EventArgs e)
    {
      MostrarEmpleados();
    }

    private void btn_EmitirActa_Click(object sender, EventArgs e)
    {
      if (_ddjj.Where(x => x.Acta != "").Count() > 0)
      {
        MessageBox.Show("No se puede emitir el acta por que hay periodos que pertencen a otra acta. Por favor corregir el intervalo de fechas.", "ATENCION");
      }
      else
      {
        if (_ddjj.Where(x => x.PerNoDec == 1).Count() > 0)
        {
          MessageBox.Show("No se puede emitir el acta por que hay periodos que no estan declarados. Por favor verificar periodos.", "ATENCION");
        }
        else
        {
          EmitirActa();
          //CalcularDeuda();
        }
      }

    }

    private void EmitirActa()
    {
      frm_GenerarActa formActasGenerar = new frm_GenerarActa();
      formActasGenerar._PreActa = _ddjj;
      formActasGenerar._PlanDePago = _PlanDePago;
      formActasGenerar.txt_CUIT.Text = txt_CUIT.Text;
      formActasGenerar.txt_RazonSocial.Text = txt_BuscarEmpesa.Text;
      formActasGenerar.msk_Desde.Text = msk_Desde.Text;
      formActasGenerar.msk_Hasta.Text = msk_Hasta.Text;
      formActasGenerar.msk_Vencimiento.Text = msk_Vencimiento.Text;
      formActasGenerar.msk_LibroSueldoDesde.Text = msk_Desde.Text;
      formActasGenerar.msk_LibroSueldoHasta.Text = msk_Hasta.Text;
      formActasGenerar.msk_ReciboSueldoDesde.Text = msk_Desde.Text;
      formActasGenerar.msk_ReciboSueldoHasta.Text = msk_Hasta.Text;
      formActasGenerar.msk_BoletaDepositoDesde.Text = msk_Desde.Text;
      formActasGenerar.msk_BoletaDepositoHasta.Text = msk_Hasta.Text;
      formActasGenerar.txt_Total.Text = txt_Total.Text;
      formActasGenerar.txt_Interes.Text = txt_Interes.Text;
      formActasGenerar.txt_InteresDiario.Text = txt_InteresDiario.Text;
      formActasGenerar.txt_Cuotas.Text = txt_CantidadDeCuotas.Text;
      formActasGenerar.txt_ImporteDeCuota.Text = txt_ImporteDeCuota.Text;
      formActasGenerar._Capital = Convert.ToDecimal(txt_Deuda.Text);
      formActasGenerar._Interes = Convert.ToDecimal(txt_TotalInteres.Text);
      formActasGenerar._Total = Convert.ToDecimal(txt_Total.Text);
      formActasGenerar.Show();

    }

    private void btn_VerPlanDePago_Click(object sender, EventArgs e)
    {
      VerPlanDePago();
    }

    private void VerPlanDePago()
    {
      if (string.IsNullOrEmpty(txt_InteresPlan.Text) || string.IsNullOrWhiteSpace(txt_InteresPlan.Text) || txt_InteresPlan.Text == "0")
      {
        MessageBox.Show("El Interes debe ser mator que Cero.", "ATENCION !!!!!!");
        txt_InteresPlan.Focus();
      }
      else
      {
        if (txt_CantidadDeCuotas.Text == "1")
        {
          txt_Anticipo.Text = "0";
          TraerPlanDePago();
        }

        if (txt_CantidadDeCuotas.Text != "1")
        {
          if (txt_CantidadDeCuotas.Text.Trim() == "")
          {
            MessageBox.Show("Debe Ingresar al menos una cuota.", "ATENCION !!!!!!");
            txt_CantidadDeCuotas.Focus();
          }
          else
          {
            TraerPlanDePago();
          }
        }
      }
    }

    private void TraerPlanDePago()
    {
      //obtengo el importe de la cuota, si la cuota es 1 entonces el interes es 0% sino se aplica el 3% lo mismo para el cuadro de amortizacion
      txt_ImporteDeCuota.Text = mtdCobranzas.ObtenerValorDeCuota(
        Convert.ToDecimal(txt_DeudaPlan.Text),
         //txt_CantidadDeCuotas.Text == "1" ? 0 : 0.03,
         txt_CantidadDeCuotas.Text == "1" ? 0 : Convert.ToDecimal(txt_InteresPlan.Text) / 100,
        Convert.ToInt32(txt_CantidadDeCuotas.Text)
        ).ToString("N2");

      _PlanDePago = mtdCobranzas.ObtenerCuadroDeAmortizacion(
        Convert.ToDouble(txt_DeudaPlan.Text),
        txt_CantidadDeCuotas.Text == "1" ? 0 : 0.03,
        Convert.ToInt32(txt_CantidadDeCuotas.Text),
        Convert.ToDouble(txt_ImporteDeCuota.Text),
        Convert.ToDouble(txt_Anticipo.Text),
        Convert.ToDateTime(dtp_VencAnticipo.Value),
        Convert.ToDateTime(dtp_VencCuota.Value.AddMonths(1)),
        Convert.ToDecimal(txt_DeudaInicial.Text)
        );

      dgv_PlanDePagos.DataSource = _PlanDePago;

    }

    private void txt_Anticipo_TextChanged(object sender, EventArgs e)
    {
      if (txt_Anticipo.Text != "")
      {
        txt_DeudaPlan.Text = (Convert.ToDouble(txt_DeudaInicial.Text) - Convert.ToDouble(txt_Anticipo.Text)).ToString("N2");
        //VerPlanDePago();
      }
      else
      {
        txt_Anticipo.Text = "0";
      }

    }

    private void txt_CantidadDeCuotas_TextChanged(object sender, EventArgs e)
    {
      if (txt_CantidadDeCuotas.Text == "0")
      {
        txt_CantidadDeCuotas.Text = "1";
      }

    }

    private void btn_ImprimirPlanDePago2_Click(object sender, EventArgs e)
    {
      ImprimirPlanDePago();
    }

    private void ImprimirPlanDePago()
    {
      string tf = _PlanDePago.Sum(x => x.ImporteDeCuota).ToString("N2"); //(decimal) Math.Round(dt.AsEnumerable().Sum(r => r.Field<double>("ImporteDeCuota")), 2);
      mtdCobranzas.ImprimirPlanDePago(_PlanDePago, txt_BuscarEmpesa.Text, txt_CUIT.Text, "", txt_Total.Text, tf.ToString(), "");
    }

    private void btn_VerRanking_Click(object sender, EventArgs e)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        List<mdlDeudaParaRanking> _dpr = new List<mdlDeudaParaRanking>();

        List<mdlDDJJpr> _ddjjpr = new List<mdlDDJJpr>();

        var dj3 = from a in context.ddjjt
                  where a.periodo >= Convert.ToDateTime("01/" + msk_Desde.Text) &&
                  a.periodo <= Convert.ToDateTime("01/" + msk_Hasta.Text) &&
                  a.acta == 0 // && a.CUIT_STR == "27172155753"
                  select new mdlDDJJpr
                  {
                    cuit = a.CUIT_STR,
                    importe = Convert.ToDecimal(a.titem1 + a.titem2),
                    depositado = Convert.ToDecimal(a.impban1),
                    periodo = Convert.ToDateTime(a.periodo),
                    rectificacion = Convert.ToInt32(a.rect)
                    //acta = mtdEmpresas.GetNroDeActa(Convert.ToDateTime(a.periodo), a.CUIT_STR)
                  };
        _ddjjpr.AddRange(dj3);

        var agrupado = from a in _ddjjpr group a by new { a.cuit, a.periodo } into grupo where grupo.Count() > 1 select grupo; // _ddjjpr.GroupBy(x => x.periodo).Where(x => x.Count() > 1);

        foreach (var item in agrupado)
        {
          foreach (var registro in item)
          {
            if (registro.depositado == 0)
            {
              _ddjjpr.RemoveAll(x => x.periodo == registro.periodo && x.rectificacion == registro.rectificacion & x.cuit == registro.cuit);
            }
          }
        }

        var CUITAgrupado = from djs in _ddjjpr
                           group djs by djs.cuit
                           into grupoCUIT
                           select new mdlDeudaParaRanking
                           {
                             Cuit = grupoCUIT.Key,
                             Empresa = mtdEmpresas.GetEmpresa(grupoCUIT.Key) != null ? mtdEmpresas.GetEmpresa(grupoCUIT.Key).MAEEMP_RAZSOC.Trim().ToString() : "desconocida",
                             Deuda = grupoCUIT.Sum(x => x.importe) - grupoCUIT.Sum(x => x.depositado),
                           };

        dgv_Ranking.DataSource = CUITAgrupado.OrderByDescending(x => x.Deuda).ToList();
      }
    }

    private void cbx_TipoDeInteres_SelectedIndexChanged(object sender, EventArgs e)
    {
      // SelectedIndex => 0 = Manual ; 1 = AFIP
      if (cbx_TipoDeInteres.SelectedIndex == 1)
      {
        txt_Interes.Enabled = false;
        txt_InteresDiario.Enabled = false;
      }
      else
      {
        txt_Interes.Enabled = true;
        txt_InteresDiario.Enabled = true;
      }
    }

    private void txt_Interes_TextChanged(object sender, EventArgs e)
    {
      //if (txt_Interes.Text == "")
      //{
      //  txt_Interes.Text = "0";
      //}

      txt_InteresDiario.Text = mtdIntereses.CalcularInteresDiario(string.IsNullOrWhiteSpace(txt_Interes.Text)  ? "0" : txt_Interes.Text);

    }

    private void btn_CalcularDifAporteSocio_Click(object sender, EventArgs e)
    {

    }

    private void cbx_Inspectores_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void btn_ConfirmAsignacion_Click(object sender, EventArgs e)
    {
      ConfirmarAsignacion();
      CalcularDeuda();
    }

    private void ConfirmarAsignacion()
    {
      int CantidadDeActas = _ddjj.Count(x => x.Acta != "");
      if (CantidadDeActas == 0)
      {
        //PREGUNTO SI YA ESTA ASIGNADA ESTA EMPRESA Y TIENE UNA VERIFICACION DE DEUDA SIN CERRAR/CANCELAR/ACTA

        if (mtdVDInspector.YaEstaAsignada(txt_CUIT.Text.Trim().ToString()) == 0)
        {
          VD_Inspector VDInspector = new VD_Inspector
          {
            Numero = mtdVDInspector.Get_NroVD(),
            InspectorId = Convert.ToInt32(cbx_Inspectores.SelectedValue),
            EmpresaId = 0,
            CUIT = txt_CUIT.Text.Trim(),
            FechaAsignacion = DateTime.Now,
            Estado = 0,
            FechaCierre = null,
            Desde = Convert.ToDateTime(msk_Desde.Text),
            Hasta = Convert.ToDateTime(msk_Hasta.Text),
            FechaVenc = Convert.ToDateTime(msk_Vencimiento.Text),
            TipoInteres = cbx_TipoDeInteres.SelectedIndex,
            InteresMensual = Convert.ToDecimal(txt_Interes.Text),
            InteresDiario = Convert.ToDecimal(txt_InteresDiario.Text),
            Capital = Convert.ToDecimal(txt_Deuda.Text),         //Math.Round(_ddjj.Sum(x => x.Capital), 2)
            Interes = Convert.ToDecimal(txt_TotalInteres.Text),
            Total = Convert.ToDecimal(txt_Total.Text),
            EmpleadosCantidad = _ddjj.Where(x => x.Periodo == _ddjj.Max(y => y.Periodo)).FirstOrDefault().Empleados,
            UserId = _UserId,
            NroDeActa = 0

          };

          int VDDId = mtdVDInspector.Insert_VDInspector(VDInspector); // Es el Numero de VD

          mtdVDDetalle.Insert_VDDetalle(_ddjj, (int)VDInspector.Numero, true); // true para insertar. No modificar

        }
        else
        {
          MessageBox.Show("Ya tiene asignada una verificacion de Deuda");
        }
      }
      else
      {
        MessageBox.Show("Debe Excluir los periodos que pertescan a un Acta ");
      }
    }

    private void btn_Actualizar_VD_Click(object sender, EventArgs e)
    {
      Actualizar_VD();
      CalcularDeuda();
    }

    private void Actualizar_VD()
    {
      int CantidadDeActas = _ddjj.Count(x => x.Acta != "");
      if (CantidadDeActas == 0)
      {
        int VDInspectorId = mtdVDInspector.YaEstaAsignada(txt_CUIT.Text.Trim().ToString());
        if (VDInspectorId > 0)
        {
          Update_VDInspector(VDInspectorId);  // Modifico la ASignacion
          mtdVDDetalle.Insert_VDDetalle(_ddjj, VDInspectorId, false); // Envio False para que modifique
        }
        else
        {
          MessageBox.Show("Esta verificacion de Deuda, No tiene asignado ningun Isnpector");
        }
      }
      else
      {
        MessageBox.Show("Debe Excluir los periodos que pertescan a un Acta ");
      }
    }

    private void Update_VDInspector(int VDInspectorId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        VD_Inspector VDInspector = context.VD_Inspector.Where(x => x.Id == VDInspectorId).Single();

        VDInspector.InspectorId = Convert.ToInt32(cbx_Inspectores.SelectedValue);
        VDInspector.EmpresaId = 0;
        VDInspector.CUIT = txt_CUIT.Text.Trim();
        VDInspector.FechaAsignacion = DateTime.Now;
        VDInspector.Estado = 0;
        VDInspector.FechaCierre = null;
        VDInspector.Desde = Convert.ToDateTime(msk_Desde.Text);
        VDInspector.Hasta = Convert.ToDateTime(msk_Hasta.Text);
        VDInspector.FechaVenc = Convert.ToDateTime(msk_Vencimiento.Text);
        VDInspector.TipoInteres = cbx_TipoDeInteres.SelectedIndex;
        VDInspector.InteresMensual = Convert.ToDecimal(txt_Interes.Text);
        VDInspector.InteresDiario = Convert.ToDecimal(txt_InteresDiario.Text);
        VDInspector.Capital = Convert.ToDecimal(txt_Deuda.Text);  //Math.Round(_ddjj.Sum(x => x.Capital), 2)
        VDInspector.Interes = Convert.ToDecimal(txt_TotalInteres.Text);
        VDInspector.Total = Convert.ToDecimal(txt_Total.Text);
        VDInspector.EmpleadosCantidad = _ddjj.Where(x => x.Periodo == _ddjj.Max(y => y.Periodo)).FirstOrDefault().Empleados;
        VDInspector.UserId = _UserId;
        context.SubmitChanges();

      }
    }

    private void btn_VerVD_Click(object sender, EventArgs e)
    {
      //frm_VerVD f_VerVD = new frm_VerVD();
      //f_VerVD._VDId = _VDId; //Convert.ToInt32(dgv_ddjj.CurrentRow.Cells["VerificacionDeuda"].Value.ToString());
      //f_VerVD.txt_CUIT.Text = txt_CUIT.Text;
      //f_VerVD.txt_BuscarEmpesa.Text = txt_BuscarEmpesa.Text;
      //f_VerVD.msk_Desde.Text = msk_Desde.Text;
      //f_VerVD.msk_Hasta.Text = msk_Hasta.Text;
      //f_VerVD.msk_Vencimiento.Text = msk_Vencimiento.Text;
      //f_VerVD.cbx_TipoDeInteres.SelectedIndex = cbx_TipoDeInteres.SelectedIndex;
      //f_VerVD.txt_Interes.Text = txt_Interes.Text;
      //f_VerVD.txt_InteresDiario.Text = txt_InteresDiario.Text;
      //f_VerVD.Show();

      mtdVDInspector.MostrarVD(_VDId, _UserId);
    }

    private void cbx_EstCont_SelectedIndexChanged(object sender, EventArgs e)
    {
      dgv_EstCont.DataSource = MtdEstCont.Get_EmpresaDeuda(Convert.ToInt32(cbx_EstCont.SelectedValue),
        Convert.ToDateTime("01/" + msk_Desde.Text),
        Convert.ToDateTime("01/" + msk_Hasta.Text),
        Convert.ToDateTime(msk_Vencimiento.Text));
    }

    private void btn_GetIngormeGeneral_Click(object sender, EventArgs e)
    {
      var EstContDeuda = MtdEstCont.Get_Informe_EstContDeudas(
        Convert.ToDateTime("01/" + msk_Desde.Text),
        Convert.ToDateTime("01/" + msk_Hasta.Text),
        Convert.ToDateTime(msk_Vencimiento.Text));
      decimal TotalGeneral = 0;
      //dgv_EstudiosConDeuda.DataSource = xxx;

      DS_cupones ds = new DS_cupones();
      DataTable dt_InformeGeneralDeuda = ds.InformeGeneralDeuda;
      dt_InformeGeneralDeuda.Clear();

      foreach (var item in EstContDeuda)
      {

        foreach (var empresa in item.EmpresasConDeuda)
        {
          DataRow row = dt_InformeGeneralDeuda.NewRow();
          row["EstContNombre"] = item.EstContNombre;
          row["EstContDomicilio"] = item.Domicilio;
          row["EstContTelefono"] = item.Telefono;
          row["EstContEmail"] = item.Email;
          row["Empresa"] = empresa.Empresa;
          row["CUIT"] = empresa.CUIT;
          row["Deuda"] = empresa.Deuda.ToString("N2");
          TotalGeneral += empresa.Deuda;
          dt_InformeGeneralDeuda.Rows.Add(row);
        };
      }

      reportes formReporte = new reportes();
      formReporte.dt = dt_InformeGeneralDeuda;
      formReporte.dt2 = mtdFilial.Get_DatosFilial();

      //      formReporte.Parametro10 = acta.Domicilio;// txt_Domicilio.Text + " " + txt_Localidad.Text;
      formReporte.NombreDelReporte = "entrega_cupones.Reportes.rpt_InformeEstContDeuda.rdlc";
      formReporte.Show();
    }

    private void Btn_Intimacion_Click(object sender, EventArgs e)
    {

    }

    private void btn_AsentarPlan_Click(object sender, EventArgs e)
    {

    }

    private void btn_ActivarPlan_Click(object sender, EventArgs e)
    {

    }
  }
}

