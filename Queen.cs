using System;
namespace ComChess
{
    public class Queen : Pieces
    {
        // Calcula os movimentos possíveis da Rainha combinando movimentos retos e diagonais
        public override void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,] PositionTab , int[,] MovementPossible , bool ColorPlayer)
        {
            int PositionVerifyfHorizontal = SelectionHorizontalN;
            int PositionVerifyfVertical = SelectionVertical;
       
            // Movimentos retos
            DirectionsContinuos(1 , 0 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(-1 , 0 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(0 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(0 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);

            // Movimentos diagonais
            DirectionsContinuos(1 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(-1 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(-1 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(1 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
        }

        // Cria uma cópia independente da Rainha mantendo seu estado atual
        public override Pieces ClonePiece()
        {
            Pieces PieceClonada = new Queen();
            PieceClonada.CollorPiece = this.CollorPiece;
            PieceClonada.HorizontalPieceN = this.HorizontalPieceN;
            PieceClonada.VerticalPiece = this.VerticalPiece;
            PieceClonada.MovementPast = this.MovementPast;

            return PieceClonada;
        }

        // Símbolo utilizado para representar a Rainha no tabuleiro
        public override char Symbol => 'Q';
    }
}