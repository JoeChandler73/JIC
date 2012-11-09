using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JIC.Charting
{
    /// <summary>
    /// Null symbol.
    /// </summary>
    public sealed class None : Symbol
    {
        #region Singleton Pattern

        private static readonly None _instance = new None();

        public static None Instance
        {
            get
            {
                return _instance;
            }
        }

        private None()
        {
        }

        #endregion

        /// <summary>
        /// Draw the symbol.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal override void Draw(Graphics g, float x, float y)
        {
        }
    }
}
