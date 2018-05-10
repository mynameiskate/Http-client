using System.Windows;
using System.Windows.Controls;

namespace HttpProtocol
{
    public class WebBrowserHelper
    {
        public static readonly DependencyProperty BodyProperty =
                DependencyProperty.RegisterAttached("Body", typeof(string), typeof(WebBrowserHelper), new PropertyMetadata(OnBodyChanged));

        public static string GetBody(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(BodyProperty);
        }

        public static void SetBody(DependencyObject dependencyObject, string body)
        {
            dependencyObject.SetValue(BodyProperty, body);
        }

        private static void OnBodyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var webBrowser = (WebBrowser)obj;
            string msg = (string)e.NewValue;
            if (!string.IsNullOrEmpty(msg))
            {
                webBrowser.NavigateToString((string)e.NewValue);
            }
        }
    }
}
