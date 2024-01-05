namespace pcaceresS3.Vistas;

public partial class vPrincipal : ContentPage
{
    public vPrincipal(string usuario)
    {
        InitializeComponent();
        lblUsuario.Text = "Inicio de sesión con: " + usuario;
    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNotaUno.Text) ||
                string.IsNullOrWhiteSpace(txtExamenUno.Text) ||
                string.IsNullOrWhiteSpace(txtNotaDos.Text) ||
                string.IsNullOrWhiteSpace(txtExamenDos.Text))
            {
                DisplayAlert("Error", "Todos los campos deben estar llenos", "Ok");
                return;
            }

            // Almacenar en variables, datos que ingresa el usuario en los txt box.
            double nota1, examen1, nota2, examen2;

            // Validar y convertir las notas y exámenes a números
            if (!double.TryParse(txtNotaUno.Text, out nota1) ||
                !double.TryParse(txtExamenUno.Text, out examen1) ||
                !double.TryParse(txtNotaDos.Text, out nota2) ||
                !double.TryParse(txtExamenDos.Text, out examen2))
            {
                DisplayAlert("Error", "Ingrese números válidos en los campos", "Ok");
                return;
            }

            // Validar que los valores estén entre 0 y 10
            if (nota1 < 0 || nota1 > 10 || examen1 < 0 || examen1 > 10 ||
                nota2 < 0 || nota2 > 10 || examen2 < 0 || examen2 > 10)
            {
                DisplayAlert("Error", "Los valores deben estar entre 0 y 10", "Ok");
                return;
            }

            // Operaciones 
            double notaparcial1 = (nota1 * 0.3) + (examen1 * 0.2);
            double notaparcial2 = (nota2 * 0.3) + (examen2 * 0.2);

            double notafinal = notaparcial1 + notaparcial2;

            // Visualizar el resultado en pantalla
            txtNotaParcialUno.Text = notaparcial1.ToString();
            txtNotaParcialDos.Text = notaparcial2.ToString();
            txtNotaFinal.Text = notafinal.ToString();

            if (notafinal >= 7)
            {
                DisplayAlert("Estado de notas", "Aprobado", "Ok");
            }
            else if (notafinal >= 5 && notafinal < 6.9)
            {
                DisplayAlert("Estado de notas", "Complementario", "Ok");
            }
            else
            {
                DisplayAlert("Estado de notas", "Reprobado", "Ok");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Mensaje de alerta", ex.Message, "Ok");
        }
    }

    private void btnLimpiar_Clicked(object sender, EventArgs e)
    {
        // Poner en blanco los campos
        txtNotaUno.Text = "";
        txtNotaDos.Text = "";
        txtExamenUno.Text = "";
        txtExamenDos.Text = "";
        txtNotaParcialUno.Text = "";
        txtNotaParcialDos.Text = "";
        txtNotaFinal.Text = "";
    }
}