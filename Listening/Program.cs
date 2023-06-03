using System;
using System.Collections.Generic;
using System.Linq;


// https://open.kattis.com/problems/areyoulistening

class Program
{

    public static void Main()
    {
        var enemies = new List<Position>();
        var inRange = new HashSet<Position>(); // No distinct elements
        var ownInfo = Console.ReadLine();

        // Parsing data
        String coords = ownInfo ?? "";
        if (coords == "") { return; }
        string[] ownCoords = coords.Split(" ", 3);

        var ownX = int.TryParse(ownCoords[0], out var x) ? x : 0;
        var ownY = int.TryParse(ownCoords[1], out var y) ? y : 0;
        var length = int.TryParse(ownCoords[2], out var c) ? c : 0;


        Position own = new Position(ownX, ownY, 0);

        // Parsing enemies to Positions
        for (int i = 0; i < length; i++)
        {
            var input = Console.ReadLine();
            string line = input ?? "";
            if (line == "") { return; }

            Position enemy = parsePosition(line);
            enemies.Add(enemy);
        }

        // A bit scuffed, but loops through and adds enemy if radius is <= our radius
        // increments our radius until it hits breakpoint and decrements 1 more
        while (inRange.Count < 4)
        {
            if (inRange.Count == 3)
            {
                own.DecrementRadius();
                break;
            }

            foreach (var enemy in enemies)
            {
                int distance = EuclidDistance(own, enemy) - enemy.radius;
                if (distance <= own.radius)
                {
                    inRange.Add(enemy);
                    if (inRange.Count == 3) { break; }
                }
            }
            own.IncrementRadius();

        }
        Console.WriteLine($"{own.radius}");
    }

    static int EuclidDistance(Position source, Position target)
    {
        var xDist = Math.Pow((target.x - source.x), 2);
        var yDist = Math.Pow((source.y - target.y), 2);
        return (int)Math.Floor(Math.Sqrt(xDist + yDist));
    }

    static Position parsePosition(string input)
    {
        string[] test = input.Split(" ", 3);
        var px = int.TryParse(test[0], out var x) ? x : 0;
        var py = int.TryParse(test[1], out var y) ? y : 0;
        var pr = int.TryParse(test[2], out var z) ? z : 0;
        return new Position(px, py, pr);
    }

    public record Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public int radius { get; set; }

        public Position(int _x, int _y, int _radius)
        {
            x = _x;
            y = _y;
            radius = _radius;
        }

        public void DecrementRadius()
        {
            radius = radius - 1;
        }

        public void IncrementRadius()
        {
            radius = radius + 1;
        }
    }
}