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
  public partial class frm_CambiarContraseña : Form
  {
    public string _Usuario;
    public string _UsuarioId;
    public frm_CambiarContraseña()
    {
      InitializeComponent();
    }

    private void Btn_Cancelar_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void Btn_Confirmar_Click(object sender, EventArgs e)
    {
      bool ok = true;
      if (!MtdUsuarios.GetUserByPwd(_Usuario,Txt_PwdActual.Text))
      {
        MessageBox.Show("La contraseña ACtual Ingresada no es la Correcta. Por favor Ingrese una Contraseña Valida.", "Contraseña Incorrecta");
        Txt_PwdActual.Focus();
        ok = false;
      }

      if (!(Txt_PwdConfirmar.Text == Txt_PwdNuevo.Text))
      {
        MessageBox.Show("La contraseña Nueva y su Confirmacion no son iguales. Por favor Verifique.", "Contraseña Incorrecta");
        Txt_PwdNuevo.Focus();
        ok = false;
      }

      if (ok)
      {
        SetPaswordChange();
      }
    
    }

    public void SetPaswordChange()
    {
      using (var context = new lts_sindicatoDataContext())
      {
       var  user = MtdUsuarios.GetUserModel(_Usuario);
        if (user!= null)
        {
          var nueva = context.Usuarios.Where(x => x.idUsuario == user.FirstOrDefault().UsrId);
          nueva.Single().Password = Txt_PwdNuevo.Text;
          context.SubmitChanges();
          MessageBox.Show("La Nueva Contraseña Fue Creada con Exito", "Contraseña Nueva");
          Close();
        }  
      }
    }
  }
}
