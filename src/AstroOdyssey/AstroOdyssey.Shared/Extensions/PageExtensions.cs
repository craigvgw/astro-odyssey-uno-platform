﻿using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Threading.Tasks;
using Page = Microsoft.UI.Xaml.Controls.Page;

namespace AstroOdyssey
{
    public static class PageExtensions
    {
        #region Methods

        #region Public      

        public async static Task PlayLoadedTransition(this UIElement page)
        {
            if (page is not null)
            {
                var timeSpan = TimeSpan.FromMilliseconds(18);
                page.Opacity = 0;
                var skipAnimation = 100;

                while (skipAnimation > 0)
                {
                    skipAnimation--;
                    page.Opacity += 0.1d;
                    await Task.Delay(timeSpan);

                    if (page.Opacity >= 1)
                        break;
                }
            }
        }

        public async static Task PlayUnLoadedTransition(this UIElement page)
        {
            if (page is not null)
            {
                var timeSpan = TimeSpan.FromMilliseconds(18);
                page.Opacity = 1;
                var skipAnimation = 100;

                while (skipAnimation > 0)
                {
                    skipAnimation--;
                    page.Opacity -= 0.1d;
                    await Task.Delay(timeSpan);

                    if (page.Opacity <= 0)
                        break;
                }
            }
        }

        public static void ShowError(
            this Page page,
            ProgressBar progressBar,
            TextBlock messageBlock,
            string message,
            params Button[] actionButtons)
        {
            progressBar.ShowPaused = true;
            progressBar.ShowError = true;

            messageBlock.Foreground = new SolidColorBrush(Colors.Crimson);
            messageBlock.Text = message;
            messageBlock.Visibility = Visibility.Visible;

            foreach (var actionButton in actionButtons)
            {
                EnableActionButton(actionButton);
            }
        }

        public static void RunProgressBar(
            this Page page,
            ProgressBar progressBar,
            TextBlock messageBlock,
            string message = null,
            params Button[] actionButtons)
        {
            progressBar.IsIndeterminate = true;
            progressBar.ShowError = false;
            progressBar.ShowPaused = false;

            messageBlock.Foreground = new SolidColorBrush(Colors.White);
            messageBlock.Text = message;
            messageBlock.Visibility = Visibility.Collapsed;

            foreach (var actionButton in actionButtons)
            {
                DisableActionButton(actionButton);
            }
        }

        public static void StopProgressBar(
            this Page page,
            ProgressBar progressBar,
            params Button[] actionButtons)
        {
            progressBar.ShowError = false;
            progressBar.ShowPaused = true;

            foreach (var actionButton in actionButtons)
            {
                EnableActionButton(actionButton);
            }
        }

        #endregion

        #region Private

        private static void EnableActionButton(Button button)
        {
            button.IsEnabled = true;
        }

        private static void DisableActionButton(Button button)
        {
            button.IsEnabled = false;
        }

        #endregion

        #endregion
    }
}
