﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using entrega_cupones.Reportes;
using entrega_cupones.Clases;
using System.Collections;
using entrega_cupones.Modelos;
using entrega_cupones.Metodos;

namespace entrega_cupones
{

  public partial class frm_edades : Form
  {
    lts_sindicatoDataContext db_socios = new lts_sindicatoDataContext();
    List<mdlMaeFlia> Edades = new List<mdlMaeFlia>();
    List<MdlCuponesEmitidos> CuponesEdad = new List<MdlCuponesEmitidos>();

    public frm_edades()
    {
      InitializeComponent();
    }

    private void btn_imprimir_Click(object sender, EventArgs e)
    {
      Func_Utiles func_utiles = new Func_Utiles();
      var edades = (from a in db_socios.soccen
                    join sf in db_socios.socflia on a.SOCCEN_CUIL equals sf.SOCFLIA_CUIL
                    join flia in db_socios.maeflia on sf.SOCFLIA_CODFLIAR equals flia.MAEFLIA_CODFLIAR
                    join maesocio in db_socios.maesoc on a.SOCCEN_CUIL equals maesocio.MAESOC_CUIL
                    //where a.SOCCEN_ESTADO == 1 && maesocio.MAESOC_CODPOS == "4220"
                    where a.SOCCEN_ESTADO == 1 && (cbx_localidad.SelectedValue.ToString() == "0" ? maesocio.MAESOC_CODPOS != cbx_localidad.SelectedValue.ToString() : maesocio.MAESOC_CODPOS == cbx_localidad.SelectedValue.ToString())
                    select new
                    {
                      sexo = flia.MAEFLIA_SEXO.ToString(),
                      edad = func_utiles.calcular_edad(flia.MAEFLIA_FECNAC)// calcular_edad(flia.MAEFLIA_FECNAC)
                    }).ToList();


      while (dgv_edades.Rows.Count > 0)
      {
        dgv_edades.Rows.RemoveAt(0);
      }
      dgv_edades.Rows.Add(5);

      //dgv_edades.Rows[4].Cells["edad"].Value = "12 a 18";
      //dgv_edades.Rows[4].Cells["F"].Value = edades.Where(x => x.edad >= 12 && x.edad <= 18 && x.sexo == "F").Count();
      //dgv_edades.Rows[4].Cells["M"].Value = edades.Where(x => x.edad >= 12 && x.edad <= 18 && x.sexo == "M").Count();
      //dgv_edades.Rows[4].Cells["cantidad"].Value = edades.Where(x => x.edad >= 12 && x.edad <= 18 && x.sexo != " ").Count();

      //dgv_edades.Rows[3].Cells["edad"].Value = "8 a 11";
      //dgv_edades.Rows[3].Cells["F"].Value = edades.Where(x => x.edad >= 8 && x.edad <= 11 && x.sexo == "F").Count();
      //dgv_edades.Rows[3].Cells["M"].Value = edades.Where(x => x.edad >= 8 && x.edad <= 11 && x.sexo == "M").Count();
      //dgv_edades.Rows[3].Cells["cantidad"].Value = edades.Where(x => x.edad >= 8 && x.edad <= 11 && x.sexo != " ").Count();

      dgv_edades.Rows[3].Cells["edad"].Value = "13 a 17";
      dgv_edades.Rows[3].Cells["F"].Value = edades.Where(x => x.edad >= 13 && x.edad <= 17 && x.sexo == "F").Count();
      dgv_edades.Rows[3].Cells["M"].Value = edades.Where(x => x.edad >= 13 && x.edad <= 17 && x.sexo == "M").Count();
      dgv_edades.Rows[3].Cells["cantidad"].Value = edades.Where(x => x.edad >= 13 && x.edad <= 17 && x.sexo != " ").Count();

      dgv_edades.Rows[2].Cells["edad"].Value = "8 a 12";
      dgv_edades.Rows[2].Cells["F"].Value = edades.Where(x => x.edad >= 8 && x.edad <= 12 && x.sexo == "F").Count();
      dgv_edades.Rows[2].Cells["M"].Value = edades.Where(x => x.edad >= 8 && x.edad <= 12 && x.sexo == "M").Count();
      dgv_edades.Rows[2].Cells["cantidad"].Value = edades.Where(x => x.edad >= 8 && x.edad <= 12 && x.sexo != " ").Count();

      dgv_edades.Rows[1].Cells["edad"].Value = "6 a 7";
      dgv_edades.Rows[1].Cells["F"].Value = edades.Where(x => x.edad >= 6 && x.edad <= 7 && x.sexo == "F").Count();
      dgv_edades.Rows[1].Cells["M"].Value = edades.Where(x => x.edad >= 6 && x.edad <= 7 && x.sexo == "M").Count();
      dgv_edades.Rows[1].Cells["cantidad"].Value = edades.Where(x => x.edad >= 6 && x.edad <= 7 && x.sexo != " ").Count();

      dgv_edades.Rows[0].Cells["edad"].Value = "3 a 5";
      dgv_edades.Rows[0].Cells["F"].Value = edades.Where(x => x.edad >= 3 && x.edad <= 5 && x.sexo == "F").Count();
      dgv_edades.Rows[0].Cells["M"].Value = edades.Where(x => x.edad >= 3 && x.edad <= 5 && x.sexo == "M").Count();
      dgv_edades.Rows[0].Cells["cantidad"].Value = edades.Where(x => x.edad >= 3 && x.edad <= 5 && x.sexo != " ").Count();

      dgv_edades.Rows[4].Cells["edad"].Value = "sin sexo";
      dgv_edades.Rows[4].Cells["cantidad"].Value = edades.Where(x => x.edad >= 3 && x.edad <= 17 && x.sexo == " ").Count();

      lbl_total_edades.Text = edades.Where(x => x.edad >= 3 && x.edad <= 17).Count().ToString();
      //dgv_linq();
    }

