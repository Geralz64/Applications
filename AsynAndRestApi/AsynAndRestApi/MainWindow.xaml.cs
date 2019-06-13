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
        public static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
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
            catch (OperationCanceledException ex)
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

        public void Parallel_Click_1(object sender, RoutedEventArgs e)
        {
            //ParallelMethodBlocksUIThread();

            ParallelMethodNotBlockingUIThread();

            textBox.Text = "Operation was completed";

        }

        //Parallel example that blocks UI thread
        public void ParallelMethodBlocksUIThread()
        {
            var parallelLoopOptions = new ParallelOptions()
            {
                CancellationToken = cancellationTokenSource.Token,
                MaxDegreeOfParallelism = 2
            };

            Parallel.Invoke(parallelLoopOptions,

                () => { AddNumbers(1, 2); },

                () => { SubstractNumbers(1, 2); },

                () => { MultiplyNumbers(1, 2); },

                () => { DivideNumbers(1, 2); }

                );

            textBox.Text = "Process completed";

        }

        public async void ParallelMethodNotBlockingUIThread()
        {

            Task addNumbers = new Task(() => AddNumbers(1, 2));
            Task substractNumbers = new Task(() => SubstractNumbers(1, 2));
            Task multiplyNumbers = new Task(() => MultiplyNumbers(1, 2));
            Task divideNumbers = new Task(() => DivideNumbers(1, 2));

            await Task.WhenAll(addNumbers, substractNumbers, multiplyNumbers, divideNumbers);

        }



        public static void AddNumbers(int x, int y)
        {
                Thread.Sleep(3000);
        }

        public static void SubstractNumbers(int x, int y)
        {
                Thread.Sleep(5000);
        }

        public static void MultiplyNumbers(int x, int y)
        {
                Thread.Sleep(2000);
            
        }
        public static void DivideNumbers(int x, int y)
        {

                Thread.Sleep(1000);
            
        }



    }
}
