using System;
using System.Net;
namespace ComChess
{
    
    public class Rook : Pieces
    {
        public override void Movimentar(int GetHorMovN, int GetVerMov)
        {
        int PosVerfVer;
        int PosVerfHor;

        PosVerfVer = GetSelVer;
        PosVerfHor = GetSelHorN;

        while(PosVerfVer < 8)
        {
        PosVerfVer = GetSelVer - 1;
        GetSelVer = GetSelVer - 1;

            if(PosTab[GetSelHorN, PosVerfVer] == null)
                MovPos[GetSelHorN, PosVerfVer] = true;
            else
            {
            if(PosTab[GetSelHorN, GetSelVer].GetCol() == GetColPly)
                continue;
            else
            {
                if(PosTab[GetSelHorN, PosVerfVer] is King)
                    Xeque = true;
                else
                    Comer();
            }
            }
        }
        }
    }
}