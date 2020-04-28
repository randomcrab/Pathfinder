using System.Linq;
using Jansk.Pathfinding.Tests.Geography;
using Jansk.Pathfinding.Tests.Geography.Maps;
using NUnit.Framework;

namespace Jansk.Pathfinding.Tests.Tests
{
    public class HeuristicTests : BasePathfindingTest
    {
        [Test]
        public void GivenNoHeuristic_ShouldBuildBigGraph()
        {
            var map2D = new Map2D(14,14);
            var pathFinder = new PathFinder<Tile>(_heuristic, 14 * 14);
            var goalPosition = map2D.Tiles[11, 12];

            var graph = pathFinder.BuildGraph(map2D.Tiles[0, 0], generateGoalTest(goalPosition), _ => 0, map2D.Neighbours(), map2D.IndexMap());
            //var graph = pathFinder.BuildGraph(map2D.Tiles[0, 0], generateGoalTest(goalPosition), position => _heuristic(position, goalPosition), map2D.Neighbours(), map2D.IndexMap());

            Assert.AreEqual(196, graph.Select(x => x != null).Count());
        }
        
        [Test]
        public void GivenValidHeuristic_ShouldBuildSmallerGraph()
        {
            var map2D = new Map2D(14,14);
            var pathFinder = new PathFinder<Tile>(_heuristic, 14 * 14);
            var goalPosition = map2D.Tiles[11, 12];
            
            var graph = pathFinder.BuildGraph(map2D.Tiles[0, 0], generateGoalTest(goalPosition), position => _heuristic(position, goalPosition), map2D.Neighbours(), map2D.IndexMap());

            Assert.AreNotEqual(196, graph.Select(x => x != null).Count());
        }
    }
}