using entrega_cupones.Clases;
using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrega_cupones.Metodos
{
  class MtdSorteos
  {
    public static bool CuponYaEmitido(string Cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var emitido = from a in context.eventos_cupones where a.CuilStr == Cuil select a;
        if (emitido.Count() > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    public static string CuponEmitidoLeyenda(string Cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var emitido = from a in context.eventos_cupones where a.CuilStr == Cuil select a;
        if (emitido.Count() > 0)
        {
          return "EL CUPON   Nº " + emitido.SingleOrDefault().event_cupon_nro + "   YA FUE EMITIDO PARA ESTE SOCIO EL DIA   " + emitido.SingleOrDefault().event_cupon_fecha + "   POR EL   USUARIO: '' " + MtdUsuarios.GetUserById(Convert.ToInt32(emitido.SingleOrDefault().UsuarioId)) + " ''    DESEA REIMPRMIR EL CUPON  ?????";
        }
        else
        {
          return "";
        }
      }
    }

    public static void ImprimirCuponSorteo(int NroSorteo, string Cuil, string Nombre, string Dni, string Empresa, string NroSocio, byte[] Foto, string Reimpresion, string NombreReporte)
    {
      DS_cupones Ds = new DS_cupones();
      DataTable dt = Ds.EntradaDDEDC;
      dt.Clear();
      DataRow Dr = dt.NewRow();
      MdlFilial filial = mtdFilial.Get_DatosFilial2().FirstOrDefault();
      convertir_imagen ConvertirImagen = new convertir_imagen();
      Dr["Nombre"] = Nombre;
      Dr["DNI"] = Dni;
      Dr["Empresa"] = Empresa;
      Dr["NumeroDeSocio"] = NroSocio;
      Dr["NumeroDeEntrada"] = NroSorteo;
      Dr["Foto"] = Foto;
      Dr["Reimpresion"] = Reimpresion;
      Dr["SecretearioGeneral"] = filial.SecretearioGeneral;
      Dr["SubSecretario"] = filial.SubSecretario;
      Dr["DatosSindicato"] = filial.Nombre;
      dt.Rows.Add(Dr);

      reportes frm_reportes = new reportes();
      frm_reportes.NombreDelReporte = NombreReporte;//"rpt_CuponSorteoDDEDC";
      frm_reportes.dt = dt;
      frm_reportes.Show();
    }

    public static void ControlPreImpresionCuponSorteo(bool EsSocio, string Cuil, string DniSocio, int UserId, string Nombre, string RazonSocial, string NroSocio, byte[] Foto, string EventoId, string NombreDelReporte)
    {
      if (EsSocio)
      {

        if (!CuponYaEmitido(Cuil))
        {

          double Dni = Convert.ToDouble(DniSocio);

          int NroSorteo = MtdDEC.GetNroSorteo(2, Cuil, UserId);

          MtdSorteos.ImprimirCuponSorteo(NroSorteo, Cuil, Nombre, Dni.ToString("N0"), RazonSocial, NroSocio, Foto, "0", NombreDelReporte);

        }

        else
        {
          if (MessageBox.Show(CuponEmitidoLeyenda(Cuil), "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {

            double Dni_ = Convert.ToDouble(DniSocio);

            int NroSorteo_ = MtdDEC.GetNroCuponYaEmitido(Cuil);

            MtdSorteos.ImprimirCuponSorteo(NroSorteo_, Cuil, Nombre, Dni_.ToString("N0"), RazonSocial, NroSocio, Foto, "1", NombreDelReporte);
            //MtdSorteos.ImprimirCuponSorteo(NroSorteo_, txt_CUIL.Text, txt_Nombre.Text, Dni_.ToString("N0"), txt_RazonSocial.Text, txt_NroSocio.Text, mtdConvertirImagen.ImageToByteArray(picbox_socio.Image), "1", "rpt_CuponSorteoDDEDC");
          }
        }
      }
      else
      {
        MessageBox.Show("El empleado no es socio Activo por lo tanto no puede emitir Numero para el Sorteo .......");
      }
    }
  }
}
