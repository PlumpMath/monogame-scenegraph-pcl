using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGameSceneGraph
{
    public class Entity : Component, IList<Component>
    {
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// <param name="touchCollection">An object represeting the current input state.</param>
        public override void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            foreach (var item in items)
                item.Update(gameTime, touchCollection);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            foreach (var item in items)
                item.Draw(gameTime, batch);
        }


        // --- IList implementation -------------------------------------------------------------------
        public Entity()
        {
            items = new List<Component>();
        }
        private List<Component> items;

        public IEnumerator<Component> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) items).GetEnumerator();
        }
        
        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(Component item)
        {
            return items.Contains(item);
        }

        public void CopyTo(Component[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(Component item)
        {
            return items.Remove(item);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(Component item)
        {
            return items.IndexOf(item);
        }
        
        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }
        
        public virtual void Add(Component item)
        {
            items.Add(item);
        }

        public virtual void Insert(int index, Component item)
        {
            items.Insert(index, item);
        }

        public virtual Component this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

    }
}
