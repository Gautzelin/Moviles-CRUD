using jcorreaS5A.Models;

namespace jcorreaS5A.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.personRepo.AddNewPerson(txtNombre.Text);

        statusMessage.Text = App.personRepo.statusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> Lista = App.personRepo.GetAllPerson();
        listPersonas.ItemsSource = Lista;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personRepo.UpdatePerson(id, txtNuevoNombre.Text);
            statusMessage.Text = App.personRepo.statusMessage;
        }
        else
        {
            statusMessage.Text = "ID inválido";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personRepo.DeletePerson(id);
            statusMessage.Text = App.personRepo.statusMessage;
        }
        else
        {
            statusMessage.Text = "ID inválido";
        }
    }
}