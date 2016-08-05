using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using MonoGameSceneGraph.Support;

namespace MonoGameSceneGraph.Components
{
    public class Sprite : Component
    {
        public Sprite(Entity parent, Texture2D texture) : base(parent)
        {
            this.texture = texture;            
            center = new Vector2((float)texture.Width / 2, (float)texture.Height / 2);
            this.tint = Color.White;
            this.effects = SpriteEffects.None;
            this.srcRect = new Rectangle(0, 0, texture.Width, texture.Height);
            this.destRect = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public override void Update(GameTime gameTime, TouchInfo[] touchCollection)
        {
            base.Update(gameTime, touchCollection);

            //for cases when the sprite is moving right to left, the rotation angle will be >90deg or < -90deg, 
            //so the sprite will be drawn upside down.
            // fix this by flipping the sprite vertically
            SpriteEffects = SpriteEffects.None;
            if (worldVelocity.X < 0)
            {
                SpriteEffects = SpriteEffects.FlipVertically;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(
                texture: texture,
                position: worldPosition,
                //destinationRectangle: destRect,
                sourceRectangle: srcRect,
                origin: center,
                rotation: worldRotation,
                scale: worldScale,
                color: Tint,
                effects: SpriteEffects,
                layerDepth: Z
                );
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public SpriteEffects SpriteEffects
        {
            get { return effects; }
            set { effects = value; }
        }

        public Color Tint
        {
            get { return tint; }
            set { tint = value; }
        }

        public float CenterX
        {
            get { return center.X; }
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
        public  int DestRectHeight
        {
            set { destRect.Height = value; }
            get { return destRect.Height; }
        }

        protected Texture2D texture;
        protected Rectangle? DestRect { get; set; }
        protected Rectangle srcRect;
        protected Rectangle destRect;
        protected Color tint;
        protected SpriteEffects effects;
        protected Vector2 center;

    }
}
