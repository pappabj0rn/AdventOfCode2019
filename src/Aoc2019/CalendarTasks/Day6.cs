using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Aoc2019.CalendarTasks
{
    public class Day6 : CalendarTask
    {
        public static string CountKey = "day6.count";
        
        public override void Run()
        {
            var map = (List<string>) Data;

            var root = new Node("COM",null);

            void FindChildren(Node node)
            {
                for (int i = 0; i < map.Count; i++)
                {
                    if (!map[i].StartsWith(node.Name)) continue;
                    var parts = map[i].Split(')');
                    node.Nodes.Add(new Node(parts[1], parts[0]));
                    map.RemoveAt(i);
                    i--;
                }

                foreach (var child in node.Nodes)
                {
                    FindChildren(child);
                }
            }

            FindChildren(root);

            Result.Add(CountKey, root.Count);
        }

        [DebuggerDisplay("{Orbits}){Name}")]
        internal class Node
        {
            public string Name { get; private set; }
            public string Orbits { get; private set; }
            public List<Node> Nodes { get; private set; }

            public Node(string name, string orbits)
            {
                Name = name;
                Orbits = orbits;
                Nodes = new List<Node>();
            }

            public int Count
            {
                get
                {
                    var childSum = Nodes.Sum(x => x.Count);

                    if (Orbits is null) return childSum;

                    return 1+ ChildCount +childSum;
                }
            }

            public int ChildCount => Nodes.Count + Nodes.Sum(x => x.ChildCount);
        }
    }
}