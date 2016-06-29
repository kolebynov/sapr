using System.Collections.Generic;
using SAPR.Classes;
using System;

namespace SAPR.Structures
{
    [Serializable()]
    public struct Graph
    {
        public Graph(List<Vertex> vertices, List<Edge> edges)
        {
            this.vertices = vertices;
            this.edges = edges;
        }

        public List<Vertex> vertices;
        public List<Edge> edges;
    }
}
