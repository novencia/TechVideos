using System;
using System.Collections.Generic;
using System.Text;

namespace GraphTools
{
    public interface IGraphNode
    {
        public List<IGraphNode> GetAdjacentNodes();
    }
}
