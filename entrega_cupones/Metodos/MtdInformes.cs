using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entrega_cupones.Modelos;

namespace entrega_cupones.Metodos
{
  class MtdInformes
  {
    public static List<MdlEqnd> EmpresasQueNoDeclaran(DateTime Desde, DateTime Hasta)
    {
      List<MdlEqnd> Eqnd = new List<MdlEqnd>();
      using (var context = new lts_sindicatoDataContext())
      {

        var Eqnd_ = from dj in context.ddjjt
                    where dj.periodo >= Desde && dj.periodo <= Hasta
                    join emp in context.maeemp on dj.CUIT_STR equals emp.MEEMP_CUIT_STR into nodj
                    from n in nodj.DefaultIfEmpty()
                    select new MdlEqnd { Empresa = n.MAEEMP_RAZSOC, Cuit = n.MEEMP_CUIT_STR }
                    ;
        Eqnd.AddRange(Eqnd_.ToList());
      }
      return Eqnd;

      //var results = from p in persons
      //              group p.car by p.PersonId into g
      //              select new { PersonId = g.Key, Cars = g.ToList() };


    }

    
  }
}
