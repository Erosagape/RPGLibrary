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
        private MapData()
        {

        }
        public MapData(string mapName,List<TilesetData> tileSets,List<MapLayerData> layers)
        {
            MapName = mapName;
            Tilesets = tileSets.ToArray();
            Layers = layers.ToArray();
        }
    }
}
