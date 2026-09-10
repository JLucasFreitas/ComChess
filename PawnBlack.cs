using System;
namespace ComChess
{
    public class PawnBlack : Pieces
    {
        PawnWhite Promo = new PawnWhite();
        public override void MovementPossible(int GetSelHorN , int GetSelVer , Pieces[,]PosTab , int[,] MovPos , bool GetColPly)
        {
            int PosVerfVer;
            int PosVerfHor;

            PosVerfVer = GetSelVer;
            PosVerfHor = GetSelHorN;

            PosVerfVer--;

            if(PosTab[PosVerfHor , PosVerfVer] == null)
                MovPos[PosVerfHor , PosVerfVer] = 1;

            if(PosVerfVer == 0)
            Promo.Promocao(PosVerfHor , PosVerfVer , PosTab);

            PosVerfVer = GetSelVer;
            PosVerfHor = GetSelHorN;

            if(PosTab[PosVerfHor , PosVerfVer].GetMovPast() == false)
            {
            PosVerfVer--;
            if(PosTab[PosVerfHor , PosVerfVer] == null){
                MovPos[PosVerfHor , PosVerfVer] = 1;

            PosVerfVer--;
            if(PosTab[PosVerfHor , PosVerfVer] == null)
                MovPos[PosVerfHor , PosVerfVer] = 1;}
            }

            PosVerfVer = GetSelVer;
            PosVerfHor = GetSelHorN;

            PosVerfVer--;
            PosVerfHor++;

            if(PosVerfHor >= 0 && PosVerfHor <= 7 && PosVerfVer >= 0 && PosVerfVer <= 7){
            if(PosTab [PosVerfHor , PosVerfVer] != null)
                Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);}

            PosVerfHor = GetSelHorN;

            PosVerfHor = PosVerfHor - 1;
            
            if(PosVerfHor >= 0 && PosVerfHor <= 7 && PosVerfVer >= 0 && PosVerfVer <= 7){
            if(PosTab [PosVerfHor , PosVerfVer] != null)
                Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);}

        }
    }
}