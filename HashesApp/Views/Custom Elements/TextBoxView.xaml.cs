using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HashesApp.Views.Custom_Elements
{
    /// <summary>
    /// Логика взаимодействия для TextBoxView.xaml
    /// </summary>
    public partial class TextBoxView : Window
    {
        public TextBoxView(string Message)
        {
            InitializeComponent();
            txtMessage.Text = Message;
            txtTitle.Text = "Error";
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
