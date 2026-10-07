using System;
namespace ComChess
{
    public class Pawn : Pieces
    {
        // Define o sentido de movimento do peão: 1 para uma cor e -1 para a outra
        public int DefineCollor {get; set;} = 0;

        // Indica se o peão pode ser capturado por En Passant
        public bool EnPassantPossible {get; set; }

        // Verifica se existe um peão adversário ao lado que possa ser capturado por En Passant
        void EnPassant(int SelectionHorizontalN , int SelectionVertical , int DefineCollor , int[,] MovementPossible , Pieces[,] PositionTab)
        {
            // Verifica o lado direito do peão
            if(InTab(SelectionHorizontalN + 1 , SelectionVertical) && PositionTab[SelectionHorizontalN  + 1 , SelectionVertical] is Pawn)
                {
                Pawn PawnRight = (Pawn)PositionTab[SelectionHorizontalN + 1 , SelectionVertical];

                if(PositionTab[SelectionHorizontalN + 1 , SelectionVertical].CollorPiece != PositionTab[SelectionHorizontalN , SelectionVertical].CollorPiece && PawnRight.EnPassantPossible){
                MovementPossible[SelectionHorizontalN + 1 , SelectionVertical + DefineCollor] = 6;}
                }

                // Verifica o lado esquerdo do peão
                if(InTab(SelectionHorizontalN - 1 , SelectionVertical) && PositionTab[SelectionHorizontalN - 1 , SelectionVertical] is Pawn)
                {
                Pawn PawnLeft = (Pawn)PositionTab[SelectionHorizontalN - 1 , SelectionVertical];

                if(PositionTab[SelectionHorizontalN - 1 , SelectionVertical].CollorPiece != PositionTab[SelectionHorizontalN , SelectionVertical].CollorPiece && PawnLeft.EnPassantPossible){
                    MovementPossible[SelectionHorizontalN - 1 , SelectionVertical + DefineCollor] = 6;}
                }
        }

        // Verifica se o próximo movimento leva o peão até a última fileira e marca o movimento como promoção
        void Promotion(int PositionVerifyfHorizontal , int PositionVerifyfVertical , int DefineCollor , int[,] MovementPossible)
        {
            if((PositionVerifyfVertical + DefineCollor == 0 ||PositionVerifyfVertical + DefineCollor == 7) && MovementPossible[PositionVerifyfHorizontal, PositionVerifyfVertical + DefineCollor] != 0)
            {
                MovementPossible[PositionVerifyfHorizontal , PositionVerifyfVertical + DefineCollor] = 5;
            }
        }

        // Verifica os movimentos do peão para frente, incluindo o movimento inicial de duas casas
        void MovementFrontPawn( int PositionVerifyfHorizontal , int PositionVerifyfVertical , int SelectionHorizontalN , int SelectionVertical , int DefineCollor , int[,] MovementPossible , Pieces[,] PositionTab , bool ColorPlayer)
        {
            // O peão só pode avançar se a casa à frente estiver vazia
            if(InTab(PositionVerifyfHorizontal , PositionVerifyfVertical + DefineCollor) && PositionTab[PositionVerifyfHorizontal, PositionVerifyfVertical + DefineCollor] == null)
            {
                Directions(0 , DefineCollor , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
                Promotion(PositionVerifyfHorizontal , PositionVerifyfVertical , DefineCollor , MovementPossible);

                 // Permite o avanço de duas casas caso o peão ainda não tenha se movido
                if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical].MovementPast == false && PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical + (2 * DefineCollor)] == null){
                Directions(0 , 2 * DefineCollor , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
                MovementPossible[SelectionHorizontalN , SelectionVertical + (2 * DefineCollor)] = 2;}
            }
        }

        // Verifica as duas diagonais onde o peão pode realizar capturas
        void MovementEatPawn(int PositionVerifyfHorizontal , int PositionVerifyfVertical , int DefineCollor , int[,] MovementPossible , Pieces[,] PositionTab , bool ColorPlayer)
        {
            // Verifica a diagonal direita
            if(InTab(PositionVerifyfHorizontal + 1 , PositionVerifyfVertical + DefineCollor) && PositionTab[PositionVerifyfHorizontal + 1 , PositionVerifyfVertical + DefineCollor] != null){
                Directions(1 , DefineCollor , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
                Promotion(PositionVerifyfHorizontal + 1 , PositionVerifyfVertical , DefineCollor , MovementPossible);}

            // Verifica a diagonal esquerda
            if(InTab(PositionVerifyfHorizontal - 1 , PositionVerifyfVertical + DefineCollor) && PositionTab[PositionVerifyfHorizontal - 1 , PositionVerifyfVertical + DefineCollor] != null){
                Directions(-1 , DefineCollor , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
                Promotion(PositionVerifyfHorizontal - 1 , PositionVerifyfVertical , DefineCollor , MovementPossible);}
        }

        // Define o sentido em que o peão deve se movimentar de acordo com sua cor
        void DefineCollorMetodo(int PositionVerifyfHorizontal , int PositionVerifyfVertical , Pieces[,] PositionTab)
        {
            if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical].CollorPiece == true)
            DefineCollor = 1;
            else{
            DefineCollor = -1;}
        }

        // Calcula todos os movimentos possíveis do peão
        public override void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,]PositionTab , int[,] MovementPossible , bool ColorPlayer)
        {
            int PositionVerifyfVertical = SelectionVertical;
            int PositionVerifyfHorizontal = SelectionHorizontalN;

            DefineCollorMetodo(PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab);

            MovementFrontPawn(PositionVerifyfHorizontal , PositionVerifyfVertical , SelectionHorizontalN , SelectionVertical , DefineCollor , MovementPossible , PositionTab , ColorPlayer);

            MovementEatPawn(PositionVerifyfHorizontal , PositionVerifyfVertical , DefineCollor , MovementPossible , PositionTab , ColorPlayer);

            EnPassant(SelectionHorizontalN , SelectionVertical , DefineCollor , MovementPossible , PositionTab);

        }

        // Cria uma cópia independente do peão,incluindo seus estados específicos
        public override Pieces ClonePiece()
        {
            Pawn PieceClonada = new Pawn();
            PieceClonada.CollorPiece = this.CollorPiece;
            PieceClonada.HorizontalPieceN = this.HorizontalPieceN;
            PieceClonada.VerticalPiece = this.VerticalPiece;
            PieceClonada.MovementPast = this.MovementPast;
            PieceClonada.DefineCollor = this.DefineCollor;
            PieceClonada.EnPassantPossible = this.EnPassantPossible;

            return PieceClonada;
        }

        // Símbolo utilizado para representar o peão no tabuleiro
        public override char Symbol => 'P';
    }
}