using System.Windows;
using WpfBetweenUs.ViewModels;

namespace WpfBetweenUs.Views
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            this.DataContext = new RegisterViewModel(this);
        }
    }
}
