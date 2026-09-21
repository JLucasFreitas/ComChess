using System;
namespace ComChess
{
    public class Knight : Pieces
    {
        public override void MovementPossible(int SelHorN , int SelVer , Pieces[,]PosTab , int[,] MovPos , bool ColPly)
        {
            int PosVerfHor = SelHorN;
            int PosVerfVer = SelVer;

            Directions(2 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(2 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(-2 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(-2 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(1 , 2 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(1 , -2 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(-1 , 2 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(-1 , -2 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
        }
    }
}