using entrega_cupones.Metodos;
using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrega_cupones.Formularios
{
  public partial class frm_Eventos3 : Form
  {
    public int _EventoId = 0;
    public int _ABMEventoAño = 0;
    public bool _Mostrardetalle = false;

    public frm_Eventos3()
    {
      InitializeComponent();
    }

    private void frm_Eventos3_Load(object sender, EventArgs e)
    {
      dgv_EventosCargados.AutoGenerateColumns = false;
      dgv_EventosAño.AutoGenerateColumns = false;
      dgv_EventosCargados.DataSource = MtdEventos.get_todos();
    }

    private void dgv_EventosCargados_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dgv_EventosCargados_SelectionChanged(object sender, EventArgs e)
    {
      MostrarEvenoAño();
    }

    private void MostrarEvenoAño()
    {
      _EventoId = Convert.ToInt32(dgv_EventosCargados.CurrentRow.Cells["EventoId"].Value);
      List<MdlEventosAño> mdl = MtdEventos.GetListEventoAño(_EventoId);
      _Mostrardetalle = mdl.Count > 0; // ? true : false;
      dgv_EventosAño.DataSource = mdl;
    }

    private void btn_CargarEvento_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(txt_Nombre.Text))
      {
        if (MtdEventos.InsertEvento(txt_Nombre.Text.Trim()))
        {
          MessageBox.Show("El evento fue cargado con exito.", "ATENCION");
          txt_Nombre.Text = "";
        }
      }
      else
      {
        MessageBox.Show("No puede grabr un evento sin nombre. ", "ATENCION");
      }
    }

    private void btn_GrabarEventoAño_Click(object sender, EventArgs e)
    {
      if (!MtdEventos.ContolarAño(_ABMEventoAño, _EventoId, Convert.ToInt32(txt_Año.Text)))
      {
        if (MtdEventos.InsertEventoAño(Convert.ToInt32(dgv_EventosCargados.CurrentRow.Cells["EventoId"].Value),
        Convert.ToInt32(txt_Año.Text),
        1,
        1,
        txt_LugarFecha.Text,
        txt_Comenatario.Text,
        txt_NombreEvento.Text,
        _ABMEventoAño

        ))
        {
          MessageBox.Show("Año Cargado con exito !!! ", "ATENCION !!!");
          Cancelar();
        }
      }
      else
      {
        MessageBox.Show("No se puede dar de Alta!!!! - El año " + txt_Año.Text
          + " ya esta cargado para el evento "
          + dgv_EventosCargados.CurrentRow.Cells["Nombre"].Value
          + " - Verifique !!!");
      }
    }

    private void Btn_NuevoEventoAño_Click(object sender, EventArgs e)
    {
      btn_ModificarEvenoAño.Enabled = false;
      btn_GrabarEventoAño.Enabled = true;
      _ABMEventoAño = 1;
      dgv_EventosCargados.Enabled = false;
    }

    private void btn_ModificarEventoAño_Click(object sender, EventArgs e)
    {
      Btn_NuevoEventoAño.Enabled = false;
      btn_GrabarEventoAño.Enabled = true;
      _ABMEventoAño = 3;
      dgv_EventosCargados.Enabled = false;
      dgv_EventosAño.Enabled = false;
    }

    private void Btn_CancelarEventoAño_Click(object sender, EventArgs e)
    {
      Cancelar();
    }

    private void Cancelar()
    {
      Btn_NuevoEventoAño.Enabled = true;
      btn_ModificarEvenoAño.Enabled = true;
      btn_GrabarEventoAño.Enabled = false;
      _ABMEventoAño = 0;
      dgv_EventosCargados.Enabled = true;
      dgv_EventosAño.Enabled = true;
    }

    private void dgv_EventosAño_SelectionChanged(object sender, EventArgs e)
    {
      if (_Mostrardetalle)
      {
        txt_Año.Text = Convert.ToString(dgv_EventosAño.CurrentRow.Cells["Año"].Value);
        txt_LugarFecha.Text = Convert.ToString(dgv_EventosAño.CurrentRow.Cells["LugarFecha"].Value);
        txt_Comenatario.Text = Convert.ToString(dgv_EventosAño.CurrentRow.Cells["Comentario"].Value);
        txt_NombreEvento.Text = Convert.ToString(dgv_EventosAño.CurrentRow.Cells["NombreEvento"].Value);
      }
      else
      {
        txt_Año.Text = "";
        txt_LugarFecha.Text = "";
        txt_Comenatario.Text = "";
        txt_NombreEvento.Text = "";
      }
    }

    private void dgv_EventosAño_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
  }
}
