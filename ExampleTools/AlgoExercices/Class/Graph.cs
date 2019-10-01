using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoExercices
{
    public class Graph
    {
        private List<Vertex> _vertexs;

        private List<Edge> _edges;

        public Graph(List<Vertex> vertexs, List<Edge> edges)
        {
            _vertexs = vertexs;
            _edges = edges;
        }

        public Graph()
            : this(null, null)
        {

        }

        public void AddEdge(Vertex src, Vertex target)
        {
            this._edges.Add(new Edge(src, target));
        }

        public void AddEdge(Edge edge)
        {
            this._edges.Add(edge);
        }

        public void AddVertex(Vertex node)
        {
            this._vertexs.Add(node);
        }

        public void RemoveVertex(Vertex vertex)
        {
            this._vertexs.Remove(vertex);
        }

        public void RemoveEdge(Edge edge)
        {
            this._edges.Remove(edge);
        }

        public bool HasEdge(Vertex v1, Vertex v2)
        {
            List<Edge> l = this._edges.Where(e => e.Source == v1 && e.Target == v2).ToList();
            if (l.Count > 0) return true;

            l = this._edges.Where(e => e.Source == v2 && e.Target == v1).ToList();
            if (l.Count > 0) return true;

            return false;
        }

        public List<Edge> GetInboundVertex(Vertex v) => this._edges.Where(e => e.Target == v).ToList();
        public List<Edge> GetOutboundVertex(Vertex v) => this._edges.Where(e => e.Source == v).ToList();

    }

    public class Edge
    {
        private Vertex _source;

        private Vertex _target;

        public Vertex Source => _source;
        public Vertex Target => _target;

        public Edge(Vertex source, Vertex target)
        {
            _source = source;
            _target = target;
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}", _source, _target);
        }
    }

    public abstract class Vertex
    {
        public Graph Graph { get; internal set; }

        public List<Edge> InboundEdges => Graph.GetOutboundVertex(this);

        public List<Edge> OutboundEdges => Graph.GetOutboundVertex(this);
    }

    public class Vertex<T> : Vertex
    {
        private T _data;

        public Vertex(T data)
        {
            _data = data;
        }

        public override string ToString() => _data.ToString();
    }
}
