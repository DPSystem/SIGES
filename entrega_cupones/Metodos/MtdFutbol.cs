using entrega_cupones.Clases;
using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrega_cupones.Metodos
{
  class MtdFutbol
  {
    public static List<MdlPartidoCanchaJug> GetPartidos(bool Actual, int PartidoId, DateTime Fecha)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        List<MdlPartidoCanchaJug> pcj = new List<MdlPartidoCanchaJug>();
        List<MdlPartidoCanchaJug> pcj1 = new List<MdlPartidoCanchaJug>();
        List<MdlPartidoCanchaJug> pcj2 = new List<MdlPartidoCanchaJug>();
        List<MdlPartidoCanchaJug> col1y2 = new List<MdlPartidoCanchaJug>();

        futbol ftbl = new futbol();
        convertir_imagen cnv_img = new convertir_imagen();

        var Campeonato = context.campeonatos.Where(x => x.CAMPESTADO == 1).FirstOrDefault();

        var sanciones = from a in context.sanciones.Where(x => x.ID_PARTIDO == 0) select a;

        var partidosCancha1 = from jug in context.jugadores
                              join eqps in context.equipos on jug.JUG_EQUIPOID equals eqps.EQUIPOID
                              join cat in context.categorias on eqps.EQUIPO_CATID equals cat.CATID
                              join prt in context.partidos on jug.JUG_EQUIPOID equals prt.PARTIDOEQUIPO1
                              join cnch in context.canchas on prt.PARTIDO_CANCHAID equals cnch.CANCHAID
                              where Actual ? prt.PARTIDOID == PartidoId : prt.PARTIDOFECHA == Fecha

                              select new MdlPartidoCanchaJug
                              {
                                equipo = eqps.EQUIPONOMBRE,
                                fecha = prt.PARTIDOFECHA,
                                hora = prt.PARTIDOHORA,
                                fase = prt.PARTIDO_FASEID,
                                cancha = cnch.CANCHANOMBRE, //+ "CUARTOS DE FINAL - PARTIDO IDA",
                                categoria = cat.CATNOMBRE,
                                partidoID = prt.PARTIDOID,
                                col1NroSocio = jug.JUG_MAESOC_NROAFIL,
                                col1Nombre = jug.JUG_APELLIDO + " " + jug.JUG_NOMBRE,
                                col1DNI = jug.JUG_SOCCENCUIL,
                                col1Foto = cnv_img.ByteArrayToImage(jug.JUG_FOTO.ToArray()),//jug.JUG_FOTO,
                                nroFecha = Convert.ToInt32(prt.PARTIDONROFECHA),
                                sancion_x_de = ftbl.get_nro_fecha_sancion(jug.JUGID), //sanciones.Where(x=>x.ID_JUG == jug.JUGID).Count() > 0 ? sanciones.Where(x => x.ID_JUG == jug.JUGID).Min(x=>x.NRO_FECHA) : 0,
                                sancion_cantidad = ftbl.get_cantidad_fecha_sancion(jug.JUGID), //sanciones.Where(x => x.ID_JUG == jug.JUGID).Count() > 0 ? sanciones.Where(x => x.ID_JUG == jug.JUGID).First().CANTIDAD_FECHAS : 0,
                                orden_fixture = 1,
                                nom_campeonato = Campeonato.CAMPNOMBRE,
                                año = Campeonato.CAMPAÑO,
                                columna = 0
                              };

        pcj1.AddRange(partidosCancha1);

        var partidosCancha2 = from jug in context.jugadores
                              join eqps in context.equipos on jug.JUG_EQUIPOID equals eqps.EQUIPOID
                              join cat in context.categorias on eqps.EQUIPO_CATID equals cat.CATID
                              join prt in context.partidos on jug.JUG_EQUIPOID equals prt.PARTIDOEQUIPO2
                              join cnch in context.canchas on prt.PARTIDO_CANCHAID equals cnch.CANCHAID
                              where Actual ? prt.PARTIDOID == PartidoId : prt.PARTIDOFECHA == Fecha
                              select new MdlPartidoCanchaJug
                              {
                                equipo = eqps.EQUIPONOMBRE,
                                fecha = prt.PARTIDOFECHA,
                                hora = prt.PARTIDOHORA,
                                fase = prt.PARTIDO_FASEID,
                                cancha = cnch.CANCHANOMBRE, //+ "CUARTOS DE FINAL - PARTIDO IDA",
                                categoria = cat.CATNOMBRE,
                                partidoID = prt.PARTIDOID,
                                col1NroSocio = jug.JUG_MAESOC_NROAFIL,
                                col1Nombre = jug.JUG_APELLIDO + " " + jug.JUG_NOMBRE,
                                col1DNI = jug.JUG_SOCCENCUIL,
                                col1Foto = cnv_img.ByteArrayToImage(jug.JUG_FOTO.ToArray()),
                                nroFecha = Convert.ToInt32(prt.PARTIDONROFECHA),
                                sancion_x_de = ftbl.get_nro_fecha_sancion(jug.JUGID),//sanciones.Where(x => x.ID_JUG == jug.JUGID).Count() > 0 ? sanciones.Where(x => x.ID_JUG == jug.JUGID).Min(x => x.NRO_FECHA) : 0,
                                sancion_cantidad = ftbl.get_cantidad_fecha_sancion(jug.JUGID),//sanciones.Where(x => x.ID_JUG == jug.JUGID).Count() > 0 ? sanciones.Where(x => x.ID_JUG == jug.JUGID).First().CANTIDAD_FECHAS : 0,
                                orden_fixture = 2,
                                nom_campeonato = Campeonato.CAMPNOMBRE,
                                año = Campeonato.CAMPAÑO,
                                columna = 0
                              };
        pcj2.AddRange(partidosCancha2);

        pcj.AddRange(pcj1.Union(pcj2));
        return pcj;//.OrderBy(x => x.cancha).ThenBy(x => x.hora).ThenBy(x => x.equipo).ThenBy(x => x.col1Nombre);

      }
    }

    public static bool ControlarEquipoRepetido(DataGridView dgv, int IdEquipo1, int IdEquipo2)
    {
      bool repetido = false;
      foreach (DataGridViewRow fila in dgv.Rows)
      {
        if (Convert.ToInt32(fila.Cells["IdEquipo1"].Value) == IdEquipo1)
        {
          repetido = true;
        }
        else
        {
          if (Convert.ToInt32(fila.Cells["IdEquipo2"].Value) == IdEquipo2)
          {
            repetido = true;
          }
        }
      }
      return repetido;
    }
  }
}
