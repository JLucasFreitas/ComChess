using System;
namespace ComChess
{
    public class PawnWhite : Pieces
    {
        public int EnPassantW {get ; set;} = 0;


        public void Promocao(int PosVerfHor , int PosVerfVer , Pieces[,]PosTab)
        {
            int Choice = 0;
            Choice = int.Parse(Console.ReadLine());

            switch(Choice)
            {
                case 1 :
                {
                Queen QueenP1 = new Queen();
                QueenP1.Col = PosTab[PosVerfHor , PosVerfVer].Col;
                QueenP1.HorN = PosVerfHor;
                QueenP1.Ver = PosVerfVer;
                QueenP1.MovPast = true;
                PosTab[PosVerfHor,PosVerfVer] = QueenP1;
                break;
                }

                case 2 :
                {
                Rook RookP1 = new Rook();
                RookP1.Col = PosTab[PosVerfHor , PosVerfVer].Col;
                RookP1.HorN = PosVerfHor;
                RookP1.Ver = PosVerfVer;
                RookP1.MovPast = true;
                PosTab[PosVerfHor , PosVerfVer] = RookP1;
                break;
                }

                case 3 :
                {
                Bishop BishopP1 = new Bishop();
                BishopP1.Col = PosTab[PosVerfHor , PosVerfVer].Col;
                BishopP1.HorN = PosVerfHor;
                BishopP1.Ver = PosVerfVer;
                BishopP1.MovPast = true;
                PosTab[PosVerfHor , PosVerfVer] = BishopP1;
                break;
                }

                case 4 : 
                {
                Knight KnightP1 = new Knight();
                KnightP1.Col = PosTab[PosVerfHor , PosVerfVer].Col;
                KnightP1.HorN = PosVerfHor;
                KnightP1.Ver = PosVerfVer;
                KnightP1.MovPast = true;
                PosTab[PosVerfHor , PosVerfVer] = KnightP1;
                break;
                }

                default :
                {
                    Promocao(PosVerfHor , PosVerfVer , PosTab);
                }
            }
        }
        public override void MovementPossible(int SelHorN , int SelVer , Pieces[,]PosTab , int[,] MovPos , bool ColPly)
        {
            int PosVerfVer = SelVer;
            int PosVerfHor = SelHorN;

            PosVerfVer++;

            if(PosTab[PosVerfHor , PosVerfVer] == null)
                MovPos[PosVerfHor , PosVerfVer] = 1;

            if(PosVerfVer == 7)
            Promocao(PosVerfHor , PosVerfVer , PosTab);

            PosVerfVer = SelVer;
            PosVerfHor = SelHorN;

            if(PosTab[PosVerfHor , PosVerfVer].MovPast == false)
            {
            PosVerfVer++;
            if(PosTab[PosVerfHor , PosVerfVer] == null){
                MovPos[PosVerfHor , PosVerfVer] = 1;

            PosVerfVer++;
            if(PosTab[PosVerfHor , PosVerfVer] == null)
                MovPos[PosVerfHor , PosVerfVer] = 1;}
            }

            PosVerfVer = SelVer;
            PosVerfHor = SelHorN;

            PosVerfVer++;
            PosVerfHor++;

            if(PosVerfHor >= 0 && PosVerfHor <= 7 && PosVerfVer >= 0 && PosVerfVer <= 7){
            if(PosTab [PosVerfHor , PosVerfVer] != null)
                Check(PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);}

            PosVerfHor = SelHorN;

            PosVerfHor = PosVerfHor - 1;
            
            if(PosVerfHor >= 0 && PosVerfHor <= 7 && PosVerfVer >= 0 && PosVerfVer <= 7){
            if(PosTab [PosVerfHor , PosVerfVer] != null)
                Check(PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);}

            if(EnPassantW == 1)
            MovPos[SelHorN - 1 , SelVer + 1] = 6;

            if(EnPassantW == 2)
            MovPos[SelHorN + 1 , SelVer + 1] = 7;

        }
    }
}