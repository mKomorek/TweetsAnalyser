using TweetsAnalyser.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Windows;
using TweetsAnalyser.View;

namespace TweetsAnalyser.ViewModel
{
    /// <summary>
    /// ViewModel of a MainWindow View. This is one and only ViewModel in the app.
    /// Contains all methods which serve the View => from buttons, to visibility changes.
    /// Implements INotifyPropertyChanged interface to make property updates available.
    /// </summary>
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public TwitterUserModel twitterUser;
        public DataBaseServiceModel dataBaseService;
        private ObservableCollection<TweetModel> tweetCollection;
        private string _userToSearch, deleteAddButtonContent = "Zapisz Tweeta";
        public event PropertyChangedEventHandler PropertyChanged;
        private Visibility userPanelVisibility;

        /// <summary>
        /// Setup main services => Twitter' API and EntityFramework' DB.
        /// Sets the default scroll page to PWr_Wroclaw' timeline. 
        /// (scroll page always shows the content of <c>tweetCollection</c> member)
        /// </summary>
        public MainWindowViewModel()
        {
            twitterUser = new TwitterUserModel();
            dataBaseService = new DataBaseServiceModel();
            twitterUser.TweetService.setUserTimeLineTweets("PWr_Wroclaw");
            tweetCollection = twitterUser.TweetService.Tweets;
        }

        /// <summary>
        /// Gets logged user' profile name.
        /// </summary>
        public string TwitterUser_ProfileName
        {
            get {return twitterUser.ProfileName;}
        }

        /// <summary>
        /// Gets logged user' profile image url.
        /// </summary>
        public string TwitterUser_ProfileImage_URL
        {
            get {return twitterUser.ProfileImageURL;}
        }

        /// <summary>
        /// Sets the SelectedTweet property to TweetModel object which is currently selected in the ListBox tweet scroller.
        /// Please refer the View/MainWindow.xaml/MainListBox.
        /// </summary>
        public TweetModel SelectedTweet {get; set;}

        /// <summary>
        /// Sets and gets the visibility property of TweetSearch stack pannel.
        /// Please refer the View/MainWindow.xaml/TweetSearch.
        /// </summary>
        public Visibility User_Panel_Visibility
        {
            get {return userPanelVisibility;}
            set {userPanelVisibility = value; OnPropertyChanged("User_Panel_Visibility");}
        }

        /// <summary>
        /// Sets and gets the username of user which' timeline should be downloaded via API.
        /// </summary>
        public string User_To_Search
        {
            get {return _userToSearch;}
            set {_userToSearch = value; OnPropertyChanged("User_To_Search");}
        }

        /// <summary>
        /// Sets and gets the main tweet collection. This is the collection which is displayed in the app.
        /// It holds currently downloaded tweets.
        /// </summary>
        public ObservableCollection<TweetModel> Tweet_Collection
        {
            get {return tweetCollection;}
            set {tweetCollection = value; OnPropertyChanged("Tweet_Collection");}
        }

        //****                ****//
        //**** BUTTON SECTION ****//
        //****                ****//

        /// <summary>
        /// Depending on actual app mode (downloaded or saved tweets display mode) returns proper function to bind the add/del 
        /// multi-functional button to.
        /// If <c>DeleteAddButtonContent</c> is set to 'Zapisz Tweeta' we are in downloaded tweets dispaly mode -> we can add some of them to DB.
        /// Thats why AddToDBButton function in returned. Similarly in saved tweets mode.
        /// Please refer the View/MainWindow.xaml/MultiButton.
        /// <see cref="DeleteAddButtonContent"/>
        /// <see cref="AddToDBButton"/>
        /// <see cref="DeleteFromDBButton"/>
        /// <see cref="CommandHandler"/>
        /// </summary>
        public ICommand AddDeleteDB
        {
            get
            {
                if (DeleteAddButtonContent == "Zapisz Tweeta")
                {
                    return new CommandHandler(() => AddToDBButton(), () => {return true;});
                }
                else
                {
                    return new CommandHandler(() => DeleteFromDBButton(), () => {return true;});
                }
            }
        }

        /// <summary>
        /// Binds SearchButton to proper function.
        /// Please refer the View/MainWindow.xaml/SearchButton.
        /// <see cref="CommandHandler"/>
        /// <see cref="SearchButton"/>
        /// </summary>
        public ICommand Search_Button_Click
        {
            get {return new CommandHandler(() => SearchButton(), () => {return true;});}
        }

        /// <summary>
        /// Binds DownloadedModeButton to proper function.
        /// Please refer the View/MainWindow.xaml/DownloadedModeButton.
        /// <see cref="CommandHandler"/>
        /// <see cref="GoToTweetsButton"/>
        /// </summary>
        public ICommand Go_To_Tweets_Button_Click
        {
            get {return new CommandHandler(() => GoToTweetsButton(), () => {return true;});}
        }

