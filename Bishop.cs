using System;
namespace ComChess
{
    public class Bishop : Pieces
    {
        public override void MovementPossible(int SelHorN , int SelVer , Pieces[,]PosTab , int[,] MovPos , bool ColPly)
        {
            int PosVerfHor = SelHorN;
            int PosVerfVer = SelVer;
       
            DirectionsContinuos(1 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(-1 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(-1 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(1 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
        }
    }
}