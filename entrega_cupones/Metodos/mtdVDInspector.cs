using entrega_cupones.Clases;
using entrega_cupones.Formularios;
using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  class mtdVDInspector
  {
    public static int Insert_VDInspector(VD_Inspector VDInspector)//int IdInspector, string Cuit,int UserId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        context.VD_Inspector.InsertOnSubmit(VDInspector);
        context.SubmitChanges();
        return (int) context.VD_Inspector.Max(x => x.Numero); //retorna el Id del al relacion inspector verificacion de deuca
      }
    }

    public static void Update_VDInspector(VD_Inspector VDInspector)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        context.SubmitChanges();
      }
    }

    public static int YaEstaAsignada(string cuit)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var YaAsignada = from a in context.VD_Inspector where a.CUIT == cuit && a.Estado == 0 select new { a.Id };
        if (YaAsignada.Count() > 0)
        {
          return YaAsignada.Single().Id;
        }
        else
        {
          return 0;
        }
      }
    }

    public static int Get_InspectorId(int VDId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        int InspectorId = (from a in context.VD_Inspector where a.Id == VDId select new { a.InspectorId }).Single().InspectorId;
        return InspectorId;
      }
    }

    public static string Get_VDCuit(int VDId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        string VD_Cuit = (from a in context.VD_Inspector where a.Id == VDId select new { a.CUIT }).Single().CUIT;
        return VD_Cuit;
      }
    }

    public static List<mdlVDInspector> Get_VDListado()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var VDI = from a in context.VD_Inspector
                  select new mdlVDInspector
                  {
                    Id = a.Id,
                    FechaAsignacion = a.FechaAsignacion,
                    Desde = Convert.ToDateTime(a.Desde),
                    Hasta = Convert.ToDateTime(a.Hasta),
                    FechaVenc = Convert.ToDateTime(a.FechaVenc),
                    TipoInteres = (int)a.TipoInteres,
                    InteresMensual = (decimal)a.InteresMensual,
                    InteresDiario = (decimal)a.InteresDiario,
                    Interes = (decimal)a.Interes,
                    CUIT = a.CUIT,
                    Empresa = mtdEmpresas.GetEmpresa(a.CUIT).MAEEMP_RAZSOC.Trim(),
                    //Domicilio = mtdEmpresas.GetDomicilio(a.CUIT),
                    Total = Convert.ToDecimal(a.Total),
                    Estado = a.Estado,
                    Numero = (int)a.Numero,
                    NroDeActa = (int)a.NroDeActa
                  };

        return VDI.ToList();
      }
    }

    public static List<mdlVDInspector> Get_VD(int VDId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var VD = from a in context.VD_Inspector.Where(x => x.Id == VDId)
                 select new mdlVDInspector
                 {
                   Id = a.Id,
                   FechaAsignacion = a.FechaAsignacion,
                   Desde = Convert.ToDateTime(a.Desde),
                   Hasta = Convert.ToDateTime(a.Hasta),
                   FechaVenc = Convert.ToDateTime(a.FechaVenc),
                   TipoInteres = (int)a.TipoInteres,
                   InteresMensual = (decimal)a.InteresMensual,
                   InteresDiario = (decimal)a.InteresDiario,
                   Interes = (decimal)a.Interes,
                   CUIT = a.CUIT,
                   Empresa = mtdEmpresas.GetEmpresa(a.CUIT).MAEEMP_RAZSOC.Trim(),
                   //Domicilio = mtdEmpresas.GetDomicilio(a.CUIT),
                   Total = Convert.ToDecimal(a.Total),
                   InspectorId = a.InspectorId,
                   Estado = a.Estado
                 };

        return VD.ToList();
      }
    }

    public static List<VD_Inspector> Get_VDListado2()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        List<VD_Inspector> VDI = (from a in context.VD_Inspector select a).ToList();

        return VDI.ToList();
      }
    }

    public static int Get_NroVD()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        if (context.VD_Inspector.Count() == 0)
        {
          return 1;
        }
        else
        {
          return (int)context.VD_Inspector.Max(x => x.Numero) + 1;
        }
        //return context.VD_Inspector.Count() == 0 ? 1 : (int)context.VD_Inspector.Max(x => x.Numero) + 1;
      }
    }

    public static void MostrarVD(int NroVD, int UsuarioId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var VD = context.VD_Inspector.Where(x => x.Numero == NroVD).SingleOrDefault();

        frm_VerVD f_VerVD = new frm_VerVD();
        f_VerVD._VDId = VD.Id;
        f_VerVD._NumeroVD =(int) VD.Numero;
        f_VerVD._UsuarioId = UsuarioId;
        //f_VerVD._Usuario = Usuario;
        f_VerVD._NroDeActa =(int) VD.NroDeActa;
        f_VerVD.Text = "Verificacion de Deuda N° " + VD.Id;//+ " - Empresa: " + dgv_VD.CurrentRow.Cells["VD_Empresa"].Value;
        f_VerVD.Lbl_VDDetalle.Text = "Detalle de Verificacione de deuda  N° " + VD.Numero.ToString();
        f_VerVD.Show();
      }
    }
  }
}
