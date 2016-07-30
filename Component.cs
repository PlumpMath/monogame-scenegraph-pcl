using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch batch);

        public virtual void Update(GameTime gameTime, TouchCollection touchCollection, float parentX, float parentY)
        {
            WorldX = parentX + X;
            WorldY = parentY + Y;
        }

        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public float WorldX
        {
            get { return worldPosition.X; }
            private set { worldPosition.X = value; }
        }

        public float WorldY
        {
            get { return worldPosition.Y; }
            private set { worldPosition.Y = value; }
        }

        public float Z
        {
            get { return z; }
            set { z = value; }
        }

        protected float z;
        protected Vector2 position;
        protected Vector2 worldPosition;
    }
}
