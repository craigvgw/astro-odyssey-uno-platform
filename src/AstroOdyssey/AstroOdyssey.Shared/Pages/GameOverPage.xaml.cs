﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Threading.Tasks;
using static AstroOdyssey.Constants;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AstroOdyssey
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GameOverPage : Page
    {
        public GameOverPage()
        {
            InitializeComponent();
            Loaded += GameOverPage_Loaded;
        }

        private void GameOverPage_Loaded(object sender, RoutedEventArgs e)
        {
            var score = App.GetScore();

            ScoreText.Text = "You Scored " + score + (score == 0 ? "\nNo luck!" : score <= 400 ? "\nGood game!" : "\nGreat game!");
        }

        private void PlayAgainButton_Click(object sender, RoutedEventArgs e)
        {
            AudioHelper.PlaySound(SoundType.MENU_SELECT);
            App.NavigateToPage(typeof(ShipSelectionPage));
            AudioHelper.PlaySound(SoundType.GAME_INTRO);
        }
    }
}
