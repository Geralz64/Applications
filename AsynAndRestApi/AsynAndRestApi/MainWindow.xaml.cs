using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Tweetinvi;
using Tweetinvi.Models;
using System.Linq;
using System.Windows.Media;

namespace AsynAndRestApi
{

    public partial class MainWindow : Window
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();

        }

        public async void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var userInfo = GetTwitterInfo();

                var tweets = await LongTakingProcess(userInfo, cancellationTokenSource.Token);

                var imageURl = userInfo.ProfileImageUrl;

                Image img = new Image();
                imgUser.Source = new BitmapImage(new Uri(imageURl));

                dgInfo.ItemsSource = tweets;

            }
            catch (OperationCanceledException ex)

            {
                textBox.Text = "Operation was cancelled by the user";
                textBox.Foreground = new SolidColorBrush(Colors.Red);
            }

        }

        public static Task<List<ITweet>> LongTakingProcess(IAuthenticatedUser userInfo, CancellationToken cancellationToken)
        {
            try
            {

                Task<List<ITweet>> task = null;

                var tweets = Timeline.GetUserTimeline(userInfo.UserIdentifier, 200);

                var newTweets = new List<ITweet>();

                task = Task.Run(() =>
                {
                    foreach (var tweet in tweets)
                    {
                        newTweets.Add(tweet);

                        cancellationToken.ThrowIfCancellationRequested();
                        Thread.Sleep(5000);

                    }

                    newTweets = newTweets.Where(t => t.Text.Contains("#100DaysOfCode")).OrderBy(t => t.Id).ToList<ITweet>();

                    return newTweets;

                });

                return task;
            }
            catch(OperationCanceledException ex)
            {

                throw;
            }
        }


        public static IAuthenticatedUser GetTwitterInfo()
        {
            var tokenSource2 = new CancellationTokenSource();
            #region keys
            string consumerKey = "yfmUxeF6eGHSkPqwJh3Th1AuN";
            string consumerSecret = "5IU13cfNx983O4DQ9caR45zmll5a9BKLSt1jKKcodV6AAcNXz0";
            string userAccessToken = "217835459-SyE1LoJ70JtLfCZwx9hFwbhernmMjK1FJz6CvPsF";
            string userAccessSecret = "GP64AUOiLNgUj4Z6JSDHyPLv5JjfNT1potfWqHvzjSDQo";
            #endregion

            Auth.SetUserCredentials(consumerKey, consumerSecret, userAccessToken, userAccessSecret);
            var userInfo = User.GetAuthenticatedUser();
            return userInfo;

        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (textBox.Text == "Write your text here")
            {
                textBox.Text = string.Empty;
            }

        }

        private void Clear_Click_1(object sender, RoutedEventArgs e)
        {

            imgUser.Source = null;
            dgInfo.ItemsSource = null;
            textBox.Text = string.Empty;

        }

        public void Cancel_Click_1(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource.Cancel();

        }



    }
}
