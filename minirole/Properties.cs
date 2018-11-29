

using Microsoft.Xna.Framework;

namespace Peace_Mill
{
    public class Properties
    {
        private IPosition<Vector2, Vector2> _position;
        private IVelocity<Vector2, Vector2> _velocity;
        private ISize<Rectangle, Rectangle> _size;

        public IPosition<Vector2,Vector2> Position { get => _position; set => _position = value; }
        public IVelocity<Vector2, Vector2> Velocity { get => _velocity; set => _velocity = value; }
        public ISize<Rectangle, Rectangle> Size { get => _size; set => _size = value; }
    }
}