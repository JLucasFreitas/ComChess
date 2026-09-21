using System;
using System.Net;
namespace ComChess
{
    
    public class Rook : Pieces
    {  
        public override void MovementPossible(int SelHorN , int SelVer , Pieces[,]PosTab , int[,] MovPos , bool ColPly)
        {
            int PosVerfHor = SelHorN;
            int PosVerfVer = SelVer;
       
            DirectionsContinuos(1 , 0 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(-1 , 0 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(0 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(0 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
        }
    }
}