using System;
namespace ComChess
{
    
    public class Rook : Pieces
    {  
        // Calcula os movimentos possíveis da Torre percorrendo continuamente as quatro direções retas
        public override void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,] PositionTab , int[,] MovementPossible , bool ColorPlayer)
        {
            int PositionVerifyfHorizontal = SelectionHorizontalN;
            int PositionVerifyfVertical = SelectionVertical;
       
            DirectionsContinuos(1 , 0 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);// Direita
            DirectionsContinuos(-1 , 0 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);// Esquerda
            DirectionsContinuos(0 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);// Cima
            DirectionsContinuos(0 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);// Baixo
        }

        // Cria uma cópia independente da Torre mantendo seu estado atual
        public override Pieces ClonePiece()
        {
            Pieces PieceClonada = new Rook();
            PieceClonada.CollorPiece = this.CollorPiece;
            PieceClonada.HorizontalPieceN = this.HorizontalPieceN;
            PieceClonada.VerticalPiece = this.VerticalPiece;
            PieceClonada.MovementPast = this.MovementPast;

            return PieceClonada;
        }

        // Símbolo utilizado para representar a Torre no tabuleiro
        public override char Symbol => 'R';
    }
}