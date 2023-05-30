using entrega_cupones.Modelos;
using entrega_cupones.Clases;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entrega_cupones.Metodos;
using System.Drawing;

namespace entrega_cupones.Metodos
{
  class MtdBeneficiarios
  {

    public static List<MdlBenef> GetBeneficiarios(double Cuil, int EventoAñoId)
    {

      using (var context = new lts_sindicatoDataContext())
      {
        //socios soc = new socios();
        var Beneficiario = from a in context.socflia
                           where a.SOCFLIA_CUIL == Cuil
                           join Familiar in context.maeflia on a.SOCFLIA_CODFLIAR equals Familiar.MAEFLIA_CODFLIAR
                           join ec in context.EventosCupones_.Where(x => x.EventoAnioId == EventoAñoId) on a.SOCFLIA_CODFLIAR.ToString() equals ec.CodigoFamiliar
                           into rqq
                           from rq in rqq.DefaultIfEmpty()

                           select new MdlBenef
                           {
                             ApeNom = Familiar.MAEFLIA_APELLIDO.Trim() + " " + Familiar.MAEFLIA_NOMBRE.Trim(),
                             Parentesco = (a.SOCFLIA_PARENT == 1) ? "CONYUGE" :
                                                    (a.SOCFLIA_PARENT == 2) ? "HIJO MENOR DE 16" :
                                                    (a.SOCFLIA_PARENT == 3) ? "HIJO MENOR DE 18" :
                                                    (a.SOCFLIA_PARENT == 4) ? "HIJO MENOR DE 21" :
                                                    (a.SOCFLIA_PARENT == 5) ? "HIJO MAYOR DE 21" : "",
                             CodigoFliar = (int)Familiar.MAEFLIA_CODFLIAR,
                             DNI = Familiar.MAEFLIA_NRODOC.ToString(),
                             FechaNac = (DateTime)Familiar.MAEFLIA_FECNAC,
                             Edad = mtdFuncUtiles.calcular_edad(Familiar.MAEFLIA_FECNAC),
                             NroCupon = rq.NroCupon,
                             FechaGeneracionDeCupon = rq.FechaGeneracion
                           };
        return Beneficiario.ToList();
      }
    }

    public static List<MdlBenef> GetBeneficiarios2(string CUIL)
    {

      using (var context = new lts_sindicatoDataContext())
      {
        //socios soc = new socios();
        var Beneficiario = from a in context.socflia.Where(x => x.CUIL_STR == CUIL)
                           join Familiar in context.maeflia on a.SOCFLIA_CODFLIAR equals Familiar.MAEFLIA_CODFLIAR
                           select new MdlBenef
                           {
                             ApeNom = Familiar.MAEFLIA_APELLIDO.Trim() + " " + Familiar.MAEFLIA_NOMBRE.Trim(),
                             Parentesco = (a.SOCFLIA_PARENT == 1) ? "CONYUGE" :
                                                    (a.SOCFLIA_PARENT == 2) ? "HIJO MENOR DE 16" :
                                                    (a.SOCFLIA_PARENT == 3) ? "HIJO MENOR DE 18" :
                                                    (a.SOCFLIA_PARENT == 4) ? "HIJO MENOR DE 21" :
                                                    (a.SOCFLIA_PARENT == 5) ? "HIJO MAYOR DE 21" : "",
                             CodigoFliar = (int)Familiar.MAEFLIA_CODFLIAR,
                             DNI = Familiar.MAEFLIA_NRODOC.ToString(),
                             FechaNac = (DateTime)Familiar.MAEFLIA_FECNAC,
                             Edad = mtdFuncUtiles.calcular_edad(Familiar.MAEFLIA_FECNAC),
                           };
        return Beneficiario.ToList();
      }
    }

    public static Image GetFotoBenef(double CodigoDeFamiliar)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var foto = from a in context.fotos where a.FOTOS_CODFLIAR == CodigoDeFamiliar select a;
        if (foto.Count() > 0)
        {
          return mtdConvertirImagen.ByteArrayToImage(foto.FirstOrDefault().FOTOS_FOTO.ToArray());
        }
        else
        {
          // cuando no hay foto trae la imagen del contorno del usuario.
          return Properties.Resources.User_Contorno_;
        }
      }
    }

    public static Binary GetFotoBenefBinary(double CodFliar)
    {
      
      using (var context = new lts_sindicatoDataContext())
      {
        Binary foto;
        var foto_ = from a in context.fotos where a.FOTOS_CODFLIAR == CodFliar select a;
        if (foto_.Count() > 0)
        {
          foto = foto_.FirstOrDefault().FOTOS_FOTO;
        }
        else
        {

          // cuando no hay foto trae la imagen del contorno del usuario.
          foto = mtdConvertirImagen.ImageToByteArray(Properties.Resources.User_Contorno_);
          //foto = cnv_img.ImageToByteArray(Properties.Resources.User_Contorno_);
        }
        return foto;
      }
    }
  }
}
