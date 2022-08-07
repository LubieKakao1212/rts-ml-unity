using UnityEngine;
using System;

namespace Game.World.Things
{
    public class TargetThing : Thing
    {
        public float CurrentHealth 
        { 
            get => health; 
            protected set
            {
                health = value;
                if (health <= 0)
                {
                    Die();
                }
            }
        }

        public float CurrentHealthNormalized => health / maxHealth;
        public float MaxHealth => maxHealth;

        private float health;
        private float maxHealth;

        public TargetThing(World world, GameObject gameObject, float maxHealth) : base(world, gameObject)
        {
            this.maxHealth = maxHealth;
            this.health = maxHealth;
        }

        public virtual void Damage(float amount)
        {
            CurrentHealth = CurrentHealth - amount;
        }

        public virtual void Die()
        {
            Destroy();
        }
    }
}
