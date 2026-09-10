using System;
namespace ComChess
{
    public class Knight : Pieces
    {
        public override void MovementPossible(int GetSelHorN , int GetSelVer , Pieces[,]PosTab , int[,] MovPos , bool GetColPly)
        {
            int PosVerfVer;
            int PosVerfHor;

            PosVerfVer = GetSelVer;
            PosVerfHor = GetSelHorN;

            PosVerfHor = PosVerfHor + 2; 
            PosVerfVer = PosVerfVer - 1;

            InTab(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

            PosVerfVer = PosVerfVer + 2; 

            InTab(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

            PosVerfVer = GetSelVer; PosVerfHor = GetSelHorN;

            PosVerfHor = PosVerfHor - 2; 
            PosVerfVer = PosVerfVer - 1; 

            InTab(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

            PosVerfVer = PosVerfVer + 2; 

            InTab(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);
            
            PosVerfVer = GetSelVer; PosVerfHor = GetSelHorN;

            PosVerfHor = PosVerfHor - 1; 
            PosVerfVer = PosVerfVer - 2; 

            InTab(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

            PosVerfHor = PosVerfHor + 2; 

            InTab(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

            PosVerfVer = GetSelVer; PosVerfHor = GetSelHorN;

            PosVerfHor = PosVerfHor - 1; 
            PosVerfVer = PosVerfVer + 2;

            InTab(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

            PosVerfHor = PosVerfHor + 2;

            InTab(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);
        }
    }
}