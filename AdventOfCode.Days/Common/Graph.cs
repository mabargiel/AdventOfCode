using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days.Common;

public class Graph<TNode>
{
    private readonly Dictionary<TNode, List<(TNode node, int weight)>> _adjacency;

    public Graph()
    {
        _adjacency = new Dictionary<TNode, List<(TNode node, int weight)>>();
    }

    public Graph(int vertices)
    {
        _adjacency = new Dictionary<TNode, List<(TNode node, int weight)>>(vertices);
    }

    public void AddEdge(TNode src, TNode dst, int weight = 1)
    {
        if (!_adjacency.TryGetValue(src, out var list))
        {
            list = [];
            _adjacency[src] = list;
        }

        list.Add((dst, weight));

        if (!_adjacency.ContainsKey(dst))
        {
            _adjacency[dst] = [];
        }
    }

    public int DijkstraShortestPath(TNode src, TNode dst)
    {
        if (!_adjacency.ContainsKey(src))
            _adjacency[src] = [];

        if (!_adjacency.ContainsKey(dst))
            _adjacency[dst] = [];

        var dist = new Dictionary<TNode, int>(_adjacency.Comparer);
        var settled = new HashSet<TNode>(_adjacency.Comparer);
        var pq = new PriorityQueue<TNode, int>();

        foreach (var node in _adjacency.Keys)
            dist[node] = int.MaxValue;

        dist[src] = 0;
        pq.Enqueue(src, 0);

        while (pq.Count > 0)
        {
            var u = pq.Dequeue();
            if (!settled.Add(u))
                continue;

            if (EqualityComparer<TNode>.Default.Equals(u, dst))
                return dist[u];

            var neighbors = _adjacency[u];
            foreach (var (neighbor, weight) in neighbors)
            {
                if (settled.Contains(neighbor))
                    continue;

                var newDistance = dist[u] + weight;
                if (newDistance >= dist[neighbor])
                {
                    continue;
                }

                dist[neighbor] = newDistance;
                pq.Enqueue(neighbor, newDistance);
            }
        }

        return dist[dst];
    }

    /// <summary>
    /// Works only in DAG graphs
    /// </summary>
    public long CountAllPaths(TNode src, TNode dst, TNode[]? through = null)
    {
        if (!_adjacency.ContainsKey(src) || !_adjacency.ContainsKey(dst))
            return 0;

        through ??= [];
        through = through.Distinct().ToArray();

        var comparer = _adjacency.Comparer;

        var reachableFromSrc = new HashSet<TNode>(_adjacency.Comparer);
        {
            var stack = new Stack<TNode>();
            stack.Push(src);
            reachableFromSrc.Add(src);
            while (stack.Count > 0)
            {
                var n = stack.Pop();
                if (!_adjacency.TryGetValue(n, out var neighbors))
                    continue;
                foreach (var (nb, _) in neighbors)
                {
                    if (reachableFromSrc.Add(nb))
                        stack.Push(nb);
                }
            }
        }

        var reverse = new Dictionary<TNode, List<TNode>>(_adjacency.Comparer);
        foreach (var node in _adjacency.Keys)
            reverse[node] = [];
        foreach (var (node, neighbors) in _adjacency)
        {
            foreach (var (nb, _) in neighbors)
            {
                if (!reverse.TryGetValue(nb, out var list))
                {
                    list = [];
                    reverse[nb] = list;
                }
                list.Add(node);
            }
        }

        var canReachDst = new HashSet<TNode>(_adjacency.Comparer);
        {
            var stack = new Stack<TNode>();
            stack.Push(dst);
            canReachDst.Add(dst);
            while (stack.Count > 0)
            {
                var n = stack.Pop();
                if (!reverse.TryGetValue(n, out var preds))
                    continue;
                foreach (var p in preds.Where(p => canReachDst.Add(p)))
                {
                    stack.Push(p);
                }
            }
        }

        if (!reachableFromSrc.Contains(dst))
            return 0;

        if (through.Any(t => !reachableFromSrc.Contains(t) || !canReachDst.Contains(t)))
        {
            return 0;
        }

        var relevant = new HashSet<TNode>(_adjacency.Comparer);
        foreach (var n in reachableFromSrc.Where(n => canReachDst.Contains(n)))
        {
            relevant.Add(n);
        }

        var onStack = new HashSet<TNode>(_adjacency.Comparer);
        var seen = new HashSet<TNode>(_adjacency.Comparer);

        if (HasCycle(src))
            throw new InvalidOperationException(
                "CountAllPaths with through-nodes requires the src→dst subgraph to be acyclic."
            );

        var indexByThrough = new Dictionary<TNode, int>(_adjacency.Comparer);
        for (var i = 0; i < through.Length; i++)
            indexByThrough[through[i]] = i;

        var fullMask = (through.Length == 0 ? 0 : (1 << through.Length) - 1);
        var memo = new Dictionary<(TNode node, int mask), long>();

        return Dfs(src, 0);

        bool HasCycle(TNode node)
        {
            if (!relevant.Contains(node))
                return false;
            if (onStack.Contains(node))
                return true;
            if (!seen.Add(node))
                return false;
            onStack.Add(node);
            if (_adjacency.TryGetValue(node, out var neighbors))
            {
                foreach (var (nb, _) in neighbors)
                {
                    if (HasCycle(nb))
                        return true;
                }
            }
            onStack.Remove(node);
            return false;
        }

        long Dfs(TNode node, int mask)
        {
            if (!relevant.Contains(node))
                return 0;

            if (indexByThrough.TryGetValue(node, out var idx))
                mask |= 1 << idx;

            if (comparer.Equals(node, dst))
                return mask == fullMask ? 1 : 0;

            var key = (node, mask);
            if (memo.TryGetValue(key, out var cached))
                return cached;

            long total = 0;
            if (_adjacency.TryGetValue(node, out var neighbors))
            {
                foreach (var (nb, _) in neighbors)
                {
                    total += Dfs(nb, mask);
                }
            }

            memo[key] = total;
            return total;
        }
    }
}
