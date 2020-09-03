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
            posts = service.GetAllPosts();
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

        private vwPost post;

        public vwPost Post
        {
            get { return post; }
            set
            {
                post = value;
                OnPropertyChanged("Post");
            }
        }

        #endregion

        #region Commands

        private ICommand addPost;

        public ICommand AddPost
        {
            get
            {
                if (addPost == null)
                {
                    addPost = new RelayCommand(param => AddPostExecute(), param => CanAddPostExecute());
                }

                return addPost;
            }
        }

        private void AddPostExecute()
        {
            try
            {
                service.Post(Account, Text);
                Text = "";
                Posts = service.GetAllPosts();
                MessageBox.Show("Thanx for sharing.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddPostExecute()
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

        private ICommand likePost;

        public ICommand LikePost
        {
            get
            {
                if (likePost == null)
                {
                    likePost = new RelayCommand(param => LikePostExecute(), param => CanLikePostExecute());
                }

                return likePost;
            }
        }

        private void LikePostExecute()
        {
            try
            {
                service.Like(Post);
                Posts = service.GetAllPosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLikePostExecute()
        {
            // TODO provera dal su prijatelji 
            return true;
        }

        #endregion

    }
}
