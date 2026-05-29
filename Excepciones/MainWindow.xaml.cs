using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Excepciones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            try // Uso de try para limpiar todos los campos 
            {
                txtNombre.Clear();
                txtEdad.Clear();
                txtCorreo.Clear();


                if (txtTelefono != null) txtTelefono.Clear();

                txtNombre.Focus();
            }
            catch (Exception ex) // Uso de catch para atrapar cualquier error al limpiar
            {
                MessageBox.Show(
                    $"Error al limpiar: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

  private void btnGuardar_Click(object sender, RoutedEventArgs e)
{
    try // Uso del try para las validaciones y restricciones
    {
    

        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            MessageBox.Show(
                "El campo 'Nombre Completo' está vacío.",
                "Error de Validación",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            return;
        }

        if (string.IsNullOrWhiteSpace(txtEdad.Text))
        {
            MessageBox.Show(
                "El campo 'Edad' está vacío.",
                "Error de Validación",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            return;
        }

           
                if (string.IsNullOrWhiteSpace(txtTelefono.Text))
                {
                    MessageBox.Show(
                        "El campo 'Teléfono' está vacío.",
                        "Error de Validación",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCorreo.Text))
        {
            MessageBox.Show(
                "El campo 'Correo Electrónico' está vacío.",
                "Error de Validación",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            return;
        }

        if (!int.TryParse(txtEdad.Text, out int edad))
        {
            MessageBox.Show(
                "La edad debe ser un número entero válido.",
                "Error de Validación",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            return;
        }

        if (edad <= 0 || edad > 20)
        {
            MessageBox.Show(
                "La edad debe estar entre 1 y 20 años.",
                "Error de Validación",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            return;
        }

        if (!EsCorreoValido(txtCorreo.Text))
        {
            MessageBox.Show(
                "El formato del correo electrónico no es válido.\nEjemplo: usuario@gmail.com",
                "Error de Validación",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            return;
        }

        if (!EsTelefonoValido(txtTelefono.Text))
        {
            MessageBox.Show(
                "El formato del teléfono no es válido.\nEjemplo: 809-555-1234",
                "Error de Validación",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            return;
        }

        // Si todas las validaciones pasan
        MessageBox.Show(
            $"¡Registro exitoso!\n\nNombre: {txtNombre.Text}\nEdad: {edad} años\nCorreo: {txtCorreo.Text}\nTeléfono: {txtTelefono.Text}",
            "Éxito",
            MessageBoxButton.OK,
            MessageBoxImage.Information
        );
    }
    catch (Exception ex)
    {
        MessageBox.Show(
            $"Error inesperado: {ex.Message}",
            "Error del Sistema",
            MessageBoxButton.OK,
            MessageBoxImage.Error
        );
    }
}
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult resultado = MessageBox.Show(
                    "¿Deseas salir de la aplicación?",
                    "Confirmar Salida",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (resultado == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al salir: {ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private bool EsCorreoValido(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patron);
        }

        private bool EsTelefonoValido(string telefono)
        {
            string telefonoLimpio = telefono.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            string patron = @"^[0-9]{10}$";
            return Regex.IsMatch(telefonoLimpio, patron);
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            placeholder.Visibility = string.IsNullOrEmpty(txtNombre.Text)
      ? Visibility.Visible
      : Visibility.Hidden;
        }

        private void txtEdad_TextChanged(object sender, TextChangedEventArgs e)
        {
            placeholder1.Visibility = string.IsNullOrEmpty(txtEdad.Text)
      ? Visibility.Visible
      : Visibility.Hidden;
        }

        private void txtTelefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            placeholder2.Visibility = string.IsNullOrEmpty(txtTelefono.Text)
      ? Visibility.Visible
      : Visibility.Hidden;
        }

        private void txtCorreo_TextChanged(object sender, TextChangedEventArgs e)
        {
            placeholder3.Visibility = string.IsNullOrEmpty(txtCorreo.Text)
      ? Visibility.Visible
      : Visibility.Hidden;
        }
    }
}