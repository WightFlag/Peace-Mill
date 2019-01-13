using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Peace_Mill
{
    public class Map :Component
    {
        private Image _tileSet;
        private Vector2 _tileSize;
        private Vector2[,] _layout;
        private Tile[,] _tiles;
        private Tile[] _activeTiles;

        public Image TileSet { get => _tileSet; set => _tileSet = value; }
        public Vector2 TileSize { get => _tileSize; set => _tileSize = value; }
        public Vector2[,] Layout { get => _layout; set => _layout = value; }

        public Map(GameObject gameObject)
        {
            this.Name = "Map";
            this.gameObject = gameObject;
        }

        public Map()
        {

        }

        public override void LoadContent()
        {
            _tileSet.LoadContent();

            var width = TileSet.Texture.Width / (int)_tileSize.X;
            var height = TileSet.Texture.Height / (int)_tileSize.Y;

            _tiles = new Tile[width,height];

            for(var i = 0; i < width; i++)
            {
                for(var j = 0; j < height; j++)
                {
                   // var tile = new Tile(new Rectangle(i * (int)_tileSize.X, j * (int)_tileSize.Y, _tileSize.X, _tileSize.Y), );
                }
            }

        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
