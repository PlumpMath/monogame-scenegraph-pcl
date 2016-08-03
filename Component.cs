using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public class Component
    {
        public virtual void Draw(GameTime gameTime, SpriteBatch batch)
        {
        }

        public virtual void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            if (Entity != null)
            {
                worldPosition.X = Entity.WorldX + X;
                worldPosition.Y = Entity.WorldY + Y;
                worldRotation = Entity.WorldRotation + rotation;
                worldScale.X = Entity.WorldScaleX*scale.X;
                worldScale.Y = Entity.WorldScaleY*scale.Y;
                worldVelocity.X = Entity.WorldVelocityX + velocity.X;
                worldVelocity.Y = Entity.WorldVelocityY + velocity.Y;
            }
            else
            {
                worldPosition.X = X;
                worldPosition.Y = Y;
                worldRotation = rotation;
                worldScale.X = scale.X;
                worldScale.Y = scale.Y;
                worldVelocity.X = velocity.X;
                worldVelocity.Y = velocity.Y;
            }
        }

        public Component(Entity parent)
        {
            Entity = parent;
            position = new Vector2(0f, 0f);
            worldPosition = new Vector2(0f, 0f);
            scale = new Vector2(1f, 1f);
            worldScale = new Vector2(1f, 1f);
            rotation = 0f;
            velocity = new Vector2(0f,0f);
            worldVelocity = new Vector2(0f,0f);
        }

        
        public virtual void ReceiveMessage(object[] message)
        {
            
        }
        public void BroadcastMessage(params object[] message)
        {
            var siblings = Entity.Where(x => x != this);
            foreach (var sibling in siblings)
                sibling.ReceiveMessage(message);
        }

       
        protected Entity Entity { get; private set; }

        public float WorldX => worldPosition.X;
        public float WorldY => worldPosition.Y;
        public float WorldRotation => worldRotation;
        public float WorldScaleX => worldScale.X;
        public float WorldScaleY => worldScale.Y;
        public float WorldVelocityX => worldVelocity.X;
        public float WorldVelocityY => worldVelocity.Y;

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
        public float Z
        {
            get { return z; }
            set { z = value; }
        }
        public float Scale
        {
            get { return scale.Y; }
            set
            {
                scale.X = value;
                scale.Y = value;
            }
        }
        public float ScaleX
        {
            get { return scale.X; }
            set { scale.X = value; }
        }
        public float ScaleY
        {
            get { return scale.Y; }
            set { scale.Y = value; }
        }
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public float VelocityX
        {
            get { return velocity.X; }
            set { velocity.X = value; }
        }
        public float VelocityY
        {
            get { return velocity.Y; }
            set { velocity.Y = value; }
        }

        protected float z;
        protected Vector2 position;
        protected Vector2 worldPosition;
        protected float rotation;
        protected float worldRotation;
        protected Vector2 scale;
        protected Vector2 worldScale;
        protected Vector2 velocity;
        protected Vector2 worldVelocity;
    }
}
