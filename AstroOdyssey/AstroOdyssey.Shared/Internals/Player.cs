﻿using System;
using Windows.Foundation;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using static AstroOdyssey.Constants;

namespace AstroOdyssey
{
    public class Player : GameObject
    {
        #region Fields

        private readonly Grid content = new Grid();


        private readonly Image contentShip = new Image()
        {
            Stretch = Stretch.Uniform,
        };

        private readonly Image contentShipBlaze = new Image()
        {
            Stretch = Stretch.Uniform,
            Margin = new Microsoft.UI.Xaml.Thickness(0, 50, 0, 0)
        };

        private readonly Border contentShipPowerGauge = new Border()
        {
            Height = 5,
            Width = 0,
            CornerRadius = new Microsoft.UI.Xaml.CornerRadius(50),
            VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Top,
            HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Center,
            Margin = new Microsoft.UI.Xaml.Thickness(0, 25, 0, 0),
        };

        private readonly Random random = new Random();

        #endregion

        #region Ctor

        public Player()
        {
            //TODO: Get side kicks which shoot additional projectile, lost on impact with enemy or meteor
            //TODO: Develop shield which protects damage for a certain number of hits

            Tag = Constants.PLAYER;

            Background = new SolidColorBrush(Colors.Transparent);
            Height = Constants.DefaultPlayerHeight;
            Width = Constants.DefaultGameObjectSize;

            Health = 100;
            HitPoint = 10;

            // combine power gauge, ship, and blaze
            content = new Grid();
            content.Children.Add(contentShipPowerGauge);
            content.Children.Add(contentShipBlaze);
            content.Children.Add(contentShip);

            Child = content;

#if DEBUG
            //Background = new SolidColorBrush(Colors.White);
#endif
        }

        #endregion

        #region Properties

        public bool IsInEtherealState { get; set; }

        public double ExhaustHeight { get; set; } = 50;

        #endregion

        #region Methods

        public void SetAttributes(double speed, double scale = 1)
        {
            Speed = speed;

            Uri shipUri = null;
            var playerShipType = random.Next(1, 13);

            ExhaustHeight = 50;

            switch (playerShipType)
            {
                case 1:
                    shipUri = new Uri("ms-appx:///Assets/Images/satellite_B.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 35;
                    break;
                case 2:
                    shipUri = new Uri("ms-appx:///Assets/Images/satellite_C.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 35;
                    break;
                case 3:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_C.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 55;
                    break;
                case 4:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_D.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 50;
                    break;
                case 5:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_E.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 50;
                    break;
                case 6:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_F.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 50;
                    break;
                case 7:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_G.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 50;
                    break;
                case 8:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_H.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 50;
                    break;
                case 9:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_I.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 35;
                    break;
                case 10:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_J.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 35;
                    break;
                case 11:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_K.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 35;
                    break;
                case 12:
                    shipUri = new Uri("ms-appx:///Assets/Images/ship_L.png", UriKind.RelativeOrAbsolute);
                    ExhaustHeight = 35;
                    break;
            }

            contentShip.Source = new BitmapImage(shipUri);

            var exhaustUri = new Uri("ms-appx:///Assets/Images/effect_purple.png", UriKind.RelativeOrAbsolute);

            contentShipBlaze.Source = new BitmapImage(exhaustUri);
            contentShipBlaze.Width = contentShip.Width;

            contentShipBlaze.Height = ExhaustHeight * scale;
            contentShipBlaze.Margin = new Microsoft.UI.Xaml.Thickness(0, 50 * scale, 0, 0);

            contentShipPowerGauge.Margin = new Microsoft.UI.Xaml.Thickness(0, 25 * scale, 0, 0);

            Height = Constants.DefaultPlayerHeight * scale;
            Width = Constants.DefaultGameObjectSize * scale;
        }

        public void ReAdjustScale(double scale)
        {
            contentShipBlaze.Height = ExhaustHeight * scale;
            contentShipBlaze.Margin = new Microsoft.UI.Xaml.Thickness(0, 50 * scale, 0, 0);

            contentShipPowerGauge.Margin = new Microsoft.UI.Xaml.Thickness(0, 25 * scale, 0, 0);

            Height = Constants.DefaultPlayerHeight * scale;
            Width = Constants.DefaultGameObjectSize * scale;
        }

        public void SetPowerGauge(double powerGauge)
        {
            contentShipPowerGauge.Width = powerGauge * 3;
        }

        public void TriggerPowerUp(PowerUpType powerUpType)
        {
            Speed += 1;
            contentShipPowerGauge.Width = Width / 2;

            var exhaustUri = new Uri("ms-appx:///Assets/Images/effect_yellow.png", UriKind.RelativeOrAbsolute);
            contentShipBlaze.Source = new BitmapImage(exhaustUri);
            contentShipPowerGauge.Background = Colors.Gold;

            //switch (powerUpType)
            //{
            //case PowerUpType.RAPIDSHOT_ROUNDS:
            //    {
            //        var exhaustUri = new Uri("ms-appx:///Assets/Images/effect_yellow.png", UriKind.RelativeOrAbsolute);
            //        contentShipBlaze.Source = new BitmapImage(exhaustUri);
            //        contentShipPowerGauge.Background = new SolidColorBrush(SPECIAL_ROUNDS_COLOR);
            //    }
            //    break;
            //case PowerUpType.DEADSHOT_ROUNDS:
            //    contentShipPowerGauge.Background = new SolidColorBrush(SPECIAL_ROUNDS_COLOR);
            //    break;
            //case PowerUpType.SONICSHOT_ROUNDS:
            //    contentShipPowerGauge.Background = new SolidColorBrush(SPECIAL_ROUNDS_COLOR);
            //    break;
            //default:
            //    break;
            //}
        }

        public void TriggerPowerDown()
        {
            var exhaustUri = new Uri("ms-appx:///Assets/Images/effect_purple.png", UriKind.RelativeOrAbsolute);
            contentShipBlaze.Source = new BitmapImage(exhaustUri);
            Speed -= 1;
            contentShipPowerGauge.Width = 0;
        }

        /// <summary>
        /// Gets the player health points.
        /// </summary>
        /// <returns></returns>
        public string GetHealthPoints()
        {
            var healthPoints = Health / HitPoint;
            var healthIcon = "❤️";
            var health = string.Empty;

            for (int i = 0; i < healthPoints; i++)
            {
                health += healthIcon;
            }

            return health;
        }

        /// <summary>
        /// Checks if there is any game object within the left side range of the player.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public bool AnyObjectsOnTheLeftProximity(GameObject gameObject)
        {
            var left = gameObject.GetX();
            var playerX = GetX();

            return left + gameObject.Width / 2 < playerX && left + gameObject.Width / 2 > playerX - 250;
        }

        /// <summary>
        /// Checks if there is any game object within the right side range of the player.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public bool AnyObjectsOnTheRightProximity(GameObject gameObject)
        {
            var left = gameObject.GetX();
            var playerX = GetX();

            return left + gameObject.Width / 2 > playerX && left + gameObject.Width / 2 <= playerX + 250;
        }

        public new Rect GetRect()
        {
            return new Rect(x: Canvas.GetLeft(this) + 5, y: Canvas.GetTop(this) + 25, width: Width - 5, height: Height - Height / 2);
        }


        #endregion
    }
}
