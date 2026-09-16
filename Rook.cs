using System;
using System.Net;
namespace ComChess
{
    
    public class Rook : Pieces
    {
        //South
        public void South(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool GetColPly)
        {
            while(PosVerfVer > 0)
            {
            PosVerfVer = PosVerfVer - 1;
            if(Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly) != 0)
                break;
            }
        }
        //South

        //North
        public void North(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool GetColPly)
        {
            while(PosVerfVer < 7)
            {
            PosVerfVer = PosVerfVer + 1;
            if(Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly) != 0)
                break;
            }
        }
        //North

        //West
        public void West(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool GetColPly)
        {
            while(PosVerfHor > 0)
            {
            PosVerfHor = PosVerfHor - 1;
            if(Check(GetSelHorN , GetSelVer , PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly) != 0)
                break;
            }
        }
        //West

        //East
        public void East(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool GetColPly)
        {
            while(PosVerfHor < 7)
            {
            PosVerfHor = PosVerfHor + 1;
            if(Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly) != 0)
                break;
            }
        }
        //East

        public override void MovementPossible(int GetSelHorN , int GetSelVer , Pieces[,]PosTab , int[,] MovPos , bool GetColPly)
        {
        int PosVerfVer;
        int PosVerfHor;

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        South(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;

        North(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;

        West(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfHor = GetSelHorN;

        East(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

}
}
}