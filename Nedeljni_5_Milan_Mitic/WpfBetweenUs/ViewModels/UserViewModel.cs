using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBetweenUs.Model;
using WpfBetweenUs.Views;

namespace WpfBetweenUs.ViewModels
{
    class UserViewModel : ViewModelBase
    {
        User user;
        Service service = new Service();

        #region Constructors

        public UserViewModel(User userOpen)
        {
            user = userOpen;
        }

        public UserViewModel(User userOpen, tblAccount accountToView)
        {
            user = userOpen;
            account = accountToView;
        }

        #endregion

        #region Properties

        private tblAccount account;

        public tblAccount Account
        {
            get { return account; }
            set
            {
                account = value;
                OnPropertyChanged("Account");
            }
        }

        #endregion

    }
}
