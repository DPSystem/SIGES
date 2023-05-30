using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using entrega_cupones.Clases;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;

namespace entrega_cupones
{
  public partial class frm_futbol : Form
  {
    
    lts_sindicatoDataContext db_sindicato = new lts_sindicatoDataContext();
    DS_cupones ds_cpns = new DS_cupones();
    Func_Utiles func_util = new Func_Utiles();
    bool Imprimir_Informe_Arbitral_Actual = true;
    bool Imprimir_Partido_Actual = true;
    int _CantJug = 0;
    public frm_futbol()
    {
      InitializeComponent();
    }

    private void frm_futbol_Load(object sender, EventArgs e)
    {
      cargar_cbx_categoria();
      dgv_equiposInscriptos.AutoGenerateColumns = false;
      //  Dim diasQueFaltanParaElDomingo As Integer = 7 + CInt(DayOfWeek.Monday) - CInt(fechaInicial.DayOfWeek)
      string año = "";
      string mes = "";
      string dia = "";
      int domingo = 0;

      domingo = 7 + Convert.ToInt32((DayOfWeek.Monday)) - Convert.ToInt32(dtp_fecha_partidos.Value.DayOfWeek);
      if (domingo > 7) domingo = domingo - 7;
      if (domingo < 7) domingo = domingo - 1;
      if (domingo == 7) domingo = 0;

      año = DateTime.Now.Year.ToString();
      mes = DateTime.Now.Month.ToString();
      // dia = (DateTime.Now.Day + domingo).ToString();
      dia = (DateTime.Now.AddDays(domingo)).ToString();

      //String f = Convert.ToString(año) + "/" + Convert.ToString(mes) + "/" + dia;

      dtp_fecha_partidos.Value = Convert.ToDateTime(dia);

      var controles = pnl_equiposInscriptos.Controls.OfType<BunifuImageButton>().ToList(); // obtengo la lista de controles

      mostrar_gerentes_inscriptos();

      Cbx_CantJug.SelectedIndex = 0;
      _CantJug = Convert.ToInt16(Cbx_CantJug.Text);

      //var controles = pnl_menu.Controls.OfType<BunifuFlatButton>().ToList(); // obtengo la lista de controles

    }

    private void cargar_cbx_categoria()
    {

      var cat = from a in db_sindicato.categorias select a; // delcaro variable con categorias
                                                            // Cargo el combo  cbx_categoria de la inscripcion de equipos
      cbx_categoria.DisplayMember = "catnombre";
      cbx_categoria.ValueMember = "catid";

      cbx_categoria_equipos_inscriptos.DisplayMember = "catnombre";
      cbx_categoria_equipos_inscriptos.ValueMember = "catid";

      cbx_categoria_incripcion_jugadores.DisplayMember = "catnombre";
      cbx_categoria_incripcion_jugadores.ValueMember = "catid";

      cbx_categoria_jugadores_inscriptos.DisplayMember = "catnombre";
      cbx_categoria_jugadores_inscriptos.ValueMember = "catid";

      cbx_categoria_partidos.DisplayMember = "catnombre";
      cbx_categoria_partidos.ValueMember = "catid";

      cbx_categoria_g.DisplayMember = "catnombre";
      cbx_categoria_g.ValueMember = "catid";

      cbx_categoria.DataSource = cat.ToList();
      cbx_categoria_equipos_inscriptos.DataSource = cat.ToList();
      cbx_categoria_incripcion_jugadores.DataSource = cat.ToList();
      cbx_categoria_jugadores_inscriptos.DataSource = cat.ToList();
      cbx_categoria_partidos.DataSource = cat.ToList();
      cbx_categoria_g.DataSource = cat.ToList();

      // Cargo el combo  cbx_liga
      var liga = from lig in db_sindicato.ligas select lig;
      cbx_liga_inscripcion_equipos.DisplayMember = "liganombre";
      cbx_liga_inscripcion_equipos.ValueMember = "ligaid";

      cbx_liga_partidos.DisplayMember = "liganombre";
      cbx_liga_partidos.ValueMember = "ligaid";

      cbx_liga_inscripcion_equipos.DataSource = liga.ToList();
      cbx_liga_partidos.DataSource = liga.ToList();

      // Cargo el combo  campeonato
      var campeonato = from camp in db_sindicato.campeonatos where camp.CAMPESTADO == 1 select camp;
      cbx_campeonato_inscripcion_equipos.DisplayMember = "campnombre";
      cbx_campeonato_inscripcion_equipos.ValueMember = "campid";

      cbx_campeonato_partidos.DisplayMember = "campnombre";
      cbx_campeonato_partidos.ValueMember = "campid";

      cbx_campeonato_inscripcion_equipos.DataSource = campeonato.ToList();
      cbx_campeonato_partidos.DataSource = campeonato.ToList();

      // Cargo el combo fases
      var fases = from f in db_sindicato.fases select f;

      cbx_fase_partidos.DisplayMember = "fasenombre";
      cbx_fase_partidos.ValueMember = "fase_id";
      cbx_fase_partidos.DataSource = fases.ToList();

      // Cargo cbx canchas

      var cancha = from can in db_sindicato.canchas select can;

      cbx_cancha_partidos.DisplayMember = "canchanombre";
      cbx_cancha_partidos.ValueMember = "canchaid";
      cbx_cancha_partidos.DataSource = cancha.ToList();

      // Cargar cbx_cambio de equipo
      var cbioEquipo = db_sindicato.equipos.OrderBy(x => x.EQUIPONOMBRE);
      cbx_cambio_equipo.DisplayMember = "equiponombre";
      cbx_cambio_equipo.ValueMember = "equipoid";
      cbx_cambio_equipo.DataSource = cbioEquipo.ToList();
    }

    private void btn_ligas_Click(object sender, EventArgs e)
    {
      //bunifuTransition1.ShowSync(picbox_formacion, false, null);
      //picbox_formacion.Visible = true;
    }

    private void btn_cerrar_futbol_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btn_formacion_Click(object sender, EventArgs e)
    {
      tabControl1.SelectedTab = tabPageFormacion;
      //bunifuTransition1.ShowSync(picbox_formacion, false, null);
      picbox_formacion.Visible = true;
      picbox_posiciones.Visible = false;
      pnl_equiposInscriptos.Visible = false;
      pnl_jugadoresInscriptos.Visible = false;
    }

    private void btn_posiciones_Click(object sender, EventArgs e)
    {
      tabControl1.SelectedTab = tabPagePosiciones;
      //bunifuTransition1.ShowSync(picbox_posiciones, false, null);
      pnl_inscripcionEquipos.Visible = false;
      picbox_posiciones.Visible = true;
      picbox_formacion.Visible = false;
      pnl_equiposInscriptos.Visible = false;
      pnl_jugadoresInscriptos.Visible = false;
    }

    private void btn_equipos_Click(object sender, EventArgs e)
    {
      tabControl1.SelectedTab = tabPageEquipos;
      //bunifuTransition1.ShowSync(pnl_inscripcionEquipos, false, null);
      pnl_inscripcionEquipos.Visible = true;
      picbox_posiciones.Visible = false;
      picbox_formacion.Visible = false;
      //transitionHD.ShowSync(pnl_equiposInscriptos, false, null);
      pnl_equiposInscriptos.Visible = true;
      pnl_jugadoresInscriptos.Visible = false;
    }

    private void btn_jugadores_Click(object sender, EventArgs e)
    {
      tabControl1.SelectedTab = tabPageJugadores;
      //bunifuTransition1.ShowSync(pnl_jugadoresInscripcion, false, null);
      pnl_jugadoresInscripcion.Visible = true;
      picbox_posiciones.Visible = false;
      picbox_formacion.Visible = false;
      pnl_equiposInscriptos.Visible = false;
      //transitionHD.ShowSync(pnl_jugadoresInscriptos, false, null);
      pnl_jugadoresInscriptos.Visible = true;
    }

    private void btn_inscribir_equipo_Click(object sender, EventArgs e)
    {
      if (txt_equipo.Text != "")
      {
        try
        {
          equipos varEquipos = new equipos();
          varEquipos.EQUIPONOMBRE = txt_equipo.Text.Trim();
          varEquipos.EQUIPO_CATID = Convert.ToInt32(cbx_categoria.SelectedValue);
          db_sindicato.equipos.InsertOnSubmit(varEquipos);
          db_sindicato.SubmitChanges();


          campequipo campe = new campequipo();
          campe.CAMP_CAMPID = Convert.ToInt32(cbx_campeonato_inscripcion_equipos.SelectedValue);
          campe.CAMP_EQUIPOID = db_sindicato.equipos.Max(x => x.EQUIPOID);
          db_sindicato.campequipo.InsertOnSubmit(campe);
          db_sindicato.SubmitChanges();


          MessageBox.Show("El equipo " + txt_equipo.Text.Trim() + " fue cargado exitosamente.");
          txt_equipo.Text = "";
          listar_equipos_inscriptos();
        }
        catch (Exception ex)
        {
          MessageBox.Show("Error" + ex.ToString());
          throw;
        }
      }
    }

