﻿using System;

namespace SpaceShooterGame
{
    public class EntityBase
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; } = null;
    }
}
