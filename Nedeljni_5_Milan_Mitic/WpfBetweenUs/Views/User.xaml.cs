using System.Windows;
using WpfBetweenUs.Model;
using WpfBetweenUs.ViewModels;

namespace WpfBetweenUs.Views
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel(this);
        }

        public User(tblAccount account)
        {
            InitializeComponent();
            this.DataContext = new UserViewModel(this, account);
        }
    }
}
