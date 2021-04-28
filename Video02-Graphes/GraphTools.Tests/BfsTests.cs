using NUnit.Framework;
using System.Linq;

namespace GraphTools.Tests
{
    public class BfsTests
    {
        GraphNodeMock _nodeA = new GraphNodeMock("A");
        GraphNodeMock _nodeB = new GraphNodeMock("B");
        GraphNodeMock _nodeC = new GraphNodeMock("C");
        GraphNodeMock _nodeD = new GraphNodeMock("D");
        GraphNodeMock _nodeE = new GraphNodeMock("E");
        GraphNodeMock _nodeF = new GraphNodeMock("F");

        [SetUp]
        public void SetUp()
        {
            _nodeA = new GraphNodeMock("A");
            _nodeB = new GraphNodeMock("B");
            _nodeC = new GraphNodeMock("C");
            _nodeD = new GraphNodeMock("D");
            _nodeE = new GraphNodeMock("E");
            _nodeF = new GraphNodeMock("F");

            _nodeA.AddNode(_nodeD);
            _nodeA.AddNode(_nodeB);

            _nodeB.AddNode(_nodeC);
            _nodeB.AddNode(_nodeB);
            _nodeB.AddNode(_nodeD);

            _nodeC.AddNode(_nodeE);

            _nodeD.AddNode(_nodeB);
            _nodeD.AddNode(_nodeC);
            _nodeD.AddNode(_nodeF);

            _nodeE.AddNode(_nodeC);
            _nodeE.AddNode(_nodeF);

            _nodeF.AddNode(_nodeB);

        }
        [Test]
        public void GivenTwoNodes_WhenPathExists_ReturnsPath()
        {
            var shortestPath = _nodeA.ShortestPathTo(_nodeE).ToList();

            Assert.That(shortestPath.Any(), Is.True, "We must have a path between these two nodes");

            var path = string.Join(" => ", shortestPath);

            Assert.That(path, Is.EqualTo("A => D => C => E"));
        }
    }
}