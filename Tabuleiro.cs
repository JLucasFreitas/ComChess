using System;
using System.Formats.Tar;
using System.Runtime.CompilerServices;
namespace ComChess
{
    public class Tabuleiro
    {
        public Pieces[,] PositionTab {get; set;} = new Pieces[8 , 8];
        public Pieces[,] TabuleiroClonado {get; set;} = new Pieces[8 , 8];

        void PassarTabuleiro(int EscolhaPassarTabuleiro , Pieces[,] PositionTab , bool ColorPlayer , int[,] MovementPossible)
        {
        int PassarTabuleiroVertical = 0;

            for(int PassarTabuleiroHorizontal = 0 ; PassarTabuleiroVertical <= 7 ; PassarTabuleiroHorizontal++)
            {
                switch(EscolhaPassarTabuleiro)
                {
                    case 1:
                    {
                    EnPassantNulo(PositionTab , ColorPlayer , PassarTabuleiroHorizontal , PassarTabuleiroVertical);
                    break;
                    }

                    case 2:
                    {
                    ClonarTab(PassarTabuleiroHorizontal , PassarTabuleiroVertical);
                    break;
                    }

                    case 3:
                    {
                    MovementPossibleNulo(MovementPossible , PassarTabuleiroHorizontal , PassarTabuleiroVertical);
                    break;
                    }

                    case 4:
                    {
                        MostrarCasa(PassarTabuleiroHorizontal , PassarTabuleiroVertical);
                        break;
                    }
                }

                if(PassarTabuleiroHorizontal == 7)
                {
                PassarTabuleiroVertical++;
                PassarTabuleiroHorizontal = -1;
                }
            }
        }

        void ClonarTab(int PassarTabuleiroHorizontal , int PassarTabuleiroVertical)
        {
            if(PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical] != null)
            TabuleiroClonado[PassarTabuleiroHorizontal , PassarTabuleiroVertical] = PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical].ClonePiece();

