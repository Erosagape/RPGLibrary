using System;
using System.Collections.Generic;
using System.Text;
namespace RpgLibrary.WorldClasses
{
    public class MapData
    {
        public string MapName;
        public MapLayerData[] Layers;
        public TilesetData[] Tilesets;
        public CollisionLayer Collisions;
        private MapData()
        {

        }
        public MapData(string mapName,List<TilesetData> tileSets,List<MapLayerData> layers,CollisionLayer collisionLayer)
        {
            MapName = mapName;
            Tilesets = tileSets.ToArray();
            Layers = layers.ToArray();
            Collisions = collisionLayer;
        }
    }
}
