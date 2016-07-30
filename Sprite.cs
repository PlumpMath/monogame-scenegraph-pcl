using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public class Sprite : Component
    {
        public Sprite(Texture2D texture)
        {
            this.texture = texture;
            position = new Vector2(0f, 0f);            
            worldPosition = new Vector2(0f,0f);
            center = new Vector2((float)texture.Width / 2, (float)texture.Height / 2);
            this.scale = new Vector2(1f, 1f);
            this.tint = Color.White;
            this.rotation = 0f;
            this.effects = SpriteEffects.None;
            this.srcRect = new Rectangle(0, 0, texture.Width, texture.Height);
            this.destRect = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public Sprite(Texture2D texture, Color? tint=null, float? scaleX=null, float? scaleY=null, float? scale=null, float? rotation=null, float? centerX=null, 
            float? centerY=null, int? srcX=null, int? srcY=null, int? srcWidth=null, int? srcHeight=null, SpriteEffects effects = SpriteEffects.None)
        {
            this.texture = texture;
            position = new Vector2(0f, 0f);
            worldPosition = new Vector2(0f, 0f);
            center = new Vector2(centerX ?? ((float)texture.Width / 2), centerY ?? ((float)texture.Height / 2));
            this.scale = new Vector2(scaleX ?? scale ?? 1f, scaleY ?? scale ?? 1f);
            this.tint = tint ?? Color.White;
            this.rotation = rotation ?? 0f;
            this.effects = effects;
            this.srcRect = new Rectangle(srcX ?? 0, srcY ?? 0, srcWidth ?? texture.Width, srcHeight ?? texture.Height);
            this.destRect = new Rectangle(0, 0, texture.Width, texture.Height);
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

        public Color Tint
        {
            get { return tint; }
            set { tint = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public SpriteEffects SpriteEffects
        {
            get { return effects; }
            set { effects = value; }
        }

        public float CenterX
        {
            get { return center.X;  }
            set { center.X = value; }
        }

        public float CenterY
        {
            get { return center.Y; }
            set { center.Y = value; }
        }

        public int SourceRectX
        {
            set { srcRect.X = value; }
            get { return srcRect.X; }
        }
        public int SourceRectY
        {
            set { srcRect.Y = value; }
            get { return srcRect.Y; }
        }
        public int SourceRectWidth
        {
            set { srcRect.Width = value; }
            get { return srcRect.Width; }
        }
        public int SourceRectHeight
        {
            set { srcRect.Height = value; }
            get { return srcRect.Height; }
        }

        public int DestRectX
        {
            set { destRect.X = value; }
            get { return destRect.X; }
        }
        public int DestRectY
        {
            set { destRect.Y = value; }
            get { return destRect.Y; }
        }
        public int DestRectWidth
        {
            set { destRect.Width = value; }
            get { return destRect.Width; }
        }
        public int DestRectHeight
        {
            set { destRect.Height = value; }
            get { return destRect.Height; }
        }


        public Rectangle? DestRect { get; set; }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(
                texture: texture,
                position: worldPosition,
                //destinationRectangle: destRect,
                sourceRectangle: srcRect,
                origin: center,
                rotation: rotation,
                scale: scale,
                color: tint,
                effects: effects,
                layerDepth: z);
        }

        public override void Update(GameTime gameTime, TouchCollection touchCollection)
        {            
        }

        private Rectangle srcRect;
        private Rectangle destRect;
        private float rotation;
        private Vector2 scale;
        private Color tint;
        private SpriteEffects effects;
        private Vector2 center;
        private Texture2D texture;
    }
}
