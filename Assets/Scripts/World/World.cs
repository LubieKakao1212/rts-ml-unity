using UnityEngine;
using UnityEngine.Assertions;

namespace Game.World
{
    using Things;

    public class World
    {
        private WorldTileInstance[,] tiles;

        public World(Vector2Int size)
        {
            tiles = new WorldTileInstance[size.x, size.y];
        }

        public void MoveThing(Thing thing, Vector2Int newPos)
        {
            Vector2Int oldPos = thing.PosInWorld;
            var tile = tiles[oldPos.x, oldPos.y];
            Assert.AreEqual(tile.ThingOnTile, thing, $"Corupted Thing {thing.GameObject}");

            var targetTile = tiles[newPos.x, newPos.y];
            if (targetTile.ThingOnTile != null)
            {
                Debug.Log($"Cannot move thing {thing.GameObject} to {targetTile}, target tile already occupied");
            }
            targetTile.ThingOnTile = thing;
            tile.ThingOnTile = null;
        }
    }

    public class WorldTileInstance
    {
        public Thing ThingOnTile { get; set; }
    }

}
