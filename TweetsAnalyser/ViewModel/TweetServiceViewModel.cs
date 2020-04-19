using TwitterTests.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Windows;
using TweetsAnalyser.View;

namespace TwitterTests.ViewModel
{
    class TweetServiceViewModel : INotifyPropertyChanged
    {
        public TwitterUserModel twitterUser;
        public DataBaseServiceModel dataBaseService;
        private string _userToSearch;
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _searchButtonClick, _OwnTimeline_Button_Click;

        public TweetServiceViewModel()
        {
            twitterUser = new TwitterUserModel();
            twitterUser.TweetService.setUserTimeLineTweets("PWr_Wroclaw");
            dataBaseService = new DataBaseServiceModel();
        }

        public string TwitterUser_ProfileName
        {
            get { return twitterUser.ProfileName; }
        }

         public string User_To_Search
        {
            get { return _userToSearch; }
            set
            {
                if (_userToSearch != value)
                {
                    _userToSearch = value;
                    OnPropertyChanged("User_To_Search");
                }
            }
        }

        public string TwitterUser_ProfileImage_URL
        {
            get { return twitterUser.ProfileImageURL; }
        }

        public ObservableCollection<TweetModel> TwitterUser_TweetService_Tweets
        {
            get { return twitterUser.TweetService.Tweets; }
        }

        public ICommand Search_Button_Click
        {
            get { return _searchButtonClick ?? (_searchButtonClick = new CommandHandler(() => SearchButton(), () => CanExecute)); }
        }

         public ICommand OwnTimeline_Button_Click
        {
            get { return _OwnTimeline_Button_Click ?? (_OwnTimeline_Button_Click = new CommandHandler(() => OwnTimelineButton(), () => CanExecute)); }
        }

        public bool CanExecute
        {
            get { return true; }
        }

        public void SearchButton()
        {
            try
            {
                twitterUser.TweetService.setUserTimeLineTweets(User_To_Search);
            }
            catch
            {
                var dialog = new UserNotFoundDialog();
                dialog.Owner = Application.Current.MainWindow;
                dialog.ShowDialog();
               
            }
        }

        public void OwnTimelineButton()
        {
            twitterUser.TweetService.setHomeTimeLineTweets();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CommandHandler : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;

        /// <summary>
        /// Creates instance of the command handler
        /// </summary>
        /// <param name="action">Action to be executed by the command</param>
        /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
        public CommandHandler(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Wires CanExecuteChanged event 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Forcess checking if execute is allowed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
