using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace JIC.Charting
{
    /// <summary>
    /// Abstract base class for all charting symbols.
    /// </summary>
    public abstract class Symbol
    {
        #region Public Members

        /// <summary>
        /// The size of the symbol.
        /// </summary>
        public float Size = 8.0f;

        /// <summary>
        /// The border colour of the symbol.
        /// </summary>
        public Color BorderColour = Color.Black;

        /// <summary>
        /// The fill colour of the symbol.
        /// </summary>
        public Color FillColour = Color.White;

        /// <summary>
        /// The border size.
        /// </summary>
        public float BorderSize = 1f;

        #endregion

        #region Internal Methods

        /// <summary>
        /// Draw the symbol.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal abstract void Draw(Graphics g, float x, float y);

        #endregion
    }
}
