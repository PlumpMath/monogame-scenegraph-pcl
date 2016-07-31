using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public class Sprite : Component
    {
        public virtual void Init(Texture2D texture)
        {
            this.texture = texture;            
            center = new Vector2((float)texture.Width / 2, (float)texture.Height / 2);
            this.tint = Color.White;
            this.effects = SpriteEffects.None;
            this.srcRect = new Rectangle(0, 0, texture.Width, texture.Height);
            this.destRect = new Rectangle(0, 0, texture.Width, texture.Height);
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
                color: tint,
                effects: effects,
                layerDepth: z);
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        private Texture2D texture;

    }
}
