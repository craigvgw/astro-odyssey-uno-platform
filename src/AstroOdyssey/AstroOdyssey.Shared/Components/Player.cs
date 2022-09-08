﻿using System;
using Windows.Foundation;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using static AstroOdyssey.Constants;
using System.Linq;

namespace AstroOdyssey
{
    public class Player : GameObject
    {
        #region Fields

        private readonly Grid _body = new Grid();

        private readonly Image _ship = new Image()
        {
            Stretch = Stretch.Uniform,
        };

        private readonly Image _contentShipBlaze = new Image()
        {
            Stretch = Stretch.Uniform
        };

        private readonly Random random = new Random();

        #endregion

        #region Ctor

        public Player()
        {
            //TODO: Player: fire additional bullet on pizza collection for a certain period of time

            Tag = PLAYER;

            Height = PLAYER_HEIGHT;
            Width = DESTRUCTIBLE_OBJECT_SIZE;

            Health = 100;
            HitPoint = 10;

            // combine power gauge, ship, and blaze
            _body = new Grid();
            _body.Children.Add(_contentShipBlaze);
            _body.Children.Add(_ship);                

            Child = _body;

            Background = new SolidColorBrush(Colors.Transparent);
            BorderBrush = new SolidColorBrush(Colors.Transparent);
            BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
#if DEBUG
            //Background = new SolidColorBrush(Colors.White);
#endif
            CornerRadius = new Microsoft.UI.Xaml.CornerRadius(0);
        }

        #endregion

        #region Properties

        public ShipClass ShipClass { get; set; }

        private bool _isRecoveringFromDamage;
        public bool IsRecoveringFromDamage
        {
            get { return _isRecoveringFromDamage; }
            set
            {
                _isRecoveringFromDamage = value;

                if (_isRecoveringFromDamage)
                    Opacity = 0.4d;
                else
                    Opacity = 1;
            }
        }


        private bool _isShieldUp;
        public bool IsShieldUp
        {
            get { return _isShieldUp; }
            set
            {
                _isShieldUp = value;

                if (_isShieldUp)
                {
                    BorderBrush = new SolidColorBrush(Colors.SkyBlue);
                    BorderThickness = new Microsoft.UI.Xaml.Thickness(0, 3, 0, 0);
                    CornerRadius = new Microsoft.UI.Xaml.CornerRadius(10);
                }
                else
                {
                    BorderBrush = new SolidColorBrush(Colors.Transparent);
                    BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
                    CornerRadius = new Microsoft.UI.Xaml.CornerRadius(0);
                }
            }
        }


        private bool _isFirePowerUp;
        public bool IsFirePowerUp
        {
            get { return _isFirePowerUp; }
            set
            {
                _isFirePowerUp = value;
            }
        }


        private bool _isCloakUp;
        public bool IsCloakUp
        {
            get { return _isCloakUp; }
            set
            {
                _isCloakUp = value;

                if (_isCloakUp)
                    Opacity = 0.6d;
                else
                    Opacity = 1;
            }
        }

        #endregion

        #region Methods

        public void SetAttributes(double speed, Ship ship, double scale = 1)
        {
            Speed = speed;

            this._ship.Source = new BitmapImage(new Uri(ship.ImageUrl, UriKind.RelativeOrAbsolute));
            ShipClass = ship.ShipClass;

            Uri exhaustUri = null;

            exhaustUri = GameObjectTemplates.PLAYER_SHIP_THRUST_TEMPLATES.FirstOrDefault(x => x.ShipClass == ShipClass).AssetUri;

            switch (ShipClass)
            {
                case ShipClass.DEFENDER:
                    HitPoint = 5;
                    break;
                case ShipClass.BERSERKER:
                    HitPoint = 15;
                    break;
                case ShipClass.SPECTRE:
                    HitPoint = 10;
                    break;
                default:
                    break;
            }

            _contentShipBlaze.Source = new BitmapImage(exhaustUri);
            _contentShipBlaze.Width = _body.Width;
            _contentShipBlaze.Height = _body.Height;
           
            Height = PLAYER_HEIGHT * scale;
            Width = DESTRUCTIBLE_OBJECT_SIZE * scale;

            HalfWidth = Width / 2;
        }

        public void ReAdjustScale(double scale)
        {
            Height = PLAYER_HEIGHT * scale;
            Width = DESTRUCTIBLE_OBJECT_SIZE * scale;
        }

        public void TriggerPowerUp(PowerUpType powerUpType)
        {
            Speed += 1;          
        }

        public void PowerUpCoolDown()
        {            
            Speed -= 1;
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

            return left + gameObject.HalfWidth < playerX && left + gameObject.HalfWidth > playerX - 250;
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

            return left + gameObject.HalfWidth > playerX && left + gameObject.HalfWidth <= playerX + 250;
        }

        public new Rect GetRect()
        {
            return new Rect(x: Canvas.GetLeft(this) + 5, y: Canvas.GetTop(this) + 25, width: Width - 5, height: Height - Height / 2);
        }

        //public void SetRecoilEffect()
        //{
        //    BorderThickness = new Microsoft.UI.Xaml.Thickness(left: 0, top: 4, right: 0, bottom: 0);
        //}

        //public void CoolDownRecoilEffect() 
        //{
        //    if (BorderThickness.Top != 0)
        //    {
        //        BorderThickness = new Microsoft.UI.Xaml.Thickness(left: 0, top: BorderThickness.Top - 1, right: 0, bottom: 0);
        //    }
        //}

        #endregion
    }
}