    private void listar_equipos_inscriptos()
    {
      var equipos_inscriptos = (from equipo in db_sindicato.equipos.Where(x => x.EQUIPO_CATID == Convert.ToInt32(cbx_categoria_equipos_inscriptos.SelectedValue)

                                )
                                select equipo).OrderBy(x => x.EQUIPONOMBRE);
      dgv_equiposInscriptos.DataSource = equipos_inscriptos.ToList();
      if (equipos_inscriptos.Count() > 0) lbl_total_equipos_inscriptos.Text = "Total inscriptos: " + equipos_inscriptos.Count().ToString();
      if (equipos_inscriptos.Count() == 0) lbl_total_equipos_inscriptos.Text = "Total inscriptos: 0";
    }

    private void cbx_categoria_equipos_inscriptos_SelectedIndexChanged(object sender, EventArgs e)
    {
      listar_equipos_inscriptos();
    }

    private void txt_dni_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        if (txt_dni.Text.Length > 8)
        {
          txt_dni.Text = txt_dni.Text.Substring(2, 8);
          //text = text.Substring(2, 8);
          buscar_socio();
        }
        else
        {
          if (txt_dni.Text.Length == 8) buscar_socio();
          if (txt_dni.Text.Length < 8) MessageBox.Show("La cantidad de digitos no es la correcta. Deben ser 8 digitos", "ATENCON");
        }
      }
    }

    private void buscar_socio()
    {


      var no_existe = from soc in db_sindicato.maesoc
                      where soc.MAESOC_NRODOC == txt_dni.Text
                      select soc;

      if (no_existe.Count() > 0) // si es mayor que cero entonces existe luego hay que ver si es socio. Si es menor que cero entonces NO EXISTE
      {
        // si existe
        futbol ftbl = new futbol();
        convertir_imagen img = new convertir_imagen();

        Image imagen = img.ByteArrayToImage(ftbl.get_Foto(no_existe.First().MAESOC_CUIL).ToArray());
        picbox_inscripcion_jugadores.Image = imagen;

        //picbox_inscripcion_jugadores.Image = img.ByteArrayToImage(ftbl.get_Foto(no_existe.First().MAESOC_CUIL).ToArray());

        //mostrar_foto(no_existe.First().MAESOC_CUIL,1);
        mostrar_datos_socio(no_existe.First().MAESOC_CUIL);
        //voy a preguntar si es socio 
        var socio = from soc in db_sindicato.maesoc
                    where soc.MAESOC_NRODOC == txt_dni.Text
                    join soce in db_sindicato.soccen on soc.MAESOC_CUIL equals soce.SOCCEN_CUIL
                    where soce.SOCCEN_ESTADO == 1
                    select soc;
        if (socio.Count() > 0) // si es > 0 entonces es socio
        {
          if (socio.Single().MAESOC_NROAFIL.Trim() == "") // si el nro de afiliado es null o espacio en blanco entonces es socio pasivo
          {
            txt_nroSocio.Text = "0";
          }
          else
          {
            txt_nroSocio.Text = socio.Single().MAESOC_NROAFIL.ToString();
          }
          if (txt_nroSocio.Text == "0")// si nro de afiliafo  es null o espacio en blanco entonces es socio pasivo
          {
            txt_estado.Text = " SOCIO PASIVO (''No posee Nº de Afiliado'')";
            //btn_inscribirJugador.Enabled = false;
            btn_activar.Enabled = false;
            txt_nroSocio.Text = "";
          }
          else
          {
            txt_estado.Text = "SOCIO ACTIVO";
            //btn_inscribirJugador.Enabled = true;
            btn_activar.Enabled = false;
            socio.Single().MAESOC_NROAFIL.ToString().Trim();
          }
        }
        else
        {
          txt_estado.Text = "NO ES SOCIO";
          //btn_inscribirJugador.Enabled = false;
          btn_activar.Enabled = true;

        }
      }
      else
      {
        txt_estado.Text = "NO EXISTE";
        picbox_inscripcion_jugadores.Image = Properties.Resources.contorno_usuario;
        limpiar_controles();
        //btn_inscribirJugador.Enabled = true;
      }
    }

    private void mostrar_foto(double cuil, int inscripcion) // inscripcion = 1 muestro foto para picbox_inscripcion
    {
      var foto = db_sindicato.fotos.Where(x => x.FOTOS_CUIL == cuil && x.FOTOS_CODFLIAR == 0); ///Convert.ToDouble(dgv_reservados.CurrentRow.Cells[6].Value.ToString()
      if (foto.Count() > 0)
      {
        if (inscripcion == 1) picbox_inscripcion_jugadores.Image = ByteArrayToImage(foto.Single().FOTOS_FOTO.ToArray());
        if (inscripcion == 2) picbox_jugadores_inscriptos.Image = ByteArrayToImage(foto.Single().FOTOS_FOTO.ToArray());

      }
      else
      {
        if (inscripcion == 1) picbox_inscripcion_jugadores.Image = Properties.Resources.contorno_usuario;
        if (inscripcion == 2) picbox_jugadores_inscriptos.Image = Properties.Resources.contorno_usuario;

      }
    }

    private void mostrar_datos_socio(double cuil)
    {
      var datos_socios = (from ds in db_sindicato.maesoc where ds.MAESOC_CUIL == cuil select ds).Single();

      txt_nroSocio.Text = datos_socios.MAESOC_NROAFIL.Trim();
      txt_CUIL.Text = datos_socios.MAESOC_CUIL.ToString();
      txt_apellido.Text = datos_socios.MAESOC_APELLIDO.Trim();
      txt_nombre.Text = datos_socios.MAESOC_NOMBRE.Trim();

      String domicilio = "", calle = "", nrocalle = "", barrio = "";
      if (datos_socios.MAESOC_CALLE != null) calle = datos_socios.MAESOC_CALLE.Trim();
      if (datos_socios.MAESOC_NROCALLE != null) nrocalle = datos_socios.MAESOC_NROCALLE.Trim();
      if (datos_socios.MAESOC_BARRIO != null) barrio = datos_socios.MAESOC_BARRIO.Trim();
      domicilio = calle + " " + nrocalle + " " + barrio;

      txt_domicilio.Text = domicilio; //datos_socios.MAESOC_CALLE.Trim() + " " + datos_socios.MAESOC_NROCALLE.Trim() + " " + datos_socios.MAESOC_BARRIO.Trim();
      txt_fechaNac.Text = Convert.ToString(datos_socios.MAESOC_FECHANAC.Date);
      txt_edad.Text = calcular_edad(datos_socios.MAESOC_FECHANAC).ToString();
      var empr = db_sindicato.maeemp.Where(t => t.MAEEMP_CUIT == db_sindicato.socemp.Where(x => x.SOCEMP_CUIL == cuil && x.SOCEMP_ULT_EMPRESA == 'S').Single().SOCEMP_CUITE);//.Single().razons.ToString();
      if (empr.Count() > 0)
      {
        txt_empresa.Text = empr.Single().MAEEMP_RAZSOC;//db_sindicato.empresas.Where(t => t.cuit == db_sindicato.socemp.Where(x => x.SOCEMP_CUIL == cuil && x.SOCEMP_ULT_EMPRESA == 'S').Single().SOCEMP_CUITE).Single().razons.ToString();
      }
      else
      {
        txt_empresa.Text = "SIN EMPRESA";
      }
      futbol ftbl = new futbol();
      string inscripto_en = ftbl.get_ya_inscripto(Convert.ToDouble(txt_CUIL.Text));
      txt_equipo_.Text = inscripto_en;
      if (inscripto_en != "" || inscripto_en == null)
      {
        btn_inscribirJugador.Enabled = false;
      }
      else
      {
        btn_inscribirJugador.Enabled = true;
      }
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

    public Image ByteArrayToImage(byte[] byteArrayIn)
    {
      using (System.IO.MemoryStream ms = new MemoryStream(byteArrayIn))
      {
        Image returnImage = Image.FromStream(ms);
        return returnImage;
      }
    }

    private void limpiar_controles()
    {
      txt_CUIL.Text = "";
      txt_nroSocio.Text = "";
      txt_apellido.Text = "";
      txt_nombre.Text = "";
      txt_domicilio.Text = "";
      txt_fechaNac.Text = "";
      txt_edad.Text = "";
      txt_empresa.Text = "";
      txt_edad.Text = "";
      txt_empresa.Text = "";
      txt_equipo_.Text = "";
    }

    private void cbx_categoria_incripcion_jugadores_SelectedIndexChanged(object sender, EventArgs e)
    {
      var var_equipos1 = (from equi1 in db_sindicato.equipos
                          where equi1.EQUIPO_CATID == Convert.ToInt32(cbx_categoria_incripcion_jugadores.SelectedValue)
                          select equi1).OrderBy(x => x.EQUIPONOMBRE);

      cbx_equipo_incripcion_jugadores.DisplayMember = "equiponombre";
      cbx_equipo_incripcion_jugadores.ValueMember = "equipoid";
      cbx_equipo_incripcion_jugadores.DataSource = var_equipos1.ToList();

    }

    private void cbx_categoria_jugadores_inscriptos_SelectedIndexChanged(object sender, EventArgs e)
    {
      futbol ftbl = new futbol();

      cbx_equipo_jugadores_inscriptos.DisplayMember = "equiponombre";
      cbx_equipo_jugadores_inscriptos.ValueMember = "equipoid";
      cbx_equipo_jugadores_inscriptos.DataSource = ftbl.get_equipos_por_categoria(Convert.ToInt32(cbx_categoria_jugadores_inscriptos.SelectedValue));


    }

    private equipos mostrar_equipos_por_categoria(int categoriaID)
    {
      var var_equipos1 = (from equi1 in db_sindicato.equipos
                          where equi1.EQUIPO_CATID == categoriaID //Convert.ToInt32(cbx_categoria_jugadores_inscriptos.SelectedValue)
                          select equi1).OrderBy(x => x.EQUIPONOMBRE);
      return (equipos)var_equipos1;
    }

    private void txt_nroSocio_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        if (txt_nroSocio.Text != "")
        {
          var cuil = from cl in db_sindicato.maesoc.Where(x => x.MAESOC_NROAFIL == txt_nroSocio.Text) select cl;
          if (cuil.Count() > 0)
          {
            txt_dni.Text = cuil.Single().MAESOC_NRODOC;
            buscar_socio();
          }
          else
          {
            limpiar_controles();
            txt_dni.Text = "";
            txt_estado.Text = "NO EXISTE";
            //btn_inscribirJugador.Enabled = false;
            mostrar_foto(1, 1);
          }
        }
        else
        {
          limpiar_controles();
          txt_dni.Text = "";
          txt_estado.Text = "NO EXISTE";
          //btn_inscribirJugador.Enabled = false;
          mostrar_foto(1, 1);
        }
      }
    }

    private void btn_inscribirJugador_Click(object sender, EventArgs e)
    {
      inscribir_jugador();


    }

    private void inscribir_jugador()
    {
      futbol ftbl = new futbol();
      ftbl.insertar_jugador(
          Convert.ToInt32(cbx_equipo_incripcion_jugadores.SelectedValue),
          txt_nroSocio.Text.Trim(),
          Convert.ToDouble(txt_CUIL.Text.Trim()),
          txt_nombre.Text.ToUpper().Trim(),
          txt_apellido.Text.ToUpper().Trim(),
          1
          );

      mostrar_jugadores_inscriptos();
    }

    private void mostrar_jugadores_inscriptos()
    {
      var jugador_inscripto = (from ji in db_sindicato.jugadores
                               where ji.JUG_EQUIPOID == Convert.ToInt32(cbx_equipo_jugadores_inscriptos.SelectedValue)
                               //join msc in db_sindicato.maesoc on ji.JUG_SOCCENCUIL equals msc.MAESOC_CUIL
                               select new
                               {
                                 jugid = ji.JUGID,
                                 jugnrosocio = ji.JUG_MAESOC_NROAFIL,
                                 jugapenom = ji.JUG_APELLIDO + " " + ji.JUG_NOMBRE,
                                 jugcuil = ji.JUG_SOCCENCUIL
                               }).OrderBy(x => x.jugapenom);
      dgv_jugadores_inscriptos.DataSource = jugador_inscripto.ToList();
      txt_total_jugadores.Text = jugador_inscripto.Count().ToString();
    }

    private void cbx_equipo_jugadores_inscriptos_SelectedIndexChanged(object sender, EventArgs e)
    {
      mostrar_jugadores_inscriptos();
    }

    private void dgv_jugadores_inscriptos_SelectionChanged(object sender, EventArgs e)
    {
      convertir_imagen img = new convertir_imagen();
      futbol ftbl = new futbol();

      double cuil = Convert.ToDouble(dgv_jugadores_inscriptos.CurrentRow.Cells["jugcuil"].Value);
      picbox_jugadores_inscriptos.Image = img.ByteArrayToImage(ftbl.get_Foto(cuil).ToArray());

      //mostrar_foto(Convert.ToDouble(dgv_jugadores_inscriptos.CurrentRow.Cells[3].Value), 2);

      mostrar_sanciones();
    }

    private void mostrar_sanciones()
    {

      func_util.limpiar_dgv(dgv_sanciones_aplicadas);

      //while (dgv_sanciones_aplicadas.Rows.Count != 0)
      //{
      //    dgv_sanciones_aplicadas.Rows.RemoveAt(0);
      //}

      futbol ftbl = new futbol();

      int fila = 0;
      int idJugador = Convert.ToInt32(dgv_jugadores_inscriptos.CurrentRow.Cells["jugid"].Value);

      foreach (var item in ftbl.get_lista_sanciones(idJugador))
      {
        dgv_sanciones_aplicadas.Rows.Add();
        fila = dgv_sanciones_aplicadas.Rows.Count - 1;
        //dgv_sanciones_aplicadas.Rows[fila].Cells["jugador"].Value = item.;
        dgv_sanciones_aplicadas.Rows[fila].Cells["nro_fecha"].Value = item.fecha;
        dgv_sanciones_aplicadas.Rows[fila].Cells["de"].Value = item.de;
        dgv_sanciones_aplicadas.Rows[fila].Cells["cant_fechas"].Value = item.total_fechas;
        dgv_sanciones_aplicadas.Rows[fila].Cells["fecha_partido"].Value = item.cumplio;
      }
    }

    private void btn_partidos_Click(object sender, EventArgs e)
    {
      tabControl1.SelectedTab = tabPagePartidos;
      // bunifuTransition1.ShowSync(pnl_inscripcionEquipos, false, null);

      pnl_inscripcionEquipos.Visible = false;
      picbox_posiciones.Visible = false;
      picbox_formacion.Visible = false;
      //transitionHD.ShowSync(pnl_equiposInscriptos, false, null);
      pnl_equiposInscriptos.Visible = true;
      pnl_jugadoresInscriptos.Visible = false;
    }

    private void cbx_liga_inscripcion_equipos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void cbx_categoria_partidos_SelectedIndexChanged(object sender, EventArgs e)
    {
      var equi1 = (from e1 in db_sindicato.equipos
                   where e1.EQUIPO_CATID == Convert.ToInt32(cbx_categoria_partidos.SelectedValue)
                   select e1).OrderBy(x => x.EQUIPONOMBRE);

      cbx_equipo1_partidos.DisplayMember = "equiponombre";
      cbx_equipo1_partidos.ValueMember = "equipoid";
      cbx_equipo1_partidos.DataSource = equi1.ToList();
    }

    private void cbx_equipo1_partidos_SelectedIndexChanged(object sender, EventArgs e)
    {


      var equi2 = (from e2 in db_sindicato.equipos
                   where e2.EQUIPO_CATID == (Convert.ToInt32(cbx_categoria_partidos.SelectedValue)) && (e2.EQUIPOID != Convert.ToInt32(cbx_equipo1_partidos.SelectedValue))
                   select e2).OrderBy(x => x.EQUIPONOMBRE);

      cbx_equipo2_partidos.DisplayMember = "equiponombre";
      cbx_equipo2_partidos.ValueMember = "equipoid";
      cbx_equipo2_partidos.DataSource = equi2.ToList();
    }

    private void btn_guardar_partido_Click(object sender, EventArgs e)
    {

    }

    private void GuardarPartido()
    {
      bool repetido = false;

      foreach (DataGridViewRow fila in dgv_partidos_cancha1.Rows)
      {
        if ((Convert.ToInt32(fila.Cells["IdEquipo1"].Value) == Convert.ToInt32(cbx_equipo1_partidos.SelectedValue))
          ||
          (Convert.ToInt32(fila.Cells["IdEquipo2"].Value) == Convert.ToInt32(cbx_equipo2_partidos.SelectedValue)))
        {
          repetido = true;

        }
      }

      if (!repetido)
      {

        partidos part = new partidos();
        part.PARTIDO_LIGAID = Convert.ToInt32(cbx_liga_partidos.SelectedValue);
        part.PARTIDO_CAMPID = Convert.ToInt32(cbx_campeonato_partidos.SelectedValue);
        part.PARTIDO_FASEID = Convert.ToInt32(cbx_fase_partidos.SelectedValue);
        part.PARTIDOFECHA = dtp_fecha_partidos.Value;
        part.PARTIDO_CANCHAID = Convert.ToInt32(cbx_cancha_partidos.SelectedValue);
        part.PARTIDO_CATID = Convert.ToInt32(cbx_categoria_partidos.SelectedValue);
        part.PARTIDOEQUIPO1 = Convert.ToInt32(cbx_equipo1_partidos.SelectedValue);
        part.PARTIDOEQUIPO2 = Convert.ToInt32(cbx_equipo2_partidos.SelectedValue);
        part.PARTIDOHORA = dtp_horario_partidos.Value.TimeOfDay;
        part.PARTIDONROFECHA = Convert.ToInt32(cbx_nrofecha.SelectedItem);
        db_sindicato.partidos.InsertOnSubmit(part);
        db_sindicato.SubmitChanges();
        mostrar_partidos();
        dtp_horario_partidos.Focus();
      }
      else
      {
        MessageBox.Show("El equipo ya esta Inscripto en un Partido", "¡¡¡¡ ATENCION !!!!");
      }
    }

    private void mostrar_partidos()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var partidos_cancha_1 = (from partido in context.partidos
                                 where partido.PARTIDOFECHA == dtp_fecha_partidos.Value
                                 select new
                                 {
                                   IdCancha = partido.PARTIDO_CANCHAID,
                                   hora = partido.PARTIDOHORA,
                                   equipo1 = context.equipos.Where(x => x.EQUIPOID == partido.PARTIDOEQUIPO1).Single().EQUIPONOMBRE,
                                   vs = "VS",
                                   equipo2 = context.equipos.Where(x => x.EQUIPOID == partido.PARTIDOEQUIPO2).Single().EQUIPONOMBRE,
                                   categoria = context.categorias.Where(x => x.CATID == partido.PARTIDO_CATID).Single().CATNOMBRE,
                                   partidoid = partido.PARTIDOID,
                                   IdEquipo1 = partido.PARTIDOEQUIPO1,
                                   IdEquipo2 = partido.PARTIDOEQUIPO2
                                 }).OrderBy(x => x.IdCancha).ThenBy(x => x.hora);
        dgv_partidos_cancha1.DataSource = partidos_cancha_1;
      }
    }

    private void dtp_fecha_partidos_ValueChanged(object sender, EventArgs e)
    {
      mostrar_partidos();
    }

    private void ImprimirPartidos()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        List<MdlPartidoCanchaJug> col1y2 = new List<MdlPartidoCanchaJug>();

        DataTable dt_imprPartido = ds_cpns.partidos;
        dt_imprPartido.Clear();

        futbol ftbl = new futbol();
        convertir_imagen cnv_img = new convertir_imagen();

        var Campeonato = context.campeonatos.Where(x => x.CAMPESTADO == 1).FirstOrDefault();

        var sanciones = from a in context.sanciones.Where(x => x.ID_PARTIDO == 0) select a;

        foreach (var equipo in MtdFutbol.GetPartidos(Imprimir_Partido_Actual, Convert.ToInt32(dgv_partidos_cancha1.CurrentRow.Cells["idPartido"].Value), dtp_fecha_partidos.Value).OrderBy(x => x.col1Nombre).GroupBy(x => x.equipo))
        {
          int i = 0;
          col1y2.Clear(); ;
          col1y2.AddRange(equipo);
          foreach (var item in equipo.ToList())
          {
            int ContCol2 = equipo.Count() - 11; //- (equipo.Count() / 2);

            if (i < 11)
            //if (i < ContCol2)
            {
              DataRow Row = dt_imprPartido.NewRow();
              Row["equipo"] = item.equipo;
              Row["fecha"] = item.fecha;
              Row["hora"] = item.hora;
              Row["fase"] = item.fase;
              Row["categoria"] = item.categoria;
              Row["cancha"] = item.cancha;//+ " - CUARTOS DE FINAL - PARTIDO IDA";
              Row["partidoID"] = item.partidoID;
              Row["col1NroSocio"] = item.col1NroSocio;
              Row["col1Nombre"] = item.col1Nombre;
              Row["col1DNI"] = item.col1DNI;
              Row["col1Foto"] = cnv_img.ImageToByteArray(item.col1Foto);    ///item.col1Foto.ToArray();
              Row["nroFecha"] = item.nroFecha;
              Row["sancion_x_de"] = item.sancion_x_de;
              Row["sancion_cantidad"] = item.sancion_cantidad;
              Row["orden_fixture"] = item.orden_fixture;
              Row["nom_campeonato"] = item.nom_campeonato;
              Row["Año"] = item.año;
              Row["columna"] = item.columna;
              if (i < ContCol2)
              {
                Row["col2NroSocio"] = col1y2[i + 11].col1NroSocio;
                Row["col2Nombre"] = col1y2[i + 11].col1Nombre;
                Row["col2DNI"] = col1y2[i + 11].col1DNI;
                Row["col2Foto"] = cnv_img.ImageToByteArray(col1y2[i + 11].col1Foto);
                Row["col2Sancion_x_de"] = col1y2[i + 11].sancion_x_de;
                Row["col2Sancion_cantidad"] = col1y2[i + 11].sancion_cantidad;
              }
              dt_imprPartido.Rows.Add(Row);
            }
            else
            {
              i = equipo.Count();
            }
            i++;
          }
        }

        DS_cupones ds = new DS_cupones();
        DataTable dt = ds.Logos; //Jugadores;
        DataRow row = dt.NewRow();

        row["Logo_Futbol"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_futbol.jpg"));
        row["Logo_Reporte"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg"));
        dt.Rows.Add(row);

        reportes frm_reportes = new reportes();
        frm_reportes.nombreReporte = "rpt_partidos_5";
        frm_reportes.dt = dt_imprPartido;
        frm_reportes.dt2 = dt;
        frm_reportes.Show();
      }
    }


    private void btn_imprmir_equipos_Click(object sender, EventArgs e)
    {

      db_sindicato.ExecuteCommand("truncate table impresion_comprobante");

    
      using (var context = new lts_sindicatoDataContext())
      {
        int orden = 0;
        foreach (DataGridViewRow fila in dgv_equiposInscriptos.Rows)
        {
          impresion_comprobante insert = new impresion_comprobante();
          insert.CATEGORIA = cbx_categoria_equipos_inscriptos.Text;
          insert.PARTIDOID = Convert.ToString(orden = orden + 1);
          insert.EQUIPO = fila.Cells["nombreEquipo"].Value.ToString();
          context.impresion_comprobante.InsertOnSubmit(insert);
          context.SubmitChanges();
        }
      }

      reportes f_report = new reportes();
      //f_report.nombreReporte = "rpt_equipos";
      f_report.NombreDelReporte = "entrega_cupones.Reportes.rpt_equipos.rdlc";
      f_report.Show();
    }

    private void imprimir_partidos5()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        List<MdlPartidoCanchaJug> pcj = new List<MdlPartidoCanchaJug>();
        List<MdlPartidoCanchaJug> pcj1 = new List<MdlPartidoCanchaJug>();
        List<MdlPartidoCanchaJug> pcj2 = new List<MdlPartidoCanchaJug>();
        List<MdlPartidoCanchaJug> col1y2 = new List<MdlPartidoCanchaJug>();

        DataTable dt_imprPartido = ds_cpns.partidos;
        dt_imprPartido.Clear();

        futbol ftbl = new futbol();
        convertir_imagen cnv_img = new convertir_imagen();

        var Campeonato = context.campeonatos.Where(x => x.CAMPESTADO == 1).FirstOrDefault();

        var sanciones = from a in context.sanciones.Where(x => x.ID_PARTIDO == 0) select a;

        var partidosCancha1 = from jug in context.jugadores
                              join eqps in context.equipos on jug.JUG_EQUIPOID equals eqps.EQUIPOID
                              join cat in context.categorias on eqps.EQUIPO_CATID equals cat.CATID
                              join prt in context.partidos on jug.JUG_EQUIPOID equals prt.PARTIDOEQUIPO1
                              join cnch in context.canchas on prt.PARTIDO_CANCHAID equals cnch.CANCHAID
                              where prt.PARTIDOFECHA == dtp_fecha_partidos.Value
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
                              where prt.PARTIDOFECHA == dtp_fecha_partidos.Value
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

        pcj.AddRange(pcj1.Union(pcj2)); //.OrderBy(x => x.cancha).ThenBy(x => x.hora).ThenBy(x => x.equipo).ThenBy(x => x.col1Nombre);

        foreach (var equipo in pcj.OrderBy(x => x.col1Nombre).GroupBy(x => x.equipo))
        {
          int i = 0;
          col1y2.Clear(); ;
          col1y2.AddRange(equipo);
          foreach (var item in equipo.ToList())
          {
            int ContCol2 = equipo.Count() - 10;

            if (i < 10)
            {
              DataRow Row = dt_imprPartido.NewRow();
              Row["equipo"] = item.equipo;
              Row["fecha"] = item.fecha;
              Row["hora"] = item.hora;
              Row["fase"] = item.fase;
              Row["categoria"] = item.categoria;
              Row["cancha"] = item.cancha;//+ " - CUARTOS DE FINAL - PARTIDO IDA";
              Row["partidoID"] = item.partidoID;
              Row["col1NroSocio"] = item.col1NroSocio;
              Row["col1Nombre"] = item.col1Nombre;
              Row["col1DNI"] = item.col1DNI;
              Row["col1Foto"] = cnv_img.ImageToByteArray(item.col1Foto);    ///item.col1Foto.ToArray();
              Row["nroFecha"] = item.nroFecha;
              Row["sancion_x_de"] = item.sancion_x_de;
              Row["sancion_cantidad"] = item.sancion_cantidad;
              Row["orden_fixture"] = item.orden_fixture;
              Row["nom_campeonato"] = item.nom_campeonato;
              Row["Año"] = item.año;
              Row["columna"] = item.columna;
              if (i < ContCol2)
              {
                Row["col2NroSocio"] = col1y2[i + 10].col1NroSocio;
                Row["col2Nombre"] = col1y2[i + 10].col1Nombre;
                Row["col2DNI"] = col1y2[i + 10].col1DNI;
                Row["col2Foto"] = cnv_img.ImageToByteArray(col1y2[i + 10].col1Foto);
              }
              dt_imprPartido.Rows.Add(Row);
            }
            else
            {
              i = equipo.Count();
            }
            i++;
          }
        }

        DS_cupones ds = new DS_cupones();
        DataTable dt = ds.Logos; //Jugadores;
        DataRow row = dt.NewRow();

        row["Logo_Futbol"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_futbol.jpg"));
        row["Logo_Reporte"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg"));
        dt.Rows.Add(row);

        reportes frm_reportes = new reportes();
        frm_reportes.nombreReporte = "rpt_partidos_5";
        frm_reportes.dt = dt_imprPartido;
        frm_reportes.dt2 = dt;
        frm_reportes.Show();
      }
    }


    private void imprimir_partidos4()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        DataTable dt_imprPartido = ds_cpns.partidos;
        dt_imprPartido.Clear();

        futbol ftbl = new futbol();
        convertir_imagen cnv_img = new convertir_imagen();

        var Campeonato = context.campeonatos.Where(x => x.CAMPESTADO == 1).FirstOrDefault();

        var sanciones = from a in context.sanciones.Where(x => x.ID_PARTIDO == 0) select a;

        var partidosCancha1 = from jug in context.jugadores
                              join eqps in context.equipos on jug.JUG_EQUIPOID equals eqps.EQUIPOID
                              join cat in context.categorias on eqps.EQUIPO_CATID equals cat.CATID
                              join prt in context.partidos on jug.JUG_EQUIPOID equals prt.PARTIDOEQUIPO1
                              join cnch in context.canchas on prt.PARTIDO_CANCHAID equals cnch.CANCHAID
                              where prt.PARTIDOFECHA == dtp_fecha_partidos.Value
                              select new
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
                                nroFecha = prt.PARTIDONROFECHA,
                                sancion_x_de = ftbl.get_nro_fecha_sancion(jug.JUGID), //sanciones.Where(x=>x.ID_JUG == jug.JUGID).Count() > 0 ? sanciones.Where(x => x.ID_JUG == jug.JUGID).Min(x=>x.NRO_FECHA) : 0,
                                sancion_cantidad = ftbl.get_cantidad_fecha_sancion(jug.JUGID), //sanciones.Where(x => x.ID_JUG == jug.JUGID).Count() > 0 ? sanciones.Where(x => x.ID_JUG == jug.JUGID).First().CANTIDAD_FECHAS : 0,
                                orden_fixture = 1,
                                nom_campeonato = Campeonato.CAMPNOMBRE,
                                año = Campeonato.CAMPAÑO
                              };

        var partidosCancha2 = from jug in context.jugadores
                              join eqps in context.equipos on jug.JUG_EQUIPOID equals eqps.EQUIPOID
                              join cat in context.categorias on eqps.EQUIPO_CATID equals cat.CATID
                              join prt in context.partidos on jug.JUG_EQUIPOID equals prt.PARTIDOEQUIPO2
                              join cnch in context.canchas on prt.PARTIDO_CANCHAID equals cnch.CANCHAID
                              where prt.PARTIDOFECHA == dtp_fecha_partidos.Value
                              select new
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
                                nroFecha = prt.PARTIDONROFECHA,
                                sancion_x_de = ftbl.get_nro_fecha_sancion(jug.JUGID),//sanciones.Where(x => x.ID_JUG == jug.JUGID).Count() > 0 ? sanciones.Where(x => x.ID_JUG == jug.JUGID).Min(x => x.NRO_FECHA) : 0,
                                sancion_cantidad = ftbl.get_cantidad_fecha_sancion(jug.JUGID),//sanciones.Where(x => x.ID_JUG == jug.JUGID).Count() > 0 ? sanciones.Where(x => x.ID_JUG == jug.JUGID).First().CANTIDAD_FECHAS : 0,
                                orden_fixture = 2,
                                nom_campeonato = Campeonato.CAMPNOMBRE,
                                año = Campeonato.CAMPAÑO
                              };
        var partidos = partidosCancha1.Union(partidosCancha2); //.OrderBy(x => x.cancha).ThenBy(x => x.hora).ThenBy(x => x.equipo).ThenBy(x => x.col1Nombre);

        foreach (var item in partidos)
        {
          DataRow Row = dt_imprPartido.NewRow();

          Row["equipo"] = item.equipo;
          Row["fecha"] = item.fecha;
          Row["hora"] = item.hora;
          Row["fase"] = item.fase;
          Row["categoria"] = item.categoria;
          Row["cancha"] = item.cancha;//+ " - CUARTOS DE FINAL - PARTIDO IDA";
          Row["partidoID"] = item.partidoID;
          Row["col1NroSocio"] = item.col1NroSocio;
          Row["col1Nombre"] = item.col1Nombre;
          Row["col1DNI"] = item.col1DNI;
          Row["col1Foto"] = cnv_img.ImageToByteArray(item.col1Foto);    ///item.col1Foto.ToArray();
          Row["nroFecha"] = item.nroFecha;
          Row["sancion_x_de"] = item.sancion_x_de;
          Row["sancion_cantidad"] = item.sancion_cantidad;
          Row["orden_fixture"] = item.orden_fixture;
          Row["nom_campeonato"] = item.nom_campeonato;
          Row["Año"] = item.año;

          dt_imprPartido.Rows.Add(Row);
        }

        DS_cupones ds = new DS_cupones();
        DataTable dt = ds.Logos; //Jugadores;
        DataRow row = dt.NewRow();

        row["Logo_Futbol"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_futbol.jpg"));
        row["Logo_Reporte"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg"));
        dt.Rows.Add(row);

        reportes frm_reportes = new reportes();
        frm_reportes.nombreReporte = "rpt_partidos_5";
        frm_reportes.dt = dt_imprPartido;
        frm_reportes.dt2 = dt;
        frm_reportes.Show();
      }
    }


    private void imprimir_partidos3()
    {
      using (var context = new lts_sindicatoDataContext())
      {

        context.ExecuteCommand("truncate table impresion_comprobante");
        DataTable dt_imprPartido = ds_cpns.partidos;
        dt_imprPartido.Clear();

        futbol ftbl = new futbol();
        convertir_imagen cnv_img = new convertir_imagen();

        //var result = from x in entity1
        //             join y in entity2
        //             on new { X1 = x.field1, X2 = x.field2 } equals new { X1 = y.field1, X2 = y.field2 }

        var prtds = (from prt in context.partidos
                     join jug in context.jugadores
                     on prt.PARTIDOEQUIPO1 equals jug.JUG_EQUIPOID
                     join jug2 in context.jugadores
                     on prt.PARTIDOEQUIPO2 equals jug2.JUG_EQUIPOID
                     join equi in context.equipos on prt.PARTIDOEQUIPO1 equals equi.EQUIPOID
                     join equi2 in context.equipos on prt.PARTIDOEQUIPO2 equals equi2.EQUIPOID
                     where prt.PARTIDOFECHA == dtp_fecha_partidos.Value
                     // on new { eq1 = prt.PARTIDOEQUIPO1, eq2 = prt.PARTIDOEQUIPO2 }
                     // equals 
                     // new { eq1 = jug.JUG_EQUIPOID, eq2 = jug.JUG_EQUIPOID }
                     //where prt.PARTIDOFECHA == dtp_fecha_partidos.Value
                     //select new { partidos = prt, jugadores = grupoeq1}).ToList();

                     select new
                     {
                       cancha = prt.PARTIDO_CANCHAID,
                       hora = prt.PARTIDOHORA,
                       partido = prt.PARTIDOID,
                       equipo1 = prt.PARTIDOEQUIPO1,
                       eq1Nombre = equi.EQUIPONOMBRE,
                       jugeq1 = jug.JUG_APELLIDO + " " + jug.JUG_NOMBRE,
                       equipo2 = prt.PARTIDOEQUIPO2,
                       eq2Nombre = equi2.EQUIPONOMBRE,
                       jugeq2 = jug2.JUG_APELLIDO + " " + jug2.JUG_NOMBRE,
                       // jugeq2 = jug.JUG_APELLIDO & " " & jug.JUG_NOMBRE,

                     }).OrderBy(x => x.cancha).ThenBy(x => x.hora).ThenBy(x => x.jugeq1);
        //dgv1.DataSource = prtds;
      }



    }

    private void imprimir_partidos2()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        context.ExecuteCommand("truncate table impresion_comprobante");
        DataTable dt_imprPartido = ds_cpns.partidos;
        dt_imprPartido.Clear();

        futbol ftbl = new futbol();
        convertir_imagen cnv_img = new convertir_imagen();
        var partidos_cancha_1 = (from pc1 in context.partidos
                                 where pc1.PARTIDOFECHA == dtp_fecha_partidos.Value
                                 select new
                                 {
                                   //campeonato = pc1.PARTIDO_CAMPID,
                                   fecha = pc1.PARTIDOFECHA,
                                   nrofecha = pc1.PARTIDONROFECHA,
                                   hora = pc1.PARTIDOHORA,
                                   fase = pc1.PARTIDO_FASEID,
                                   equipo1_id = pc1.PARTIDOEQUIPO1,
                                   equipo1 = ftbl.get_equipo_nombre(pc1.PARTIDOEQUIPO1),
                                   vs = "VS",
                                   equipo2_id = pc1.PARTIDOEQUIPO2,
                                   equipo2 = ftbl.get_equipo_nombre(pc1.PARTIDOEQUIPO2),
                                   categoria = ftbl.get_equipo_categoria(pc1.PARTIDO_CATID),
                                   partidoid = pc1.PARTIDOID,
                                   cancha = pc1.PARTIDO_CANCHAID
                                 }).OrderBy(x => x.cancha).ThenBy(x => x.hora);

        foreach (var item in partidos_cancha_1.ToList())
        {
          var jugequipo1 = from a in context.jugadores
                           where a.JUG_EQUIPOID == Convert.ToInt32(item.equipo1_id)
                           select new
                           {
                             equipo = item.equipo1,
                             categoria = item.categoria,
                             cancha = item.cancha,
                             dia = item.fecha,
                             nrofecha = item.nrofecha,
                             hora = item.hora,
                             fase = item.fase,
                             nombre = a.JUG_APELLIDO + " " + a.JUG_NOMBRE,
                             nrosocio = a.JUG_MAESOC_NROAFIL,
                             cuil = a.JUG_SOCCENCUIL,
                             estado = a.JUG_ESTADO,
                             foto = a.JUG_FOTO,
                             partidoid = item.partidoid,
                             jug_id = a.JUGID

                           };
          foreach (var itemE1 in jugequipo1.ToList())
          {



            DataRow Row = dt_imprPartido.NewRow();

            Row["equipo"] = itemE1.equipo;
            Row["fecha"] = itemE1.dia;
            Row["hora"] = itemE1.hora;
            Row["fase"] = itemE1.fase;
            Row["categoria"] = itemE1.categoria;
            Row["cancha"] = itemE1.cancha;
            Row["partidoID"] = itemE1.partidoid;
            Row["col1NroSocio"] = itemE1.nrosocio;
            Row["col1Nombre"] = itemE1.nombre;
            Row["col1DNI"] = itemE1.cuil;
            Row["col1Foto"] = itemE1.foto.ToArray();
            Row["nroFecha"] = itemE1.nrofecha;
            Row["sancion_x_de"] = ftbl.get_nro_fecha_sancion(itemE1.jug_id).ToString();
            Row["sancion_cantidad"] = ftbl.get_cantidad_fecha_sancion(itemE1.jug_id).ToString();

            dt_imprPartido.Rows.Add(Row);

          }

          var jugequipo2 = from a in context.jugadores
                           where a.JUG_EQUIPOID == Convert.ToInt32(item.equipo2_id)
                           select new
                           {
                             equipo = item.equipo2,
                             categoria = item.categoria,
                             cancha = item.cancha,
                             dia = item.fecha,
                             nrofecha = item.nrofecha,
                             hora = item.hora,
                             fase = item.fase,
                             nombre = a.JUG_APELLIDO + " " + a.JUG_NOMBRE,
                             nrosocio = a.JUG_MAESOC_NROAFIL,
                             cuil = a.JUG_SOCCENCUIL,
                             estado = a.JUG_ESTADO,
                             foto = a.JUG_FOTO,
                             partidoid = item.partidoid,
                             jug_id = a.JUGID
                           };
          foreach (var itemE2 in jugequipo2.ToList())
          {


            DataRow Row = dt_imprPartido.NewRow();

            Row["equipo"] = itemE2.equipo;
            Row["fecha"] = itemE2.dia;
            Row["hora"] = itemE2.hora;
            Row["fase"] = itemE2.fase;
            Row["categoria"] = itemE2.categoria;
            Row["cancha"] = itemE2.cancha;
            Row["partidoID"] = itemE2.partidoid;
            Row["col1NroSocio"] = itemE2.nrosocio;
            Row["col1Nombre"] = itemE2.nombre;
            Row["col1DNI"] = itemE2.cuil;
            Row["col1Foto"] = itemE2.foto.ToArray();
            Row["nroFecha"] = itemE2.nrofecha;
            Row["sancion_x_de"] = ftbl.get_nro_fecha_sancion(itemE2.jug_id).ToString();
            Row["sancion_cantidad"] = ftbl.get_cantidad_fecha_sancion(itemE2.jug_id).ToString();

            dt_imprPartido.Rows.Add(Row);

          }
        }

        reportes frm_reportes = new reportes();
        frm_reportes.partidos = dt_imprPartido;
        //frm_reportes.nombreReporte = "planilla_partidos";
        frm_reportes.nombreReporte = "rpt_partidos";
        frm_reportes.Show();
      }
    }

    private void imprimir_partidos()
    {
      convertir_imagen cnv_img = new convertir_imagen();
      using (var context = new lts_sindicatoDataContext())
      {
        context.ExecuteCommand("truncate table impresion_comprobante");

        futbol ftbl = new futbol();
        var partidos_cancha_1 = (from pc1 in context.partidos
                                 where pc1.PARTIDOFECHA == dtp_fecha_partidos.Value
                                 select new
                                 {
                                   //campeonato = pc1.PARTIDO_CAMPID,
                                   fecha = pc1.PARTIDOFECHA,
                                   nrofecha = pc1.PARTIDONROFECHA,
                                   hora = pc1.PARTIDOHORA,
                                   fase = pc1.PARTIDO_FASEID,
                                   equipo1_id = pc1.PARTIDOEQUIPO1,
                                   equipo1 = ftbl.get_equipo_nombre(pc1.PARTIDOEQUIPO1),
                                   vs = "VS",
                                   equipo2_id = pc1.PARTIDOEQUIPO2,
                                   equipo2 = ftbl.get_equipo_nombre(pc1.PARTIDOEQUIPO2),
                                   categoria = ftbl.get_equipo_categoria(pc1.PARTIDO_CATID),
                                   partidoid = pc1.PARTIDOID,
                                   cancha = pc1.PARTIDO_CANCHAID
                                 }).OrderBy(x => x.cancha).ThenBy(x => x.hora);

        foreach (var item in partidos_cancha_1.ToList())
        {
          var jugequipo1 = from a in context.jugadores
                           where a.JUG_EQUIPOID == Convert.ToInt32(item.equipo1_id)
                           select new
                           {
                             equipo = item.equipo1,
                             categoria = item.categoria,
                             cancha = item.cancha + " - PARTIDO FINAL",
                             dia = item.fecha,
                             nrofecha = item.nrofecha,
                             hora = item.hora,
                             fase = item.fase,
                             nombre = a.JUG_APELLIDO + " " + a.JUG_NOMBRE,
                             nrosocio = a.JUG_MAESOC_NROAFIL,
                             cuil = a.JUG_SOCCENCUIL,
                             estado = a.JUG_ESTADO,
                             foto = cnv_img.ByteArrayToImage(a.JUG_FOTO.ToArray()), // a.JUG_FOTO,
                             partidoid = item.partidoid,
                             jug_id = a.JUGID

                           };
          foreach (var itemE1 in jugequipo1.ToList())
          {
            impresion_comprobante imp = new impresion_comprobante();
            //imp.CAMPEONATO = iteme1;
            imp.EQUIPO = itemE1.equipo;
            imp.FECHA = itemE1.dia;
            imp.HORA = itemE1.hora.ToString();
            imp.FASE = itemE1.fase.ToString();
            imp.CATEGORIA = itemE1.categoria;
            imp.CANCHA = itemE1.cancha.ToString();
            imp.PARTIDOID = Convert.ToString(itemE1.partidoid);
            imp.COL1NROSOCIO = itemE1.nrosocio;
            imp.COL1NOMBRE = itemE1.nombre;
            imp.COL1DNI = itemE1.cuil.ToString();
            imp.COL1FOTO = cnv_img.ImageToByteArray(itemE1.foto); // itemE1.foto;
            imp.NROFECHA = itemE1.nrofecha.ToString();
            imp.sancion_x_de = ftbl.get_nro_fecha_sancion(itemE1.jug_id).ToString();
            imp.sancion_cantidad = ftbl.get_cantidad_fecha_sancion(itemE1.jug_id).ToString();
            context.impresion_comprobante.InsertOnSubmit(imp);
            context.SubmitChanges();
          }

          var jugequipo2 = from a in context.jugadores
                           where a.JUG_EQUIPOID == Convert.ToInt32(item.equipo2_id)
                           select new
                           {
                             equipo = item.equipo2,
                             categoria = item.categoria,
                             cancha = item.cancha + " - PARTIDO FINAL",
                             dia = item.fecha,
                             nrofecha = item.nrofecha,
                             hora = item.hora,
                             fase = item.fase,
                             nombre = a.JUG_APELLIDO + " " + a.JUG_NOMBRE,
                             nrosocio = a.JUG_MAESOC_NROAFIL,
                             cuil = a.JUG_SOCCENCUIL,
                             estado = a.JUG_ESTADO,
                             foto = cnv_img.ByteArrayToImage(a.JUG_FOTO.ToArray()),// a.JUG_FOTO,
                             partidoid = item.partidoid,
                             jug_id = a.JUGID
                           };
          foreach (var itemE2 in jugequipo2.ToList())
          {
            impresion_comprobante imp2 = new impresion_comprobante();
            //imp.CAMPEONATO = itemE2;
            imp2.EQUIPO = itemE2.equipo;
            imp2.FECHA = itemE2.dia;
            imp2.HORA = itemE2.hora.ToString();
            imp2.FASE = itemE2.fase.ToString();
            imp2.CATEGORIA = itemE2.categoria;
            imp2.CANCHA = itemE2.cancha.ToString();
            imp2.PARTIDOID = Convert.ToString(itemE2.partidoid);
            imp2.COL1NROSOCIO = itemE2.nrosocio;
            imp2.COL1NOMBRE = itemE2.nombre;
            imp2.COL1DNI = itemE2.cuil.ToString();
            imp2.COL1FOTO = cnv_img.ImageToByteArray(itemE2.foto);//temE2.foto;
            imp2.NROFECHA = itemE2.nrofecha.ToString();
            imp2.sancion_x_de = ftbl.get_nro_fecha_sancion(itemE2.jug_id).ToString();
            imp2.sancion_cantidad = ftbl.get_cantidad_fecha_sancion(itemE2.jug_id).ToString();
            context.impresion_comprobante.InsertOnSubmit(imp2);
            context.SubmitChanges();
          }
        }
      }

      reportes frm_reportes = new reportes();
      frm_reportes.nombreReporte = "planilla_partidos";
      frm_reportes.Show();

    }

    private string nro_sancion(DateTime fecha_partido, string id_jugador)
    {
      var nrosanc = from a in db_sindicato.sanciones where a.FECHA_PARTIDO.Date == fecha_partido.Date && a.ID_JUG == Convert.ToInt32(id_jugador.Trim()) select a;
      if (nrosanc.Count() > 0)
      {
        return nrosanc.Single().NRO_FECHA.ToString();
      }
      else
      {
        return "";
      }
    }

    private string cantidad_fechas_sancion(DateTime fecha_partido, string id_jugador)
    {
      var nrosanc = from a in db_sindicato.sanciones where a.FECHA_PARTIDO.Date == fecha_partido.Date && a.ID_JUG == Convert.ToInt32(id_jugador) select a;
      if (nrosanc.Count() > 0)
      {
        return nrosanc.Single().CANTIDAD_FECHAS.ToString();
      }
      else
      {
        return "";
      }
    }

    private fotos buscar_foto(float cuil)
    {
      var f = db_sindicato.fotos.Where(x => x.FOTOS_CUIL == cuil && x.FOTOS_CODFLIAR == 0);
      if (f.Count() > 0) return (fotos)f;
      else
      {
        return (fotos)f;
      }
    }

    private void Imprimir_Informe_Arbitral()
    {
      using (var context = new lts_sindicatoDataContext())
      {

        var Campeonato = context.campeonatos.Where(x => x.CAMPESTADO == 1).FirstOrDefault();

        DS_cupones ds = new DS_cupones();
        DataTable dt = ds.Logos; //Jugadores;
        DataTable dt2 = ds.partidos;
        DataRow row = dt.NewRow();

        row["Logo_Futbol"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_futbol.jpg"));
        row["Logo_Reporte"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg"));
        row["Año"] = Campeonato.CAMPAÑO;
        row["Nom_Campeonato"] = Campeonato.CAMPNOMBRE;
        dt.Rows.Add(row);

        var partidos = (from prt in context.partidos
                        join cat in context.categorias on prt.PARTIDO_CATID equals cat.CATID
                        //where prt.PARTIDOFECHA == dtp_fecha_partidos.Value
                        where Imprimir_Informe_Arbitral_Actual ? prt.PARTIDOID == Convert.ToInt32(dgv_partidos_cancha1.CurrentRow.Cells["idPartido"].Value) : prt.PARTIDOFECHA == dtp_fecha_partidos.Value
                        //where prt.PARTIDOID == Convert.ToInt32(dgv_partidos_cancha1.CurrentRow.Cells["idPartido"].Value)
                        select new
                        {
                          partidoId = prt.PARTIDOID,
                          cancha = prt.PARTIDO_CANCHAID,
                          fecha = prt.PARTIDOFECHA,
                          nrofecha = prt.PARTIDONROFECHA,
                          hora = prt.PARTIDOHORA,
                          categoria = cat.CATNOMBRE,
                          equipo1 = context.equipos.Where(x => x.EQUIPOID == prt.PARTIDOEQUIPO1).Single().EQUIPONOMBRE,
                          equipo2 = context.equipos.Where(x => x.EQUIPOID == prt.PARTIDOEQUIPO2).Single().EQUIPONOMBRE,
                        }).OrderBy(x => x.cancha).ThenBy(x => x.hora);


        DataTable dt_InformeArbitro = ds.InformeArbitro;
        dt_InformeArbitro.Clear();

        foreach (var Partido in partidos)
        {
          DataRow Row = dt_InformeArbitro.NewRow();
          Row["partidoId"] = Partido.partidoId;
          Row["cancha"] = Partido.cancha;
          Row["fecha"] = Partido.fecha;
          Row["nrofecha"] = Partido.nrofecha;
          Row["hora"] = Partido.hora;
          Row["categoria"] = Partido.categoria;
          Row["equipo1"] = Partido.equipo1;
          Row["equipo2"] = Partido.equipo2;

          dt_InformeArbitro.Rows.Add(Row);
        }

        reportes f_report = new reportes();
        f_report.nombreReporte = "planilla_arbitro";
        f_report.dt = dt;
        f_report.dt2 = dt_InformeArbitro;
        f_report.Show();
      }
    }


    private void pnl_jugadoresInscriptos_Paint(object sender, PaintEventArgs e)
    {

    }

    private void btn_guardar_cambio_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Esta seguro de cambiar de equipo al jugador ''" + dgv_jugadores_inscriptos.CurrentRow.Cells[2].Value.ToString() + "''", "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        var jug = db_sindicato.jugadores.Where(x => x.JUGID == Convert.ToInt32(dgv_jugadores_inscriptos.CurrentRow.Cells[0].Value) && x.JUG_EQUIPOID == Convert.ToInt32(cbx_equipo_jugadores_inscriptos.SelectedValue)).Single();
        jug.JUG_EQUIPOID = Convert.ToInt32(cbx_cambio_equipo.SelectedValue);
        db_sindicato.SubmitChanges();
        mostrar_jugadores_inscriptos();
      }
    }

    private void btn_quitar_jugador_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Esta seguro de quitar del equipo " + cbx_equipo_jugadores_inscriptos.Text + " al jugador ''" + dgv_jugadores_inscriptos.CurrentRow.Cells[2].Value.ToString() + "''", "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        var jug = db_sindicato.jugadores.Where(x => x.JUGID == Convert.ToInt32(dgv_jugadores_inscriptos.CurrentRow.Cells[0].Value) && x.JUG_EQUIPOID == Convert.ToInt32(cbx_equipo_jugadores_inscriptos.SelectedValue)).Single();
       // jug.JUG_EQUIPOID = 0;
        db_sindicato.jugadores.DeleteOnSubmit(jug);
        db_sindicato.SubmitChanges();
        mostrar_jugadores_inscriptos();
      }
    }

    private void btn_aplicar_sancion_Click_1(object sender, EventArgs e)
    {
      futbol ftbl = new futbol();
      int jug_id = Convert.ToInt32(dgv_jugadores_inscriptos.CurrentRow.Cells["JUGID"].Value.ToString());
      DateTime desde = dtp_sancion_desde.Value;
      DateTime hasta = dtp_sancion_hasta.Value;
      int cantidad_fechas = Convert.ToInt32(cbx_cantidad_fechas.SelectedItem.ToString());

      ftbl.crear_sancion(jug_id, desde, hasta, cantidad_fechas);

      MessageBox.Show("Sancion Aplicada con Exito !!!!", "Atencion");

    }

    private void btn_campeonato_Click(object sender, EventArgs e)
    {

    }

    private void btn_imprimir_jugadores_Click(object sender, EventArgs e)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Campeonato = context.campeonatos.Where(x => x.CAMPESTADO == 1).FirstOrDefault();
        DS_cupones ds = new DS_cupones();
        DataTable dt = ds.Jugadores;
        foreach (DataGridViewRow fila in dgv_jugadores_inscriptos.Rows)
        {
          DataRow row = dt.NewRow();

          row["Categoria"] = cbx_categoria_jugadores_inscriptos.Text;
          row["Equipo"] = cbx_equipo_jugadores_inscriptos.Text;
          row["NroSocio"] = Convert.ToInt32(fila.Cells["nroafil"].Value);
          row["Jugador"] = fila.Cells["jugador_"].Value.ToString().Trim();
          row["DNI"] = fila.Cells["jugcuil"].Value.ToString();
          row["LogoFutbol"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_futbol.jpg"));
          row["LogoReporte"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg"));
          row["Campeonato"] = Campeonato.CAMPNOMBRE;
          row["Año"] = Campeonato.CAMPAÑO;
          row["Cantidad"] = txt_total_jugadores.Text;
          dt.Rows.Add(row);
        }
        reportes f_report = new reportes();
        f_report.NombreDelReporte = "entrega_cupones.Reportes.rpt_jugadores_inscriptos.rdlc";//"rpt_jugadores_inscriptos";
        f_report.dt = dt;
        f_report.Show();
      }
    }

    private void btn_activar_Click(object sender, EventArgs e)
    {
      activar_jugador();
    }

    private void activar_jugador()
    {
      if (MessageBox.Show("Esta seguro de pasar a ''SOCIO ACTIVO'' al jugador '' " + txt_apellido.Text.Trim() + " " + txt_nombre.Text.Trim() + "''", "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        var juga = db_sindicato.soccen.Where(x => x.SOCCEN_CUIL == Convert.ToDouble(txt_CUIL.Text.Trim())).Single();
        juga.SOCCEN_ESTADO = 1;
        db_sindicato.SubmitChanges();
        mostrar_jugadores_inscriptos();
      }
    }

    private void btn_inscribir_gerentes_Click(object sender, EventArgs e)
    {


    }

    private void btn_cancelar_incripcion_Click(object sender, EventArgs e)
    {

    }

    private void cbx_categoria_g_SelectedIndexChanged(object sender, EventArgs e)
    {
      var var_equipos1 = (from equi1 in db_sindicato.equipos
                          where equi1.EQUIPO_CATID == Convert.ToInt32(cbx_categoria_g.SelectedValue)
                          select equi1).OrderBy(x => x.EQUIPONOMBRE);

      cbx_equipo_g.DisplayMember = "equiponombre";
      cbx_equipo_g.ValueMember = "equipoid";
      cbx_equipo_g.DataSource = var_equipos1.ToList();
    }

    private void btn_inscripcion__Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Esta seguro de Inscribir al jugador ''" + txt_apellido_gerente.Text.Trim() + " " + txt_nombre_gerente.Text.Trim() + "''", "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {

        try
        {
          futbol ftbl = new futbol();
          ftbl.insertar_jugador(
              Convert.ToInt32(cbx_equipo_g.SelectedValue),
              "0",
              Convert.ToInt64(txt_cuil_gerente.Text),
              txt_nombre_gerente.Text.ToUpper(),
              txt_apellido_gerente.Text.ToUpper(),
              (cbx_tipo_gerente.Text == "Gerente" ? 1 : 0)
              );

          limpiar_inscripcion_gerente();
          MessageBox.Show("Jugador agregado con exito !!!!", "¡¡¡ ATENCION !!!", MessageBoxButtons.OK);
          mostrar_gerentes_inscriptos();
        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    private void limpiar_inscripcion_gerente()
    {
      txt_apellido_gerente.Text = "";
      txt_nombre_gerente.Text = "";
      txt_dni_gerente.Text = "";
      txt_cuil_gerente.Text = "";
    }

    private void mostrar_gerentes_inscriptos()
    {
      var gerentes_i = (from a in db_sindicato.jugadores_exepciones
                        join eq in db_sindicato.equipos on a.equipo_ID equals eq.EQUIPOID
                        join cat in db_sindicato.categorias on a.categoria_ID equals cat.CATID
                        where (cbx_tipo_gerente.Text == "Gerente" ? a.tipo == 1 : a.tipo == 0)
                        select new
                        {
                          jugador = a.apellido + " " + a.nombre,
                          equipo = eq.EQUIPONOMBRE,
                          categoria = cat.CATNOMBRE,
                          cuil = a.cuil
                        }).OrderBy(x => x.jugador);
      dgv_gerentes_inscriptos.DataSource = gerentes_i.ToList();
    }

    private void btn_salir_Click(object sender, EventArgs e)
    {
      tabControl1.SelectedTab = tabPageJugadores;
    }

    private void cbx_tipo_gerente_SelectedIndexChanged(object sender, EventArgs e)
    {
      mostrar_gerentes_inscriptos();
    }

    private void btn_inscribir_exepcion_Click(object sender, EventArgs e)
    {
      tabControl1.SelectedTab = tabPageGerentes;
    }

    private void transferir_Click(object sender, EventArgs e)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        futbol ftbl = new futbol();

        var jugador = from jug in context.jugadores select jug;
        foreach (var item in jugador.ToList())
        {

          item.JUG_FOTO = ftbl.get_Foto(item.JUG_SOCCENCUIL);
          context.SubmitChanges();
        }
      };
    }

    private void bunifuCustomLabel36_Click(object sender, EventArgs e)
    {

    }

    private void Btn_CargarFoto_Click(object sender, EventArgs e)
    {
      openFileDialog1.ShowDialog();
      picbox_jugadores_inscriptos.ImageLocation = openFileDialog1.FileName;
    }

    private void Btn_GuardarFoto_Click(object sender, EventArgs e)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        double cuil = Convert.ToDouble(dgv_jugadores_inscriptos.CurrentRow.Cells["jugcuil"].Value);
        var jugador_foto = context.jugadores.Where(x => x.JUG_SOCCENCUIL == cuil).Single();
        jugador_foto.JUG_FOTO = mtdConvertirImagen.ImageToByteArray(picbox_jugadores_inscriptos.Image);
        context.SubmitChanges();
      }
    }

    private void btn_Imprmir_Informe_Todos_Click(object sender, EventArgs e)
    {
      Imprimir_Informe_Arbitral_Actual = false;
      Imprimir_Informe_Arbitral();
    }

    private void btn_Imprmir_Informe_Actual_Click(object sender, EventArgs e)
    {
      Imprimir_Informe_Arbitral_Actual = true;
      Imprimir_Informe_Arbitral();
    }

    private void btn_PartidoTodos_Click(object sender, EventArgs e)
    {
      Imprimir_Partido_Actual = false;
      ImprimirPartidos();
    }

    private void btn_PartidoActual_Click(object sender, EventArgs e)
    {
      Imprimir_Partido_Actual = true;
      ImprimirPartidos();
    }

    private void btn_GuardarPartido_Click(object sender, EventArgs e)
    {
      GuardarPartido();
    }

    private void dgv_jugadores_inscriptos_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void txt_equipo1_Click(object sender, EventArgs e)
    {

    }

    private void btn_CargarResultadosPartidos_Click(object sender, EventArgs e)
    {
      Lbl_CargaDeResultados.Text = "Carga de Resultados Partido " + dgv_partidos_cancha1.CurrentRow.Cells["Equipo1"].Value + "  VS  " + dgv_partidos_cancha1.CurrentRow.Cells["Equipo2"].Value;
    }

    private void btn_buscar_jugador_Click(object sender, EventArgs e)
    {

    }

    private void txt_dni_OnValueChanged(object sender, EventArgs e)
    {

    }
  }
}
