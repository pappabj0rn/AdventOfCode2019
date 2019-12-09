using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Aoc2019.CalendarTasks
{
    public class Day6 : CalendarTask
    {
        public static string CountKey = "day6.count";
        public static string JumpCountKey = "day6.jumpCount";
        
        public override void Run()
        {
            var map = (List<string>) Data;

            var root = new Node("COM",null);

            void FindChildren(Node node)
            {
                for (int i = 0; i < map.Count; i++)
                {
                    if (!map[i].StartsWith(node.Name)) continue;
                    
                    node.Nodes.Add(
                        new Node(
                            map[i].Split(')')[1], 
                            node));
                    map.RemoveAt(i);
                    i--;
                }

                foreach (var child in node.Nodes)
                {
                    FindChildren(child);
                }
            }

            int CountOrbitTransfers(string start, string target)
            {
                var transfers = 0;

                var n1 = root.FindNode(start);
                if (n1 is null)
                    return -1;


                var parent = n1.Parent;
                while (true)
                {
                    var relation = parent.HasNode(target);
                    if (relation == Relation.No)
                    {
                        transfers++;
                        parent = parent.Parent;
                        continue;
                    }

                    if (relation == Relation.Direct)
                    {
                        break;
                    }

                    foreach (var child in parent.Nodes)
                    {
                        var childRelation = child.HasNode(target);
                        switch (childRelation)
                        {
                            case Relation.No:
                                continue;
                            case Relation.Direct:
                                return ++transfers;
                            default:
                                transfers++;
                                parent = child;
                                break;
                        }
                    }
                }
                
                return transfers;
            }

            FindChildren(root);

            Result.Add(CountKey, root.Count);
            Result.Add(JumpCountKey, CountOrbitTransfers("YOU","SAN"));
        }

        [DebuggerDisplay("{Parent.Name}){Name}")]
        internal class Node
        {
            public string Name { get; private set; }
            public List<Node> Nodes { get; private set; }
            public Node Parent { get; set; }

            public Node(string name, Node parent)
            {
                Name = name;
                Parent = parent;
                Nodes = new List<Node>();
            }

            public int Count
            {
                get
                {
                    var childSum = Nodes.Sum(x => x.Count);

                    if (Parent is null) return childSum;

                    return 1 + ChildCount + childSum;
                }
            }

            public int ChildCount => Nodes.Count + Nodes.Sum(x => x.ChildCount);

            public Node FindNode(string name)
            {
                foreach (var child in Nodes)
                {
                    if (child.Name == name)
                        return child;

                    if (child.HasNode(name) != Relation.No)
                        return child.FindNode(name);
                }

                return null;
            }

            public Relation HasNode(string name)
            {
                foreach (var child in Nodes)
                {
                    if (child.Name == name)
                        return Relation.Direct;

                    if (child.HasNode(name) != Relation.No)
                        return Relation.Decendant;
                }

                return Relation.No;
            }
        }

        internal enum Relation
        {
            No,
            Direct,
            Decendant
        }
    }
}