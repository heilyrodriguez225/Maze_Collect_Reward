using System; 
using System.Collections.Generic; 
namespace Game
{
    public enum Type
        {
            ReturnToStart, //regresar a la posicion inicial
            Paralyze, //paralizar durante los sgtes 3 turnos
            OverrideSkill, //anular habilidad
            SlowDownChip, //disminuir velocidad de tu ficha
            MoveToARandomCell, //transportar una ficha a una celda aleatoria
            LoseADiamond, //perder un diamante
            LoseACoin, //perder una moneda
            WinADiamond, //gana un diamante
            WinACoin, //gana una moneda
            PassThroughWall, //atravesar un muro NO IMPLEMENTADO
            SuperSpeed //duplicar velocidad
        }
    public abstract class Modifier
    {
        public int CoordinateX { get; }
        public int CoordinateY { get; }
        public Type TypeOfModifier { get; }

        public Modifier(int coordinateX, int coordinateY, Type type)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            TypeOfModifier = type;
        }
        public abstract void ActivatedModifier();
    }
    public class ReturnToStartTrap : Modifier 
    {
        public ReturnToStartTrap(int coordinateX, int coordinateY, Type type) : base (coordinateX, coordinateY, type){}
        public override void ActivatedModifier()
        {
            throw new NotImplementedException();
        }
        public void ActivatedModifier(int positionInitialX, int positionInitialY, int positionActualX, int positionActualY)
        {
                positionActualX = positionInitialX;
                positionActualY = positionInitialY;
        }
    }
    public class MoveToARandomCellTrap : Modifier 
    {
        public MoveToARandomCellTrap(int coordinateX, int coordinateY, Type type) : base (coordinateX, coordinateY, type){}
         public override void ActivatedModifier()
        {
            throw new NotImplementedException();
        }
        public void ActivatedModifier(int positionActualX, int positionActualY, List<int[]> PathCells)
        {
            Random random = new Random();
            int randomCell = random.Next(PathCells.Count); 
            positionActualX = PathCells[randomCell][0];
            positionActualY = PathCells[randomCell][1];
        }
    }
    public class ParalyzeTrap : Modifier 
    {
        public ParalyzeTrap(int coordinateX, int coordinateY, Type type) : base (coordinateX, coordinateY, type){}
        public override void ActivatedModifier()
        {
            throw new NotImplementedException();
        }
        int slow = 3;
        int paralyzeRound;
        public void ActivatedModifier(int positionActualX, int positionActualY, int round, bool itsYourTurn)
        {
            if (round != paralyzeRound + slow && itsYourTurn == true)
            {
                itsYourTurn = false;
            }
            else
            {
                itsYourTurn = true;
            }
        }
    }
    public class OverrideSkillTrap : Modifier 
    {
        public OverrideSkillTrap(int coordinateX, int coordinateY, Type type) : base (coordinateX, coordinateY, type){}
        public override void ActivatedModifier()
        {
            throw new NotImplementedException();
        }
        public void ActivatedModifier(int cooldown , int initialCooldown)
        {
            if(cooldown == 0)
            {
                cooldown = initialCooldown;
            }
        }
    }
    public class SlowDownChipTrap : Modifier 
    {
        public SlowDownChipTrap(int coordinateX, int coordinateY, Type type) : base (coordinateX, coordinateY, type){}
         public override void ActivatedModifier()
        {
            throw new NotImplementedException();
        }
        int retarder = 3;
        int retarderRound;
        public void ActivatedModifier(int speed, int round, bool isYourTurn)
        {
            if (round != retarderRound + retarder && isYourTurn == true)
            {
                speed = 1;
            }
        }
    }
    public class WinADiamondBenefit : Modifier 
    {
        public WinADiamondBenefit(int coordinateX, int coordinateY, Type type) : base (coordinateX, coordinateY, type){}
         public override void ActivatedModifier()
        {
            throw new NotImplementedException();
        }
        int diamond = 3;
        public void ActivatedModifier(int playerMoney)
        {
            playerMoney = playerMoney + diamond;
        }
    }
    public class WinACoinBenefit : Modifier 
    {
        public WinACoinBenefit(int coordinateX, int coordinateY, Type type) : base (coordinateX, coordinateY, type){}
         public override void ActivatedModifier()
        {
            throw new NotImplementedException();
        }
        int coin = 1;
        public void ActivatedModifier(int playerMoney)
        {
            playerMoney = playerMoney + coin;
        }
    }
    public class PassThroughWallBenefit : Modifier 
    {
        public PassThroughWallBenefit(int coordinateX, int coordinateY, Type type) : base (coordinateX, coordinateY, type){}
         public override void ActivatedModifier()
        {
            throw new NotImplementedException();
        }
        public void ActivatedModifier(int positionActualX, int positionActualY)
        {
            /*switch()
            {
                case {0,-1}:

                break;
                case {0,1}:

                break;
                case {-1,0}:

                break;
                case {1,0}:

                break;
            }*/
        }
    }
    public class SuperSpeedBenefit : Modifier 
    {
        public SuperSpeedBenefit(int coordinateX, int coordinateY, Type type) : base (coordinateX, coordinateY, type){}
         public override void ActivatedModifier()
        {
            throw new NotImplementedException();
        }
        int count = 3;
        int speedRound;
        public void ActivatedModifier(int speed, int round)
        {
            if (round != speedRound + count)
            {
                speed = speed * 2;
            }
        }
    }
}