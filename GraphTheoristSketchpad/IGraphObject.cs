using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GraphTheoristSketchpad
{
    public interface IGraphObject
    {
        /// <summary>
        /// Gets the path of the object.
        /// </summary>
        /// <returns>the object's graphics path</returns>
        GraphicsPath GetPath();

        /// <summary>
        /// Whether or not the object exists at the clicked point.
        /// </summary>
        /// <param name="clickPos">point clicked</param>
        /// <returns>whether or not the object was clicked</returns>
        bool HitTest(Point clickPos);

        /// <summary>
        /// Draws the object on a graphics.
        /// </summary>
        /// <param name="g">graphics to draw on</param>
        /// <param name="pen">pen to draw with</param>
        void Draw(Graphics g, Pen pen);

    }
}
