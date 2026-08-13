using System;
using System.Net;
namespace ComChess
{
    
    public class Rook : Pieces
    {
        public override void Movimentar(int GetHorMovN , int GetVerMov)
        {
         while(SelVer < 8)
         {
            SelVer = SelVer - 1;

            if(PosTab[SelHor , SelVer] == null)
            {
                MovPos[SelHor , SelVer] = true;
            }
            else
            {
                if(PosTab[SelHor , SelVer].GetCol == CollorPly )
                    continue;

                else
                {
                    
                    if()

                }
            }
         }
        }
    }
    
}