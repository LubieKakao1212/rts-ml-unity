using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.World.Things
{
    public class Unit : TargetThing
    {
        private float attackDamage;
        private float range;
        private float attackCooldown;
        private float attackTimer;

        private TargetThing target;

        private Vector2Int movementTarget;

        public Unit(World world, GameObject gameObject, float maxHealth) : base(world, gameObject, maxHealth)
        {

        }

        public void SetTarget(TargetThing target)
        {
            this.target = target;
        }

        public bool AttackTarget()
        {
            if (attackTimer > 0)
            {
                return false;
            }

            var relativePosition = target.PosInWorld - PosInWorld;

            if (relativePosition.magnitude > range)
            {
                return false;
            }

            target.Damage(attackDamage);
            attackTimer = attackCooldown;
            return true;
        }

        public void Update(float deltaTime)
        {
            attackTimer -= deltaTime;

            MoveInDirection(movementTarget - PosInWorld);
        }
    }
}
