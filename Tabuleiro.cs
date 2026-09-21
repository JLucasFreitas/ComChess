using System;
using System.Formats.Tar;
using System.Runtime.CompilerServices;
namespace ComChess
{
    public class Tabuleiro
    {
        public Pieces[,] PosTab {get; set;} = new Pieces[8 , 8];


        void EnPassantNulo(Pieces[,]PosTab , bool ColPly)
        {
            int EnPassantHorNulo = 0;
            int EnPassantVerNulo = 1;

            while(EnPassantVerNulo <= 6)
            {
                if(ColPly == false){
                if(PosTab[EnPassantHorNulo , EnPassantVerNulo] is PawnBlack)
                ((PawnBlack)PosTab[EnPassantHorNulo , EnPassantVerNulo]).EnPassantB = 0;}

                else{
                if(PosTab[EnPassantHorNulo , EnPassantVerNulo] is PawnWhite)
                ((PawnWhite)PosTab[EnPassantHorNulo , EnPassantVerNulo]).EnPassantW = 0;}

                EnPassantHorNulo++;
                if(EnPassantHorNulo == 8)
                {
                EnPassantVerNulo++; 
                EnPassantHorNulo = 0;
                }

            }
        }

        void MovPosNulo(int[,]MovPos)
        {
        int MovPosHorNulo = 0;
        int MovPosVerNulo = 0;

        while(MovPosVerNulo <= 7)
        {

            MovPos[MovPosHorNulo , MovPosVerNulo] = 0;

            MovPosHorNulo++;
            if(MovPosHorNulo == 8)
            {
            MovPosVerNulo++; 
            MovPosHorNulo = 0;
            }

        }
        }

        void EnPassant(int HorMovN, int VerMov, int SelVer, Pieces[,] PosTab)
        {
            if(PosTab[HorMovN, VerMov] is PawnWhite)
            {
                if(VerMov == SelVer + 2)
                {
                    if(HorMovN + 1 < 8)
                    {
                        if(PosTab[HorMovN + 1, VerMov] is PawnBlack)
                            ((PawnBlack)PosTab[HorMovN + 1 , VerMov]).EnPassantB = 1;
                    }

                    if(HorMovN - 1 >= 0)
                    {
                        if(PosTab[HorMovN - 1, VerMov] is PawnBlack)
                            ((PawnBlack)PosTab[HorMovN - 1 , VerMov]).EnPassantB = 2;
                    }
                }
            }
        

        if(PosTab[HorMovN, VerMov] is PawnBlack)
        {
            if(VerMov == SelVer - 2)
            {
                if(HorMovN + 1 < 8)
                {
                    if(PosTab[HorMovN + 1, VerMov] is PawnWhite)
                    ((PawnWhite)PosTab[HorMovN + 1 , VerMov]).EnPassantW = 1;
                }

                if(HorMovN - 1 >= 0)
                {
                    if(PosTab[HorMovN - 1, VerMov] is PawnWhite)
                    ((PawnWhite)PosTab[HorMovN - 1 , VerMov]).EnPassantW = 2;
                }
            }
        }
    }

        void PosPiece(Pieces peca , bool CollorPeca , int HorizontalPeca , int VerticalPeca)
        {

            peca.Col = CollorPeca;
            peca.HorN = HorizontalPeca;
            peca.Ver = VerticalPeca;
            peca.MovPast = false;

            PosTab[HorizontalPeca , VerticalPeca] = peca;

        }

        void MovimentPiece(int MovementHorizontal , int MovementVertical , int SelectHorizontal , int SelectVertical)
        {

            PosTab[MovementHorizontal , MovementVertical] = PosTab[SelectHorizontal , SelectVertical];
            PosTab[SelectHorizontal , SelectVertical] = null;
            PosTab[MovementHorizontal , MovementVertical].MovPast = true;
            PosTab[MovementHorizontal , MovementVertical].HorN = MovementHorizontal;
            PosTab[MovementHorizontal , MovementVertical].Ver = MovementVertical;

        }

        public void TabStart()
        {

            PosPiece(new Rook() , true , 0 , 0);
            PosPiece(new Knight() , true , 1 , 0);
            PosPiece(new Bishop() , true , 2 , 0);
            PosPiece(new Queen() , true , 3 , 0);
            PosPiece(new King() , true , 4 , 0);
            PosPiece(new Bishop() , true , 5 , 0);
            PosPiece(new Knight() , true , 6 , 0);
            PosPiece(new Rook() , true , 7 , 0);

            PosPiece(new Rook() , false , 0 , 7);
            PosPiece(new Knight() , false , 1 , 7);
            PosPiece(new Bishop() , false , 2 , 7);
            PosPiece(new Queen() , false , 3 , 7);
            PosPiece(new King() , false , 4 , 7);
            PosPiece(new Bishop() , false , 5 , 7);
            PosPiece(new Knight() , false , 6 , 7);
            PosPiece(new Rook() , false , 7 , 7);

            for(int HorizontalPeao = 0 ; HorizontalPeao < 8 ; HorizontalPeao++)
            {

                PosPiece(new PawnWhite() , true , HorizontalPeao , 1);
                PosPiece(new PawnBlack() , false , HorizontalPeao , 6);

            }

        }

       public void Movement(int HorMovN , int VerMov , int SelHorN , int SelVer , int[,] MovPos , bool ColPly , Player PlyG)
        {

        PosTab[SelHorN , SelVer].MovementPossible(SelHorN , SelVer , PosTab , MovPos , ColPly);
        PlyG.Play();
        HorMovN = PlyG.HorMovN;
        VerMov = PlyG.VerMov;

        if(MovPos[HorMovN , VerMov] == 1 || MovPos[HorMovN , VerMov] == 2)
        {

            MovimentPiece(HorMovN , VerMov , SelHorN , SelVer);

            EnPassant(HorMovN , VerMov, SelVer , PosTab);


        }

        else if(MovPos[HorMovN , VerMov] == 3 && PosTab[SelHorN , SelVer].Col == true)
        {

            MovimentPiece(2 , 0 , SelHorN , SelVer);

            MovimentPiece(3 , 0 , 0 , 0);

        }

        else if(MovPos[HorMovN , VerMov] == 4 && PosTab[SelHorN , SelVer].Col == true)
        {

            MovimentPiece(6 , 0 , SelHorN , SelVer);

            MovimentPiece(5 , 0 , 7 , 0);

        }

        else if(MovPos[HorMovN , VerMov] == 3 && PosTab[SelHorN , SelVer].Col == false)
        {

            MovimentPiece(2 , 7 , SelHorN , SelVer);

            MovimentPiece(3 , 7 , 0 , 7);

        }

        else if(MovPos[HorMovN , VerMov] == 4 && PosTab[SelHorN , SelVer].Col == false)
        {

            MovimentPiece(6 , 7 , SelHorN , SelVer);

            MovimentPiece(5 , 7 , 7 , 7);

        }

        else if(MovPos[HorMovN , VerMov] == 6)
        {

            MovimentPiece(HorMovN , VerMov , SelHorN ,SelVer);
            PosTab[SelHorN - 1 , SelVer] = null;

        }

        else if(MovPos[HorMovN , VerMov] == 7)
        {

            MovimentPiece(HorMovN , VerMov , SelHorN , SelVer);
            PosTab[SelHorN + 1 , SelVer] = null; 

        }

        if(MovPos[HorMovN , VerMov] != 0){
        MovPosNulo(MovPos);
        EnPassantNulo(PosTab , ColPly);}



        }
       
    }
}