        /// <summary>
        /// Binds SavedModeButton to proper function.
        /// Please refer the View/MainWindow.xaml/SavedModeButton.
        /// <see cref="CommandHandler"/>
        /// <see cref="GoToSavedButton"/>
        /// </summary>
        public ICommand Go_To_Save_Button_Click
        {
            get {return new CommandHandler(() => GoToSavedButton(), () => {return true;});}
        }

        /// <summary>
        /// Binds DownloadOwnButton to proper function.
        /// Please refer the View/MainWindow.xaml/DownloadOwnButton.
        /// <see cref="CommandHandler"/>
        /// <see cref="OwnTimelineButton"/>
        /// </summary>
        public ICommand OwnTimeline_Button_Click
        {
            get {return new CommandHandler(() => OwnTimelineButton(), () => {return true;});}
        }

        /// <summary>
        /// Tries to pull and save <c>User_To_Serach</c> timeline from API. If any exception is thrown
        /// error dialog pops up.
        /// <see cref="View.UserNotFoundDialog"/>
        /// <see cref="Model.TweetServiceModel.setUserTimeLineTweets(string)"/>
        /// </summary>
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

        /// <summary>
        /// Pulls and saves logged user' own timeline from API.
        /// <see cref="Model.TweetServiceModel.setUserTimeLineTweets(string)"/>
        /// </summary>
        public void OwnTimelineButton()
        {
            twitterUser.TweetService.setHomeTimeLineTweets();
        }

        /// <summary>
        /// Adds TweetModel object to database. This object is get from SelectedTweet property.
        /// Method checks if property is not empty first.
        /// <see cref="Model.DataBaseServiceModel.add(TweetModel)"/>
        /// <see cref="SelectedTweet"/>
        /// </summary>
        public void AddToDBButton()
        {
            if(SelectedTweet != null)
            {
                dataBaseService.add(SelectedTweet);
            }
        }

        /// <summary>
        /// Deletes TweetModel object from database. This object is get from SelectedTweet property.
        /// Method checks if property is not empty first.
        /// <see cref="Model.DataBaseServiceModel.remove(TweetModel)"/>
        /// <see cref="SelectedTweet"/>
        /// </summary>
        public void DeleteFromDBButton()
        {
            if(SelectedTweet != null)
            {
                dataBaseService.remove(SelectedTweet);
                Tweet_Collection.Remove(SelectedTweet);
            }
        }

        /// <summary>
        /// Gets and sets the content of MultiButton.
        /// Please refer the View/MainWindow.xaml/MultiButton.
        /// </summary>
        public string DeleteAddButtonContent
        {
            get { return deleteAddButtonContent; }
            set { deleteAddButtonContent = value; OnPropertyChanged("DeleteAddButtonContent"); OnPropertyChanged("AddDeleteDB"); }
        }

        /// <summary>
        /// Triggers the mode change to saved tweets mode.
        /// It swaps the donwloaded tweets with the DB ones and updates the MulitButton content. 
        /// It also changes the visibility of TweetSearch stack pannel.
        /// Please refer the View/MainWindow.xaml/TweetSearch.
        /// Please refer the View/MainWindow.xaml/MultiButton.
        /// <see cref="Model.DataBaseServiceModel.getAllFavoriteTweets"/>
        /// </summary>
        private void GoToSavedButton()
        {
            DeleteAddButtonContent = "Usuń Tweeta";
            Tweet_Collection = dataBaseService.getAllFavoriteTweets();
            User_Panel_Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Triggers the mode change to downloaded tweets mode.
        /// It swaps the DB tweets with the downloaded ones and updates the MulitButton content. 
        /// It also changes the visibility of TweetSearch stack pannel.
        /// Please refer the View/MainWindow.xaml/TweetSearch.
        /// Please refer the View/MainWindow.xaml/MultiButton.
        /// <see cref="Model.TweetServiceModel"/>
        /// </summary>
        private void GoToTweetsButton()
        {
            DeleteAddButtonContent = "Zapisz Tweeta";
            Tweet_Collection = twitterUser.TweetService.Tweets;
            User_Panel_Visibility = Visibility.Visible;
        }
        //****                    ****//
        //**** BUTTON SECTION END ****//
        //****                    ****//

        /// <summary>
        /// Triggers the property-changed event. Every interested party will be notified.
        /// </summary>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Simple ICommand interface wrapper.
    /// </summary>
    public class CommandHandler : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;

        /// <summary>
        /// Creates instance of the command handler.
        /// </summary>
        /// <param name="action">Action to be executed by the command</param>
        /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
        public CommandHandler(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Wires CanExecuteChanged event.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Forces checking if execute is allowed.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke();
        }

        /// <summary>
        /// Overloaded ICommand function.
        /// Defines which command should be executed.
        /// </summary>
        public void Execute(object parameter)
        {
            _action();
        }
    }
}
