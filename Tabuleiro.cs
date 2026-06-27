using System;
namespace ComChess
{
    public class Tabuleiro
    {
        Pieces[,] PosTab = new Pieces[8 , 8];

        //Rook---------------------------------------------------------------------------------------------------------------
        Rook RookW1 = new Rook();
        Rook RookW2 = new Rook();
        Rook RookB1 = new Rook();
        Rook RookB2 = new Rook();

        void RookW1Start()
        {
            RookW1.SetCol(true);
            RookW1.SetSta(true);
            RookW1.SetHor('a');
            RookW1.SetVer(0);
        }
        void RookW2Start()
        {
            RookW2.SetCol(true);
            RookW2.SetSta(true);
            RookW2.SetHor('h');
            RookW2.SetVer(0);
        }
        void RookB1Start()
        {
            RookB1.SetCol(false);
            RookB1.SetSta(true);
            RookB1.SetHor('a');
            RookB1.SetVer(7);
        }
        void RookB2Start()
        {
            RookB2.SetCol(false);
            RookB2.SetSta(true);
            RookB2.SetHor('h');
            RookB2.SetVer(7);
        }
        //Rook---------------------------------------------------------------------------------------------------------------

        //Bishop-------------------------------------------------------------------------------------------------------------
        Bishop BishopW1 = new Bishop();
        Bishop BishopW2 = new Bishop();
        Bishop BishopB1 = new Bishop();
        Bishop BishopB2 = new Bishop();

        void BishopW1Start()
        {
            BishopW1.SetCol(true);
            BishopW1.SetSta(true);
            BishopW1.SetHor('c');
            BishopW1.SetVer(0);
        }
        void BishopW2Start()
        {
            BishopW2.SetCol(true);
            BishopW2.SetSta(true);
            BishopW2.SetHor('f');
            BishopW2.SetVer(0);
        }
        void BishopB1Start()
        {
            BishopB1.SetCol(false);
            BishopB1.SetSta(true);
            BishopB1.SetHor('c');
            BishopB1.SetVer(7);
        }
        void BishopB2Start()
        {
            BishopB2.SetCol(false);
            BishopB2.SetSta(true);
            BishopB2.SetHor('f');
            BishopB2.SetVer(7);
        }
        //Bishop-------------------------------------------------------------------------------------------------------------

        //Knight-------------------------------------------------------------------------------------------------------------
        Knight KnightW1 = new Knight();
        Knight KnightW2 = new Knight();
        Knight KnightB1 = new Knight();
        Knight KnightB2 = new Knight();


       void KnightW1Start()
       {
            KnightW1.SetCol(true);
            KnightW1.SetSta(true);
            KnightW1.SetHor('b');
            KnightW1.SetVer(0);
       }
       void KnightW2Start()
       {
           KnightW2.SetCol(true);
           KnightW2.SetSta(true);
           KnightW2.SetHor('g');
           KnightW2.SetVer(0);
       }
       void KnightB1Start()
       {
           KnightB1.SetCol(false);
           KnightB1.SetSta(true);
           KnightB1.SetHor('b');
           KnightB1.SetVer(7);
       }
       void KnightB2Start()
       {
           KnightB2.SetCol(false);
           KnightB2.SetSta(true);
           KnightB2.SetHor('g');
           KnightB2.SetVer(7);
       }
       //Knight--------------------------------------------------------------------------------------------------------------

       //Queen---------------------------------------------------------------------------------------------------------------
        Queen QueenW1 = new Queen();
        Queen QueenB1 = new Queen();
       void QueenW1Start()
       {
           QueenW1.SetCol(true);
           QueenW1.SetSta(true);
           QueenW1.SetHor('d');
           QueenW1.SetVer(0);
       }
       void QueenB1Start()
       {
           QueenB1.SetCol(false);
           QueenB1.SetSta(true);
           QueenB1.SetHor('d');
           QueenB1.SetVer(7);
       }
       //Queen---------------------------------------------------------------------------------------------------------------

       //King----------------------------------------------------------------------------------------------------------------
        King KingW1 = new King();
        King KingB1 = new King();
       void KingW1Start()
       {
           KingW1.SetCol(true);
           KingW1.SetSta(true);
           KingW1.SetHor('e');
           KingW1.SetVer(0);
       }
       void KingB1Start()
       {
           KingB1.SetCol(false);
           KingB1.SetSta(true);
           KingB1.SetHor('e');
           KingB1.SetVer(7);
       }
        //King----------------------------------------------------------------------------------------------------------------

