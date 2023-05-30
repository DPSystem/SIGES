using entrega_cupones.Clases;
using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  class mtdFilial
  {
    public static DataTable Get_DatosFilial()
    {
      DS_cupones ds = new DS_cupones();
      DataTable dt_Filial = ds.Filial;
      dt_Filial.Clear();

      using (var context = new lts_sindicatoDataContext())
      {

        foreach (var item in context.Filial)
        {
          DataRow row = dt_Filial.NewRow();
          row["Nombre"] = item.Nombre;
          row["Domicilio"] = item.Domicilio + " - " + item.Provincia + " - " + item.Localidad + " - " + item.Telefono + " - " + item.Email;
          row["Localidad"] = item.Localidad;
          row["Telefono"] = item.Telefono;
          row["Provincia"] = item.Provincia;
          row["Email"] = item.Email;
          row["Logo"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg"));
          row["SecretarioGeneral"] = item.SecretarioGeneral;
          row["SubSecretario"] = item.SubSecretario;
          row["NombreCorto"] = item.NombreCorto;
          row["Aux1"] = item.Aux1;
          row["Aux2"] = item.Aux2;
          row["SecretariaDeLaMujer"] = item.SecretariaDeLaMujer;
          dt_Filial.Rows.Add(row);
        }
      }
      return dt_Filial;
    }

    public static List<MdlFilial> Get_DatosFilial2()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        //MdlFilial DatosFilial;
        var datos = from a in context.Filial
                          select new MdlFilial
                          {
                             Id = a.Id,
                             Nombre = a.Nombre,
                             Domicilio = a.Domicilio,
                             Localidad = a.Localidad,
                             Telefono = a.Telefono, 
                             Provincia = a.Provincia,
                             email = a.Email,
                             SecretearioGeneral = a.SecretarioGeneral,
                             SubSecretario = a.SubSecretario,
                             
                          };
        return datos.ToList();
      }
    }

    public static int Get_FilialSorteoConfig()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        return (int)context.Filial.SingleOrDefault().SorteoConfig;
      }
    }
  }
}
