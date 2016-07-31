using System;
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
            worldPosition.X = component.WorldX + X;
            worldPosition.Y = component.WorldY + Y;
            worldRotation = component.WorldRotation + rotation;
            worldScale.X = component.WorldScaleX * scale.X;
            worldScale.Y = component.WorldScaleY * scale.Y;
            worldVelocity.X = component.WorldVelocityX + velocity.X;
            worldVelocity.Y = component.WorldVelocityY + velocity.Y;
        }

        public virtual void Init()
        {
            position = new Vector2(0f, 0f);
            worldPosition = new Vector2(0f, 0f);
            scale = new Vector2(1f, 1f);
            worldScale = new Vector2(1f, 1f);
            rotation = 0f;
            velocity = new Vector2(0f,0f);
            worldVelocity = new Vector2(0f,0f);
        }

        public virtual void ReceiveMessage(int message)
        {
            
        }

        public void Broadcast(int message)
        {
            var siblings = component.Where(x => x != this);
            foreach (var sibling in siblings)
                sibling.ReceiveMessage(message);
        }


        public void Attach(Entity parent)
        {
            this.component = parent;
            Init();
        }
        public void Detach()
        {
            this.component = null;
        }
       
        protected Entity component { get; private set; }

        public float WorldX => worldPosition.X;
        public float WorldY => worldPosition.Y;
        public float WorldRotation => worldRotation;
        public float WorldScaleX => worldScale.X;
        public float WorldScaleY => worldScale.Y;

        public virtual float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public virtual float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public virtual float Z
        {
            get { return z; }
            set { z = value; }
        }

        protected float z;
        protected Vector2 position;

        protected Vector2 worldPosition;

        public virtual float Scale
        {
            get { return scale.Y; }
            set
            {
                scale.X = value;
                scale.Y = value;
            }
        }

        public virtual Color Tint
        {
            get { return tint; }
            set { tint = value; }
        }

        public virtual float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public virtual SpriteEffects SpriteEffects
        {
            get { return effects; }
            set { effects = value; }
        }

        public virtual float CenterX
        {
            get { return center.X; }
            set { center.X = value; }
        }

        public virtual float CenterY
        {
            get { return center.Y; }
            set { center.Y = value; }
        }

        public virtual int SourceRectX
        {
            set { srcRect.X = value; }
            get { return srcRect.X; }
        }
        public virtual int SourceRectY
        {
            set { srcRect.Y = value; }
            get { return srcRect.Y; }
        }
        public virtual int SourceRectWidth
        {
            set { srcRect.Width = value; }
            get { return srcRect.Width; }
        }
        public virtual int SourceRectHeight
        {
            set { srcRect.Height = value; }
            get { return srcRect.Height; }
        }

        public virtual int DestRectX
        {
            set { destRect.X = value; }
            get { return destRect.X; }
        }
        public virtual int DestRectY
        {
            set { destRect.Y = value; }
            get { return destRect.Y; }
        }
        public virtual int DestRectWidth
        {
            set { destRect.Width = value; }
            get { return destRect.Width; }
        }
        public virtual int DestRectHeight
        {
            set { destRect.Height = value; }
            get { return destRect.Height; }
        }

        public virtual float VelocityX
        {
            get { return velocity.X; }
            set { velocity.X = value; }
        }
        public virtual float VelocityY
        {
            get { return velocity.Y; }
            set { velocity.Y = value; }
        }
        public virtual float WorldVelocityX
        {
            get { return worldVelocity.X; }
            set { worldVelocity.X = value; }
        }
        public virtual float WorldVelocityY
        {
            get { return worldVelocity.Y; }
            set { worldVelocity.Y = value; }
        }

        public Rectangle? DestRect { get; set; }

        protected Rectangle srcRect;
        protected Rectangle destRect;
        protected float rotation;
        protected float worldRotation;
        protected Vector2 scale;
        protected Vector2 worldScale;
        protected Color tint;
        protected SpriteEffects effects;
        protected Vector2 center;
        protected Vector2 velocity;
        protected Vector2 worldVelocity;
    }
}