            else
            TabuleiroClonado[PassarTabuleiroHorizontal , PassarTabuleiroVertical] = null;
        }

        void EnPassantNulo(Pieces[,] PositionTab , bool ColorPlayer , int PassarTabuleiroHorizontal , int PassarTabuleiroVertical)
        {
            if(PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical] is Pawn && PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical].CollorPiece != ColorPlayer)
            {
                Pawn PawnEnpassantNulo = (Pawn)PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical];
                PawnEnpassantNulo.EnPassantPossible = false;
            }
        }

        void MovementPossibleNulo(int[,] MovementPossible , int PassarTabuleiroHorizontal , int PassarTabuleiroVertical)
        {
            MovementPossible[PassarTabuleiroHorizontal , PassarTabuleiroVertical] = 0;
        }

        void MostrarCasa(int PassarTabuleiroHorizontal , int PassarTabuleiroVertical)
        {
            if(PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical] == null)
            Console.Write(" . ");

            else
            Console.Write($" {PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical].Symbol} ");

            if(PassarTabuleiroHorizontal == 7)
            Console.WriteLine("");
        }

        public void MostrarTabuleiro()
        {
            PassarTabuleiro(4 , PositionTab , false , new int[8,8]);
        }

        void PromotionTrans(int HorizontalMovementN , int VerticalMovement , bool ColorPlayer , Player PlyG)
        {
            switch(PlyG.PromotionSelect())
            {
            case 1:{
            PosPiece(new Rook() , ColorPlayer , HorizontalMovementN , VerticalMovement , true , 1);
            break;}

            case 2:{
            PosPiece(new Bishop() , ColorPlayer , HorizontalMovementN , VerticalMovement , true , 1);
            break;}

            case 3:{
            PosPiece(new Knight() , ColorPlayer , HorizontalMovementN , VerticalMovement , true , 1);
            break;}

            case 4:{
            PosPiece(new Queen() , ColorPlayer , HorizontalMovementN , VerticalMovement , true , 1);
            break;}
            }
        }

        void PosPiece(Pieces peca , bool CollorPeca , int HorizontalPeca , int VerticalPeca , bool MovementPast , int WhichTab)
        {
            peca.CollorPiece = CollorPeca;
            peca.HorizontalPieceN = HorizontalPeca;
            peca.VerticalPiece = VerticalPeca;
            peca.MovementPast = MovementPast;

            if(WhichTab == 1)
                PositionTab[HorizontalPeca , VerticalPeca] = peca;
            else
                TabuleiroClonado[HorizontalPeca , VerticalPeca] = peca;
        }

        void MovimentPiece(int MovementHorizontal , int MovementVertical , int SelectHorizontal , int SelectVertical)
        {
            PositionTab[MovementHorizontal , MovementVertical] = PositionTab[SelectHorizontal , SelectVertical];
            PositionTab[SelectHorizontal , SelectVertical] = null;
            PositionTab[MovementHorizontal , MovementVertical].MovementPast = true;
            PositionTab[MovementHorizontal , MovementVertical].HorizontalPieceN = MovementHorizontal;
            PositionTab[MovementHorizontal , MovementVertical].VerticalPiece = MovementVertical;
        }

        public void TabStart()
        {
            PosPiece(new Rook() , true , 0 , 0 , false , 1);
            PosPiece(new Knight() , true , 1 , 0 , false , 1);
            PosPiece(new Bishop() , true , 2 , 0 , false , 1);
            PosPiece(new Queen() , true , 3 , 0 , false , 1);
            PosPiece(new King() , true , 4 , 0 , false , 1);
            PosPiece(new Bishop() , true , 5 , 0 , false , 1);
            PosPiece(new Knight() , true , 6 , 0 , false , 1);
            PosPiece(new Rook() , true , 7 , 0 , false , 1);

            PosPiece(new Rook() , false , 0 , 7 , false , 1);
            PosPiece(new Knight() , false , 1 , 7 , false , 1);
            PosPiece(new Bishop() , false , 2 , 7 , false , 1);
            PosPiece(new Queen() , false , 3 , 7 , false , 1);
            PosPiece(new King() , false , 4 , 7 , false , 1);
            PosPiece(new Bishop() , false , 5 , 7 , false , 1);
            PosPiece(new Knight() , false , 6 , 7 , false , 1);
            PosPiece(new Rook() , false , 7 , 7 , false , 1);

            for(int HorizontalPeao = 0 ; HorizontalPeao < 8 ; HorizontalPeao++)
            {
                PosPiece(new Pawn() , true , HorizontalPeao , 1 , false , 1);
                PosPiece(new Pawn() , false , HorizontalPeao , 6 , false , 1);
            }
        }

       public void Movement(int HorizontalMovementN , int VerticalMovement , int SelectionHorizontalN , int SelectionVertical , int[,] MovementPossible , bool ColorPlayer , Player PlyG)
        {
        PositionTab[SelectionHorizontalN , SelectionVertical].MovementPossible(SelectionHorizontalN , SelectionVertical , PositionTab , MovementPossible , ColorPlayer);
        PlyG.Play();
        HorizontalMovementN = PlyG.HorizontalMovementN;
        VerticalMovement = PlyG.VerticalMovement;

        PassarTabuleiro(2 , PositionTab , ColorPlayer , MovementPossible);

        if(MovementPossible[HorizontalMovementN , VerticalMovement] == 1)
        {
            MovimentPiece(HorizontalMovementN , VerticalMovement , SelectionHorizontalN , SelectionVertical);
        }

        if(MovementPossible[HorizontalMovementN , VerticalMovement] == 2)
        {
            MovimentPiece(HorizontalMovementN , VerticalMovement , SelectionHorizontalN , SelectionVertical);
            Pawn PawnEnpassant = (Pawn)PositionTab[HorizontalMovementN , VerticalMovement];
            PawnEnpassant.EnPassantPossible = true;
        }

        else if(MovementPossible[HorizontalMovementN , VerticalMovement] == 3)
        {
            MovimentPiece(2 , SelectionVertical , SelectionHorizontalN , SelectionVertical);
            MovimentPiece(3 , SelectionVertical , 0 , SelectionVertical);
        }

        else if(MovementPossible[HorizontalMovementN , VerticalMovement] == 4)
        {
            MovimentPiece(6 , SelectionVertical , SelectionHorizontalN , SelectionVertical);
            MovimentPiece(5 , SelectionVertical , 7 , SelectionVertical);
        }

        else if(MovementPossible[HorizontalMovementN, VerticalMovement] == 5)
        {
            MovimentPiece(HorizontalMovementN , VerticalMovement , SelectionHorizontalN , SelectionVertical);

            PromotionTrans(HorizontalMovementN , VerticalMovement , ColorPlayer , PlyG);
        }

        else if(MovementPossible[HorizontalMovementN , VerticalMovement] == 6)
        {
            MovimentPiece(HorizontalMovementN , VerticalMovement , SelectionHorizontalN ,SelectionVertical);
            Pawn PawnMov = (Pawn)PositionTab[HorizontalMovementN, VerticalMovement];
            PositionTab[HorizontalMovementN , VerticalMovement - PawnMov.DefineCollor] = null;
        }

        if(MovementPossible[HorizontalMovementN , VerticalMovement] != 0){
        PassarTabuleiro(1 , PositionTab , ColorPlayer , MovementPossible);
        PassarTabuleiro(3 , PositionTab , ColorPlayer , MovementPossible);}

        }      
    }
}