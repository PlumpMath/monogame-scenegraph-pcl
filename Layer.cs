using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public class Layer :  IEnumerable<Sprite>
    {
        public Layer(GraphicsDevice graphicsDevice)
        {
            spriteBatch = new SpriteBatch(graphicsDevice);
            sprites = new List<Sprite>();
        }
        public Layer()
        {            
        }
        public void Init(GraphicsDevice graphicsDevice)
        {
            spriteBatch = new SpriteBatch(graphicsDevice);
            sprites = new List<Sprite>();
        }
        private SpriteBatch spriteBatch;
        private List<Sprite> sprites; 

        public IEnumerator<Sprite> GetEnumerator()
        {
            return sprites.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(Sprite sprite)
        {
            sprite.SpriteBatch = spriteBatch;
            sprites.Add(sprite);
        }

        public void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

            foreach (var sprite in sprites)
                sprite.Draw(gameTime);

            spriteBatch.End();
        }

        public void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            foreach (var sprite in sprites)
                sprite.Update(gameTime, touchCollection);
        }
    }
}
