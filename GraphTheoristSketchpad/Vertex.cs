using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GraphTheoristSketchpad
{
    public class Vertex : IGraphObject
    {
        /// <summary>
        /// Identifier of vertex.
        /// </summary>
        private string id;

        /// <summary>
        /// Color of the vertex.
        /// </summary>
        private Color color;

        /// <summary>
        /// If the node is selected.
        /// </summary>
        private bool selected;

        /// <summary>
        /// Vertex coordinates.
        /// </summary>
        private Point point;

        private int radius; // radius for the vertex.

        private int parallelEdgeCount; // amount of parallel edges.

        private List<Edge> connectedEdges; // list of edges connected to this vertex.

        private List<Vertex> neighbors; // list of neighboring vertices.

        /// <summary>
        /// Construct a new vertex.
        /// </summary>
        /// <param name="id">id for the vertex</param>
        /// <param name="color">color for the vertex</param>
        /// <param name="point">vertex coordinates</param>
        /// <param name="radius">radius of the vertex</param>
        public Vertex(string id, Color color, Point point, int radius)
        {
            this.id = id;
            this.color = color;
            this.selected = false;
            this.radius = radius;
            this.parallelEdgeCount = 0;
            Point p = point;
            p.Offset(-radius, -radius);
            this.point = p;
            this.connectedEdges = new List<Edge>();
            this.neighbors = new List<Vertex>();
        }

        /// <summary>
        /// Gets the connected edges.
        /// </summary>
        public List<Edge> Edges
        {
            get
            {
                return connectedEdges;
            }
        }

        /// <summary>
        /// Gets the vertex neighbors.
        /// </summary>
        public List<Vertex> Neighbors
        {
            get
            {
                return neighbors;
            }
        }

        /// <summary>
        /// Gets the vertex radius.
        /// </summary>
        public int Radius
        {
            get
            {
                return radius; 
            }
        }

        /// <summary>
        /// Gets the amount of parallel edges.
        /// </summary>
        public int ParallelEdges
        {
            get
            {
                return parallelEdgeCount;
            }
        }

        /// <summary>
        /// Gets or sets the vertex id.
        /// </summary>
        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the vertex color.
        /// </summary>
        public Color VertexColor
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        /// <summary>
        /// Gets or sets whether or not the vertex is selected.
        /// </summary>
        public bool Selected
        {
            get
            {
                return this.selected;
            }

            set
            {
                this.selected = value;
            }
        }

        /// <summary>
        /// Gets the vertex's point.
        /// </summary>
        public Point VertexPoint
        {
            get
            {
                return this.point;
            }

            set
            {
                this.point = value;
            }
        }

        /// <summary>
        /// Increment the amount of parallel edges
        /// </summary>
        public void IncrementParallelEdges()
        {
            parallelEdgeCount++;
        }

        /// <summary>
        /// Draws the vertex on a graphics object.
        /// </summary>
        /// <param name="g">the graphics to draw on</param>
        /// <param name="pen">the pen to draw the vertex with</param>
        public void Draw(Graphics g, Pen pen)
        {
            using (var path = GetPath())
            using (var brush = new SolidBrush(color))
                g.FillPath(brush, path);
            using (var path = GetPath())
                g.DrawPath(pen, path);
        }

        /// <summary>
        /// Gets the vertex's path.
        /// </summary>
        /// <returns> the vertex's graphics path</returns>
        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            var p = point;
            path.AddEllipse(p.X, p.Y, 2 * radius, 2 * radius);
            return path;
        }

        /// <summary>
        /// Checks whether or not the clicked point is on the vertex.
        /// </summary>
        /// <param name="clickPos">point clicked</param>
        /// <returns>whether or not the vertex was clicked</returns>
        public bool HitTest(Point clickPos)
        {
            var result = false;
            using (var path = GetPath())
            using (var pen = new Pen(color, radius + 15))
                result = path.IsOutlineVisible(clickPos, pen) || path.IsVisible(clickPos);
            return result;
        }

        /// <summary>
        /// Moves the vertex to a new point
        /// </summary>
        /// <param name="target">point to move to</param>
        public void Move(Point target)
        {
            point = new Point(point.X + target.X, point.Y + target.Y);
        }
    }
}
