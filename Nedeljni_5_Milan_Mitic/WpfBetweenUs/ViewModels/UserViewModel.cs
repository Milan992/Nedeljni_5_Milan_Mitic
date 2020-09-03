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

        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        private List<vwPost> posts;

        public List<vwPost> Posts
        {
            get { return posts; }
            set
            {
                posts = value;
                OnPropertyChanged("Posts");
            }
        }
        
        #endregion

        #region Commands

        private ICommand post;

        public ICommand Post
        {
            get
            {
                if (post == null)
                {
                    post = new RelayCommand(param => PostExecute(), param => CanPostExecute());
                }

                return post;
            }
        }

        private void PostExecute()
        {
            try
            {
                service.Post(Account, Text);
                Text = "";
                MessageBox.Show("Thanx for sharing.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanPostExecute()
        {
            if (!string.IsNullOrWhiteSpace(Text))
            {
                if (Text.Length <= 100)
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

        #endregion

    }
}
