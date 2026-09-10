using System;
namespace ComChess
{
    public class Bishop : Pieces
    {

        //NorthWest
        public void NorthWest(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool GetColPly)
        {
            while(PosVerfHor > 0 && PosVerfVer < 7)
            {
            PosVerfHor = PosVerfHor - 1;
            PosVerfVer = PosVerfVer + 1; 
            if(Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly) != 0)
            break;
            }
        }
        //NorthWest

        //NorthEast
        public void NorthEast(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool GetColPly)
        {
            while(PosVerfHor < 7 && PosVerfVer < 7)
            {
            PosVerfHor = PosVerfHor + 1;
            PosVerfVer = PosVerfVer + 1;
            if(Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly) != 0)
            break;
            }
        }
        //NorthEast

        //SouthEast
        public void SouthEast(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool GetColPly)
        {
            while(PosVerfHor < 7 && PosVerfVer > 0)
            {   
            PosVerfHor = PosVerfHor + 1;
            PosVerfVer = PosVerfVer - 1;
            if(Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly) != 0)
            break;
            }
        }
        //SouthEast

        //SouthWest
        public void SouthWest(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool GetColPly)
        {
            while(PosVerfHor > 0 && PosVerfVer > 0)
            {
            PosVerfHor = PosVerfHor - 1;
            PosVerfVer = PosVerfVer - 1;
            if(Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly) != 0)
            break;
            }
        }
        //SouthWest

        public override void MovementPossible(int GetSelHorN , int GetSelVer , Pieces[,]PosTab , int[,] MovPos , bool GetColPly)
        {
        int PosVerfVer;
        int PosVerfHor;
        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        NorthWest(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        NorthEast(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        SouthEast(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        SouthWest(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        }
    }
}