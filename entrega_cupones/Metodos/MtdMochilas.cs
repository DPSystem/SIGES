using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace entrega_cupones.Metodos
{
  class MtdMochilas
  {
    public static List<MdlMochilas> GetMochilas()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var mochilas = from a in context.articulos
                       select new MdlMochilas
                       {
                         Id = a.ID,
                         Descripcion = a.Descripcion //+ (a.Sexo == 'F' ? " - MUJER" : " - VARON")
                       };
        return mochilas.ToList();
      }
    }

    public static List<MdlControlStockMochilas> GetControlStock()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var stock = from m in context.articulos
                    select new MdlControlStockMochilas
                    {
                      Id = m.ID,
                      Mochila = m.Descripcion,
                      ParaEntregar = context.CuponBenefArticulos.Where(x => x.ArticuloId == m.ID).Count(),
                      Entregadas = context.CuponBenefArticulos.Where(x => x.ArticuloId == m.ID && x.Estado == 1).Count(),
                      EnStock = Convert.ToInt32(m.StockInicial - context.CuponBenefArticulos.Where(x => x.ArticuloId == m.ID && x.Estado == 1).Count())
                      // (context.CuponBenefArticulos.Where(x => x.ArticuloId == m.ID).Count()) - (context.CuponBenefArticulos.Where(x => x.ArticuloId == m.ID && x.Estado == 1).Count()),
                    };
        return stock.ToList();
      }
    }
    public static List<MdlCuponMochila> GetCuponMochila(int NroCupon)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var cm = from a in context.CuponBenefArticulos.Where(x => x.NroCupon == NroCupon) select a;
        List<MdlCuponMochila> cpm = new List<MdlCuponMochila>();
        MdlCuponMochila CuponMochila = new MdlCuponMochila();
        foreach (var item in cm.ToList())
        {
          CuponMochila.JM += item.ArticuloId == 1 ? 1 : 0;
          CuponMochila.JV += item.ArticuloId == 2 ? 1 : 0;
          CuponMochila.P1M += item.ArticuloId == 3 ? 1 : 0;
          CuponMochila.P1V += item.ArticuloId == 4 ? 1 : 0;
          CuponMochila.P2M += item.ArticuloId == 5 ? 1 : 0;
          CuponMochila.P2V += item.ArticuloId == 6 ? 1 : 0;
          CuponMochila.SM += item.ArticuloId == 7 ? 1 : 0;
          CuponMochila.SV += item.ArticuloId == 8 ? 1 : 0;
        }
        cpm.Add(CuponMochila);
        return cpm.ToList();
      }
    }

    public static List<MdlCuponesEmitidos> GetCuponesEmitidos(int EventoId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var CuponesEmitidos = from a in context.eventos_cupones.Where (x=>x.eventcupon_evento_id == EventoId)
                              join soc in context.maesoc on a.CuilStr equals soc.MAESOC_CUIL_STR orderby a.event_cupon_nro
                              select new MdlCuponesEmitidos
                              {
                                NroCupon = a.event_cupon_nro,
                                Socio = soc.APENOM,
                                FechaEntrega = a.FechaDeEntregaArticulo
                              };

        return CuponesEmitidos.ToList();                     
      }
    }
  }
}
