using Xamarians.Interfaces;
using Xamarin.Forms;

namespace Xamarians
{
    public class Loader
    {
        public static StackLayout RegisterLoader(ContentPage contentPage, string imageName)
        {
            var content = contentPage.Content;
            var overlay = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            var activityIndicatorWebView = new WebView()
            {
                IsEnabled = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            activityIndicatorWebView.Source = new HtmlWebViewSource
            {
                Html = $@"<html><body bgcolor='#0e0e0e'>
                            <img src='{imageName}'
                            style='position:absolute; top:50%; left:50%; margin-top:-25px; margin-left:-25px; height:50px; width:50px' />
                            </body>
                            </html>",
                BaseUrl = DependencyService.Get<IGif>().GetGifImageUrl()
            };

            var stackLayout = new StackLayout()
            {
                BackgroundColor = Color.DarkGray,
                Opacity = 0.5
            };
            stackLayout.Children.Add(activityIndicatorWebView);

            AbsoluteLayout.SetLayoutFlags(content, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(content, new Rectangle(0f, 0f, 1, 1));
            AbsoluteLayout.SetLayoutFlags(stackLayout, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stackLayout, new Rectangle(0f, 0f, 1, 1));

            contentPage.Content = overlay;

            overlay.Children.Add(content);
            overlay.Children.Add(stackLayout);

            //activityIndicator.IsRunning = true;
            stackLayout.IsVisible = false;

            return stackLayout;
        }
    }
}
