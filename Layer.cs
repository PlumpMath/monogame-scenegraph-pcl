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

        public override void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            worldPosition.X = X;
            worldPosition.Y = Y;
            worldRotation = rotation;
            worldScale.X = scale.X;
            worldScale.Y = scale.Y;
            worldVelocity.X = velocity.X;
            worldVelocity.Y = velocity.Y;

            foreach (var item in this)
            {
                item.Update(gameTime, touchCollection);
            }

        }

    }
}
