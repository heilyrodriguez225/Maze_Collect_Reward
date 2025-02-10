using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class VirtualPlayer : Player
    {
        public VirtualPlayer(string name, Chip chip, int money, Maze maze) : base(name, chip, money, maze) { }

        public override void Move(Maze maze)
        {
            if (Chip.Cooldown <= 0)
            {
                Parameters parameters = new Parameters
                {
                    positionActualX = PositionX,
                    positionActualY = PositionY,
                    speed = Chip.Speed,
                    playerMoney = Money,
                    PathCells = maze.PathCells,
                    maze = maze
                };
                Chip.UseSkill(parameters, this);
                Chip.Cooldown = Chip.MaxCooldown;
            }

            var target = FindNearestMoney(maze);

            if (target != null)
            {
                var path = FindShortestPath(maze, PositionX, PositionY, target.CoordinateX, target.CoordinateY);

                if (path != null && path.Count > 1)
                {
                    PositionX = path[1][0];
                    PositionY = path[1][1];
                }
            }

            CollectMoney(maze);
        }

        private Money FindNearestMoney(Maze maze)
        {
            // Combina las listas de monedas y diamantes
            var allMoney = new List<Money>();
            allMoney.AddRange(maze.Coins);
            allMoney.AddRange(maze.Diamonds);

            Money nearestMoney = null;
            int minDistance = int.MaxValue;

            foreach (var money in allMoney)
            {
                int distance = CalculateDistance(PositionX, PositionY, money.CoordinateX, money.CoordinateY);

                if (distance < minDistance || (distance == minDistance && money is Diamond))
                {
                    minDistance = distance;
                    nearestMoney = money;
                }
            }

            return nearestMoney;
        }

        private int CalculateDistance(int x1, int y1, int x2, int y2)
        {
            // Distancia Manhattan
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        private List<int[]> FindShortestPath(Maze maze, int startX, int startY, int targetX, int targetY)
        {
            // Implementación del algoritmo de Lee (BFS)
            int rows = maze.rows;
            int cols = maze.columns;

            int[,] distance = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    distance[i, j] = -1; // Inicializa todas las distancias como -1 (no visitado)
                }
            }

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { startX, startY });
            distance[startX, startY] = 0;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                int x = current[0];
                int y = current[1];

                if (x == targetX && y == targetY)
                {
                    return ReconstructPath(distance, startX, startY, targetX, targetY, dx, dy);
                }

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (nx >= 0 && nx < rows && ny >= 0 && ny < cols && maze.maze[nx, ny] == 0 && distance[nx, ny] == -1)
                    {
                        distance[nx, ny] = distance[x, y] + 1;
                        queue.Enqueue(new int[] { nx, ny });
                    }
                }
            }

            return null;
        }

        private List<int[]> ReconstructPath(int[,] distance, int startX, int startY, int targetX, int targetY, int[] dx, int[] dy)
        {
            List<int[]> path = new List<int[]>();
            int x = targetX;
            int y = targetY;

            while (x != startX || y != startY)
            {
                path.Add(new int[] { x, y });

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (nx >= 0 && nx < distance.GetLength(0) && ny >= 0 && ny < distance.GetLength(1) && distance[nx, ny] == distance[x, y] - 1)
                    {
                        x = nx;
                        y = ny;
                        break;
                    }
                }
            }
            path.Add(new int[] { startX, startY });
            path.Reverse();
            return path;
        }
    }
}