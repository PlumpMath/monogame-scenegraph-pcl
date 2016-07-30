using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch batch);
        public abstract void Update(GameTime gameTime, TouchCollection touchCollection);
    }
}