    private int calcular_edad(DateTime fecha_nac)
    {
      int edad = 0;
      DateTime fecha_actual = DateTime.Today;
      edad = fecha_actual.Year - fecha_nac.Year;
      if ((fecha_actual.Month < fecha_nac.Month) || (fecha_actual.Month == fecha_nac.Month && fecha_actual.Day < fecha_nac.Day))
      {
        edad--;
      }
      return edad;
    }

    private void dgv_linq()
    {
      DS_cupones.crystalDataTable DT = new DS_cupones.crystalDataTable();

      DT.AddcrystalRow("1", "2", "3", "4");
      //rpt_edades ed = new rpt_edades();
      ////ed.SetDataSource(DT.ToList());
      //reportes_CR rpt = new reportes_CR("SS");
      //rpt.Show();

    }

    private void frm_edades_Load(object sender, EventArgs e)
    {
      dgv_EdadesCupones.AutoGenerateColumns = false;
      cargar_localidad();
      Edades.AddRange(mtdEdades.GenerarEdades());
      MostrarEdadesCupones();
      
    }

    private void MostrarEdadesCupones()
    {

      var a = MtdEventos.GetCuponesEmitidosPorEdad().OrderBy(x => x.Edad);
      foreach (var edad in a.GroupBy(x => x.Edad))
      {
        MdlCuponesEmitidos ce = new MdlCuponesEmitidos();
        ce.Edad = edad.Key;
        ce.Mujer = edad.Count(x => x.Sexo == "F");
        ce.Varon = edad.Count(x => x.Sexo == "M");
        ce.Total = edad.Count();
        CuponesEdad.Add(ce);
      };

      dgv_EdadesCupones.DataSource = CuponesEdad.ToList();

      Lbl_TotalCuponesJuguetes.Text = a.Count().ToString();
    }

    private void cargar_localidad()
    {
      var loc = (from a in db_socios.localidades where a.idprovincias == 14 select a).OrderBy(x => x.nombre);
      cbx_localidad.DisplayMember = "nombre";
      cbx_localidad.ValueMember = "codigopostal";

      cbx_localidad.DataSource = loc.ToList();

    }

    private void btn_CalcularEdades_Click(object sender, EventArgs e)
    {
      dgv_Edades2.DataSource = mtdEdades.GetEdades(Convert.ToInt32(cbx_localidad.SelectedValue));//Edades,Convert.ToInt32 (cbx_Desde.Text), Convert.ToInt32(cbx_Hasta.Text));

      foreach (DataGridViewRow Fila in dgv_Edades2.Rows)
      {
        Fila.Cells["Cantidad2"].Value = Convert.ToInt32(Fila.Cells["Varon2"].Value) + Convert.ToInt32(Fila.Cells["Mujer2"].Value);

      }
    }

  }
}
