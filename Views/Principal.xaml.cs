using aBustillosS5B.Models;

namespace aBustillosS5B.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void btnAñadir_Clicked(object sender, EventArgs e)
    {
        App.personRepo.AddNewPerson(txtName.Text);
        lblStatus.Text = App.personRepo.status;
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        List<Persona> people = App.personRepo.GetAllPerson();
        listapersonas.ItemsSource = people;
    }
}