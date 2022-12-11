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
    public class Edge : IGraphObject
    {
        private Vertex v1; // edge point 1
        private Vertex v2; // edge point 2
        private Color color; // edge color
        private bool selected; // whether or not the edge is selected
        private bool isLoop; // whether or not the edge is a loop
        private int width; // edge width
        private int parallelEdge; // wether or not the edge is a parallel edge

        /// <summary>
        /// Constructs a new edge.
        /// </summary>
        /// <param name="v1">first edge point</param>
        /// <param name="v2">second edge point</param>
        /// <param name="color">color for the edge</param>
        /// <param name="width">width for the edge</param>
        public Edge(Vertex v1, Vertex v2, Color color, int width)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.isLoop = (v1 == v2);
            this.color = color;
            this.width = width;
            this.parallelEdge = 0;
        }

        /// <summary>
        /// Constructs a new edge.
        /// </summary>
        /// <param name="v1">first edge point</param>
        /// <param name="v2">second edge point</param>
        /// <param name="color">color for the edge</param>
        /// <param name="width">width for the edge</param>
        /// <param name="parallelEdge">the ith parallel edge for the vertex points</param>
        public Edge(Vertex v1, Vertex v2, Color color, int width, int parallelEdge)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.isLoop = (v1 == v2);
            this.color = color;
            this.width = width;
            this.parallelEdge = parallelEdge;
        }

        /// <summary>
        /// Gets or sets if the edge is selected
        /// </summary>
        public bool Selected
        {
            get
            {
                return selected;
            }

            set
            {
                selected = value;
            }
        }

        /// <summary>
        /// Gets if the edge is a loop
        /// </summary>
        public bool IsLoop
        {
            get
            {
                return isLoop;
            }
        }

        /// <summary>
        /// Gets the first vertex
        /// </summary>
        public Vertex Vertex1
        {
            get
            {
                return v1;
            }
        }

        /// <summary>
        /// Gets the second vertex
        /// </summary>
        public Vertex Vertex2
        {
            get
            {
                return v2;
            }
        }

        /// <summary>
        /// Gets the edge color
        /// </summary>
        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        /// <summary>
        /// Draws the edge on the graphics object.
        /// </summary>
        /// <param name="g">graphics object to draw on</param>
        /// <param name="pen">pen for drawing</param>
        public void Draw(Graphics g, Pen pen)
        {
            using (var path = GetPath())
                g.DrawPath(pen, path);
        }

        /// <summary>
        /// Gets the path for the edge.
        /// </summary>
        /// <returns>a graphics path of the edge</returns>
        public GraphicsPath GetPath()
        {
            GraphicsPath path = new GraphicsPath();
            int offset = v1.Radius;
            int x1 = v1.VertexPoint.X + offset;
            int x2 = v2.VertexPoint.X + offset;
            int y1 = v1.VertexPoint.Y + offset;
            int y2 = v2.VertexPoint.Y + offset;

            int parallelOffset = DetermineParallelOffsetAmount();

            // if horizontal
            if (Math.Abs(x1) - Math.Abs(x2) > Math.Abs(y1) - Math.Abs(y2))
            {
               return BuildPath(path, x1, y1, x2, y2, parallelOffset, 0);
            }
            // if vertical
            else
            {
               return BuildPath(path, x1, y1, x2, y2, 0, parallelOffset);
            }
        }

        /// <summary>
        /// Test if point is located on the edge.
        /// </summary>
        /// <param name="clickPos">point clicked</param>
        /// <returns>whether or not the edge was clicked</returns>
        public bool HitTest(Point clickPos)
        {
            var result = false;
            using (var path = GetPath())
            using (var pen = new Pen(color, width + 15))
                result = path.IsOutlineVisible(clickPos, pen);
            return result;
        }
        /// <summary>
        /// Determines the offset amount for paralell edges.
        /// </summary>
        /// <returns>the offset</returns>
        private int DetermineParallelOffsetAmount()
        {
            if (parallelEdge == 0)
            {
                return 0;
            }
            else if (parallelEdge % 2 == 0)
            {
                return -12 * parallelEdge;
            }
            else
            {
                return 12 * parallelEdge;
            }
        }

        /// <summary>
        /// Builds the path of the edge.
        /// </summary>
        /// <param name="path">base path to build on</param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <returns>the edge's path</returns>
        private GraphicsPath BuildPath(GraphicsPath path, int x1, int y1, int x2, int y2, int xOffset, int yOffset)
        {
            // loop
            if (v1 == v2)
            {
                int dim = 35 + (parallelEdge * 10);
                path.AddArc(new Rectangle(x1 - 16, y1, 30, dim), 0, 360);
                return path;
            }
            else
            {
                PointF[] points = new PointF[3];
                points[0] = (new PointF(x1, y1));
                points[1] = (new PointF(((x1 + x2) / 2) + xOffset, ((y1 + y2) / 2) + yOffset));
                points[2] = (new PointF(x2, y2));

                path.AddCurve(points);
                return path;
            }
        }
    }
}
