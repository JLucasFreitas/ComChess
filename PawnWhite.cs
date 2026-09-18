using System;
namespace ComChess
{
    public class PawnWhite : Pieces
    {
        private int EnPassantW = 0;

        public int GetEnPassantW()
        {
        return EnPassantW;
        }

        public void SetEnPassantW(int EnPassantWhite)
        {
        EnPassantW = EnPassantWhite;
        }

        public void Promocao(int PosVerfHor , int PosVerfVer , Pieces[,]PosTab)
        {
            int Choice = 0;
            Choice = int.Parse(Console.ReadLine());

            switch(Choice)
            {
                case 1 :
                {
                Queen QueenP1 = new Queen();
                QueenP1.SetCol(PosTab[PosVerfHor , PosVerfVer].GetCol());
                QueenP1.SetSta(true);
                QueenP1.SetHorN(PosVerfHor);
                QueenP1.SetVer(PosVerfVer);
                QueenP1.SetMovPast(true);
                PosTab[PosVerfHor,PosVerfVer] = QueenP1;
                break;
                }

                case 2 :
                {
                Rook RookP1 = new Rook();
                RookP1.SetCol(PosTab[PosVerfHor , PosVerfVer].GetCol());
                RookP1.SetSta(true);
                RookP1.SetHorN(PosVerfHor);
                RookP1.SetVer(PosVerfVer);
                RookP1.SetMovPast(true);
                PosTab[PosVerfHor , PosVerfVer] = RookP1;
                break;
                }

                case 3 :
                {
                Bishop BishopP1 = new Bishop();
                BishopP1.SetCol(PosTab[PosVerfHor , PosVerfVer].GetCol());
                BishopP1.SetSta(true);
                BishopP1.SetHorN(PosVerfHor);
                BishopP1.SetVer(PosVerfVer);
                BishopP1.SetMovPast(true);
                PosTab[PosVerfHor , PosVerfVer] = BishopP1;
                break;
                }

                case 4 : 
                {
                Knight KnightP1 = new Knight();
                KnightP1.SetCol(PosTab[PosVerfHor , PosVerfVer].GetCol());
                KnightP1.SetSta(true);
                KnightP1.SetHorN(PosVerfHor);
                KnightP1.SetVer(PosVerfVer);
                KnightP1.SetMovPast(true);
                PosTab[PosVerfHor , PosVerfVer] = KnightP1;
                break;
                }

                default :
                {
                    Promocao(PosVerfHor , PosVerfVer , PosTab);
                }
            }
        }
        public override void MovementPossible(int GetSelHorN , int GetSelVer , Pieces[,]PosTab , int[,] MovPos , bool GetColPly)
        {
            int PosVerfVer;
            int PosVerfHor;

            PosVerfVer = GetSelVer;
            PosVerfHor = GetSelHorN;

            PosVerfVer++;

            if(PosTab[PosVerfHor , PosVerfVer] == null)
                MovPos[PosVerfHor , PosVerfVer] = 1;

            if(PosVerfVer == 7)
            Promocao(PosVerfHor , PosVerfVer , PosTab);

            PosVerfVer = GetSelVer;
            PosVerfHor = GetSelHorN;

            if(PosTab[PosVerfHor , PosVerfVer].GetMovPast() == false)
            {
            PosVerfVer++;
            if(PosTab[PosVerfHor , PosVerfVer] == null){
                MovPos[PosVerfHor , PosVerfVer] = 1;

            PosVerfVer++;
            if(PosTab[PosVerfHor , PosVerfVer] == null)
                MovPos[PosVerfHor , PosVerfVer] = 1;}
            }

            PosVerfVer = GetSelVer;
            PosVerfHor = GetSelHorN;

            PosVerfVer++;
            PosVerfHor++;

            if(PosVerfHor >= 0 && PosVerfHor <= 7 && PosVerfVer >= 0 && PosVerfVer <= 7){
            if(PosTab [PosVerfHor , PosVerfVer] != null)
                Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);}

            PosVerfHor = GetSelHorN;

            PosVerfHor = PosVerfHor - 1;
            
            if(PosVerfHor >= 0 && PosVerfHor <= 7 && PosVerfVer >= 0 && PosVerfVer <= 7){
            if(PosTab [PosVerfHor , PosVerfVer] != null)
                Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);}

            if(EnPassantW == 1)
            MovPos[GetSelHorN - 1 , GetSelVer + 1] = 6;

            if(EnPassantW == 2)
            MovPos[GetSelHorN + 1 , GetSelVer + 1] = 7;

        }
    }
}