using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Excepciones.Controles
{
    /// <summary>
    /// Interaction logic for TextBoxP.xaml
    /// </summary>
    public partial class TextBoxP : UserControl
    {
        public TextBoxP()
        {
            InitializeComponent();
        }

        private string placeHolder;

        public string PlaceHolder
        {
            get { return placeHolder; }
            set
            {
                placeHolder = value;
                tbPlaceHolder.Text = placeHolder;
            }
        }

        private void txtP_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtP.Text))
            {
                tbPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                tbPlaceHolder.Visibility = Visibility.Hidden;
            }
        }
    }
}
