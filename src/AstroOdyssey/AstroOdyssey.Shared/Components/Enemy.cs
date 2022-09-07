﻿using System;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

namespace AstroOdyssey
{
    public class Enemy : GameObject
    {
        #region Fields

        private readonly Image content = new Image() { Stretch = Stretch.Uniform };

        private readonly Random random = new Random();

        #endregion

        #region Ctor

        public Enemy()
        {
            Tag = Constants.ENEMY;
            Height = Constants.DESTRUCTIBLE_OBJECT_SIZE;
            Width = Constants.DESTRUCTIBLE_OBJECT_SIZE;

            IsDestructible = true;
            Child = content;
            YDirection = YDirection.DOWN;

            Background = new SolidColorBrush(Colors.Transparent);
            BorderBrush = new SolidColorBrush(Colors.Transparent);
            BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
        }

        #endregion

        #region Properties

        public int ProjectileSpawnCounter { get; set; }

        public int ProjectileSpawnDelay { get; set; } = 60;

        public int OverPoweredProjectileSpawnCounter { get; set; }

        public int OverPoweredProjectileSpawnDelay { get; set; } = 5;

        public bool IsPlayerColliding { get; set; }

        public bool IsProjectileFiring { get; set; }

        public bool IsHovering { get; set; }

        public bool IsEvading { get; set; }

        public bool IsEvadingTriggered { get; set; }


        private bool _isBoss;

        public bool IsBoss
        {
            get { return _isBoss; }
            set
            {
                _isBoss = value;

                if (_isBoss)
                {
                    var enemyType = random.Next(0, GameObjectTemplates.BOSS_TEMPLATES.Length);
                    var enemyTemplate = GameObjectTemplates.BOSS_TEMPLATES[enemyType];

                    switch (enemyType)
                    {
                        case 0:
                            {
                                Width = 209;
                                Height = 272;
                            }
                            break;
                        case 1:
                            {
                                Width = 224;
                                Height = 132;
                            }
                            break;
                        case 2:
                            {
                                Width = 325;
                                Height = 169;
                            }
                            break;
                        default:
                            break;
                    }

                    Uri uri = enemyTemplate;
                    content.Source = new BitmapImage(uri);
                }
            }
        }

        #endregion

        #region Methods

        public void SetAttributes(double speed, double scale = 1)
        {
            Speed = speed;
            XDirection = XDirection.NONE;
            IsMarkedForFadedDestruction = false;
            Opacity = 1;

            var enemyType = random.Next(0, GameObjectTemplates.ENEMY_TEMPLATES.Length);
            var enemyTemplate = GameObjectTemplates.ENEMY_TEMPLATES[enemyType];

            Uri uri = enemyTemplate.AssetUri;
            Health = enemyTemplate.Health;

            var size = enemyTemplate.Size;
            Height = size * scale;
            Width = size * scale;

            content.Source = new BitmapImage(uri);

            HalfWidth = Width / 2;
        }

        public void Evade()
        {
            if (XDirection == XDirection.NONE)
            {
                XDirection = (XDirection)random.Next(1, Enum.GetNames<XDirection>().Length);
                Speed = Speed / 1.85; // decrease speed

                IsEvadingTriggered = true;
            }
        }

        //public void SetRecoilEffect()
        //{
        //    BorderThickness = new Microsoft.UI.Xaml.Thickness(left: 0, top: 0, right: 0, bottom: 4);
        //}

        //public void CoolDownRecoilEffect()
        //{
        //    if (BorderThickness.Bottom != 0)
        //    {
        //        BorderThickness = new Microsoft.UI.Xaml.Thickness(left: 0, top: 0, right: 0, bottom: BorderThickness.Bottom - 1);
        //    }
        //}

        public void SetProjectileImpactEffect()
        {
            var effect = random.Next(0, 2);

            switch (effect)
            {
                case 0: BorderThickness = new Microsoft.UI.Xaml.Thickness(left: 0, top: 0, right: 5, bottom: 0); break;
                case 1: BorderThickness = new Microsoft.UI.Xaml.Thickness(left: 5, top: 0, right: 0, bottom: 0); break;
                default:
                    break;
            }
        }

        public void CoolDownProjectileImpactEffect()
        {
            if (BorderThickness.Left != 0)
            {
                BorderThickness = new Microsoft.UI.Xaml.Thickness(left: BorderThickness.Left - 1, top: 0, right: 0, bottom: 0);
            }

            if (BorderThickness.Right != 0)
            {
                BorderThickness = new Microsoft.UI.Xaml.Thickness(left: 0, top: 0, right: BorderThickness.Right - 1, bottom: 0);
            }
        }

        #endregion
    }
}

