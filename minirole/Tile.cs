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
    public class Tile
    {
        private Rectangle _sourceRect;
        private Vector2 _position;

        public Rectangle SourceRect { get => _sourceRect; set => _sourceRect = value; }
        public Vector2 Position { get => _position; set => _position = value; }

        public Tile(Rectangle rectangle, Vector2 position)
        {
            _sourceRect = rectangle;
            _position = position;
        }

        public Tile()
        {

        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
