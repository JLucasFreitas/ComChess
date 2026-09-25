using System;
namespace ComChess
{
    public class Pawn : Pieces
    {
        public int DefineCollor {get; set;} = 0;
        public bool EnPassantPossible {get; set; }

        void EnPassant(int SelHorN , int SelVer , int DefineCollor , int[,] MovPos , Pieces[,] PosTab)
        {
            if(InTab(SelHorN + 1 , SelVer) && PosTab[SelHorN  + 1 , SelVer] is Pawn)
                {
                Pawn PawnRight = (Pawn)PosTab[SelHorN + 1 , SelVer];

                if(PosTab[SelHorN + 1 , SelVer].Col != PosTab[SelHorN , SelVer].Col && PawnRight.EnPassantPossible){
                MovPos[SelHorN + 1 , SelVer + DefineCollor] = 6;}
                }

                if(InTab(SelHorN - 1 , SelVer) && PosTab[SelHorN - 1 , SelVer] is Pawn)
                {
                Pawn PawnLeft = (Pawn)PosTab[SelHorN - 1 , SelVer];

                if(PosTab[SelHorN - 1 , SelVer].Col != PosTab[SelHorN , SelVer].Col && PawnLeft.EnPassantPossible){
                    MovPos[SelHorN - 1 , SelVer + DefineCollor] = 6;}
                }
        }

        void Promotion(int PosVerfHor , int PosVerfVer , int DefineCollor , int[,] MovPos)
        {
            if((PosVerfVer + DefineCollor == 0 ||PosVerfVer + DefineCollor == 7) &&MovPos[PosVerfHor, PosVerfVer + DefineCollor] != 0)
            {
                MovPos[PosVerfHor, PosVerfVer + DefineCollor] = 5;
            }
        }

        void MovementFrontPawn( int PosVerfHor , int PosVerfVer , int SelHorN , int SelVer , int DefineCollor , int[,] MovPos , Pieces[,] PosTab , bool ColPly)
        {
            if(InTab(PosVerfHor , PosVerfVer + DefineCollor) && PosTab[PosVerfHor , PosVerfVer + DefineCollor] == null)
            {
                Directions(0 , DefineCollor , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
                Promotion(PosVerfHor , PosVerfVer , DefineCollor , MovPos);

                if(PosTab[PosVerfHor , PosVerfVer].MovPast == false && PosTab[PosVerfHor , PosVerfVer + (2 * DefineCollor)] == null){
                Directions(0 , 2 * DefineCollor , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
                MovPos[SelHorN , SelVer + (2 * DefineCollor)] = 2;}
            }
        }

        void MovementEatPawn(int PosVerfHor , int PosVerfVer , int DefineCollor , int[,] MovPos , Pieces[,] PosTab , bool ColPly)
        {
            if(InTab(PosVerfHor + 1 , PosVerfVer + DefineCollor) && PosTab[PosVerfHor + 1 , PosVerfVer + DefineCollor] != null){
                Directions(1 , DefineCollor , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
                Promotion(PosVerfHor + 1 , PosVerfVer , DefineCollor , MovPos);}

            if(InTab(PosVerfHor - 1 , PosVerfVer + DefineCollor) && PosTab[PosVerfHor - 1 , PosVerfVer + DefineCollor] != null){
                Directions(-1 , DefineCollor , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
                Promotion(PosVerfHor - 1 , PosVerfVer , DefineCollor , MovPos);}
        }

        void DefineCollorMetodo(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab)
        {
            if(PosTab[PosVerfHor , PosVerfVer].Col == true)
            DefineCollor = 1;
            else{
            DefineCollor = -1;}
        }

        public override void MovementPossible(int SelHorN , int SelVer , Pieces[,]PosTab , int[,] MovPos , bool ColPly)
        {
            int PosVerfVer = SelVer;
            int PosVerfHor = SelHorN;

            DefineCollorMetodo(PosVerfHor , PosVerfVer , PosTab);

            MovementFrontPawn(PosVerfHor , PosVerfVer , SelHorN , SelVer , DefineCollor , MovPos , PosTab , ColPly);

            MovementEatPawn(PosVerfHor , PosVerfVer , DefineCollor , MovPos , PosTab , ColPly);

            EnPassant(SelHorN , SelVer , DefineCollor , MovPos , PosTab);


        }
    }
}