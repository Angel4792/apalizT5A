using apalizT5A.Models;

namespace apalizT5A.Views;

public partial class Personas : ContentPage
{
    public Personas()
    {
        InitializeComponent();
    }
    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.PersonRepo.addNewPerson(txtPersona.Text);
        lblStatus.Text = App.PersonRepo.statusMessage;
        btnObtener_Clicked(sender, e);
    }
    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        // lblStatus.Text = "";
        List<Persona> people = App.PersonRepo.GetAllPeople();
        listapersona.ItemsSource = people;
    }
    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

        bool confirmacion = await DisplayAlert("Confirmacion", $"�Est�s seguro de borrar a {persona.Name}?", "si", "no");

        if (confirmacion)
        {
            App.PersonRepo.DeletePerson(persona.Id);
            await DisplayAlert("Confirmacion", App.PersonRepo.statusMessage, "Aceptar");
            btnObtener_Clicked(sender, e);
        }
    }
    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

        Navigation.PushAsync(new Views.Editar(persona.Name, persona.Id));
    }
}