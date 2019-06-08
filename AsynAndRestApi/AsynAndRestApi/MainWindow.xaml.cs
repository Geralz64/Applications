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

namespace AsynAndRestApi
{
    
    public partial class MainWindow : Window
    {

        public static string imageURl;
        public static IEnumerable<ITweet> tweets;
        public MainWindow()
        {
            InitializeComponent();
        }

        public async void Button_Click(object sender, RoutedEventArgs e)
        {

            await LongTakingTask();

            Image img = new Image();
            imgUser.Source = new BitmapImage(new Uri(imageURl));

            dgInfo.ItemsSource = tweets;
        }



        public static Task LongTakingTask()
        {
            return Task.Run(() =>
            {
                #region keys
                string consumerKey = "yfmUxeF6eGHSkPqwJh3Th1AuN";
                string consumerSecret = "5IU13cfNx983O4DQ9caR45zmll5a9BKLSt1jKKcodV6AAcNXz0";
                string userAccessToken = "217835459-SyE1LoJ70JtLfCZwx9hFwbhernmMjK1FJz6CvPsF";
                string userAccessSecret = "GP64AUOiLNgUj4Z6JSDHyPLv5JjfNT1potfWqHvzjSDQo";
                #endregion

                Auth.SetUserCredentials(consumerKey, consumerSecret, userAccessToken, userAccessSecret);
                var userInfo = User.GetAuthenticatedUser();

                imageURl = userInfo.ProfileImageUrl;

                tweets = Timeline.GetUserTimeline(userInfo.UserIdentifier, 200);

                Thread.Sleep(10000);

            });
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (textBox.Text == "Write your text here")
            {
                textBox.Text = string.Empty;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            imgUser.Source = null;
            dgInfo.ItemsSource = null;
            textBox.Text = string.Empty;

        }
    }
}
