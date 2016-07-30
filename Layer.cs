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
            
            //empty component parent needed for worldXY calculation
            // speed optimization, more memmory usage less null reference checks
            Attach(new Component());
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
