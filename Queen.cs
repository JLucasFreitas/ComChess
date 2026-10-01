using System;
namespace ComChess
{
    public class Queen : Pieces
    {
        public override void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,] PositionTab , int[,] MovementPossible , bool ColorPlayer)
        {
            int PositionVerifyfHorizontal = SelectionHorizontalN;
            int PositionVerifyfVertical = SelectionVertical;
       
            DirectionsContinuos(1 , 0 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(-1 , 0 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(0 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(0 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);

            DirectionsContinuos(1 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(-1 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(-1 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            DirectionsContinuos(1 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
        }

        public override Pieces ClonePiece()
        {
            Pieces PieceClonada = new Queen();
            PieceClonada.CollorPiece = this.CollorPiece;
            PieceClonada.HorizontalPieceN = this.HorizontalPieceN;
            PieceClonada.VerticalPiece = this.VerticalPiece;
            PieceClonada.MovementPast = this.MovementPast;

            return PieceClonada;
        }
    }
}