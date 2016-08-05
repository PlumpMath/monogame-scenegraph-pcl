using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameSceneGraph.Support
{
    public class RandomNumberCache
    {

        public RandomNumberCache(int cacheSize)
        {
            var r = new Random();
            lut = new float[cacheSize];
            for (var i = 0; i < cacheSize; i++)
            {
                lut[i] = (float) r.NextDouble();
            }
            index = 0;
        }

        /// <summary>
        /// Returns a random value within a range
        /// </summary>
        /// <param name="min">minimum value (inclusive)</param>
        /// <param name="max">maximum value (inclusive)</param>
        /// <returns>a random value</returns>
        public float Range(float min, float max)
        {
            var rnd = Next();
            var range = max - min;
            return rnd * range + min;
        }

        /// <summary>
        /// Returns a random value within a range favoring higher values using a distribution curve
        /// </summary>
        /// <param name="min">minimum value (inclusive)</param>
        /// <param name="max">maximum value (inclusive)</param>
        /// <returns>a random value</returns>
        public float RangeHigh(float min, float max)
        {
            var rnd = NextHigh();
            var range = max - min;
            return rnd * range + min;
        }

        /// <summary>
        /// Returns a random value within a range favoring lower values using a distribution curve
        /// </summary>
        /// <param name="min">minimum value (inclusive)</param>
        /// <param name="max">maximum value (inclusive)</param>
        /// <returns>a random value</returns>
        public float RangeLow(float min, float max)
        {
            var rnd = NextLow();
            var range = max - min;
            return rnd * range + min;
        }

        /// <summary>
        /// Returns a random value between 0 and 1 favoring higher values using a distribution curve
        /// </summary>
        /// <returns>a random value</returns>
        public float NextHigh()
        {
            return 1 - NextLow();
        }

        /// <summary>
        /// Returns a random value between 0 and 1 favoring lower values using a distribution curve
        /// </summary>
        /// <returns>a random value</returns>
        public float NextLow()
        {
            return Math.Abs(Next() - Next());
        }

        /// <summary>
        /// Returns a random value between 0 and 1 (inclusive)
        /// </summary>
        /// <returns>a random value</returns>
        public float Next()
        {
            return lut[nextIndex()];
        }

        private int nextIndex()
        {
            index++;
            if (index == lut.Length) index = 0;
            return index;
        }

        private float[] lut;
        private int index;

    }
}
