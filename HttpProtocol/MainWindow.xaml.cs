using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;

namespace HttpProtocol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _model;
        public MainWindow()
        {
            InitializeComponent();

            _model = new MainWindowViewModel();  
            DataContext = _model;
            /*var message = HttpHelper.Get("https://vk.com/kusochekf");
            Console.WriteLine(message);
            var postData = "thing1=hello";
            postData += "&thing2=world";
            message = HttpHelper.Post("http://ptsv2.com/t/tzxbb-1525113747/post", postData);
            message = HttpHelper.Head("https://www.imdb.com/"); */
        }

        private async void Navigate()
        {
            _model.Message = string.Empty;
            _model.Status = string.Empty;

            try
            {
                if (String.IsNullOrEmpty(uriTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter correct URI", "Field is empty", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (String.IsNullOrEmpty(methodBox.Text))
                {
                    MessageBox.Show("Choose method type", "Field is empty", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _model.Message = await RequestSender.SendRequest(methodBox.Text, uriTextBox.Text, dataTextBox.Text);
                    _model.Status = RequestSender.Status;
                }
            }
            catch (WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;
                if (response == null)
                {
                    _model.Status = ex.Message;
                }
                else
                {
                    string status;
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        status = reader.ReadToEnd();
                    }
                    _model.Message = "Response Code: " + (int)response.StatusCode + " : " + status + "\n";
                }
            }
            catch (Exception ex)
            {
                _model.Status = ex.Message;
            }

        }

        private async void startBtn_Click (object sender, RoutedEventArgs e)
        {
            _model.Message = string.Empty;
            _model.Status = string.Empty;

            try
            {
                if (String.IsNullOrEmpty(uriTextBox.Text.Trim()))
                {
                    MessageBox.Show("Enter correct URI", "Field is empty", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (String.IsNullOrEmpty(methodBox.Text))
                {
                    MessageBox.Show("Choose method type", "Field is empty", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _model.Message = await RequestSender.SendRequest(methodBox.Text, uriTextBox.Text, dataTextBox.Text);
                    _model.Status = RequestSender.Status;
                }
            }
            catch (WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;
                if (response == null)
                {
                    _model.Status = ex.Message;
                }
                else
                {
                    string status;
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        status = reader.ReadToEnd();
                    }
                    _model.Message = "Response Code: " + (int)response.StatusCode + " : " + status + "\n";
                }
            }
            catch (Exception ex)
            {
                _model.Status = ex.Message;
            }
        }

        private void requestWebBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            string currentUri = string.Empty;
            if (e.Uri != null)
            {
                uriTextBox.Text = e.Uri.AbsolutePath;
                Navigate();
            }
            dynamic activeX = requestWebBrowser.GetType().InvokeMember("ActiveXInstance",
                BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, requestWebBrowser, new object[] { });
            activeX.Silent = true;
        }
    }
}
