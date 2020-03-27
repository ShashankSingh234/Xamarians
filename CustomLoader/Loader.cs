using System;
using System.IO;
using System.Reflection;
using Xamarians.Interfaces;
using Xamarin.Forms;

namespace Xamarians
{
    public class Loader
    {
        /// <summary>
        /// Initialize loader.
        /// </summary>
        /// <param name="contentPage">Page on which loader will be registered.</param>
        /// <param name="imageName">Loader image name with extention.</param>
        /// <param name="loadingMessage">Message to show with loader.</param>
        /// <returns></returns>
        public static StackLayout RegisterLoader(ContentPage contentPage, string imageName, string loadingMessage = null)
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
                Html = $@"<html>
                        <body bgcolor = '#0e0e0e'>
                        <div style = 'height: 100%; position: relative;'>
                          <div style = 'margin: 0; position: absolute; top: 50%; left: 50%; -ms-transform: translate(-50%, -50%); transform: translate(-50%, -50%); text-align: center;'>
                          <img src = '{imageName}' style = 'height:50px; width:50px'/>
                          <p style = 'color:white;'>{loadingMessage}</p>
                          </div>
                        </div>
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

            stackLayout.IsVisible = false;

            return stackLayout;
        }
    }
}
