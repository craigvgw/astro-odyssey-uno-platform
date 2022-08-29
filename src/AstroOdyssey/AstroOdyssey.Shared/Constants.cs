﻿using System;
using Windows.Foundation;

namespace AstroOdyssey
{
    public static class Constants
    {
        #region Fields

        public const double DESTRUCTIBLE_OBJECT_SIZE = 70;
        public const double PLAYER_HEIGHT = 80;

        public const string PLAYER = "player";

        public const string ENEMY = "enemy";
        public const string METEOR = "meteor";

        public const string HEALTH = "health";
        public const string POWERUP = "powerup";

        public const string PLAYER_PROJECTILE = "player_projectile";
        public const string ENEMY_PROJECTILE = "enemy_projectile";

        public const string STAR = "star";

        public const double RAGE_THRESHOLD = 25;
        public const double POWER_UP_METER = 100;

        public static CelestialObjectTemplate[] STAR_TEMPLATES = new CelestialObjectTemplate[]
        {
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/star_large.png", UriKind.RelativeOrAbsolute), size : 20),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/star_medium.png", UriKind.RelativeOrAbsolute), size : 20),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/star_small.png", UriKind.RelativeOrAbsolute), size : 20),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/star_tiny.png", UriKind.RelativeOrAbsolute), size : 20),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/star_large2.png", UriKind.RelativeOrAbsolute), size : 20),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/star_medium2.png", UriKind.RelativeOrAbsolute), size : 20),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/star_small2.png", UriKind.RelativeOrAbsolute), size : 20),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/star_tiny2.png", UriKind.RelativeOrAbsolute), size : 20),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/gas_star1.png", UriKind.RelativeOrAbsolute), size : 30),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/gas_star2.png", UriKind.RelativeOrAbsolute), size : 30),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/gas_star3.png", UriKind.RelativeOrAbsolute), size : 30),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/nebula1.png", UriKind.RelativeOrAbsolute), size : 130),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/nebula2.png", UriKind.RelativeOrAbsolute), size : 130),
        };

        public static CelestialObjectTemplate[] PLANET_TEMPLATES = new CelestialObjectTemplate[]
        {
            new CelestialObjectTemplate(assetUri: new Uri("ms-appx:///Assets/Images/black-hole2.png", UriKind.RelativeOrAbsolute), size: 1400),
            new CelestialObjectTemplate(assetUri: new Uri("ms-appx:///Assets/Images/galaxy.png", UriKind.RelativeOrAbsolute), size: 700),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/planet1.png", UriKind.RelativeOrAbsolute), size : 1400),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/planet2.png", UriKind.RelativeOrAbsolute), size : 700),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/planet3.png", UriKind.RelativeOrAbsolute), size : 700),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/planet4.png", UriKind.RelativeOrAbsolute), size : 700),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/planet5.png", UriKind.RelativeOrAbsolute), size : 700),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/planet6.png", UriKind.RelativeOrAbsolute), size : 700),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/planet7.png", UriKind.RelativeOrAbsolute), size : 700),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/planet8.png", UriKind.RelativeOrAbsolute), size : 700),
            new CelestialObjectTemplate(assetUri : new Uri("ms-appx:///Assets/Images/planet9.png", UriKind.RelativeOrAbsolute), size : 700),
        };

        public static EnemyTemplate[] ENEMY_TEMPLATES = new EnemyTemplate[]
        {
            new EnemyTemplate(assetUri: new Uri("ms-appx:///Assets/Images/enemy_1.png", UriKind.RelativeOrAbsolute), health: 1),
            new EnemyTemplate(assetUri: new Uri("ms-appx:///Assets/Images/enemy_2.png", UriKind.RelativeOrAbsolute), health: 2),
            new EnemyTemplate(assetUri: new Uri("ms-appx:///Assets/Images/enemy_3.png", UriKind.RelativeOrAbsolute), health: 3),
            new EnemyTemplate(assetUri: new Uri("ms-appx:///Assets/Images/enemy_4.png", UriKind.RelativeOrAbsolute), health: 1),
            new EnemyTemplate(assetUri: new Uri("ms-appx:///Assets/Images/enemy_5.png", UriKind.RelativeOrAbsolute), health: 2),
            new EnemyTemplate(assetUri: new Uri("ms-appx:///Assets/Images/enemy_6.png", UriKind.RelativeOrAbsolute), health: 3),
        };

        #endregion

        #region Methods

        /// <summary>
        /// Checks if the provided string is null or empty or white space.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrBlank(this string value)
        {
            return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Get initials from a given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetInitials(string name)
        {
            string[] nameSplit = name.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

            string initials = "";

            foreach (string item in nameSplit)
            {
                initials += item.Substring(0, 1).ToUpper();
            }

            return initials;
        }

        /// <summary>
        /// Checks if a two rects intersect.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool Intersects(this Rect source, Rect target)
        {
            var targetX = target.X;
            var targetY = target.Y;
            var sourceX = source.X;
            var sourceY = source.Y;

            var sourceWidth = source.Width;
            var sourceHeight = source.Height;

            var targetWidth = target.Width;
            var targetHeight = target.Height;

            if (source.Width >= 0.0 && target.Width >= 0.0
                && targetX <= sourceX + sourceWidth && targetX + targetWidth >= sourceX
                && targetY <= sourceY + sourceHeight)
            {
                return targetY + targetHeight >= sourceY;
            }

            return false;
        }

        #endregion
    }
}
