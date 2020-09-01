using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfBetweenUs.Model;
using WpfBetweenUs.Views;

namespace WpfBetweenUs.ViewModels
{
    class RegisterViewModel : ViewModelBase
    {
        Register register;
        Service service = new Service();

        #region Constructors

        public RegisterViewModel(Register registerOpen)
        {
            register = registerOpen;
            account = new tblAccount();
            genderList = new List<string> { "M", "Z" };
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

        private List<string> genderList;

        public List<string> GenderList
        {
            get { return genderList; }
            set
            {
                genderList = value;
                OnPropertyChanged("GenderList");
            }
        }

        #endregion

        #region Commands

        private ICommand save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }

                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {
                service.AddAccount(Account);
                MessageBox.Show("Registration completed.");
                register.Close();
            }
            catch 
            {
                MessageBox.Show("Username already exists, please choose another username");
            }
        }

        private bool CanSaveExecute()
        {
            if (Account.FirstName != null && Account.LastName != null && Account.Gender != null
                && Account.UserName != null && Account.Pass != null)
            {
                if (Account.UserName.Length >= 6 && Account.Pass.Length >= 6 && Account.FirstName.Length >= 1 && Account.LastName.Length >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private ICommand close;

        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }

                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                register.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
