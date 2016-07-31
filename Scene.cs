using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public class Scene : IList<Layer>
    {
        private List<Layer> layers;
         
        public Scene()
        {
            this.layers = new List<Layer>();
        }

        public Layer AddLayer()
        {
            var layer = new Layer(App.GraphicsDevice);
            Add( layer );
            return layer;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Update(GameTime gameTime)
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (var layer in layers)
                layer.Update(gameTime, touchCollection);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(GameTime gameTime)
        {
            App.GraphicsDevice.Clear(Color.Black);
            
            foreach (var layer in layers)
                layer.Draw(gameTime);
        }

        public IEnumerator<Layer> GetEnumerator()
        {
            return layers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) layers).GetEnumerator();
        }

        public void Add(Layer item)
        {
            item.Init();
            layers.Add(item);
        }

        public void Clear()
        {
            layers.Clear();
        }

        public bool Contains(Layer item)
        {
            return layers.Contains(item);
        }

        public void CopyTo(Layer[] array, int arrayIndex)
        {
            layers.CopyTo(array, arrayIndex);
        }

        public bool Remove(Layer item)
        {
            return layers.Remove(item);
        }

        public int Count
        {
            get { return layers.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(Layer item)
        {
            return layers.IndexOf(item);
        }

        public void Insert(int index, Layer item)
        {
            item.Init();
            layers.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            layers.RemoveAt(index);
        }

        public Layer this[int index]
        {
            get
            {
                return layers[index];
            }
            set
            {
                value.Init();
                layers[index] = value;
            }
        }
    }
}
