﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GDIBitmap = System.Drawing.Bitmap;
using GDIColor = System.Drawing.Color;
using GDIImage = System.Drawing.Image;
using GDIGraphics = System.Drawing.Graphics;
using GDIGraphicsUnit = System.Drawing.GraphicsUnit;
using GDIRectangle = System.Drawing.Rectangle;
using RpgLibrary.WorldClasses;
using MGRpgLibrary.TileEngine;
namespace XLevelEditor
{
    public partial class FormMain : Form
    {
        #region Field Region
        LevelData levelData;

        public static TileMap map;
        public static List<Tileset> tileSets = new List<Tileset>();
        public static List<ILayer> layers = new List<ILayer>();
        public static Camera camera;
        public static Engine engine;
        public static int brushWidth;
        public static Color gridColor = Color.White;

        Point mouse = new Point();
        bool isMouseDown = false;
        bool trackMouse = false;
        List<TilesetData> tileSetData = new List<TilesetData>();
        int frameCount = 0;

        #endregion
        #region Property Region
        public static bool DrawGrid { get; set; } = true;
        public static int SelectedTileset
        {
            get; set;
        }
        public static int SelectedTile
        {
            get; set;
        }
        public GraphicsDevice GraphicsDevice
        {
            get { return mapDisplay.GraphicsDevice; }
        }
        #endregion
        #region Constructor Region
        public FormMain()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormMain_Load);
            this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);
            tilesetToolStripMenuItem.Enabled = false;
            mapLayerToolStripMenuItem.Enabled = false;
            charactersToolStripMenuItem.Enabled = false;
            chestsToolStripMenuItem.Enabled = false;
            keysToolStripMenuItem.Enabled = false;
            newLevelToolStripMenuItem.Click += new EventHandler(newLevelToolStripMenuItem_Click);
            newTilesetToolStripMenuItem.Click += new EventHandler(newTilesetToolStripMenuItem_Click);
            newLayerToolStripMenuItem.Click += new EventHandler(newLayerToolStripMenuItem_Click);
            saveLevelToolStripMenuItem.Click += new EventHandler(saveLevelToolStripMenuItem_Click);
            openLevelToolStripMenuItem.Click += new EventHandler(openLevelToolStripMenuItem_Click);
        }

        private void openLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog
            {
                Filter = "Level Files (*.xml)|*.xml",
                CheckFileExists = true,
                CheckPathExists = true
            };
            DialogResult result = ofDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            string path = Path.GetDirectoryName(ofDialog.FileName);
            LevelData newLevel = null;
            MapData mapData = null;
            try
            {
                newLevel = XnaSerializer.Deserialize<LevelData>(ofDialog.FileName);
                mapData = XnaSerializer.Deserialize<MapData>(path + @"\Maps\" + newLevel.MapName +
                ".xml");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error reading level");
                return;
            }
            tileSetImages.Clear();
            tileSetData.Clear();
            tileSets.Clear();
            layers.Clear();
            lbTileset.Items.Clear();
            clbLayers.Items.Clear();
            levelData = newLevel;
            foreach (TilesetData data in mapData.Tilesets)
            {
                Texture2D texture = null;
                tileSetData.Add(data);
                lbTileset.Items.Add(data.TilesetName);
                GDIImage image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);
                tileSetImages.Add(image);
                using (Stream stream = new FileStream(data.TilesetImageName, FileMode.Open,
                FileAccess.Read))
                {

                    texture = Texture2D.FromStream(GraphicsDevice, stream);
                    tileSets.Add(
                    new Tileset(
                    texture,
                    data.TilesWide,
                    data.TilesHigh,
                    data.TileWidthInPixels,
                    data.TileHeightInPixels));
                }
            }
            foreach (MapLayerData data in mapData.Layers)
            {
                clbLayers.Items.Add(data.MapLayerName, true);
                layers.Add(MapLayer.FromMapLayerData(data));
            }
            lbTileset.SelectedIndex = 0;
            clbLayers.SelectedIndex = 0;
            nudCurrentTile.Value = 0;
            map = new TileMap(tileSets[0], (MapLayer)layers[0]);
            for (int i = 1; i < tileSets.Count; i++)
            {
                map.AddTileset(tileSets[i]);
            }
            for (int i = 1; i < layers.Count; i++)
            {
                map.AddLayer(layers[i]);
            }
            tilesetToolStripMenuItem.Enabled = true;
            mapLayerToolStripMenuItem.Enabled = true;
            charactersToolStripMenuItem.Enabled = true;
            chestsToolStripMenuItem.Enabled = true;
            keysToolStripMenuItem.Enabled = true;
        }

        private void saveLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map == null)
                return;
            List<MapLayerData> mapLayerData = new List<MapLayerData>();
            for (int i = 0; i < clbLayers.Items.Count; i++)
            {
                if (layers[i] is MapLayer)
                {
                    MapLayerData data = new MapLayerData(
                    clbLayers.Items[i].ToString(),
                    ((MapLayer)layers[i]).Width,
                    ((MapLayer)layers[i]).Height);
                    for (int y = 0; y < ((MapLayer)layers[i]).Height; y++)
                        for (int x = 0; x < ((MapLayer)layers[i]).Width; x++)
                            data.SetTile(
                            x,
                            y,
                            ((MapLayer)layers[i]).GetTile(x, y).TileIndex,
                            ((MapLayer)layers[i]).GetTile(x, y).Tileset);
                    mapLayerData.Add(data);
                }
            }
            MapData mapData = new MapData(levelData.MapName, tileSetData, mapLayerData,new CollisionLayer());
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();
            fbDialog.Description = "Select Game Folder";
            fbDialog.SelectedPath = Application.StartupPath;
            DialogResult result = fbDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!File.Exists(fbDialog.SelectedPath + @"\Game.xml"))
                {
                    MessageBox.Show("Game not found", "Error");
                    return;
                }
                string LevelPath = Path.Combine(fbDialog.SelectedPath, @"Levels\");
                string MapPath = Path.Combine(LevelPath, @"Maps\");
                if (!Directory.Exists(LevelPath))
                    Directory.CreateDirectory(LevelPath);
                if (!Directory.Exists(MapPath))

                    Directory.CreateDirectory(MapPath);
                XnaSerializer.Serialize<LevelData>(LevelPath + levelData.LevelName + ".xml",
                levelData);
                XnaSerializer.Serialize<MapData>(MapPath + mapData.MapName + ".xml", mapData);
            }
        }
        #endregion
        #region Form Event Handler Region
        void FormMain_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            this.Load += new EventHandler(FormMain_Load);
            this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);
            tilesetToolStripMenuItem.Enabled = false;
            mapLayerToolStripMenuItem.Enabled = false;
            charactersToolStripMenuItem.Enabled = false;
            chestsToolStripMenuItem.Enabled = false;
            keysToolStripMenuItem.Enabled = false;
            newLevelToolStripMenuItem.Click += new EventHandler(newLevelToolStripMenuItem_Click);
            newTilesetToolStripMenuItem.Click += new EventHandler(newTilesetToolStripMenuItem_Click);
            newLayerToolStripMenuItem.Click += new EventHandler(newLayerToolStripMenuItem_Click);
            saveLevelToolStripMenuItem.Click += new EventHandler(saveLevelToolStripMenuItem_Click);
            openLevelToolStripMenuItem.Click += new EventHandler(openLevelToolStripMenuItem_Click);
            x1ToolStripMenuItem.Click += new EventHandler(x1ToolStripMenuItem_Click);
            x2ToolStripMenuItem.Click += new EventHandler(x2ToolStripMenuItem_Click);
            x4ToolStripMenuItem.Click += new EventHandler(x4ToolStripMenuItem_Click);
            x8ToolStripMenuItem.Click += new EventHandler(x8ToolStripMenuItem_Click);
            blackToolStripMenuItem.Click += new EventHandler(blackToolStripMenuItem_Click);
            blueToolStripMenuItem.Click += new EventHandler(blueToolStripMenuItem_Click);
            redToolStripMenuItem.Click += new EventHandler(redToolStripMenuItem_Click);
            greenToolStripMenuItem.Click += new EventHandler(greenToolStripMenuItem_Click);
            yellowToolStripMenuItem.Click += new EventHandler(yellowToolStripMenuItem_Click);
            whiteToolStripMenuItem.Click += new EventHandler(whiteToolStripMenuItem_Click);
            saveTilesetToolStripMenuItem.Click += new EventHandler(saveTilesetToolStripMenuItem_Click);
            saveLayerToolStripMenuItem.Click += new EventHandler(saveLayerToolStripMenuItem_Click);
            openTilesetToolStripMenuItem.Click += new EventHandler(openTilesetToolStripMenuItem_Click);
            openLayerToolStripMenuItem.Click += new EventHandler(openLayerToolStripMenuItem_Click);
        }

        private void openTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog
            {
                Filter = "Tileset Data (*.tdat)|*.tdat",
                CheckPathExists = true,
                CheckFileExists = true

            };
            DialogResult result = ofDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            TilesetData data = null;
            Texture2D texture = null;
            Tileset tileset = null;
            GDIImage image = null;
            try
            {
                data = XnaSerializer.Deserialize<TilesetData>(ofDialog.FileName);
                using (Stream stream = new FileStream(data.TilesetImageName, FileMode.Open,
                FileAccess.Read))
                {
                    texture = Texture2D.FromStream(GraphicsDevice, stream);
                    stream.Close();
                }
                image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);
                tileset = new Tileset(
                texture,
                data.TilesWide,
                data.TilesHigh,
                data.TileWidthInPixels,
                data.TileHeightInPixels);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error reading tileset");
                return;
            }
            for (int i = 0; i < lbTileset.Items.Count; i++)
            {
                if (lbTileset.Items[i].ToString() == data.TilesetName)
                {
                    MessageBox.Show("Level already contains a tileset with this name.",
                    "Existing tileset");
                    return;
                }
            }
            tileSetData.Add(data);
            tileSets.Add(tileset);
            lbTileset.Items.Add(data.TilesetName);
            pbTilesetPreview.Image = image;
            tileSetImages.Add(image);
            lbTileset.SelectedIndex = lbTileset.Items.Count - 1;
            nudCurrentTile.Value = 0;
            mapLayerToolStripMenuItem.Enabled = true;
        }

        private void openLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog
            {
                Filter = "Map Layer Data (*.mldt)|*.mldt",
                CheckPathExists = true,
                CheckFileExists = true
            };
            DialogResult result = ofDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }
            MapLayerData data = null;
            try
            {
                data = XnaSerializer.Deserialize<MapLayerData>(ofDialog.FileName);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error reading map layer");
                return;
            }
            for (int i = 0; i < clbLayers.Items.Count; i++)
            {
                if (clbLayers.Items[i].ToString() == data.MapLayerName)
                {
                    MessageBox.Show("Layer by that name already exists.", "Existing layer");
                    return;
                }
            }
            clbLayers.Items.Add(data.MapLayerName, true);
            layers.Add(MapLayer.FromMapLayerData(data));
            if (map == null)
            {
                map = new TileMap(tileSets[0], (MapLayer)layers[0]);
                for (int i = 1; i < tileSets.Count; i++)
                {
                    map.AddTileset(tileSets[i]);
                }
            }
        }

        void saveTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tileSetData.Count == 0)
                return;
            SaveFileDialog sfDialog = new SaveFileDialog
            {
                Filter = "Tileset Data (*.tdat)|*.tdat",
                CheckPathExists = true,
                OverwritePrompt = true,
                ValidateNames = true
            };
            DialogResult result = sfDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            try
            {
                XnaSerializer.Serialize<TilesetData>(
                sfDialog.FileName,
                tileSetData[lbTileset.SelectedIndex]);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error saving tileset");
            }
        }
        void saveLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (layers.Count == 0)
                return;
            if (layers[clbLayers.SelectedIndex] is MapLayer)
            {
                SaveFileDialog sfDialog = new SaveFileDialog();
                sfDialog.Filter = "Map Layer Data (*.mldt)|*.mldt";
                sfDialog.CheckPathExists = true;
                sfDialog.OverwritePrompt = true;
                sfDialog.ValidateNames = true;
                DialogResult result = sfDialog.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                MapLayerData data = new MapLayerData(
                clbLayers.SelectedItem.ToString(),
                ((MapLayer)layers[clbLayers.SelectedIndex]).Width,
                ((MapLayer)layers[clbLayers.SelectedIndex]).Height);
                for (int y = 0; y < ((MapLayer)layers[clbLayers.SelectedIndex]).Height; y++)
                {
                    for (int x = 0; x < ((MapLayer)layers[clbLayers.SelectedIndex]).Width; x++)
                    {
                        data.SetTile(
                        x,
                        y,
                        ((MapLayer)layers[clbLayers.SelectedIndex]).GetTile(x, y).TileIndex,
                        ((MapLayer)layers[clbLayers.SelectedIndex]).GetTile(x, y).Tileset);
                    }
                }
                try
                {
                    XnaSerializer.Serialize<MapLayerData>(sfDialog.FileName, data);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error saving map layer data");
                }
            }
        }
        void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.White;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = true;
        }
        void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Yellow;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = true;
            whiteToolStripMenuItem.Checked = false;
        }
        void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Green;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = true;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }
        void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Red;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = true;
            greenToolStripMenuItem.Checked = false;

            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }
        void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Blue;
            blackToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = true;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }
        void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridColor = Color.Black;
            blackToolStripMenuItem.Checked = true;
            blueToolStripMenuItem.Checked = false;
            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            yellowToolStripMenuItem.Checked = false;
            whiteToolStripMenuItem.Checked = false;
        }
        void x1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = true;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = false;
            brushWidth = 1;
        }
        void x2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = true;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = false;
            brushWidth = 2;
        }
        void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = true;
            x8ToolStripMenuItem.Checked = false;
            brushWidth = 4;
        }
        void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x1ToolStripMenuItem.Checked = false;
            x2ToolStripMenuItem.Checked = false;
            x4ToolStripMenuItem.Checked = false;
            x8ToolStripMenuItem.Checked = true;
            brushWidth = 8;
        }
        private void DisplayGridToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            FormMain.DrawGrid = displayGridToolStripMenuItem.Checked;
        }

        private void mapDisplay_SizeChanged(object sender, EventArgs e)
        {
            Rectangle viewPort = new Rectangle(0, 0, mapDisplay.Width, mapDisplay.Height);
            Vector2 cameraPosition = camera.Position;
            camera = new Camera(viewPort, cameraPosition);
            camera.LockCamera();
            mapDisplay.Invalidate();
        }

        private void pbTilesetPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbTileset.Items.Count == 0)
                return;
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            int index = lbTileset.SelectedIndex;
            float xScale = (float)tileSetImages[index].Width /
            pbTilesetPreview.Width;
            float yScale = (float)tileSetImages[index].Height /
            pbTilesetPreview.Height;
            Point previewPoint = new Point(e.X, e.Y);
            Point tilesetPoint = new Point(
            (int)(previewPoint.X * xScale),
            (int)(previewPoint.Y * yScale));
            Point tile = new Point(
            tilesetPoint.X / tileSets[index].TileWidth,
            tilesetPoint.Y / tileSets[index].TileHeight);
            nudCurrentTile.Value = tile.Y * tileSets[index].TilesWide + tile.X;
        }

        private void controlTimer_Tick(object sender, EventArgs e)
        {
            frameCount = ++frameCount % 6;
            mapDisplay.Invalidate();
            Logic();
        }

        private void Logic()
        {
            if (layers.Count == 0)
                return;
            Vector2 position = camera.Position;
            if (trackMouse)
            {
                if (frameCount == 0)
                {
                    if (mouse.X < Engine.TileWidth)
                        position.X -= Engine.TileWidth;
                    if (mouse.X > mapDisplay.Width - Engine.TileWidth)
                        position.X += Engine.TileWidth;
                    if (mouse.Y < Engine.TileHeight)
                        position.Y -= Engine.TileHeight;
                    if (mouse.Y > mapDisplay.Height - Engine.TileHeight)
                        position.Y += Engine.TileHeight;
                    camera.Position = position;
                    camera.LockCamera();
                }
                position.X = mouse.X + camera.Position.X;
                position.Y = mouse.Y + camera.Position.Y;
                Point tile = Engine.VectorToCell(position);
                tbMapLocation.Text =
                "( " + tile.X.ToString() + ", " + tile.Y.ToString() + " )";
                if (isMouseDown)
                {
                    if (rbDraw.Checked)
                        SetTiles(tile, (int)nudCurrentTile.Value, lbTileset.SelectedIndex);
                    if (rbErase.Checked)
                        SetTiles(tile, -1, -1);
                }
            }
        }
        private void SetTiles(Point tile, int tileIndex, int tileset)
        {
            int selected = clbLayers.SelectedIndex;
            if (layers[selected] is MapLayer)
            {
                for (int y = 0; y < brushWidth; y++)
                {
                    if (tile.Y + y >= ((MapLayer)layers[selected]).Height)
                        break;
                    for (int x = 0; x < brushWidth; x++)
                    {
                        if (tile.X + x < ((MapLayer)layers[selected]).Width)
                            ((MapLayer)layers[selected]).SetTile(
                            tile.X + x,
                            tile.Y + y,
                            tileIndex,
                            tileset);
                    }
                }
            }
        }
        private void nudCurrentTile_ValueChanged(object sender, EventArgs e)
        {
            if (lbTileset.SelectedItem != null)
            {
                FillPreviews();
            }
        }

        private void lbTileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTileset.SelectedItem != null)
            {
                nudCurrentTile.Value = 0;
                nudCurrentTile.Maximum = tileSets[lbTileset.SelectedIndex].SourceRectangles.Length - 1;
                FillPreviews();
            }
        }

        private void FillPreviews()
        {
            int selected = lbTileset.SelectedIndex;
            int tile = (int)nudCurrentTile.Value;
            FormMain.SelectedTileset = selected;
            FormMain.SelectedTile = tile;
            GDIImage preview = (GDIImage)new GDIBitmap(pbTilePreview.Width, pbTilePreview.Height);
            GDIRectangle dest = new GDIRectangle(0, 0, preview.Width, preview.Height);
            GDIRectangle source = new GDIRectangle(
            tileSets[selected].SourceRectangles[tile].X,
            tileSets[selected].SourceRectangles[tile].Y,
            tileSets[selected].SourceRectangles[tile].Width,
            tileSets[selected].SourceRectangles[tile].Height);
            GDIGraphics g = GDIGraphics.FromImage(preview);
            g.DrawImage(tileSetImages[selected], dest, source, GDIGraphicsUnit.Pixel);
            pbTilesetPreview.Image = tileSetImages[selected];
            pbTilePreview.Image = preview;
        }

        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        void Application_Idle(object sender, EventArgs e)
        {
            mapDisplay.Invalidate();
        }
        #endregion
        #region New Menu Item Event Handler Region
        void newLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewLevel frmNewLevel = new FormNewLevel())
            {
                frmNewLevel.ShowDialog();
                if (frmNewLevel.OKPressed)
                {
                    levelData = frmNewLevel.LevelData;
                    tilesetToolStripMenuItem.Enabled = true;
                }
            }
        }
        List<GDIImage> tileSetImages = new List<GDIImage>();
        void newTilesetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewTileset frmNewTileset = new FormNewTileset())
            {
                frmNewTileset.ShowDialog();
                if (frmNewTileset.OKPressed)
                {
                    TilesetData data = frmNewTileset.TilesetData;
                    try
                    {
                        GDIImage image = (GDIImage)GDIBitmap.FromFile(data.TilesetImageName);
                        tileSetImages.Add(image);
                        Stream stream = new FileStream(data.TilesetImageName, FileMode.Open,
                        FileAccess.Read);
                        Texture2D texture = Texture2D.FromStream(GraphicsDevice, stream);
                        Tileset tileset = new Tileset(
                        texture,
                        data.TilesWide,
                        data.TilesHigh,
                        data.TileWidthInPixels,
                        data.TileHeightInPixels);
                        tileSets.Add(tileset);
                        tileSetData.Add(data);
                        if (map != null)
                            map.AddTileset(tileset);
                        stream.Close();
                        stream.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading file.\n" + ex.Message, "Error reading image");
                        return;
                    }
                    lbTileset.Items.Add(data.TilesetName);
                    if (lbTileset.SelectedItem == null)
                        lbTileset.SelectedIndex = 0;
                    mapLayerToolStripMenuItem.Enabled = true;
                }
            }
        }
        void newLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormNewLayer frmNewLayer = new FormNewLayer(levelData.MapWidth,
 levelData.MapHeight))
            {
                frmNewLayer.ShowDialog();
                if (frmNewLayer.OKPressed)
                {
                    MapLayerData data = frmNewLayer.MapLayerData;
                    if (clbLayers.Items.Contains(data.MapLayerName))
                    {
                        MessageBox.Show("Layer with name " + data.MapLayerName + " exists.", "Existing layer");
                        return;
                    }
                    MapLayer layer = MapLayer.FromMapLayerData(data);

                    clbLayers.Items.Add(data.MapLayerName, true);
                    clbLayers.SelectedIndex = clbLayers.Items.Count - 1;
                    layers.Add(layer);
                    if (map == null)
                    {
                        map = new TileMap(tileSets[0], (MapLayer)layers[0]);
                        for (int i = 1; i < tileSets.Count; i++)
                            map.AddTileset(tileSets[1]);
                        for (int i = 1; i < layers.Count; i++)
                            map.AddLayer(layers[1]);
                    }
                    charactersToolStripMenuItem.Enabled = true;
                    chestsToolStripMenuItem.Enabled = true;
                    keysToolStripMenuItem.Enabled = true;
                }
            }

            #endregion
        }
    }
}