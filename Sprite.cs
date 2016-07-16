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
        }
        public Sprite(Texture2D texture, float x=0f, float y=0f, float scale=1f, Color? tint = null)
        {
            this.texture = texture;
            position = new Vector2(x,y);
            center = new Vector2((float)texture.Width/2, (float)texture.Height/2);
            this.scale = new Vector2(scale,scale);
            this.tint = tint ?? Color.White;
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

        private Vector2 position;
        private SpriteBatch spriteBatch;
        private Vector2 scale;
        private Color tint;

        private readonly Texture2D texture;        
        private readonly Vector2 center;        
        

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(
                texture: texture, 
                position: position,
                destinationRectangle: null, 
                sourceRectangle: null,
                origin: center,
                rotation: 0f,
                scale: scale,
                color: tint, 
                effects: SpriteEffects.None, 
                layerDepth: 0f);
        }

        public virtual void Update(GameTime gameTime, TouchCollection touchCollection)
        {
        }
    }
}
