namespace pcaceresS3.Vistas;

    public partial class vLogin : ContentPage
{

    public vLogin()
    {
        InitializeComponent();
    }

    private void IniciarSesion_Click(object sender, EventArgs e)
    {

        // Vectores de usuarios y contraseñas
        string[] usuarios = { "Carlos", "Ana", "Jose" };
        string[] contrasenas = { "carlos123", "ana123", "jose123" };

        string usuario = txtUsuario.Text;
        string contrasena= txtContrasena.Text;

        // Verificar las credenciales
        bool credencialesValidas = false;

        for (int i = 0; i < usuarios.Length; i++)
        {
            if (usuario == usuarios[i] && contrasena == contrasenas[i])
            {
                credencialesValidas = true;
              //  Navigation.PushAsync(new vPrincipal(usuario));
                break;
            }
        }
        if (credencialesValidas == true)
            {
                Navigation.PushAsync(new vPrincipal(usuario));
                MostrarMensajeBienvenida(usuario);
            }
            else
            {
                 DisplayAlert("Alerta", "Crendenciales incorrectos", "Cancelar");
            }

        }

    private void MostrarMensajeBienvenida(string usuario)
    {
        DisplayAlert("UISRAEL", $"¡Bienvenido, {usuario}!", "OK");
        
    }
}

