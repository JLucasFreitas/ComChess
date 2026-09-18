using System;
using System.Formats.Tar;
using System.Runtime.CompilerServices;
namespace ComChess
{
    public class Tabuleiro
    {
        Pieces[,] PosTab = new Pieces[8 , 8];

        public Pieces [,] GetPosTab()
        {
            return PosTab;
        }
        public void SetPosTab(Pieces [,] SetterPosTab)
        {
            PosTab = SetterPosTab;
        }

        void EnPassantNulo(Pieces[,]PosTab , bool GetColPly)
        {
            int EnPassantHorNulo = 0;
            int EnPassantVerNulo = 1;

            while(EnPassantVerNulo <= 6)
            {
                if(GetColPly == false){
                if(PosTab[EnPassantHorNulo , EnPassantVerNulo] is PawnBlack)
                ((PawnBlack)PosTab[EnPassantHorNulo , EnPassantVerNulo]).SetEnPassantB(0);}

                else{
                if(PosTab[EnPassantHorNulo , EnPassantVerNulo] is PawnWhite)
                ((PawnWhite)PosTab[EnPassantHorNulo , EnPassantVerNulo]).SetEnPassantW(0);}

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

        void EnPassant(int GetHorMovN, int GetVerMov, int GetSelVer, Pieces[,] PosTab)
        {
            if(PosTab[GetHorMovN, GetVerMov] is PawnWhite)
            {
                if(GetVerMov == GetSelVer + 2)
                {
                    if(GetHorMovN + 1 < 8)
                    {
                        if(PosTab[GetHorMovN + 1, GetVerMov] is PawnBlack)
                            ((PawnBlack)PosTab[GetHorMovN + 1 , GetVerMov]).SetEnPassantB(1);
                    }

                    if(GetHorMovN - 1 >= 0)
                    {
                        if(PosTab[GetHorMovN - 1, GetVerMov] is PawnBlack)
                            ((PawnBlack)PosTab[GetHorMovN - 1 , GetVerMov]).SetEnPassantB(2);
                    }
                }
            }
        

        if(PosTab[GetHorMovN, GetVerMov] is PawnBlack)
        {
            if(GetVerMov == GetSelVer - 2)
            {
                if(GetHorMovN + 1 < 8)
                {
                    if(PosTab[GetHorMovN + 1, GetVerMov] is PawnWhite)
                    ((PawnWhite)PosTab[GetHorMovN + 1 , GetVerMov]).SetEnPassantW(1);
                }

                if(GetHorMovN - 1 >= 0)
                {
                    if(PosTab[GetHorMovN - 1, GetVerMov] is PawnWhite)
                    ((PawnWhite)PosTab[GetHorMovN - 1 , GetVerMov]).SetEnPassantW(2);
                }
            }
        }
    }

        void PosPiece(Pieces peca , bool CollorPeca , int HorizontalPeca , int VerticalPeca)
        {

            peca.SetCol(CollorPeca);
            peca.SetHorN(HorizontalPeca);
            peca.SetVer(VerticalPeca);
            peca.SetMovPast(false);

            PosTab[HorizontalPeca , VerticalPeca] = peca;

        }

        void MovimentPiece(int MovementHorizontal , int MovementVertical , int SelectHorizontal , int SelectVertical)
        {

            PosTab[MovementHorizontal , MovementVertical] = PosTab[SelectHorizontal , SelectVertical];
            PosTab[SelectHorizontal , SelectVertical] = null;
            PosTab[MovementHorizontal , MovementVertical].SetMovPast(true);
            PosTab[MovementHorizontal , MovementVertical].SetHorN(MovementHorizontal);
            PosTab[MovementHorizontal , MovementVertical].SetVer(MovementVertical);

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

       public void Movement(int GetHorMovN , int GetVerMov , int GetSelHorN , int GetSelVer , int[,] MovPos , bool GetColPly , Player PlyG)
        {

        PosTab[GetSelHorN , GetSelVer].MovementPossible(GetSelHorN , GetSelVer , PosTab , MovPos , GetColPly);
        PlyG.Play();
        GetHorMovN = PlyG.GetHorMovN();
        GetVerMov = PlyG.GetVerMov();

        if(MovPos[GetHorMovN , GetVerMov] == 1 || MovPos[GetHorMovN , GetVerMov] == 2)
        {

            MovimentPiece(GetHorMovN , GetVerMov , GetSelHorN , GetSelVer);

            EnPassant(GetHorMovN , GetVerMov, GetSelVer , PosTab);


        }

        else if(MovPos[GetHorMovN , GetVerMov] == 3 && PosTab[GetSelHorN , GetSelVer].GetCol() == true)
        {

            MovimentPiece(2 , 0 , GetSelHorN , GetSelVer);

            MovimentPiece(3 , 0 , 0 , 0);

        }

        else if(MovPos[GetHorMovN , GetVerMov] == 4 && PosTab[GetSelHorN , GetSelVer].GetCol() == true)
        {

            MovimentPiece(6 , 0 , GetSelHorN , GetSelVer);

            MovimentPiece(5 , 0 , 7 , 0);

        }

        else if(MovPos[GetHorMovN , GetVerMov] == 3 && PosTab[GetSelHorN , GetSelVer].GetCol() == false)
        {

            MovimentPiece(2 , 7 , GetSelHorN ,GetSelVer);

            MovimentPiece(3 , 7 , 0 , 7);

        }

        else if(MovPos[GetHorMovN , GetVerMov] == 4 && PosTab[GetSelHorN , GetSelVer].GetCol() == false)
        {

            MovimentPiece(6 , 7 , GetSelHorN ,GetSelVer);

            MovimentPiece(5 , 7 , 7 , 7);

        }

        else if(MovPos[GetHorMovN , GetVerMov] == 6)
        {

            MovimentPiece(GetHorMovN , GetVerMov , GetSelHorN ,GetSelVer);
            PosTab[GetSelHorN - 1 , GetSelVer] = null;

        }

        else if(MovPos[GetHorMovN , GetVerMov] == 7)
        {

            MovimentPiece(GetHorMovN , GetVerMov , GetSelHorN ,GetSelVer);
            PosTab[GetSelHorN + 1 , GetSelVer] = null; 

        }

        if(MovPos[GetHorMovN , GetVerMov] != 0){
        MovPosNulo(MovPos);
        EnPassantNulo(PosTab , GetColPly);}



        }
       
    }
}