using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public class Sprite
    {
        public Sprite(Texture2D texture)
        {
            this.texture = texture;
            position = new Vector2(0f, 0f);
            center = new Vector2((float)texture.Width / 2, (float)texture.Height / 2);
            this.scale = new Vector2(1f, 1f);
            this.tint = Color.White;
            this.rotation = 0f;
            this.effects = SpriteEffects.None;
        }

        public SpriteBatch SpriteBatch
        {
            set {
                this.spriteBatch = value;
            }            
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

        public Rectangle? SourceRect { get; set; }
        public Rectangle? DestRect { get; set; }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(
                texture: texture, 
                position: position,
                destinationRectangle: DestRect, 
                sourceRectangle: SourceRect,
                origin: center,
                rotation: rotation,
                scale: scale,
                color: tint, 
                effects: effects, 
                layerDepth: z);
        }

        public virtual void Update(GameTime gameTime, TouchCollection touchCollection)
        {
        }

        private float z;
        private float rotation;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private Vector2 scale;
        private Color tint;
        private SpriteEffects effects;
        private Vector2 center;
        private readonly Texture2D texture;
    }
}
