﻿using System;
using static AstroOdyssey.Constants;

namespace AstroOdyssey
{
    public class PlayerProjectileHelper
    {
        #region Fields

        private readonly GameEnvironment gameEnvironment;
        private readonly string baseUrl;

        private readonly Random random = new Random();

        private int projectileCounter;
        private int projectileSpawnLimit = 16;
        private double projectileSpeed = 18;

        private readonly int RAPIDSHOT_ROUNDS_LIMIT_DECREASE = 2;
        private readonly int RAPIDSHOT_ROUNDS_SPEED_INCREASE = 1;

        private readonly int DEADSHOT_ROUNDS_LIMIT_INCREASE = 30;
        private readonly int DEADSHOT_ROUNDS_SPEED_DECREASE = 10;

        private readonly int SONICSHOT_ROUNDS_LIMIT_INCREASE = 25;
        private readonly int SONICSHOT_ROUNDS_SPEED_INCREASE = 25;

        #endregion

        #region Ctor

        public PlayerProjectileHelper(GameEnvironment gameEnvironment, string baseUrl)
        {
            this.gameEnvironment = gameEnvironment;
            this.baseUrl = baseUrl;
        }

        #endregion

        #region Methods       

        /// <summary>
        /// Spawns a projectile.
        /// </summary>
        /// <param name="isPoweredUp"></param>
        /// <param name="firingProjectiles"></param>
        /// <param name="player"></param>
        /// <param name="gameLevel"></param>
        /// <param name="powerUpType"></param>
        public void SpawnProjectile(bool isPoweredUp, bool firingProjectiles, Player player, GameLevel gameLevel, PowerUpType powerUpType)
        {
            // each frame progress decreases this counter
            projectileCounter -= 1;

            if (projectileCounter <= 0)
            {
                if (firingProjectiles)
                //// any object falls within player range
                //if (GameView.GetGameObjects<GameObject>().Where(x => x.IsDestructible).Any(x => Player.AnyObjectsOnTheRightProximity(gameObject: x) || Player.AnyObjectsOnTheLeftProximity(gameObject: x)))
                {
                    GenerateProjectile(isPoweredUp: isPoweredUp, player: player, gameLevel: gameLevel, powerUpType: powerUpType);
                }

                projectileCounter = projectileSpawnLimit;
            }
        }

