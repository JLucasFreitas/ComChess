using System;
namespace ComChess
{
    public class Bishop : Pieces
    {
        // Calcula os movimentos possíveis do Bispo percorrendo continuamente as quatro diagonais
        public override void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,] PositionTab , int[,] MovementPossible , bool ColorPlayer)
        {
            int PositionVerifyfHorizontal = SelectionHorizontalN;
            int PositionVerifyfVertical = SelectionVertical;
       
            DirectionsContinuos(1 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);// Diagonal inferior direita
            DirectionsContinuos(-1 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);// Diagonal superior esquerda
            DirectionsContinuos(-1 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer); // Diagonal inferior esquerda
            DirectionsContinuos(1 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);// Diagonal superior direita
        }

        // Cria uma cópia independente do Bispo mantendo seu estado atual
        public override Pieces ClonePiece()
        {
            Pieces PieceClonada = new Bishop();
            PieceClonada.CollorPiece = this.CollorPiece;
            PieceClonada.HorizontalPieceN = this.HorizontalPieceN;
            PieceClonada.VerticalPiece = this.VerticalPiece;
            PieceClonada.MovementPast = this.MovementPast;

            return PieceClonada;
        }

        // Símbolo utilizado para representar o Bispo no tabuleiro
        public override char Symbol => 'B';
    }
}