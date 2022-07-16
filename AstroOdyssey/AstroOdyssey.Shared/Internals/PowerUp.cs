﻿using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

namespace AstroOdyssey
{
    public class PowerUp : GameObject
    {
        #region Fields
        
        private readonly Image content = new Image() { Stretch = Stretch.Uniform }; 

        #endregion

        #region Ctor

        public PowerUp()
        {
            Tag = Constants.POWERUP;
            Height = Constants.DefaultGameObjectSize;
            Width = Constants.DefaultGameObjectSize;
            Child = content;
            YDirection = YDirection.DOWN;
        } 

        #endregion

        #region Methods

        public void SetAttributes(double speed, double scale = 1)
        {
            Speed = speed;

            var uri = new Uri("ms-appx:///Assets/Images/icon_exclamationSmall.png", UriKind.RelativeOrAbsolute);
            Health = 10;

            content.Source = new BitmapImage(uri);

            Height = Constants.DefaultGameObjectSize * scale;
            Width = Constants.DefaultGameObjectSize * scale;
        } 

        #endregion
    }
}
