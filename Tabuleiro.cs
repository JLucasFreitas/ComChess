using System;
using System.Formats.Tar;
using System.Runtime.CompilerServices;
namespace ComChess
{
    public class Tabuleiro
    {
        public Pieces[,] PositionTab {get; set;} = new Pieces[8 , 8];
        public Pieces[,] TabuleiroClonado {get; set;} = new Pieces[8 , 8];

        // Percorre todas as posições do tabuleiro e executa a operação selecionada.
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

        // Clona a peça da posição atual para o tabuleiro de backup.
        void ClonarTab(int PassarTabuleiroHorizontal , int PassarTabuleiroVertical)
        {
            if(PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical] != null)
            TabuleiroClonado[PassarTabuleiroHorizontal , PassarTabuleiroVertical] = PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical].ClonePiece();

            else
            TabuleiroClonado[PassarTabuleiroHorizontal , PassarTabuleiroVertical] = null;
        }

        // Remove a possibilidade de En Passant dos peões adversários quando ela não é mais válida.
        void EnPassantNulo(Pieces[,] PositionTab , bool ColorPlayer , int PassarTabuleiroHorizontal , int PassarTabuleiroVertical)
        {
            if(PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical] is Pawn && PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical].CollorPiece != ColorPlayer)
            {
                Pawn PawnEnpassantNulo = (Pawn)PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical];
                PawnEnpassantNulo.EnPassantPossible = false;
            }
        }

        // Zera uma posição do array de movimentos possíveis.
        void MovementPossibleNulo(int[,] MovementPossible , int PassarTabuleiroHorizontal , int PassarTabuleiroVertical)
        {
            MovementPossible[PassarTabuleiroHorizontal , PassarTabuleiroVertical] = 0;
        }

        // Exibe a peça ou uma casa vazia na posição atual do tabuleiro.
        void MostrarCasa(int PassarTabuleiroHorizontal , int PassarTabuleiroVertical)
        {
            if(PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical] == null)
            Console.Write(" . ");

            else
            Console.Write($" {PositionTab[PassarTabuleiroHorizontal , PassarTabuleiroVertical].Symbol} ");

            if(PassarTabuleiroHorizontal == 7)
            Console.WriteLine("");
        }

        // Percorre e exibe todo o tabuleiro no console.
        public void MostrarTabuleiro()
        {
            PassarTabuleiro(4 , PositionTab , false , new int[8,8]);
        }

        // Lê a peça escolhida na promoção e substitui o peão pela nova peça.
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

        // Cria as informações da peça e a posiciona no tabuleiro selecionado.
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

        // Move uma peça para outra posição, realizando também capturas quando houver uma peça no destino.
        void MovimentPiece(int MovementHorizontal , int MovementVertical , int SelectHorizontal , int SelectVertical)
        {
            PositionTab[MovementHorizontal , MovementVertical] = PositionTab[SelectHorizontal , SelectVertical];
            PositionTab[SelectHorizontal , SelectVertical] = null;
            PositionTab[MovementHorizontal , MovementVertical].MovementPast = true;
            PositionTab[MovementHorizontal , MovementVertical].HorizontalPieceN = MovementHorizontal;
            PositionTab[MovementHorizontal , MovementVertical].VerticalPiece = MovementVertical;
        }

        // Posiciona todas as peças em suas posições iniciais.
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

        // Obtém a posição de destino e executa o tipo de movimento correspondente.
        public void Movement(int HorizontalMovementN , int VerticalMovement , int SelectionHorizontalN , int SelectionVertical , int[,] MovementPossible , bool ColorPlayer , Player PlyG)
        {
        PositionTab[SelectionHorizontalN , SelectionVertical].MovementPossible(SelectionHorizontalN , SelectionVertical , PositionTab , MovementPossible , ColorPlayer);
        PlyG.Play();
        HorizontalMovementN = PlyG.HorizontalMovementN;
        VerticalMovement = PlyG.VerticalMovement;

        // Clona o tabuleiro antes de executar a jogada.
        PassarTabuleiro(2 , PositionTab , ColorPlayer , MovementPossible);

        // Movimento normal ou captura.
        if(MovementPossible[HorizontalMovementN , VerticalMovement] == 1)
        {
            MovimentPiece(HorizontalMovementN , VerticalMovement , SelectionHorizontalN , SelectionVertical);
        }

        // Movimento inicial de duas casas do peão.
        if(MovementPossible[HorizontalMovementN , VerticalMovement] == 2)
        {
            MovimentPiece(HorizontalMovementN , VerticalMovement , SelectionHorizontalN , SelectionVertical);
            Pawn PawnEnpassant = (Pawn)PositionTab[HorizontalMovementN , VerticalMovement];
            PawnEnpassant.EnPassantPossible = true;
        }

        // Roque Longo
        else if(MovementPossible[HorizontalMovementN , VerticalMovement] == 3)
        {
            MovimentPiece(2 , SelectionVertical , SelectionHorizontalN , SelectionVertical);
            MovimentPiece(3 , SelectionVertical , 0 , SelectionVertical);
        }

        // Roque Curto
        else if(MovementPossible[HorizontalMovementN , VerticalMovement] == 4)
        {
            MovimentPiece(6 , SelectionVertical , SelectionHorizontalN , SelectionVertical);
            MovimentPiece(5 , SelectionVertical , 7 , SelectionVertical);
        }

        // Promoção do Peão
        else if(MovementPossible[HorizontalMovementN, VerticalMovement] == 5)
        {
            MovimentPiece(HorizontalMovementN , VerticalMovement , SelectionHorizontalN , SelectionVertical);

            PromotionTrans(HorizontalMovementN , VerticalMovement , ColorPlayer , PlyG);
        }

        // EnPassant
        else if(MovementPossible[HorizontalMovementN , VerticalMovement] == 6)
        {
            MovimentPiece(HorizontalMovementN , VerticalMovement , SelectionHorizontalN ,SelectionVertical);
            Pawn PawnMov = (Pawn)PositionTab[HorizontalMovementN, VerticalMovement];
            PositionTab[HorizontalMovementN , VerticalMovement - PawnMov.DefineCollor] = null;
        }

        // Após uma jogada válida, atualiza o En Passant e limpa os movimentos possíveis.
        if(MovementPossible[HorizontalMovementN , VerticalMovement] != 0){
        PassarTabuleiro(1 , PositionTab , ColorPlayer , MovementPossible);
        PassarTabuleiro(3 , PositionTab , ColorPlayer , MovementPossible);}

        }      
    }
}