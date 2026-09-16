using System;
namespace ComChess
{
    public class King : Pieces
    {
        int [,] MovKing = new int[8,8];
        public override void MovementPossible(int GetSelHorN , int GetSelVer , Pieces[,]PosTab , int[,] MovPos , bool GetColPly)        
        {
        int PosVerfVer = 0;
        int PosVerfHor = 0;
        
        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        PosVerfHor = PosVerfHor + 1;

        InTab(PosVerfVer , PosVerfHor , PosTab , MovPos , GetColPly);
        
        PosVerfVer = PosVerfVer + 1;

        InTab(PosVerfVer , PosVerfHor , PosTab , MovPos , GetColPly);

        PosVerfVer = PosVerfVer - 2;

        InTab(PosVerfVer , PosVerfHor , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        PosVerfHor = PosVerfHor - 1;

        InTab(PosVerfVer , PosVerfHor , PosTab , MovPos , GetColPly);

        PosVerfVer = PosVerfVer + 1;

        InTab(PosVerfVer , PosVerfHor , PosTab , MovPos , GetColPly);

        PosVerfVer = PosVerfVer - 2;

        InTab(PosVerfVer , PosVerfHor , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        PosVerfVer = PosVerfVer + 1;

        InTab(PosVerfVer , PosVerfHor , PosTab , MovPos , GetColPly);

        PosVerfVer = PosVerfVer - 2;

        InTab(PosVerfVer , PosVerfHor , PosTab , MovPos , GetColPly);

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        if(GetMovPast() == false)
        {
            while(PosVerfHor > 0)
            {
            PosVerfHor = PosVerfHor - 1;
            if(PosTab[PosVerfHor , PosVerfVer] == null)
                continue;

            else
                break;
            }
            
            if(PosTab[PosVerfHor , PosVerfVer] is Rook){
            if(PosTab[PosVerfHor , PosVerfVer].GetMovPast() == false){
                PosVerfVer = GetSelVer;
                PosVerfHor = GetSelHorN;
                MovPos[PosVerfHor , PosVerfVer - 2] = 3;}}

        }

        if(GetMovPast() == false)
        {
            while(PosVerfHor < 7)
            {
            PosVerfHor = PosVerfHor + 1;
            if(PosTab[PosVerfHor , PosVerfVer] == null)
                continue;

            else
                break;
            }
            
            if(PosTab[PosVerfHor , PosVerfVer] is Rook){
            if(PosTab[PosVerfHor , PosVerfVer].GetMovPast() == false){
                PosVerfVer = GetSelVer;
                PosVerfHor = GetSelHorN;
                MovPos[PosVerfHor , PosVerfVer + 2] = 4;}}

        }

        }
    }
}