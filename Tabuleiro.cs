using System;
using System.Formats.Tar;
using System.Runtime.CompilerServices;
namespace ComChess
{
    public class Tabuleiro
    {
        Pieces[,] PosTab = new Pieces[8 , 8];

        public Pieces [,] GetPosTab()
        {
            return PosTab;
        }
        public void SetPosTab(Pieces [,] SetterPosTab)
        {
            PosTab = SetterPosTab;
        }

        //Rook---------------------------------------------------------------------------------------------------------------
        Rook RookW1 = new Rook();
        Rook RookW2 = new Rook();
        Rook RookB1 = new Rook();
        Rook RookB2 = new Rook();

        void RookW1Start()
        {
            RookW1.SetCol(true);
            RookW1.SetSta(true);
            RookW1.SetHorN(0);
            RookW1.SetVer(0);
            RookW1.SetMovPast(false);
            PosTab[0,0] = RookW1;
        }
        void RookW2Start()
        {
            RookW2.SetCol(true);
            RookW2.SetSta(true);
            RookW2.SetHorN(7);
            RookW2.SetVer(0);
            RookW2.SetMovPast(false);
            PosTab[7,0] = RookW2;
        }
        void RookB1Start()
        {
            RookB1.SetCol(false);
            RookB1.SetSta(true);
            RookB1.SetHorN(0);
            RookB1.SetVer(7);
            RookB1.SetMovPast(false);
            PosTab[0,7] = RookB1;
        }
        void RookB2Start()
        {
            RookB2.SetCol(false);
            RookB2.SetSta(true);
            RookB2.SetHorN(7);
            RookB2.SetVer(7);
            RookB2.SetMovPast(false);
            PosTab[7,7] = RookB2;
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
            BishopW1.SetHorN(2);
            BishopW1.SetVer(0);
            BishopW1.SetMovPast(false);
            PosTab[2,0] = BishopW1;
        }
        void BishopW2Start()
        {
            BishopW2.SetCol(true);
            BishopW2.SetSta(true);
            BishopW2.SetHorN(5);
            BishopW2.SetVer(0);
            BishopW2.SetMovPast(false);
            PosTab[5,0] = BishopW2;
        }
        void BishopB1Start()
        {
            BishopB1.SetCol(false);
            BishopB1.SetSta(true);
            BishopB1.SetHorN(2);
            BishopB1.SetVer(7);
            BishopB1.SetMovPast(false);
            PosTab[2,7] = BishopB1;
        }
        void BishopB2Start()
        {
            BishopB2.SetCol(false);
            BishopB2.SetSta(true);
            BishopB2.SetHorN(5);
            BishopB2.SetVer(7);
            BishopB2.SetMovPast(false);
            PosTab[5,7] = BishopB2;
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
            KnightW1.SetHorN(1);
            KnightW1.SetVer(0);
            KnightW1.SetMovPast(false);
            PosTab[1,0] = KnightW1;
       }
       void KnightW2Start()
       {
           KnightW2.SetCol(true);
           KnightW2.SetSta(true);
           KnightW2.SetHorN(6);
           KnightW2.SetVer(0);
           KnightW2.SetMovPast(false);
           PosTab[6,0] = KnightW2;
       }
       void KnightB1Start()
       {
           KnightB1.SetCol(false);
           KnightB1.SetSta(true);
           KnightB1.SetHorN(1);
           KnightB1.SetVer(7);
           KnightB1.SetMovPast(false);
           PosTab[1,7] = KnightB1;
       }
       void KnightB2Start()
       {
           KnightB2.SetCol(false);
           KnightB2.SetSta(true);
           KnightB2.SetHorN(6);
           KnightB2.SetVer(7);
           KnightB2.SetMovPast(false);
           PosTab[6,7] = KnightB2;
       }
       //Knight--------------------------------------------------------------------------------------------------------------

       //Queen---------------------------------------------------------------------------------------------------------------
        Queen QueenW1 = new Queen();
        Queen QueenB1 = new Queen();
       void QueenW1Start()
       {
           QueenW1.SetCol(true);
           QueenW1.SetSta(true);
           QueenW1.SetHorN(3);
           QueenW1.SetVer(0);
           QueenW1.SetMovPast(false);
           PosTab[3,0] = QueenW1;
       }
       void QueenB1Start()
       {
           QueenB1.SetCol(false);
           QueenB1.SetSta(true);
           QueenB1.SetHorN(3);
           QueenB1.SetVer(7);
           QueenB1.SetMovPast(false);
           PosTab[3,7] = QueenB1;
       }
       //Queen---------------------------------------------------------------------------------------------------------------

       //King----------------------------------------------------------------------------------------------------------------
        King KingW = new King();
        King KingB = new King();
       void KingWStart()
       {
           KingW.SetCol(true);
           KingW.SetSta(true);
           KingW.SetHorN(4);
           KingW.SetVer(0);
           KingW.SetMovPast(false);
           PosTab[4,0] = KingW;
       }
       void KingBStart()
       {
           KingB.SetCol(false);
           KingB.SetSta(true);
           KingB.SetHorN(4);
           KingB.SetVer(7);
           KingB.SetMovPast(false);
           PosTab[4,7] = KingB;
       }
        //King----------------------------------------------------------------------------------------------------------------