        //PawnWhite-----------------------------------------------------------------------------------------------------------
        Pawn PawnW1 = new Pawn();
        Pawn PawnW2 = new Pawn();
        Pawn PawnW3 = new Pawn();
        Pawn PawnW4 = new Pawn();
        Pawn PawnW5 = new Pawn();
        Pawn PawnW6 = new Pawn();
        Pawn PawnW7 = new Pawn();
        Pawn PawnW8 = new Pawn();
       void PawnW1Start()
       {
           PawnW1.SetCol(true);
           PawnW1.SetSta(true);
           PawnW1.SetHor('a');
           PawnW1.SetVer(1);
       }
       void PawnW2Start()
       {
           PawnW2.SetCol(true);
           PawnW2.SetSta(true);
           PawnW2.SetHor('b');
           PawnW2.SetVer(1);
       }
       void PawnW3Start()
       {
           PawnW3.SetCol(true);
           PawnW3.SetSta(true);
           PawnW3.SetHor('c');
           PawnW3.SetVer(1);
       }
       void PawnW4Start()
       {
           PawnW4.SetCol(true);
           PawnW4.SetSta(true);
           PawnW4.SetHor('d');
           PawnW4.SetVer(1);
       }
       void PawnW5Start()
       {
           PawnW5.SetCol(true);
           PawnW5.SetSta(true);
           PawnW5.SetHor('e');
           PawnW5.SetVer(1);
       }
       void PawnW6Start()
       {
           PawnW6.SetCol(true);
           PawnW6.SetSta(true);
           PawnW6.SetHor('f');
           PawnW6.SetVer(1);
       }
       void PawnW7Start()
       {
           PawnW7.SetCol(true);
           PawnW7.SetSta(true);
           PawnW7.SetHor('g');
           PawnW7.SetVer(1);
       }
       void PawnW8Start()
       {
           PawnW8.SetCol(true);
           PawnW8.SetSta(true);
           PawnW8.SetHor('h');
           PawnW8.SetVer(1);
       }
       //PawnWhite-----------------------------------------------------------------------------------------------------------

       //PawnBlack-----------------------------------------------------------------------------------------------------------
        Pawn PawnB1 = new Pawn();
        Pawn PawnB2 = new Pawn();
        Pawn PawnB3 = new Pawn();
        Pawn PawnB4 = new Pawn();
        Pawn PawnB5 = new Pawn();
        Pawn PawnB6 = new Pawn();
        Pawn PawnB7 = new Pawn();
        Pawn PawnB8 = new Pawn();
       void PawnB1Start()
       {
           PawnB1.SetCol(false);
           PawnB1.SetSta(true);
           PawnB1.SetHor('a');
           PawnB1.SetVer(6);
       }
       void PawnB2Start()
       {
           PawnB2.SetCol(false);
           PawnB2.SetSta(true);
           PawnB2.SetHor('b');
           PawnB2.SetVer(6);
       }
       void PawnB3Start()
       {
           PawnB3.SetCol(false);
           PawnB3.SetSta(true);
           PawnB3.SetHor('c');
           PawnB3.SetVer(6);
       }
       void PawnB4Start()
       {
           PawnB4.SetCol(false);
           PawnB4.SetSta(true);
           PawnB4.SetHor('d');
           PawnB4.SetVer(6);
       }
       void PawnB5Start()
       {
           PawnB5.SetCol(false);
           PawnB5.SetSta(true);
           PawnB5.SetHor('e');
           PawnB5.SetVer(6);
       }
       void PawnB6Start()
       {
           PawnB6.SetCol(false);
           PawnB6.SetSta(true);
           PawnB6.SetHor('f');
           PawnB6.SetVer(6);
       }
       void PawnB7Start()
       {
           PawnB7.SetCol(false);
           PawnB7.SetSta(true);
           PawnB7.SetHor('g');
           PawnB7.SetVer(6);
       }
       void PawnB8Start()
       {
           PawnB8.SetCol(false);
           PawnB8.SetSta(true);
           PawnB8.SetHor('h');
           PawnB8.SetVer(6);
       } 
       //PawnBlack-----------------------------------------------------------------------------------------------------------

    }
}