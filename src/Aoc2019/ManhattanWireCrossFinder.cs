using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Aoc2019
{
    public class ManhattanWireCrossFinder : Command
    {
        public static string ClosesManhattanIntersectionKey = "ManhattanWireCrossFinder_closestIntersection";
        private readonly string _wireDataKey;

        public ManhattanWireCrossFinder(string wireDataKey)
        {
            _wireDataKey = wireDataKey;
        }

        public override void Execute(Dictionary<string, object> data)
        {
            var closestIntersection = int.MaxValue;

            var rawWireData = (string[]) data[_wireDataKey];
            var wireData = new List<WireData>();

            foreach (string wire in rawWireData)
            {
                wireData.Add(new WireData(wire));
            }

            var intersections = wireData[0].Coordinates
                .Intersect(wireData[1].Coordinates)
                .Where(c=>c.X != 0 
                          && c.Y != 0)
                .ToList();

            foreach (var intersection in intersections)
            {
                var distance = Math.Abs(intersection.X) + Math.Abs(intersection.Y);
                if (distance < closestIntersection)
                    closestIntersection = distance;
            }

            data.Add(ClosesManhattanIntersectionKey,closestIntersection);
        }

        
    }
    internal class WireData
    {
        public List<Coordinate> Coordinates { get; set; }

        public WireData(string wireData)
        {
            Coordinates = new List<Coordinate>
            {
                new Coordinate(0, 0)
            };

            var moves = wireData.Split(',');

            foreach (string move in moves)
            {
                var direction = move[0];
                var distance = int.Parse(move.Substring(1));

                for (int i = 0; i < distance; i++)
                {
                    var lc = Coordinates.Last();
                    switch (direction)
                    {
                        case 'U':
                            Coordinates.Add(new Coordinate(lc.X, lc.Y + 1));
                            break;
                        case 'R':
                            Coordinates.Add(new Coordinate(lc.X + 1, lc.Y));
                            break;
                        case 'D':
                            Coordinates.Add(new Coordinate(lc.X, lc.Y - 1));
                            break;
                        case 'L':
                            Coordinates.Add(new Coordinate(lc.X - 1, lc.Y));
                            break;
                    }
                }
            }
        }
    }

    [DebuggerDisplay("[{X},{Y}]")]
    internal class Coordinate : IEquatable<Coordinate>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}|{Y}";
        }

        public bool Equals(Coordinate other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Coordinate) obj);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(Coordinate left, Coordinate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Coordinate left, Coordinate right)
        {
            return !Equals(left, right);
        }
    }
}