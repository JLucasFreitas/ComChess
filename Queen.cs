using System;
namespace ComChess
{
    public class Queen : Pieces
    {
        public override void MovementPossible(int SelHorN , int SelVer , Pieces[,]PosTab , int[,] MovPos , bool ColPly)
        {
            int PosVerfHor = SelHorN;
            int PosVerfVer = SelVer;
       
            DirectionsContinuos(1 , 0 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(-1 , 0 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(0 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(0 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);

            DirectionsContinuos(1 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(-1 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(-1 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            DirectionsContinuos(1 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
        }
    }
}