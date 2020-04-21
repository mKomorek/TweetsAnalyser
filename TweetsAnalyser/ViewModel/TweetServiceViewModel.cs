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
        private ObservableCollection<TweetModel> tweetCollection;
        private string _userToSearch, deleteAddButtonContent = "Zapisz Tweeta";
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand _searchButtonClick, _OwnTimeline_Button_Click, _goToSavedButtonClick, _gotToTweetsButtonClick, _addToDb;
        private Visibility userPanelVisibility;

        public TweetServiceViewModel()
        {
            twitterUser = new TwitterUserModel();
            twitterUser.TweetService.setUserTimeLineTweets("PWr_Wroclaw");
            tweetCollection = twitterUser.TweetService.Tweets;
            dataBaseService = new DataBaseServiceModel();
        }

        public string TwitterUser_ProfileName
        {
            get {return twitterUser.ProfileName;}
        }

        public TweetModel SelectedTweet { get; set; }

        public string DeleteAddButtonContent
        {
            get {return deleteAddButtonContent;}
            set {deleteAddButtonContent = value; OnPropertyChanged("DeleteAddButtonContent"); OnPropertyChanged("AddDeleteDB");}
        }

        public Visibility User_Panel_Visibility
        {
            get {return userPanelVisibility;}
            set {userPanelVisibility = value; OnPropertyChanged("User_Panel_Visibility");}
        }

        public string User_To_Search
        {
            get {return _userToSearch;}
            set {_userToSearch = value; OnPropertyChanged("User_To_Search");}
        }

        public string TwitterUser_ProfileImage_URL
        {
            get {return twitterUser.ProfileImageURL;}
        }

        public ObservableCollection<TweetModel> Tweet_Collection
        {
            get {return tweetCollection;}
            set {tweetCollection = value; OnPropertyChanged("Tweet_Collection");}
        }

        public ICommand AddDeleteDB
        {
            get
            {
                if (DeleteAddButtonContent == "Zapisz Tweeta")
                {
                    return new CommandHandler(() => AddToDBButton(), () => CanExecute);
                }
                else
                {
                    return new CommandHandler(() => DeleteFromDBButton(), () => CanExecute);
                }
            }
        }
        public ICommand Search_Button_Click
        {
            get {return new CommandHandler(() => SearchButton(), () => CanExecute);}
        }
        public ICommand Go_To_Tweets_Button_Click
        {
            get {return new CommandHandler(() => GoToTweetsButton(), () => CanExecute);}
        }
        public ICommand Go_To_Save_Button_Click
        {
            get {return new CommandHandler(() => GoToSavedButton(), () => CanExecute);}
        }

        public ICommand OwnTimeline_Button_Click
        {
            get {return new CommandHandler(() => OwnTimelineButton(), () => CanExecute);}
        }

        public bool CanExecute {get {return true;}}

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
        public void AddToDBButton()
        {
            dataBaseService.add(SelectedTweet);
        }
        public void DeleteFromDBButton()
        {
            dataBaseService.remove(SelectedTweet);
            Tweet_Collection.Remove(SelectedTweet);
        }
        private void GoToSavedButton()
        {
            DeleteAddButtonContent = "Usuń Tweeta";
            Tweet_Collection = dataBaseService.getAllFavoriteTweets();
            User_Panel_Visibility = Visibility.Hidden;
        }

        private void GoToTweetsButton()
        {
            DeleteAddButtonContent = "Zapisz Tweeta";
            Tweet_Collection = twitterUser.TweetService.Tweets;
            User_Panel_Visibility = Visibility.Visible;
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
