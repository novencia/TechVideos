using System.Collections.Generic;

namespace GraphTools.Tests
{
    internal class GraphNodeMock : IGraphNode
    {
        private string _value;

        private List<IGraphNode> _graphNodes = new List<IGraphNode>();

        public GraphNodeMock(string value)
        {
            _value = value;
        }

        public void AddNode(IGraphNode node)
        {
            _graphNodes.Add(node);
        }
        public List<IGraphNode> GetAdjacentNodes()
        {
            return _graphNodes;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                GraphNodeMock node = (GraphNodeMock)obj;
                return _value == node._value;
            }
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
