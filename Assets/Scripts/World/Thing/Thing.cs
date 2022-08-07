using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.World.Things
{
    public class Thing
    {
        public event Action<Thing> Destroyed;

        public GameObject GameObject { get; private set; }

        public World world { get; }

        public Vector2Int PosInWorld { get; set; }

        public Thing(World world, GameObject gameObject)
        {
            this.GameObject = gameObject;
            this.world = world;
        }

        public void Destroy()
        {
            Destroyed?.Invoke(this);
            GameObject.Destroy(GameObject);
        }

        public void Move(Vector2Int delta)
        {
            world.MoveThing(this, delta);
        }

        public void MoveInDirection(Vector2Int dir)
        {
            Move(new Vector2Int((int)Mathf.Sign(dir.x), (int)Mathf.Sign(dir.y)));
        }
    }
}
