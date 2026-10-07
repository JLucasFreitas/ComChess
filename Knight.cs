using System;
namespace ComChess
{
    public class Knight : Pieces
    {
        // Calcula os movimentos possíveis do Cavalo verificando suas oito combinações de movimento em "L"
        public override void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,] PositionTab , int[,] MovementPossible , bool ColorPlayer)
        {
            int PositionVerifyfHorizontal = SelectionHorizontalN;
            int PositionVerifyfVertical = SelectionVertical;

            // Movimentos com deslocamento horizontal de 2 e vertical de 1
            Directions(2 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(2 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(-2 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(-2 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);

            // Movimentos com deslocamento horizontal de 1 e vertical de 2
            Directions(1 , 2 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(1 , -2 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(-1 , 2 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(-1 , -2 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
        }

        // Cria uma cópia independente do Cavalo mantendo seu estado atual
        public override Pieces ClonePiece()
        {
            Pieces PieceClonada = new Knight();
            PieceClonada.CollorPiece = this.CollorPiece;
            PieceClonada.HorizontalPieceN = this.HorizontalPieceN;
            PieceClonada.VerticalPiece = this.VerticalPiece;
            PieceClonada.MovementPast = this.MovementPast;

            return PieceClonada;
        }

        // Símbolo utilizado para representar o Cavalo no tabuleiro
        public override char Symbol => 'N';
    }
}