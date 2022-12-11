/*
 * Graph Theorist's Sketchpad
 * Author: Samuel Gibson
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace GraphTheoristSketchpad
{
    public partial class SketchPad : Form
    {
        private Graph graph; // graph holding vertices, edges, and info
        private int vertex_count = 0; // amount of drawn vertices
        private const int VERTEX_RADIUS = 12; // default vertex radius
        private const int EDGE_WIDTH = 3; // default edge width
        private bool moveState; // state of moving vertex
        private bool deleteState; // state of deleting
        private Vertex movingVertex; // the vertex being moved
        private Point lastVertexLocation; // previous moving vertex location
        public SketchPad()
        {
            InitializeComponent();
            graph = new Graph();
            movingVertex = null;
            moveState = false;
            deleteState = false;

            // stop flickering on panel repaint
            this.DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered", 
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, 
            null, graphPanel, new object[] { true });
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // draw edges
            if (graph.Edges != null)
            {
                foreach (Edge edge in graph.Edges)
                {
                    Pen edgePen;
                    // draw selected edge
                    if (graph.SelectedEdges.Contains(edge))
                    {
                        edgePen = new Pen(edge.Color, EDGE_WIDTH);
                        edgePen.DashStyle = DashStyle.Dot;
                    }
                    // draw regular edge
                    else
                    {
                        edgePen = new Pen(edge.Color, EDGE_WIDTH);
                        edgePen.DashStyle = DashStyle.Solid;
                        
                    }
                    edge.Draw(g, edgePen);
                    edgePen.Dispose();
                }
            }

            // draw vertices
            if (graph.Vertices != null)
            {
                foreach (Vertex v in graph.Vertices)
                {
                    Pen pen;

                    // add blue outline for selected vertex
                    if (graph.SelectedVertex == v)
                    {
                        pen = new Pen(Color.DeepSkyBlue, 3);
                        pen.DashStyle = DashStyle.Solid;
                    }
                    // draw regular vertex
                    else
                    {
                        pen = new Pen(Color.Black, 2);
                        pen.DashStyle = DashStyle.Solid;
                    }

                    SolidBrush brush = new SolidBrush(v.VertexColor);
                    v.Draw(g, pen);
                    pen.Dispose();
                }
            }
        }
        private void panel1_MouseClick_1(object sender, MouseEventArgs e)
        {
            Point clickPos = e.Location;
            Edge edge = TryGetEdge(clickPos); // the clicked edged
            Vertex v = TryGetVertex(clickPos); // the clicked vertex

            // right click used for selecting objects
            if (e.Button == MouseButtons.Right)
            {
                // select vertex
                if (v != null)
                {
                    // if selected vertex is already the selected vertex, deselect it
                    if (graph.SelectedVertex == v)
                    {
                        graph.UpdateSelectedVertex(graph.SelectedVertex, false);
                        UpdateGraphInfo();
                        return;
                    }
                    // if selected vertex already exists, deselect it and select new vertex
                    else if (graph.SelectedVertex != null)
                    {
                        graph.UpdateSelectedVertex(graph.SelectedVertex, false);
                    }
                    graph.UpdateSelectedVertex(v, true);
                    UpdateGraphInfo();
                    return;
                }
                // select edge
                else if (edge != null)
                {
                    // if selected edge is already selected, deselect it
                    if (graph.SelectedEdges.Contains(edge))
                    {
                        graph.DeselectEdge(edge);
                    }
                    // select edge
                    else
                    {
                        graph.AddSelectedEdge(edge);
                    }

                    graphPanel.Invalidate();
                    return;
                }
            }
            // if deleting, try delete selected object
            else if (e.Button == MouseButtons.Left && deleteState)
            {
                TryDeleteObject(clickPos);
                return;
            }

            // Mouse left click for adding and selecting objects
            else if (e.Button == MouseButtons.Left)
            {
                // check if vertex
                if (v != null)
                {
                    // if one vertex is selected, the next selected vertex forms an edge between the two.
                    if (graph.SelectedVertex != null)
                    {
                        graph.AddEdge(graph.SelectedVertex, v, select_color_button.BackColor, EDGE_WIDTH);
                        UpdateGraphInfo();
                    }

                    return;
                }
                // check for edges.
                else if (edge != null)
                {
                    // deselect edge if it's already selected.
                    if (graph.SelectedEdges.Contains(edge))
                    {
                        graph.DeselectEdge(edge);
                    }

                    graphPanel.Invalidate();
                    return;
                }
                // create new vertex
                else if (v == null)
                {
                    vertex_count++;
                    graph.AddVertex(new Vertex("V" + vertex_count, select_color_button.BackColor, clickPos, VERTEX_RADIUS));
                    UpdateGraphInfo();
                    return;
                }
            }
        }
        private Vertex TryGetVertex(Point pCurrent)
        {
            foreach (Vertex v in graph.Vertices)
            {
                if (v.HitTest(pCurrent))
                {
                    return v;
                }
            }

            return null;
        }
        private Edge TryGetEdge(Point pCurrent)
        {
            foreach (Edge edge in graph.Edges)
            {
                if (edge.HitTest(pCurrent)) {
                    return edge;
                }
            }

            return null;
        }
        private void TryDeleteObject(Point point)
        {
            Vertex v = TryGetVertex(point);
            Edge e = TryGetEdge(point);

            // Vertex
            if (v != null)
            {
                // remove edges with vertex
                foreach(Edge edge in v.Edges)
                {
                    // update vertex neighbors
                    graph.Vertices.Find(vertex => vertex == edge.Vertex1).Neighbors.Remove(edge.Vertex2);
                    graph.Vertices.Find(vertex => vertex == edge.Vertex2).Neighbors.Remove(edge.Vertex1);

                    if (graph.SelectedEdges.Contains(edge))
                    {
                        graph.DeselectEdge(edge);
                    }
                    graph.Edges.Remove(edge);
                }

                if (graph.SelectedVertex == v)
                {
                    graph.UpdateSelectedVertex(v, false);
                }

                v.Edges.Clear();
                graph.Vertices.Remove(v);
                vertex_count--;
                UpdateGraphInfo();
            }
            // Edge
            else if (e != null) {
                if (graph.SelectedEdges.Contains(e))
                {
                    graph.DeselectEdge(e);
                }
                // update vertex neighbors
                graph.Vertices.Find(vertex => vertex == e.Vertex1).Neighbors.Remove(e.Vertex2);
                graph.Vertices.Find(vertex => vertex == e.Vertex2).Neighbors.Remove(e.Vertex1);
                graph.Edges.Remove(e);
                e.Vertex1.Edges.Remove(e);
                e.Vertex2.Edges.Remove(e);
                UpdateGraphInfo();
            }
        }
        private void GraphPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // select vertex to move
            if (e.Button == MouseButtons.Left)
            {
                movingVertex = TryGetVertex(e.Location);

                if (movingVertex != null)
                {
                    moveState = true;
                    lastVertexLocation = movingVertex.VertexPoint;
                }
            }  
        }
        private void GraphPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // move vertex with mouse
            if (moveState && e.Button == MouseButtons.Left)
            {
                Point newPoint = new Point(e.X - lastVertexLocation.X, e.Y - lastVertexLocation.Y);
                lastVertexLocation = e.Location;
                movingVertex.Move(newPoint);
                graphPanel.Invalidate();
            }
        }
        private void GraphPanel_MouseUp(object sender, MouseEventArgs e)
        {
            // reset vertex moving attributes
            if (moveState && e.Button == MouseButtons.Left)
            {
                moveState = false;
                movingVertex = null;
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (!deleteState)
            {
                // set button active
                deleteButton.BackColor = Color.Red;
                deleteState = true;
            }
            else
            {
                // set button inactive
                deleteButton.BackColor = SystemColors.ButtonFace;
                deleteState = false;
            }
        }
        private void Paint_button_Click_1(object sender, EventArgs e)
        {
            // paint selected objects
            foreach (Edge edge in graph.SelectedEdges)
            {
                edge.Color = select_color_button.BackColor;
            }
            if (graph.SelectedVertex != null)
            {
                graph.SelectedVertex.VertexColor = select_color_button.BackColor;
                graph.UpdateSelectedVertex(graph.SelectedVertex, false);
            }
            graph.SelectedEdges.Clear();
            graphPanel.Invalidate();
        }
        private void Select_color_button_Click(object sender, EventArgs e)
        {
            // choose color
            paint_color_dialog.ShowDialog();
            select_color_button.BackColor = paint_color_dialog.Color;
        }
        private void UpdateGraphInfo()
        {
            edge_label.Text = "m = " + graph.Edges.Count();
            vertex_label.Text = "n = " + graph.Vertices.Count();

            if (graph.SelectedVertex != null)
            {
                deg_label.Text = "deg(" + graph.SelectedVertex.ID + ") = " + graph.SelectedVertex.Edges.Count();
            }
            else
            {
                deg_label.Text = "deg(V) = ";
            }

            component_label.Text = "components = " + graph.CountComponents();

            bipartite_label.Text = "bipartite: ";

            int[,] adjacenyMatrix = graph.GetMatrix();
            int dimX = adjacenyMatrix.GetLength(0);
            int dimY = adjacenyMatrix.GetLength(1);
            string[] matrix = new string[dimY];

            for (int y = 0; y < dimY; y++)
            {
                for (int x = 0; x < dimX; x++)
                {
                    matrix[y] += adjacenyMatrix[x, y];
                }
            }
            matrix_display.Lines = matrix;
            

            graphPanel.Invalidate();
        }
        private void Clear_all_button_Click(object sender, EventArgs e)
        {
            graph = new Graph();
            movingVertex = null;
            moveState = false;
            deleteState = false;
            vertex_count = 0;
            UpdateGraphInfo();
        }
        private void Bipartite_test_button_Click(object sender, EventArgs e)
        {
            bipartite_label.Text = "bipartite: " + graph.CheckBipartite().ToString();
            graphPanel.Invalidate();
        }
    }
}
