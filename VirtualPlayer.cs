using System;
using System.Collections.Generic;
namespace Game
{    
    public class VirtualPlayer
    {
        /*Busca el camino mas corto hacia el dinero, si hay un diamante y una moneda a la 
        minima distancia se dirige hacia el diamante
        VirtualPlayer se usa cuando juega solo un player y escoge una ficha random a excepcion
         de la que halla escogido el player*/
        
        /*public int[] FindShortestPathToTarget(int positionActualX, int positionActualY,int[,] maze, int target) // ??dudas en el target para que sea money
        {
            int totalRows = maze.GetLength(0);
            int totalColumns = maze.GetLength(1);
            int[,] distance = new int[totalRows, totalColumns];
            distance[positionActualX,positionActualY] = 1;
            //                          N  S  E  W
            int[] directionRows =    { -1, 1, 0, 0};     
            int[] directionColumns = { 0, 0, 1, -1};
            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalColumns; j++)
                {
                    distance[i,j] = int.MaxValue;
                }
            }
            distance[positionActualX,positionActualY] = 0;
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] {positionActualX, positionActualY});
            while(queue.Count > 0)
            {
                int[] pos = queue.Dequeue();
                int x = pos[0];
                int y = pos[1];
                for (int i = 0; i < length; i++)
                {
                    int nx = x + directionRows[i];
                    int ny = y  = directionColumns[i];
                    if(InsideTheRange(nx, ny) && maze[nx,ny] == Path && distance[nx,ny] == int.MaxValue)
                    {
                        distance[nx,ny] = distance[x,y] + 1;
                        queue.Enqueue(new int[] { nx, ny});
                        if(maze[nx,ny] == target)
                        {
                            return new int[] { nx, ny};
                        }
                    }
                }
            }
            return null;
        }
        public int[] FindOptimalTarget( positionActualX, positionActualY)
        {
            int[] coinLocation = FindShortestPathToTarget(positionActualX, positionActualY, Coin);
            int[] diamondLocation = FindShortestPathToTarget(positionActualX, positionActualY, Diamond);
            if(diamondLocation != null && coinLocation != null)
            {
                if(MazeDistance(positionActualX, positionActualY, diamondLocation[0], diamondLocation[1] < MazeDistance(positionActualX, positionActualY, coinLocation[0], coinLocation[1])))
                {
                    return diamondLocation;
                }
                return coinLocation;
                else if (diamondLocation != null)
                {
                    return diamondLocation;
                }
                else return coinLocation;
            }
        }
        private int MazeDistance(int x1, int y1, int x2, int y2) // calcula la distancia de Manhattan entre dos puntos del laberinto
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }
    }
    /*public int[,] LeeAlgorithm(int positionActualX, int positionActualY, bool[,] maze)
    {
        int totalRows = maze.GetLength(0);
        int totalColumns = maze.GetLength(1);
        int[,] distance = new int[totalRows, totalColumns];
        distance[positionActualX,positionActualY] = 1;
        //                          N  S  E  W
        int[] directionRows =    { -1, 1, 0, 0};     
        int[] directionColumns = { 0, 0, 1, -1};
        bool isThereChange;
        do
        {
            isThereChange = false;
            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalColumns; j++)
                {
                    if(distance[i,j] == 0) continue;
                    if(!maze[i,j]) continue;
                    for (int k = 0; k < directionRows.Length; k++)
                    {
                        int neighborI = i + directionRows[k];
                        int neighborJ = j + directionColumns[k];
                        if (ValidPosition(totalRows, totalColumns, neighborI, neighborJ) && distance[neighborI,neighborJ] == 0 && maze[neighborI,neighborJ])
                        {
                            distance[neighborI,neighborJ] = distance[i,j] + 1;
                            isThereChange = true;
                        }
                    }
                }
            }
        } 
        while (isThereChange);
        {
            return distance;
        }*/
    }
}