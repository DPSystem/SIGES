using entrega_cupones.Clases;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrega_cupones.Metodos
{
  class MtdDEC
  {
    public static int GetNroSorteo(int eventoID, string cuilSocio, int UsuarioID)
    {
      using (lts_sindicatoDataContext context = new lts_sindicatoDataContext())
      {
        eventos_cupones insert = new eventos_cupones();

        if (context.eventos_cupones.Count() > 0)
        {
          insert.event_cupon_nro = context.eventos_cupones.Max(x => x.event_cupon_nro) + 1;
        }
        else
        {
          insert.event_cupon_nro = 1;
        }

        //insert.TurnoId = //GetTurno(cuilSocio, Termas);
        insert.eventcupon_evento_id = eventoID;
        insert.CuilStr = cuilSocio;
        //insert.eventcupon_maesoc_cuil = cuil;
        //insert.eventcupon_maeflia_codfliar = CodigoFliar;
        //insert.event_cupon_event_exep_id = ExepcionID;
        insert.event_cupon_fecha = DateTime.Now;
        insert.UsuarioId = UsuarioID;
        //insert.ArticuloID = ArticuloID;
        //insert.QuienRetiraCupon = QuienRetira;
        //insert.FondoDeDesempleo = FondoDeDesempleo;


        context.eventos_cupones.InsertOnSubmit(insert);
        context.SubmitChanges();

        return insert.event_cupon_nro;
      }
    }

    public void LlenarDtEntradaDDEDC(int NumeroDeEntrada, int NumeroDeComprobante)
    {
      //  DS_cupones Ds = new DS_cupones();
      //  DataTable Dt = Ds.EntradaDDEDC;
      //  Dt.Clear();
      //  DataRow Dr = Dt.NewRow();

      //  //if (_EsSocio)
      //  //{
      //    convertir_imagen ConvertirImagen = new convertir_imagen();
      //    Dr["Nombre"] = txt_Nombre.Text;
      //    Dr["DNI"] = txt_Dni.Text;
      //    Dr["Empresa"] = txt_Empresa.Text;
      //    Dr["NumeroDeSocio"] = txt_NroSocio.Text;
      //    Dr["NumeroDeEntrada"] = NumeroDeEntrada;
      //    Dr["NumeroDeRecibo"] = NumeroDeComprobante;
      //    Dr["EsInvitado"] = "NO";
      //    Dr["Foto"] = ConvertirImagen.ImageToByteArray(picbox_socio.Image);
      //    Dr["Reimpresion"] = "0";
      //  //}
      //  //else
      //  //{
      //  //  Func_Utiles fu = new Func_Utiles();
      //  //  Dr["NumeroDeRecibo"] = fu.generar_ceros(NumeroDeComprobante.ToString(), 5);
      //  //  Dr["DNI"] = fu.generar_ceros(txt_Dni.Text, 10);
      //  //}
      //  Dt.Rows.Add(Dr);

      //  string ReporteAMostrar = string.Empty;

      //  //if (_EsSocio)
      //  //{
      //  //  if (NumeroDeEntrada > 0) //pregunto pro la entrada = a cero por que entonces Es socio
      //  //  {
      //  //    //frm_reportes.nombreReporte = "rpt_EntradaSocioDDEDC";
      //      ReporteAMostrar = "entrega_cupones.Reportes.rpt_EntradaSocioDDEDC.rdlc";
      //  //  }
      //  //  else
      //  //  {
      //  //    //frm_reportes.nombreReporte = "rpt_EntradaInvitadoDDEDC";
      //  //    ReporteAMostrar = "entrega_cupones.Reportes.rpt_EntradaInvitadoDDEDC.rdlc";
      //  //  }
      //  //}
      //  //else
      //  //{
      //  //  //frm_reportes.nombreReporte = "rpt_EntradaInvitadoDDEDC";
      //  //  ReporteAMostrar = "entrega_cupones.Reportes.rpt_EntradaInvitadoDDEDC.rdlc";
      //  //}


      //  try
      //  {   //Instanciamos un LocalReport, le indicamos el report a imprimir y le cargamos los datos
      //    LocalReport rdlc = new LocalReport();
      //    rdlc.ReportEmbeddedResource = ReporteAMostrar;
      //    rdlc.DataSources.Add(new ReportDataSource("DataSet1", Dt));
      //    //Imprime el report
      //    Impresor imp = new entrega_cupones.Impresor();

      //    imp.Imprime(rdlc);
      //  }
      //  catch (Exception ex)
      //  {
      //    MessageBox.Show(ex.Message);
      //  }

    }

    public static int GetNroCuponYaEmitido(string Cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var emitido = from a in context.eventos_cupones where a.CuilStr == Cuil select a;
        if (emitido.Count() > 0)
        {
          return emitido.SingleOrDefault().event_cupon_nro;
        }
        else
        {
          return 0;
        }
      }
    }

    //public static bool CuponYaEmitido(string Cuil)
    //{
    //  using (var context = new lts_sindicatoDataContext())
    //  {
    //    var emitido = from a in context.eventos_cupones where a.CuilStr == Cuil select a;
    //    if (emitido.Count() > 0)
    //    {
    //      return true;
    //    }
    //    else
    //    {
    //      return false;
    //    }
    //  }
    //}

    public static string CuponEmitidoLeyenda(string Cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var emitido = from a in context.eventos_cupones where a.CuilStr == Cuil select a;
        if (emitido.Count() > 0)
        {
          return "EL CUPON   Nº " + emitido.SingleOrDefault().event_cupon_nro + "   YA FUE EMITIDO PARA ESTE SOCIO EL DIA   " + emitido.SingleOrDefault().event_cupon_fecha + "   POR EL   USUARIO: '' " + GetUsuario(Convert.ToInt32(emitido.SingleOrDefault().UsuarioId)) + " ''    DESEA REIMPRMIR EL CUPON  ?????";
        }
        else
        {
          return "";
        }
      }
    }

    public static string GetUsuario(int UsuarioId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var usuario = from a in context.Usuarios where a.idUsuario == UsuarioId select a;
        if (usuario.Count() > 0)
        {
          return usuario.SingleOrDefault().Usuario;
        }
        else
        {
          return "";
        }
      }
    }

    public static void ImprimirCuponSorteo(int NroSorteo, string Cuil, string Nombre, string Dni, string Empresa, string NroSocio,  byte[] Foto,string Reimpresion, string NombreReporte  )
    {
      DS_cupones Ds = new DS_cupones();
      DataTable dt = Ds.EntradaDDEDC;
      dt.Clear();
      DataRow Dr = dt.NewRow();

      convertir_imagen ConvertirImagen = new convertir_imagen();
      Dr["Nombre"] = Nombre;
      Dr["DNI"] = Dni;
      Dr["Empresa"] = Empresa;
      Dr["NumeroDeSocio"] = NroSocio;
      Dr["NumeroDeEntrada"] = NroSorteo;

      Dr["Foto"] = Foto;
      Dr["Reimpresion"] = Reimpresion;

      dt.Rows.Add(Dr);
      reportes frm_reportes = new reportes();
      frm_reportes.NombreDelReporte = NombreReporte;//"rpt_CuponSorteoDDEDC";
      frm_reportes.dt = dt;
      frm_reportes.Show();
    }
  }
}
