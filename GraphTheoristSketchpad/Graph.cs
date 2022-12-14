using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GraphTheoristSketchpad
{
    class Graph
    {
        private List<Vertex> vertices; // list of graph vertices
        private List<Edge> edges; // list of graph edges
        private Vertex selectedVertex; // current selected vertex
        private List<Edge> selectedEdges; // list of selected edges
        private bool hasSelectedVertex; // wether or not a selected vertex exists

        /// <summary>
        /// Graph constructor
        /// </summary>
        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
            selectedEdges = new List<Edge>();
            this.hasSelectedVertex = false;
        }
        /// <summary>
        /// Gets the graph's vertex list
        /// </summary>
        public List<Vertex> Vertices
        {
            get
            {
                return vertices;
            }
        }

        /// <summary>
        /// Gets the graph's edge list
        /// </summary>
        public List<Edge> Edges
        {
            get
            {
                return edges;
            }
        }

        /// <summary>
        /// Gets the selected vertex
        /// </summary>
        public Vertex SelectedVertex
        {
            get
            {
                return this.selectedVertex;
            }
        }

        /// <summary>
        /// Gets the selected edges list
        /// </summary>
        public List<Edge> SelectedEdges
        {
            get
            {
                return this.selectedEdges;
            }
        }

        /// <summary>
        /// Updates the selected vertex.
        /// </summary>
        /// <param name="v">target vertex</param>
        /// <param name="value">wether to deselect or select the vertex</param>
        public void UpdateSelectedVertex(Vertex v, bool value)
        {
            if (!hasSelectedVertex && value)
            {
                v.Selected = true;
                this.selectedVertex = v;
                this.hasSelectedVertex = true;
            }
            else if (!value)
            {
                v.Selected = false;
                this.selectedVertex = null;
                this.hasSelectedVertex = false;
            }
        }

        /// <summary>
        /// Select a new edge.
        /// </summary>
        /// <param name="e">edge to be selected</param>
        public void AddSelectedEdge(Edge e)
        {
            selectedEdges.Add(e);
        }
        
        /// <summary>
        /// Deselects an edge.
        /// </summary>
        /// <param name="e">edge to deselect</param>
        public void DeselectEdge(Edge e)
        {
            selectedEdges.Remove(e);
        }

        /// <summary>
        /// Adds a new vertex to the graph.
        /// </summary>
        /// <param name="v"> vertex to add.</param>
        public void AddVertex(Vertex v)
        {
            vertices.Add(v);
        }

        /// <summary>
        /// Adds a new edge to the graph.
        /// </summary>
        /// <param name="from">start point for edge</param>
        /// <param name="to">end point for edge</param>
        /// <param name="color">edge color</param>
        /// <param name="width">edge width</param>
        public void AddEdge(Vertex from, Vertex to, Color color, int width)
        {
            Edge edge;
            foreach (Edge e in from.Edges)
            {
                // parallel edge
                if (e.Vertex1 == from && e.Vertex2 == to)
                {
                    from.IncrementParallelEdges();
                    to.IncrementParallelEdges();
                    edge = new Edge(from, to, color, width, from.ParallelEdges);
                    edges.Add(edge);
                    from.Edges.Add(edge);
                    to.Edges.Add(edge);
                    return;
                }
            }

            from.Neighbors.Add(to);
            to.Neighbors.Add(from);
            edge = new Edge(from, to, color, width);
            edges.Add(edge);

            from.Edges.Add(edge);
            to.Edges.Add(edge);
        }
        /// <summary>
        /// Checks if the graph is bipartite.
        /// </summary>
        /// <returns></returns>
        public bool CheckBipartite()
        {
            if (HasLoop())
            {
                return false;
            }

            foreach (Vertex v in vertices)
            {
                v.VertexColor = Color.Black;
            }
            bool[] visited = new bool[vertices.Count()];
            int index;
            bool result = false;

            while ((index = CheckIfVisited(visited)) != -1)
            {
                result = PaintGraph(index, Color.Red, visited);
            }

            return result;
        }
        /// <summary>
        /// Gets an adjacency matrix of the graph.
        /// </summary>
        /// <returns>the adjacency matrix</returns>
        public int[,] GetMatrix()
        {
            int n = vertices.Count;
            int[,] adjacencyMatrix  = new int[n, n];
            int indexX = 0;
            int indexY = 0;
            foreach (Vertex v in vertices)
            {
                indexX = vertices.IndexOf(v);

                foreach(Vertex neighbor in v.Neighbors)
                {
                    indexY = vertices.IndexOf(neighbor);
                    adjacencyMatrix[indexX, indexY] = 1;
                }
            }
            return adjacencyMatrix;
        }
        /// <summary>
        /// Counts the amount of graph components.
        /// </summary>
        /// <returns>amount of graph components</returns>
        public int CountComponents()
        {
            bool[] visited = new bool[vertices.Count()];
            int count = 0;
            int index;

            while ((index = CheckIfVisited(visited)) != -1)
            {
                SearchGraph(index, visited);
                count++;
            }

            return count;
        }
        /// <summary>
        /// Checks if a vertex has been visited.
        /// </summary>
        /// <param name="visited">boolean array of visited values</param>
        /// <returns>index of next unvisited vertex or -1 if all have been visited.</returns>
        private int CheckIfVisited(bool[] visited)
        {
            for (int i = 0; i < visited.Length; i++)
            {
                if (!visited[i])
                {
                    return i;
                }
            }

            return -1;
        }
        /// <summary>
        /// Depth first search of graph.
        /// </summary>
        /// <param name="start">start index.</param>
        /// <param name="visited">bool array of visited values</param>
        private void SearchGraph(int start, bool[] visited)
        {
            visited[start] = true;

            Vertex current = vertices.ElementAt(start);

            foreach (Vertex neighbor in current.Neighbors)
            {
                int destination = vertices.IndexOf(neighbor);

                if (destination != -1 && !visited[destination])
                {
                    SearchGraph(destination, visited);
                }
            }
        }
        /// <summary>
        /// Depth first painting of graph.
        /// </summary>
        /// <param name="start">start index.</param>
        /// <param name="color">color to paint visited vertex</param>
        /// <param name="visited">bool arraya of visited values</param>
        private bool PaintGraph(int start, Color color, bool[] visited)
        {
            Vertex current = vertices.ElementAt(start);

            visited[start] = true;
            Color newColor;

            if (color == Color.Red)
            {
                newColor = Color.Blue;
            }
            else
            {
                newColor = Color.Red;
            }

            current.VertexColor = color;

            foreach (Vertex neighbor in current.Neighbors)
            {
                int destination = vertices.IndexOf(neighbor);
                if(vertices.ElementAt(destination).VertexColor == color)
                {
                    return false;
                }

                if (destination != -1 && !visited[destination])
                {
                    PaintGraph(destination, newColor, visited);
                }
            }

            return true;
        }

        /// <summary>
        /// Wether the graph has a loop or not.
        /// </summary>
        /// <returns>true if a loop exists, false otherwise</returns>
        private bool HasLoop()
        {
            foreach (Edge e in edges)
            {
                if (e.IsLoop)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
