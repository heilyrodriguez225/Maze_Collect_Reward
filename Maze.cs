using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Spectre.Console;
namespace Game
{
    //generacion del laberinto utilizando el algoritmo "Recursive Backtracking"
    public class Maze
    {
        private int columns; 
        private int rows;
        private const int Path = 0;
        private const int Wall = 1;
        public int[,] maze;
        private Random random = new Random();
        private List<Modifier> Modifiers = new List<Modifier>();
        
        public Maze(int rows, int columns) //Constructor de la clase Maze
        {
           this.columns = columns;
           this.rows = rows;
           maze = new int[rows, columns];
           InitializeMaze();
           GenerateMaze(1,1);
        }
        private void InitializeMaze()
        {
            for (int y = 0; y < columns ; y++)
            {
                for (int x = 0; x < rows; x++)
                {
                    // Inicializar todas las celdas como muros (1)
                    maze[x,y] = Wall;
                }
            }
        }
        private void GenerateMaze(int x, int y) //Generacion recursiva del laberinto
        {
            var Directions = new List<int[]>
            {
                new int[] {0,-1},
                new int[] {0,1},
                new int[] {-1,0},
                new int[] {1,0}
            };
            Shuffle(Directions);

            foreach (var direction in Directions)
            {
                int nx = x + direction[0];int ny = y + direction[1];
                int nx2 = nx + direction[0];int ny2 = ny + direction[1];
                if(InsideTheRange(nx2, ny2))
                {
                    if(maze[nx2,ny2] == Wall){
                        maze[nx, ny] = Path;
                        maze[nx2, ny2] = Path;
                        GenerateMaze(nx2, ny2);
                    }
                }
            }
            return;
        }
        private bool InsideTheRange(int x, int y) // Verifica si una celda esta dentro de los limites del laberinto
        {
            //Excluye los bordes del laberinto
            return x > 0 && x < rows - 1 && y > 0 && y < columns - 1;
        }
        private void Mask()
        {

        }
        private void Shuffle(List<int[]> list) //Mezcla la lista de direcciones usando el algoritmo Fisher-Yates
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        public void Imprimir() // este metodo es de prueba 
        {
            for (int y = 0; y < columns; y++)
            {
                for (int x = 0; x < rows; x++)
                {
                    Console.WriteLine(maze[x,y] == Wall ? "1 " : "0 ");
                }
                Console.WriteLine();
            }
        }
        public List<int[]> PathCells = new List<int[]>();
        public void AddModifiersInMaze(int amountModifiers)
        {
            while (maze[rows, columns] == Path)
            {
                PathCells.Add([rows,columns]);
            }
            int modifiersInTheMaze = 0;
            while(modifiersInTheMaze <= amountModifiers)
            {
                Random random = new Random(); 
                int x = random.Next(PathCells.Count);
                Modifiers.Add(new Modifier(PathCells[x][0],PathCells[x][1],TypeOfModifier));
                amountModifiers--;
            }
        }
         public void AddMoneyInMaze()
        {
           while(maze[rows,columns] == Path && /*!Modifiers[PathCells[x]]*/ )
           {
            //mientras sea camino y no halla trampa pon dinero, 70% coin y 30% diamond random
           }
        }
    }
}
