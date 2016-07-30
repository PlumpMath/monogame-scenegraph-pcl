using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public class Component
    {
        public virtual void Draw(GameTime gameTime, SpriteBatch batch)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            throw new NotImplementedException();
        }

        public void Attach(Component parent)
        {
            this.parent = parent;
        }
        public void Detach()
        {
            this.parent = null;
        }

        private Component parent;

        public float X
        {
            get { return position.X; }
            set
            {
                position.X = value;
                worldPosition.X = value + parent.worldPosition.X;
            }
        }

        public float Y
        {
            get { return position.Y; }
            set
            {
                position.Y = value;
                worldPosition.Y = value + parent.worldPosition.Y;
            }
        }

        public float WorldX => worldPosition.X;
        public float WorldY => worldPosition.Y;

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
