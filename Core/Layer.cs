using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSceneGraph.Core
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
            batch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, transformMatrix: App.Viewport.Matrix);

            base.Draw(gameTime, batch);

            batch.End();
        }
    }
}