        /// <summary>
        /// Generates a projectile.
        /// </summary>
        /// <param name="projectileHeight"></param>
        /// <param name="projectileWidth"></param>
        public void GenerateProjectile(bool isPoweredUp, Player player, GameLevel gameLevel, PowerUpType powerUpType)
        {
            var projectile = new PlayerProjectile();

            var scale = gameEnvironment.GetGameObjectScale();

            projectile.SetAttributes(speed: projectileSpeed, gameLevel: gameLevel, isPoweredUp: isPoweredUp, powerUpType: powerUpType, scale: scale);

            projectile.AddToGameEnvironment(top: player.GetY() + (5 * scale) - projectile.Height / 2, left: player.GetX() + player.Width / 2 - projectile.Width / 2, gameEnvironment: gameEnvironment);

            if (projectile.IsPoweredUp)
            {
                switch (powerUpType)
                {
                    case PowerUpType.NONE:
                        App.PlaySound(baseUrl, SoundType.PLAYER_ROUNDS_FIRE);
                        break;
                    case PowerUpType.RAPIDSHOT_ROUNDS:
                        App.PlaySound(baseUrl, SoundType.PLAYER_RAPIDSHOT_ROUNDS_FIRE);
                        break;
                    case PowerUpType.DEADSHOT_ROUNDS:
                        App.PlaySound(baseUrl, SoundType.PLAYER_DEADSHOT_ROUNDS_FIRE);
                        break;
                    case PowerUpType.SONICSHOT_ROUNDS:
                        App.PlaySound(baseUrl, SoundType.PLAYER_SONICSHOT_ROUNDS_FIRE);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                App.PlaySound(baseUrl, SoundType.PLAYER_ROUNDS_FIRE);
            }
        }

        /// <summary>
        /// Updates a projectile.
        /// </summary>
        /// <param name="projectile"></param>
        /// <param name="destroyed"></param>
        public void UpdateProjectile(PlayerProjectile projectile, out bool destroyed)
        {
            destroyed = false;

            // move projectile up                
            projectile.MoveY();

            // remove projectile if outside game canvas
            if (projectile.GetY() < 10)
            {
                gameEnvironment.AddDestroyableGameObject(projectile);
                destroyed = true;
            }
        }

        /// <summary>
        /// Collides a projectile with destructible game objects.
        /// </summary>
        /// <param name="projectile"></param>
        /// <param name="score"></param>
        /// <param name="destroyedObject"></param>
        public void CollidePlayerProjectile(PlayerProjectile projectile, out double score, out GameObject destroyedObject)
        {
            score = 0;
            destroyedObject = null;

            // get the destructible objects which intersect with the current projectile
            var destructibles = gameEnvironment.GetDestructibles(projectile.GetRect());

            foreach (var destructible in destructibles)
            {
                // if projectile is powered up then execute over kill
                if (projectile.IsPoweredUp)
                {
                    switch (projectile.PowerUpType)
                    {
                        case PowerUpType.RAPIDSHOT_ROUNDS:
                            {
                                // upon hit with a destructible object remove the projectile
                                gameEnvironment.AddDestroyableGameObject(projectile);
                                destructible.LooseHealth(destructible.HitPoint);
                            }
                            break;
                        case PowerUpType.DEADSHOT_ROUNDS:
                            {
                                // upon hit with a destructible object remove the projectile
                                gameEnvironment.AddDestroyableGameObject(projectile);
                                // loose 3 times hit point
                                destructible.LooseHealth(destructible.HitPoint * 3);
                            }
                            break;
                        case PowerUpType.SONICSHOT_ROUNDS:
                            {
                                // loose health point but projectile is armor penetrating
                                destructible.LooseHealth(destructible.HitPoint);
                            }
                            break;
                        default:
                            {
                                // upon hit with a destructible object remove the projectile
                                gameEnvironment.AddDestroyableGameObject(projectile);
                                destructible.LooseHealth();
                            }
                            break;
                    }
                }
                else
                {
                    // upon hit with a destructible object remove the projectile
                    gameEnvironment.AddDestroyableGameObject(projectile);
                    destructible.LooseHealth();
                }

                //App.PlaySound(SoundType.ROUNDS_HIT);

                switch (destructible.Tag)
                {
                    case ENEMY:
                        {
                            var enemy = destructible as Enemy;

                            if (enemy.IsBoss)
                            {
                                if (enemy.Health <= 3)
                                    enemy.Fade();
                            }
                            else
                            {
                                // fade the a bit on projectile hit
                                enemy.Fade();
                            }

                            if (destructible.HasNoHealth)
                            {
                                if (enemy.IsPlayerTargeting)
                                    score += 3;
                                else if (enemy.IsOverPowered)
                                    score += 4;
                                else if (enemy.IsBoss)
                                    score += 6;
                                else
                                    score += 2;

                                destroyedObject = enemy;

                                return;
                            }

                            if (destructible.HasHealth)
                            {
                                if (enemy.IsEvading && !enemy.IsEvadingTriggered)
                                    enemy.Evade();
                            }
                        }
                        break;
                    case METEOR:
                        {
                            var meteor = destructible as Meteor;

                            // fade the a bit on projectile hit
                            meteor.Fade();

                            if (destructible.HasNoHealth)
                            {
                                if (meteor.IsOverPowered)
                                    score += 2;
                                else
                                    score++;

                                destroyedObject = meteor;

                                return;
                            }

                            if (destructible.HasHealth)
                            {
                                // meteors float away on impact
                                if (!meteor.IsFloating)
                                    meteor.Float();
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Triggers the powered up state.
        /// </summary>
        public void PowerUp(PowerUpType powerUpType)
        {
            switch (powerUpType)
            {
                case PowerUpType.NONE:
                    break;
                case PowerUpType.RAPIDSHOT_ROUNDS:
                    {
                        projectileSpawnLimit -= RAPIDSHOT_ROUNDS_LIMIT_DECREASE; // fast firing rate
                        projectileSpeed += RAPIDSHOT_ROUNDS_SPEED_INCREASE; // fast projectile
                    }
                    break;
                case PowerUpType.DEADSHOT_ROUNDS:
                    {
                        projectileSpawnLimit += DEADSHOT_ROUNDS_LIMIT_INCREASE; // slow firing rate
                        projectileSpeed -= DEADSHOT_ROUNDS_SPEED_DECREASE; // slow projectile
                    }
                    break;
                case PowerUpType.SONICSHOT_ROUNDS:
                    {
                        projectileSpawnLimit += SONICSHOT_ROUNDS_LIMIT_INCREASE; // slow firing rate
                        projectileSpeed += SONICSHOT_ROUNDS_SPEED_INCREASE; // fast projectile
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Triggers the powered up state down.
        /// </summary>
        public void PowerDown(PowerUpType powerUpType)
        {
            switch (powerUpType)
            {
                case PowerUpType.NONE:
                    break;
                case PowerUpType.RAPIDSHOT_ROUNDS:
                    {
                        projectileSpawnLimit += RAPIDSHOT_ROUNDS_LIMIT_DECREASE;
                        projectileSpeed -= RAPIDSHOT_ROUNDS_SPEED_INCREASE;
                    }
                    break;
                case PowerUpType.DEADSHOT_ROUNDS:
                    {
                        projectileSpawnLimit -= DEADSHOT_ROUNDS_LIMIT_INCREASE;
                        projectileSpeed += DEADSHOT_ROUNDS_SPEED_DECREASE;
                    }
                    break;
                case PowerUpType.SONICSHOT_ROUNDS:
                    {
                        projectileSpawnLimit -= SONICSHOT_ROUNDS_LIMIT_INCREASE;
                        projectileSpeed -= SONICSHOT_ROUNDS_SPEED_INCREASE;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Levels up projectiles.
        /// </summary>
        public void LevelUp()
        {
            projectileSpawnLimit -= 1;
        }

        #endregion
    }
}
