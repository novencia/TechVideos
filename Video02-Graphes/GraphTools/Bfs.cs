using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphTools
{
    public static class Bfs
    {
        public static IEnumerable<IGraphNode> ShortestPathTo(this IGraphNode nodeSource, IGraphNode nodeTarget)
        {
            if (nodeSource == null || nodeTarget == null)
            {
                throw new ArgumentNullException("Please input non null arguments");
            }

            Queue<IGraphNode> graphNodes = new Queue<IGraphNode>();
            HashSet<IGraphNode> visitedNodes = new HashSet<IGraphNode>();
            Dictionary<IGraphNode, IGraphNode> parents = new Dictionary<IGraphNode, IGraphNode>();

            graphNodes.Enqueue(nodeSource);
            visitedNodes.Add(nodeSource);

            while (graphNodes.TryDequeue(out IGraphNode currentNode))
            {

                if (currentNode == nodeTarget)
                {
                    break;
                }

                foreach(IGraphNode node in currentNode.GetAdjacentNodes())
                {
                    if (visitedNodes.Contains(node))
                    {
                        continue;
                    }

                    parents.TryAdd(node, currentNode);
                    graphNodes.Enqueue(node);
                    visitedNodes.Add(node);
                }
            }

            Stack<IGraphNode> pathStack = new Stack<IGraphNode>();

            if (parents.ContainsKey(nodeTarget))
            {
                IGraphNode parent = parents[nodeTarget];
                pathStack.Push(nodeTarget);

                while(parent != nodeSource)
                {
                    pathStack.Push(parent);
                    parent = parents[parent];
                }

                pathStack.Push(nodeSource);
            }

            return  pathStack.ToList();
        }
    }
}
