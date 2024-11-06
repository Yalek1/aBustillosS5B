using aBustillosS5B.Models;

namespace aBustillosS5B.Views;

public partial class Principal : ContentPage
{
    private int selectedPersonId;

	public Principal()
	{
		InitializeComponent();
	}

    private void btnAñadir_Clicked(object sender, EventArgs e)
    {
        App.personRepo.AddNewPerson(txtName.Text);
        lblStatus.Text = App.personRepo.status;
        txtName.Text = string.Empty;
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        List<Persona> people = App.personRepo.GetAllPerson();
        listapersonas.ItemsSource = people;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        if (selectedPersonId == 0)
        {
            lblStatus.Text = "Seleccione una persona para actualizar.";
            return;
        }

        App.personRepo.UpdatePerson(selectedPersonId, txtUpdateName.Text);
        lblStatus.Text = App.personRepo.status;
        txtUpdateName.Text = string.Empty;
        selectedPersonId = 0;
        btnMostrar_Clicked(sender, e); //Actualizamos la Lista
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (selectedPersonId == 0)
        {
            lblStatus.Text = "Seleccione una persona para eliminar.";
            return;
        }

        App.personRepo.DeletePerson(selectedPersonId);
        lblStatus.Text = App.personRepo.status;
        txtUpdateName.Text = string.Empty;
        selectedPersonId = 0;
        btnMostrar_Clicked(sender, e); //Actualizamos la Lista
    }

    private void btnSeleccionar_Clicked(object sender, EventArgs e)
    {
        // Cuando seleccionamos una persona obtenemos su ID
        if ((sender as Button)?.CommandParameter is Persona selectedPerson)
        {
            selectedPersonId = selectedPerson.Id;
            txtUpdateName.Text = selectedPerson.Name; // Mostramos el nombre actual
        }
    }
}