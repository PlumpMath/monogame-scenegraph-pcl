using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public class Layer : Entity
    {
        
        public Layer(GraphicsDevice graphicsDevice)
        {            
            batch = new SpriteBatch(graphicsDevice);
        }

        private readonly SpriteBatch batch;

        public void Draw(GameTime gameTime)
        {
            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

            base.Draw(gameTime, batch);

            batch.End();
        }
        
    }
}
