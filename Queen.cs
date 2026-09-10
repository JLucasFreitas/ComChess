using System;
namespace ComChess
{
    public class Queen : Pieces
    {
        Rook DirectionsR = new Rook();
        Bishop DirectionsB = new Bishop();
        public override void MovementPossible(int GetSelHorN , int GetSelVer , Pieces[,]PosTab , int[,] MovPos , bool GetColPly)
        {
        int PosVerfVer;
        int PosVerfHor;

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        DirectionsR.South(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;

        DirectionsR.North(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        
        DirectionsR.West(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfHor = GetSelHorN;

        DirectionsR.East(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        DirectionsB.NorthWest(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        DirectionsB.NorthEast(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        DirectionsB.SouthEast(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        DirectionsB.SouthWest(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);

        }
    }
}