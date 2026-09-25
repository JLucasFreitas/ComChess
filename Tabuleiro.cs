using System;
using System.Formats.Tar;
using System.Runtime.CompilerServices;
namespace ComChess
{
    public class Tabuleiro
    {
        public Pieces[,] PosTab {get; set;} = new Pieces[8 , 8];

        void MovPosNulo(int[,] MovPos)
        {
        int MovPosVerNulo = 0;

        for(int MovPosHorNulo = 0 ; MovPosVerNulo <= 7 ; MovPosHorNulo++)
        {
            MovPos[MovPosHorNulo , MovPosVerNulo] = 0;

            if(MovPosHorNulo == 7)
            {
            MovPosVerNulo++;
            MovPosHorNulo = -1;
            }
        }
        }

        void EnPassantNulo(Pieces[,] PosTab , bool ColPly)
        {
        int EnPassantVerNulo = 0;

        for(int EnPassantHorNulo = 0 ; EnPassantVerNulo <= 7 ; EnPassantHorNulo++)
        {
            if(PosTab[EnPassantHorNulo , EnPassantVerNulo] is Pawn && PosTab[EnPassantHorNulo , EnPassantVerNulo].Col != ColPly)
            {
            Pawn PawnEnpassantNulo = (Pawn)PosTab[EnPassantHorNulo , EnPassantVerNulo];
            PawnEnpassantNulo.EnPassantPossible = false;
            }

            if(EnPassantHorNulo == 7)
            {
            EnPassantVerNulo++;
            EnPassantHorNulo = -1;
            }
        }
        }

        void PromotionTrans(int HorMovN , int VerMov , bool ColPly , Player PlyG)
        {
            switch(PlyG.PromotionSelect())
            {
            case 1:{
            PosPiece(new Rook() , ColPly , HorMovN , VerMov , true);
            break;}

            case 2:{
            PosPiece(new Bishop() , ColPly , HorMovN , VerMov , true);
            break;}

            case 3:{
            PosPiece(new Knight() , ColPly , HorMovN , VerMov , true);
            break;}

            case 4:{
            PosPiece(new Queen() , ColPly , HorMovN , VerMov , true);
            break;}
            }
        }

        void PosPiece(Pieces peca , bool CollorPeca , int HorizontalPeca , int VerticalPeca , bool MovementPast)
        {
            peca.Col = CollorPeca;
            peca.HorN = HorizontalPeca;
            peca.Ver = VerticalPeca;
            peca.MovPast = MovementPast;

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
            PosPiece(new Rook() , true , 0 , 0 , false);
            PosPiece(new Knight() , true , 1 , 0 , false);
            PosPiece(new Bishop() , true , 2 , 0 , false);
            PosPiece(new Queen() , true , 3 , 0 , false);
            PosPiece(new King() , true , 4 , 0 , false);
            PosPiece(new Bishop() , true , 5 , 0 , false);
            PosPiece(new Knight() , true , 6 , 0 , false);
            PosPiece(new Rook() , true , 7 , 0 , false);

            PosPiece(new Rook() , false , 0 , 7 , false);
            PosPiece(new Knight() , false , 1 , 7 , false);
            PosPiece(new Bishop() , false , 2 , 7 , false);
            PosPiece(new Queen() , false , 3 , 7 , false);
            PosPiece(new King() , false , 4 , 7 , false);
            PosPiece(new Bishop() , false , 5 , 7 , false);
            PosPiece(new Knight() , false , 6 , 7 , false);
            PosPiece(new Rook() , false , 7 , 7 , false);

            for(int HorizontalPeao = 0 ; HorizontalPeao < 8 ; HorizontalPeao++)
            {
                PosPiece(new Pawn() , true , HorizontalPeao , 1 , false);
                PosPiece(new Pawn() , false , HorizontalPeao , 6 , false);
            }
        }

       public void Movement(int HorMovN , int VerMov , int SelHorN , int SelVer , int[,] MovPos , bool ColPly , Player PlyG)
        {
        PosTab[SelHorN , SelVer].MovementPossible(SelHorN , SelVer , PosTab , MovPos , ColPly);
        PlyG.Play();
        HorMovN = PlyG.HorMovN;
        VerMov = PlyG.VerMov;

        if(MovPos[HorMovN , VerMov] == 1)
        {
            MovimentPiece(HorMovN , VerMov , SelHorN , SelVer);
        }

        if(MovPos[HorMovN , VerMov] == 2)
        {
            MovimentPiece(HorMovN , VerMov , SelHorN , SelVer);
            Pawn PawnEnpassant = (Pawn)PosTab[HorMovN , VerMov];
            PawnEnpassant.EnPassantPossible = true;
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

        else if(MovPos[HorMovN, VerMov] == 5)
        {
            MovimentPiece(HorMovN , VerMov , SelHorN , SelVer);

            PromotionTrans(HorMovN , VerMov , ColPly , PlyG);
        }

        else if(MovPos[HorMovN , VerMov] == 6)
        {
            MovimentPiece(HorMovN , VerMov , SelHorN ,SelVer);
            Pawn PawnMov = (Pawn)PosTab[HorMovN, VerMov];
            PosTab[HorMovN , VerMov - PawnMov.DefineCollor] = null;
        }

        if(MovPos[HorMovN , VerMov] != 0){
        MovPosNulo(MovPos);
        EnPassantNulo(PosTab , ColPly);}

        }      
    }
}