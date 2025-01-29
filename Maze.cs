using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Spectre.Console;
namespace Game
{
    //generacion del laberinto utilizando el algoritmo "Recursive Backtracking"
    public class Maze
    {
        public int columns; 
        public int rows;
        private const int Path = 0;
        private const int Wall = 1;
        public int[,] maze;
        private Random random = new Random();
        public List<Modifier> Modifiers = new List<Modifier>();
        public List<Coin> Coins = new List<Coin>();
        public List<Diamond> Diamonds = new List<Diamond>();

        public Maze(int rows, int columns) //Constructor de la clase Maze
        {
           this.columns = columns;
           this.rows = rows;
           maze = new int[rows, columns];
           //InitializeMaze();
           //GenerateMaze(1,1);
           //ApplyMask();
           //AddPathCells();
           //AddModifiersInMaze(5);
           //AddMoneyInMaze(6,2);
        }
        public void InitializeMaze()
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
        public void GenerateMaze(int x, int y) //Generacion recursiva del laberinto
        {
            var Directions = new List<int[]>
            {
                new int[] {0,-1}, //izquierda
                new int[] {0,1}, //derecha
                new int[] {-1,0}, //arriba
                new int[] {1,0} //abajo
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
        public bool InsideTheRange(int x, int y) // Verifica si una celda esta dentro de los limites del laberinto
        {
            //Excluye los bordes del laberinto
            return x > 0 && x < rows - 1 && y > 0 && y < columns - 1;
        }
        public void Mask(int x, int y)
        {
            //eliminar callejones sin salida
            if((x>0 && y>0 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-1 && maze[x+1,y] == Path) && (maze[x,y] == Wall) && (maze[x,y-1] == Wall) && (maze[x,y+1] == Wall) && (maze[x+1,y-1] == Wall) && (maze[x+1,y+1] == Wall))
            {
                maze[x,y] = Path;
            }
            else if((x>0 && y>0 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-1 && maze[x-1,y] == Path) && (maze[x,y] == Wall) && (maze[x,y-1] == Wall) && (maze[x,y+1] == Wall) && (maze[x-1,y-1] == Wall) && (maze[x-1,y+1] == Wall))
            {
                maze[x,y] = Path;
            }
            else if((x>0 && y>0 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-1 && maze[x,y+1] == Path) && (maze[x,y] == Wall) && (maze[x-1,y] == Wall) && (maze[x+1,y] == Wall) && (maze[x-1,y+1] == Wall) && (maze[x+1,y+1] == Wall))
            {
                maze[x,y] = Path;
            }
            else if((x>0 && y>0 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-1 && maze[x,y-1] == Path) && (maze[x,y] == Wall) && (maze[x-1,y] == Wall) && (maze[x+1,y+1] == Wall) && (maze[x-1,y-1] == Wall) && (maze[x+1,y-1] == Wall))
            {
                maze[x,y] = Path;
            }
            //levantar muros pero pueden generar callejones sin salida
            else if((x>1 && y>0 && x<maze.GetLength(0)-2 && y<maze.GetLength(1)-1 && maze[x+1,y] == Wall) && (maze[x-1,y] == Wall) && (maze[x,y] == Path) && (maze[x-1,y-1] == Path) && (maze[x,y-1] == Path) && (maze[x+1,y-1] == Path) && (maze[x-1,y+1] == Path) && (maze[x,y+1] == Path) && (maze[x+1,y+1] == Path))
            {
                maze[x,y] = Wall;
            }
            else if((x>0 && y>1 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-2 && maze[x,y-1] == Wall) && (maze[x,y+1] == Wall) && (maze[x,y] == Path) && (maze[x+1,y] == Path) && (maze[x-1,y] == Path) && (maze[x-1,y-1] == Path) && (maze[x+1,y-1] == Path) && (maze[x-1,y+1] == Path) && (maze[x+1,y+1] == Path))
            {
                maze[x,y] = Wall;
            }
            //eliminar callejones sin salida en secciones cercanas a la pared exterior del laberinto
            else if((x>0 && y>0 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-3 && maze[x,y-1] == Wall) && (maze[x,y] == Wall) && (maze[x,y+1] == Wall) && (maze[x,y+2] == Wall) && (maze[x,y+3] == Wall) && (maze[x+1,y-1] == Wall) && (maze[x+1,y] == Path) && (maze[x+1,y+1] == Path) && (maze[x+1,y+2] == Path) && (maze[x+1,y+3] == Path))
            {
                maze[x,y] = Path;
            }
            else if((x>1 && y>3 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-1 && maze[x,y+1] == Wall) && (maze[x,y] == Wall) && (maze[x,y-1] == Wall) && (maze[x,y-2] == Wall) && (maze[x,y-3] == Wall) && (maze[x+1,y+1] == Wall) && (maze[x+1,y] == Path) && (maze[x+1,y-1] == Path) && (maze[x+1,y-2] == Path) && (maze[x+1,y-3] == Path))
            {
                maze[x,y] = Path;
            }
            else if((x>1 && y>3 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-1 && maze[x,y+1] == Wall) && (maze[x,y] == Wall) && (maze[x,y-1] == Wall) && (maze[x,y-2] == Wall) && (maze[x,y-3] == Wall) && (maze[x-1,y+1] == Wall) && (maze[x-1,y] == Path) && (maze[x-1,y-1] == Path) && (maze[x-1,y-2] == Path) && (maze[x-1,y-3] == Path))
            {
                maze[x,y] = Path;
            }
            else if((x>0 && y>0 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-3 && maze[x,y-1] == Wall) && (maze[x,y] == Wall) && (maze[x,y+1] == Wall) && (maze[x,y+2] == Wall) && (maze[x,y+3] == Wall) && (maze[x-1,y-1] == Wall) && (maze[x-1,y] == Path) && (maze[x-1,y+1] == Path) && (maze[x-1,y+2] == Path) && (maze[x-1,y+3] == Path))
            {
                maze[x,y] = Path;
            }
            else if((x>0 && y>0 && x<maze.GetLength(0)-3 && y<maze.GetLength(1)-1 && maze[x-1,y] == Wall) && (maze[x,y] == Wall) && (maze[x+1,y] == Wall) && (maze[x+2,y] == Wall) && (maze[x+3,y] == Wall) && (maze[x-1,y+1] == Wall) && (maze[x,y+1] == Path) && (maze[x+1,y+1] == Path) && (maze[x+2,y+1] == Path) && (maze[x+3,y+1] == Path))
            {
                maze[x,y] = Path;
            }
            else if((x>0 && y>0 && x<maze.GetLength(0)-3 && y<maze.GetLength(1)-1 && maze[x-1,y] == Wall) && (maze[x,y] == Wall) && (maze[x+1,y] == Wall) && (maze[x+2,y] == Wall) && (maze[x+3,y] == Wall) && (maze[x-1,y-1] == Wall) && (maze[x,y-1] == Path) && (maze[x+1,y-1] == Path) && (maze[x+2,y-1] == Path) && (maze[x+3,y-1] == Path))
            {
                maze[x,y] = Path;
            }
            else if(x>3 && y>0 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-1 && (maze[x+1,y] == Wall) && (maze[x,y] == Wall) && (maze[x-1,y] == Wall) && (maze[x-2,y] == Wall) && (maze[x-3,y] == Wall) && (maze[x+1,y+1] == Wall) && (maze[x,y+1] == Path) && (maze[x-1,y+1] == Path) && (maze[x-2,y+1] == Path) && (maze[x-3,y+1] == Path))
            {
                maze[x,y] = Path;
            }
            else if(x>3 && y>0 && x<maze.GetLength(0)-1 && y<maze.GetLength(1)-1 && (maze[x+1,y] == Wall) && (maze[x,y] == Wall) && (maze[x-1,y] == Wall) && (maze[x-2,y] == Wall) && (maze[x-3,y] == Wall) && (maze[x-1,y-1] == Wall) && (maze[x,y-1] == Path) && (maze[x-1,y-1] == Path) && (maze[x-2,y-1] == Path) && (maze[x-3,y-1] == Path))
            {
                maze[x,y] = Path;
            }
            else return;
        }
        public void ApplyMask(){
            for(int i = 1;i<maze.GetLength(0)-1; i++){
                for(int j = 1;j < maze.GetLength(1)-1; j++){
                    Mask(i,j);
                }
            }
        }
        public void Shuffle(List<int[]> list) //Mezcla la lista de direcciones usando el algoritmo Fisher-Yates
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
        
        public List<int[]> PathCells;
        public void AddPathCells()
        {
            PathCells = new List<int[]>();
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if(maze[i, j] == Path)
                    {
                        PathCells.Add([i, j]);
                    }
                }
            }
        }
        public void AddModifiersInMaze(int amountModifiers)
        {
            int modifiersInTheMaze = 0;
            while(modifiersInTheMaze <= amountModifiers)
            {
                Random random = new Random(); 
                int x = random.Next(PathCells.Count);
                int r = random.Next(11);
                switch (r)
                {
                    case 0:
                        Modifiers.Add( new ReturnToStartTrap(PathCells[x][0],PathCells[x][1]));
                        break;
                    case 1:
                        Modifiers.Add( new MoveToARandomCellTrap(PathCells[x][0],PathCells[x][1]));
                        break;
                    case 2:
                        Modifiers.Add( new ParalyzeTrap(PathCells[x][0],PathCells[x][1]));
                        break;
                    case 3:
                        Modifiers.Add( new OverrideSkillTrap(PathCells[x][0],PathCells[x][1]));
                        break;
                    case 4:
                        Modifiers.Add( new SlowDownChipTrap(PathCells[x][0],PathCells[x][1]));
                        break;
                    case 5:
                        Modifiers.Add( new WinADiamondBenefit(PathCells[x][0],PathCells[x][1]));
                        break;   
                    case 6:
                        Modifiers.Add( new WinACoinBenefit(PathCells[x][0],PathCells[x][1]));
                        break;
                    case 7:
                        Modifiers.Add( new PassThroughWallBenefit(PathCells[x][0],PathCells[x][1]));
                        break;
                    case 8:
                        Modifiers.Add( new SuperSpeedBenefit(PathCells[x][0],PathCells[x][1]));
                        break;
                    case 9:
                        Modifiers.Add( new LoseADiamondTrap(PathCells[x][0],PathCells[x][1]));
                        break;
                    case 10:
                        Modifiers.Add( new LoseACoinTrap(PathCells[x][0],PathCells[x][1]));
                        break;
                } 
                modifiersInTheMaze++;
            }
        }
        public Modifier CheckForModifierInTheCell(int positionActualX, int positionActualY)
        {
            for (int k = 0; k < Modifiers.Count; k++)
            {
                if(positionActualX == Modifiers[k].CoordinateX && positionActualY == Modifiers[k].CoordinateY)
                {
                    return Modifiers[k];
                }
            }
            return null;
        }
        public void ActivatedModifierInMaze(int positionActualX, int positionActualY)
        {
            Modifier m = CheckForModifierInTheCell(positionActualX, positionActualY);
            if(m == null) return;
            m.ActivatedModifier();
        }
        public void AddMoneyInMaze(int amountCoins, int amountDiamonds)
        {
            int coinsInTheMaze = 0;
            while (coinsInTheMaze <= amountCoins)
            {
                Random random = new Random();
                int x = random.Next(PathCells.Count);
                Coins.Add(new Coin(PathCells[x][0], PathCells[x][1]));
                coinsInTheMaze ++;
            }
            int diamondsInTheMaze = 0;
            while(diamondsInTheMaze <= amountDiamonds)
            {
                Random random = new Random();
                int x = random.Next(PathCells.Count);
                
                if(!Coins.Contains(new Coin(PathCells[x][0], PathCells[x][1])))
                {
                    Diamonds.Add(new Diamond(PathCells[x][0], PathCells[x][1]));
                }
                diamondsInTheMaze ++;
            }
        }
        
    }
}