        //PawnWhite-----------------------------------------------------------------------------------------------------------
        PawnWhite PawnW1 = new PawnWhite();
        PawnWhite PawnW2 = new PawnWhite();
        PawnWhite PawnW3 = new PawnWhite();
        PawnWhite PawnW4 = new PawnWhite();
        PawnWhite PawnW5 = new PawnWhite();
        PawnWhite PawnW6 = new PawnWhite();
        PawnWhite PawnW7 = new PawnWhite();
        PawnWhite PawnW8 = new PawnWhite();
       void PawnW1Start()
       {
           PawnW1.SetCol(true);
           PawnW1.SetSta(true);
           PawnW1.SetHorN(0);
           PawnW1.SetVer(1);
           PawnW1.SetMovPast(false);
           PosTab[0,1] = PawnW1;
       }
       void PawnW2Start()
       {
           PawnW2.SetCol(true);
           PawnW2.SetSta(true);
           PawnW2.SetHorN(1);
           PawnW2.SetVer(1);
           PawnW2.SetMovPast(false);
           PosTab[1,1] = PawnW2;
       }
       void PawnW3Start()
       {
           PawnW3.SetCol(true);
           PawnW3.SetSta(true);
           PawnW3.SetHorN(2);
           PawnW3.SetVer(1);
           PawnW3.SetMovPast(false);
           PosTab[2,1] = PawnW3;
       }
       void PawnW4Start()
       {
           PawnW4.SetCol(true);
           PawnW4.SetSta(true);
           PawnW4.SetHorN(3);
           PawnW4.SetVer(1);
           PawnW4.SetMovPast(false);
           PosTab[3,1] = PawnW4;
       }
       void PawnW5Start()
       {
           PawnW5.SetCol(true);
           PawnW5.SetSta(true);
           PawnW5.SetHorN(4);
           PawnW5.SetVer(1);
           PawnW5.SetMovPast(false);
           PosTab[4,1] = PawnW5;
       }
       void PawnW6Start()
       {
           PawnW6.SetCol(true);
           PawnW6.SetSta(true);
           PawnW6.SetHorN(5);
           PawnW6.SetVer(1);
           PawnW6.SetMovPast(false);
           PosTab[5,1] = PawnW6;
       }
       void PawnW7Start()
       {
           PawnW7.SetCol(true);
           PawnW7.SetSta(true);
           PawnW7.SetHorN(6);
           PawnW7.SetVer(1);
           PawnW7.SetMovPast(false);
           PosTab[6,1] = PawnW7;
       }
       void PawnW8Start()
       {
           PawnW8.SetCol(true);
           PawnW8.SetSta(true);
           PawnW8.SetHorN(7);
           PawnW8.SetVer(1);
           PawnW8.SetMovPast(false);
           PosTab[7,1] = PawnW8;
       }
       //PawnWhite-----------------------------------------------------------------------------------------------------------

       //PawnBlack-----------------------------------------------------------------------------------------------------------
        PawnBlack PawnB1 = new PawnBlack();
        PawnBlack PawnB2 = new PawnBlack();
        PawnBlack PawnB3 = new PawnBlack();
        PawnBlack PawnB4 = new PawnBlack();
        PawnBlack PawnB5 = new PawnBlack();
        PawnBlack PawnB6 = new PawnBlack();
        PawnBlack PawnB7 = new PawnBlack();
        PawnBlack PawnB8 = new PawnBlack();
       void PawnB1Start()
       {
           PawnB1.SetCol(false);
           PawnB1.SetSta(true);
           PawnB1.SetHorN(0);
           PawnB1.SetVer(6);
           PawnB1.SetMovPast(false);
           PosTab[0,6] = PawnB1;
       }
       void PawnB2Start()
       {
           PawnB2.SetCol(false);
           PawnB2.SetSta(true);
           PawnB2.SetHorN(1);
           PawnB2.SetVer(6);
           PawnB2.SetMovPast(false);
           PosTab[1,6] = PawnB2;
       }
       void PawnB3Start()
       {
           PawnB3.SetCol(false);
           PawnB3.SetSta(true);
           PawnB3.SetHorN(2);
           PawnB3.SetVer(6);
           PawnB3.SetMovPast(false);
           PosTab[2,6] = PawnB3;
       }
       void PawnB4Start()
       {
           PawnB4.SetCol(false);
           PawnB4.SetSta(true);
           PawnB4.SetHorN(3);
           PawnB4.SetVer(6);
           PawnB4.SetMovPast(false);
           PosTab[3,6] = PawnB4;
       }
       void PawnB5Start()
       {
           PawnB5.SetCol(false);
           PawnB5.SetSta(true);
           PawnB5.SetHorN(4);
           PawnB5.SetVer(6);
           PawnB5.SetMovPast(false);
           PosTab[4,6] = PawnB5;
       }
       void PawnB6Start()
       {
           PawnB6.SetCol(false);
           PawnB6.SetSta(true);
           PawnB6.SetHorN(5);
           PawnB6.SetVer(6);
           PawnB6.SetMovPast(false);
           PosTab[5,6] = PawnB6;
       }
       void PawnB7Start()
       {
           PawnB7.SetCol(false);
           PawnB7.SetSta(true);
           PawnB7.SetHorN(6);
           PawnB7.SetVer(6);
           PawnB7.SetMovPast(false);
           PosTab[6,6] = PawnB7;
       }
       void PawnB8Start()
       {
           PawnB8.SetCol(false);
           PawnB8.SetSta(true);
           PawnB8.SetHorN(7);
           PawnB8.SetVer(6);
           PawnB8.SetMovPast(false);
           PosTab[7,6] = PawnB8;
       } 
       //PawnBlack-----------------------------------------------------------------------------------------------------------
       
    }
}