﻿using System;
using System.Collections.Generic;

namespace Advanced.Algorithms.DataStructures.Graph;

/// <summary>
///     Directed graph.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDiGraph<T>
{
    bool IsWeightedGraph { get; }
    IDiGraphVertex<T> ReferenceVertex { get; }
    IEnumerable<IDiGraphVertex<T>> VerticesAsEnumberable { get; }
    int VerticesCount { get; }

    bool ContainsVertex(T value);
    IDiGraphVertex<T> GetVertex(T key);

    bool HasEdge(T source, T destination);

    IDiGraph<T> Clone();
}

public interface IDiGraphVertex<T>
{
    T Key { get; }
    IEnumerable<IDiEdge<T>> OutEdges { get; }
    IEnumerable<IDiEdge<T>> InEdges { get; }

    int OutEdgeCount { get; }
    int InEdgeCount { get; }

    IDiEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex);
}

public interface IDiEdge<T>
{
    T TargetVertexKey { get; }
    IDiGraphVertex<T> TargetVertex { get; }
    W Weight<W>() where W : IComparable;
}

internal class DiEdge<T, C> : IDiEdge<T> where C : IComparable
{
    private readonly object weight;

    internal DiEdge(IDiGraphVertex<T> target, C weight)
    {
        TargetVertex = target;
        this.weight = weight;
    }

    public T TargetVertexKey => TargetVertex.Key;

    public IDiGraphVertex<T> TargetVertex { get; }

    public W Weight<W>() where W : IComparable
    {
        return (W)weight;
    }
}