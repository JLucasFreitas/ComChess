using System;
namespace ComChess
{
    public class Pawn : Pieces
    {
        public int DefineCollor {get; set;} = 0;
        public bool EnPassantPossible {get; set; }

        void EnPassant(int SelectionHorizontalN , int SelectionVertical , int DefineCollor , int[,] MovementPossible , Pieces[,] PositionTab)
        {
            if(InTab(SelectionHorizontalN + 1 , SelectionVertical) && PositionTab[SelectionHorizontalN  + 1 , SelectionVertical] is Pawn)
                {
                Pawn PawnRight = (Pawn)PositionTab[SelectionHorizontalN + 1 , SelectionVertical];

                if(PositionTab[SelectionHorizontalN + 1 , SelectionVertical].CollorPiece != PositionTab[SelectionHorizontalN , SelectionVertical].CollorPiece && PawnRight.EnPassantPossible){
                MovementPossible[SelectionHorizontalN + 1 , SelectionVertical + DefineCollor] = 6;}
                }

                if(InTab(SelectionHorizontalN - 1 , SelectionVertical) && PositionTab[SelectionHorizontalN - 1 , SelectionVertical] is Pawn)
                {
                Pawn PawnLeft = (Pawn)PositionTab[SelectionHorizontalN - 1 , SelectionVertical];

                if(PositionTab[SelectionHorizontalN - 1 , SelectionVertical].CollorPiece != PositionTab[SelectionHorizontalN , SelectionVertical].CollorPiece && PawnLeft.EnPassantPossible){
                    MovementPossible[SelectionHorizontalN - 1 , SelectionVertical + DefineCollor] = 6;}
                }
        }

        void Promotion(int PositionVerifyfHorizontal , int PositionVerifyfVertical , int DefineCollor , int[,] MovementPossible)
        {
            if((PositionVerifyfVertical + DefineCollor == 0 ||PositionVerifyfVertical + DefineCollor == 7) && MovementPossible[PositionVerifyfHorizontal, PositionVerifyfVertical + DefineCollor] != 0)
            {
                MovementPossible[PositionVerifyfHorizontal , PositionVerifyfVertical + DefineCollor] = 5;
            }
        }

        void MovementFrontPawn( int PositionVerifyfHorizontal , int PositionVerifyfVertical , int SelectionHorizontalN , int SelectionVertical , int DefineCollor , int[,] MovementPossible , Pieces[,] PositionTab , bool ColorPlayer)
        {
            if(InTab(PositionVerifyfHorizontal , PositionVerifyfVertical + DefineCollor) && PositionTab[PositionVerifyfHorizontal, PositionVerifyfVertical + DefineCollor] == null)
            {
                Directions(0 , DefineCollor , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
                Promotion(PositionVerifyfHorizontal , PositionVerifyfVertical , DefineCollor , MovementPossible);

                if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical].MovementPast == false && PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical + (2 * DefineCollor)] == null){
                Directions(0 , 2 * DefineCollor , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
                MovementPossible[SelectionHorizontalN , SelectionVertical + (2 * DefineCollor)] = 2;}
            }
        }

        void MovementEatPawn(int PositionVerifyfHorizontal , int PositionVerifyfVertical , int DefineCollor , int[,] MovementPossible , Pieces[,] PositionTab , bool ColorPlayer)
        {
            if(InTab(PositionVerifyfHorizontal + 1 , PositionVerifyfVertical + DefineCollor) && PositionTab[PositionVerifyfHorizontal + 1 , PositionVerifyfVertical + DefineCollor] != null){
                Directions(1 , DefineCollor , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
                Promotion(PositionVerifyfHorizontal + 1 , PositionVerifyfVertical , DefineCollor , MovementPossible);}

            if(InTab(PositionVerifyfHorizontal - 1 , PositionVerifyfVertical + DefineCollor) && PositionTab[PositionVerifyfHorizontal - 1 , PositionVerifyfVertical + DefineCollor] != null){
                Directions(-1 , DefineCollor , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
                Promotion(PositionVerifyfHorizontal - 1 , PositionVerifyfVertical , DefineCollor , MovementPossible);}
        }

        void DefineCollorMetodo(int PositionVerifyfHorizontal , int PositionVerifyfVertical , Pieces[,] PositionTab)
        {
            if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical].CollorPiece == true)
            DefineCollor = 1;
            else{
            DefineCollor = -1;}
        }

        public override void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,]PositionTab , int[,] MovementPossible , bool ColorPlayer)
        {
            int PositionVerifyfVertical = SelectionVertical;
            int PositionVerifyfHorizontal = SelectionHorizontalN;

            DefineCollorMetodo(PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab);

            MovementFrontPawn(PositionVerifyfHorizontal , PositionVerifyfVertical , SelectionHorizontalN , SelectionVertical , DefineCollor , MovementPossible , PositionTab , ColorPlayer);

            MovementEatPawn(PositionVerifyfHorizontal , PositionVerifyfVertical , DefineCollor , MovementPossible , PositionTab , ColorPlayer);

            EnPassant(SelectionHorizontalN , SelectionVertical , DefineCollor , MovementPossible , PositionTab);


        }
    }
}