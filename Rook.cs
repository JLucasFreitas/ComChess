using System;
using System.Net;
namespace ComChess
{
    
    public class Rook : Pieces
    {
        void Directions(int HorizontalDirections , int VerticalDirections)
        {

            while(PosVerfHor + HorizontalDirections >= 0 && 
            PosVerfHor+ HorizontalDirections <= 7 && 
            PosVerfVer + VerticalDirections >= 0 && 
            PosVerfVer + VerticalDirections <= 7)
            {
            PosVerfHor = PosVerfHor + HorizontalDirections;
            PosVerfVer = PosVerfVer + VerticalDirections;

            if(Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly) != 0)
                break;
            }
        }

       

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