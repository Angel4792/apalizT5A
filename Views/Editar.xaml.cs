using apalizT5A.Models;

namespace apalizT5A.Views;

public partial class Editar : ContentPage
{
    public Editar(string nombre, int id)
    {
        InitializeComponent();
        txtNombre.Text = nombre;
        lblIb.Text = id.ToString();
    }
    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        string nuevonombre = txtNombre.Text;
        int id = int.Parse(lblIb.Text);

        if (id > 0)
        {
            Persona persona = new Persona { Id = id, Name = nuevonombre };
            App.PersonRepo.UpdatePerson(persona);
            Navigation.PushAsync(new Views.Personas());
        }
        else
        {
            App.PersonRepo.addNewPerson(nuevonombre);
        }
    }
}