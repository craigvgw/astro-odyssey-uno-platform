﻿using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Windows.Foundation;
using Point = Windows.Foundation.Point;

namespace AstroOdyssey
{
    public class GameObject : Border
    {
        #region Fields

        private readonly CompositeTransform compositeTransform = new CompositeTransform()
        {
            CenterX = 0.5,
            CenterY = 0.5,
            Rotation = 0,
            ScaleX = 1,
            ScaleY = 1,
        };

        #endregion

        #region Ctor

        public GameObject()
        {
            RenderTransformOrigin = new Point(0.5, 0.5);
            RenderTransform = compositeTransform;

            CanDrag = false;
        }

        #endregion

        #region Properties

        public double Health { get; set; } = 1;

        public double HitPoint { get; set; } = 1;

        public double Speed { get; set; } = 1;

        public new double Rotation { get; set; } = 0;

        public YDirection YDirection { get; set; } = YDirection.NONE;

        public XDirection XDirection { get; set; } = XDirection.NONE;

        public bool HasNoHealth => Health <= 0;

        public bool HasHealth => Health > 0;

        public double ExplosionCounter { get; set; } = 1;

        public bool HasExploded => ExplosionCounter <= 0;

        public bool IsOverPowered { get; set; } = false;

        private bool _isDestructible;

        public bool IsDestructible
        {
            get { return _isDestructible; }
            set
            {
                _isDestructible = value;

                if (_isDestructible)
                {
                    DestructionLayer = new Border()
                    {
                        Height = this.Height,
                        Width = this.Width,
                        BorderThickness = new Microsoft.UI.Xaml.Thickness(3),
                        CornerRadius = new Microsoft.UI.Xaml.CornerRadius(100),
                        BorderBrush = new SolidColorBrush(Colors.OrangeRed),
                        Background = new SolidColorBrush(Colors.Orange),
                    };
                }
            }
        }

        public bool IsProjectile { get; set; }

        public bool IsPickup { get; set; }

        public bool IsCollectible { get; set; }

        public bool IsPlayer { get; set; }

        public double HalfWidth { get; set; }

        public Border DestructionLayer { get; set; }

        private bool _isMarkedForFadedDestruction;
        public bool IsMarkedForFadedDestruction
        {
            get { return _isMarkedForFadedDestruction; }
            set
            {
                _isMarkedForFadedDestruction = value;

                if (_isMarkedForFadedDestruction)
                {
                    // set exploding effect
                    if (IsDestructible)
                    {
                        Child = DestructionLayer;
                    }

                    if (IsProjectile)
                    {
                        Height = 15;
                        Width = 15;
                        YDirection = YDirection.NONE;
                        CornerRadius = new Microsoft.UI.Xaml.CornerRadius(50);
                    }
                }
            }
        }

        #endregion

        #region Methods

        public void SetSize(double size)
        {
            Height = size;
            Width = size;
        }

        public void Rotate()
        {
            compositeTransform.Rotation += Rotation;
        }

        public void GainHealth()
        {
            Health += HitPoint;
        }

        public void GainHealth(double health)
        {
            Health += health;
        }

        public void LooseHealth()
        {
            Health -= HitPoint;
        }

        public void LooseHealth(double health)
        {
            Health -= health;
        }

        public Rect GetRect()
        {
            return new Rect(Canvas.GetLeft(this), Canvas.GetTop(this), Width, Height);
        }

        public double GetY()
        {
            return Canvas.GetTop(this);
        }

        public double GetX()
        {
            return Canvas.GetLeft(this);
        }

        public void SetY(double top)
        {
            Canvas.SetTop(this, top);
        }

        public void SetX(double left)
        {
            Canvas.SetLeft(this, left);
        }

        public void MoveX()
        {
            Canvas.SetLeft(this, GetX() + (Speed * GetXDirectionModifier()));
        }

        public void MoveX(double left)
        {
            Canvas.SetLeft(this, GetX() + (left * GetXDirectionModifier()));
        }

        public void MoveX(double left, XDirection xDirection)
        {
            Canvas.SetLeft(this, GetX() + (left * GetXDirectionModifier(xDirection)));
        }

        public void MoveX(XDirection xDirection)
        {
            Canvas.SetLeft(this, GetX() + (Speed * GetXDirectionModifier(xDirection)));
        }

        public void MoveY()
        {
            Canvas.SetTop(this, GetY() + (Speed * GetYDirectionModifier()));
        }

        public void MoveY(double top)
        {
            Canvas.SetTop(this, GetY() + (top * GetYDirectionModifier()));
        }

        public void MoveY(double top, YDirection yDirection)
        {
            Canvas.SetTop(this, GetY() + (top * GetYDirectionModifier(yDirection)));
        }

        public void SetPosition(double top, double left)
        {
            Canvas.SetTop(this, top);
            Canvas.SetLeft(this, left);
        }

        private int GetXDirectionModifier(XDirection? xDirection = null)
        {
            var modifier = 0;
            var xDirectionConsider = xDirection ?? XDirection;

            switch (xDirectionConsider)
            {
                case XDirection.NONE:
                    modifier = 0;
                    break;
                case XDirection.LEFT:
                    modifier = -1;
                    break;
                case XDirection.RIGHT:
                    modifier = 1;
                    break;
                default:
                    break;
            }

            return modifier;
        }

        private int GetYDirectionModifier(YDirection? yDirection = null)
        {
            var modifier = 0;
            var yDirectionConsider = yDirection ?? YDirection;

            switch (yDirectionConsider)
            {
                case YDirection.UP:
                    modifier = -1;
                    break;
                case YDirection.DOWN:
                    modifier = 1;
                    break;
                default:
                    break;
            }

            return modifier;
        }

        public void AddToGameEnvironment(double top, double left, GameEnvironment gameEnvironment)
        {
            SetPosition(top, left);
            gameEnvironment.AddGameObject(this);
        }

        public void Explode()
        {
            ExplosionCounter -= 0.1d;

            if (ExplosionCounter <= 0.3d)
                Opacity -= 0.1d;

            ScaleUp();
        }

        public void ScaleUp()
        {
            compositeTransform.ScaleX += 0.3d;
            compositeTransform.ScaleY += 0.3d;
        }

        public void Widen()
        {
            Width += 1.2d;
            Height += 0.08d;
        }

        public void Lengthen()
        {
            Height += 0.6d;
        }

        public void OverPower()
        {
            Height = Height * 1.5;
            Width = Width * 1.5;
            HalfWidth = Width / 2;
            Speed--;
            Health += 3;

            IsOverPowered = true;
        }

        #endregion
    }

    public enum YDirection
    {
        NONE,
        UP,
        DOWN,
    }

    public enum XDirection
    {
        NONE,
        LEFT,
        RIGHT,
    }
}
