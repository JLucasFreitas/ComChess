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

        void MovPosNulo(int[,]MovPos)
        {
        int MovPosHorNulo = 0;
        int MovPosVerNulo = 0;

        while(MovPosVerNulo <= 7)
        {

            MovPos[MovPosHorNulo , MovPosVerNulo] = 0;

            MovPosHorNulo++;
            if(MovPosHorNulo == 8)
            {
            MovPosVerNulo++; 
            MovPosHorNulo = 0;
            }

        }
        }

        //Rook---------------------------------------------------------------------------------------------------------------
        Rook RookW1 = new Rook();
        Rook RookW2 = new Rook();
        Rook RookB1 = new Rook();
        Rook RookB2 = new Rook();

        Bishop BishopW1 = new Bishop();
        Bishop BishopW2 = new Bishop();
        Bishop BishopB1 = new Bishop();
        Bishop BishopB2 = new Bishop();

        Knight KnightW1 = new Knight();
        Knight KnightW2 = new Knight();
        Knight KnightB1 = new Knight();
        Knight KnightB2 = new Knight();

        Queen QueenW1 = new Queen();
        Queen QueenB1 = new Queen();

        King KingW = new King();
        King KingB = new King();

        PawnWhite PawnW1 = new PawnWhite();
        PawnWhite PawnW2 = new PawnWhite();
        PawnWhite PawnW3 = new PawnWhite();
        PawnWhite PawnW4 = new PawnWhite();
        PawnWhite PawnW5 = new PawnWhite();
        PawnWhite PawnW6 = new PawnWhite();
        PawnWhite PawnW7 = new PawnWhite();
        PawnWhite PawnW8 = new PawnWhite();

        PawnBlack PawnB1 = new PawnBlack();
        PawnBlack PawnB2 = new PawnBlack();
        PawnBlack PawnB3 = new PawnBlack();
        PawnBlack PawnB4 = new PawnBlack();
        PawnBlack PawnB5 = new PawnBlack();
        PawnBlack PawnB6 = new PawnBlack();
        PawnBlack PawnB7 = new PawnBlack();
        PawnBlack PawnB8 = new PawnBlack();

        public void TabStart()
        {
            //Rook---------------------------------------------------------------------------------------------------------------

            RookW1.SetCol(true);
            RookW1.SetSta(true);
            RookW1.SetHorN(0);
            RookW1.SetVer(0);
            RookW1.SetMovPast(false);
            PosTab[0,0] = RookW1;
        
            RookW2.SetCol(true);
            RookW2.SetSta(true);
            RookW2.SetHorN(7);
            RookW2.SetVer(0);
            RookW2.SetMovPast(false);
            PosTab[7,0] = RookW2;
        
            RookB1.SetCol(false);
            RookB1.SetSta(true);
            RookB1.SetHorN(0);
            RookB1.SetVer(7);
            RookB1.SetMovPast(false);
            PosTab[0,7] = RookB1;
        
            RookB2.SetCol(false);
            RookB2.SetSta(true);
            RookB2.SetHorN(7);
            RookB2.SetVer(7);
            RookB2.SetMovPast(false);
            PosTab[7,7] = RookB2;
        
        //Rook---------------------------------------------------------------------------------------------------------------

        //Bishop-------------------------------------------------------------------------------------------------------------

            BishopW1.SetCol(true);
            BishopW1.SetSta(true);
            BishopW1.SetHorN(2);
            BishopW1.SetVer(0);
            BishopW1.SetMovPast(false);
            PosTab[2,0] = BishopW1;
        
            BishopW2.SetCol(true);
            BishopW2.SetSta(true);
            BishopW2.SetHorN(5);
            BishopW2.SetVer(0);
            BishopW2.SetMovPast(false);
            PosTab[5,0] = BishopW2;
        
            BishopB1.SetCol(false);
            BishopB1.SetSta(true);
            BishopB1.SetHorN(2);
            BishopB1.SetVer(7);
            BishopB1.SetMovPast(false);
            PosTab[2,7] = BishopB1;
        
            BishopB2.SetCol(false);
            BishopB2.SetSta(true);
            BishopB2.SetHorN(5);
            BishopB2.SetVer(7);
            BishopB2.SetMovPast(false);
            PosTab[5,7] = BishopB2;
        
        //Bishop-------------------------------------------------------------------------------------------------------------

        //Knight-------------------------------------------------------------------------------------------------------------

            KnightW1.SetCol(true);
            KnightW1.SetSta(true);
            KnightW1.SetHorN(1);
            KnightW1.SetVer(0);
            KnightW1.SetMovPast(false);
            PosTab[1,0] = KnightW1;
       
           KnightW2.SetCol(true);
           KnightW2.SetSta(true);
           KnightW2.SetHorN(6);
           KnightW2.SetVer(0);
           KnightW2.SetMovPast(false);
           PosTab[6,0] = KnightW2;
       
           KnightB1.SetCol(false);
           KnightB1.SetSta(true);
           KnightB1.SetHorN(1);
           KnightB1.SetVer(7);
           KnightB1.SetMovPast(false);
           PosTab[1,7] = KnightB1;

           KnightB2.SetCol(false);
           KnightB2.SetSta(true);
           KnightB2.SetHorN(6);
           KnightB2.SetVer(7);
           KnightB2.SetMovPast(false);
           PosTab[6,7] = KnightB2;

       //Knight--------------------------------------------------------------------------------------------------------------

       //Queen---------------------------------------------------------------------------------------------------------------
        
           QueenW1.SetCol(true);
           QueenW1.SetSta(true);
           QueenW1.SetHorN(3);
           QueenW1.SetVer(0);
           QueenW1.SetMovPast(false);
           PosTab[3,0] = QueenW1;
       
           QueenB1.SetCol(false);
           QueenB1.SetSta(true);
           QueenB1.SetHorN(3);
           QueenB1.SetVer(7);
           QueenB1.SetMovPast(false);
           PosTab[3,7] = QueenB1;

       //Queen---------------------------------------------------------------------------------------------------------------

       //King----------------------------------------------------------------------------------------------------------------

           KingW.SetCol(true);
           KingW.SetSta(true);
           KingW.SetHorN(4);
           KingW.SetVer(0);
           KingW.SetMovPast(false);
           PosTab[4,0] = KingW;
        

           KingB.SetCol(false);
           KingB.SetSta(true);
           KingB.SetHorN(4);
           KingB.SetVer(7);
           KingB.SetMovPast(false);
           PosTab[4,7] = KingB;

        //King----------------------------------------------------------------------------------------------------------------

        //PawnWhite-----------------------------------------------------------------------------------------------------------
    
       
           PawnW1.SetCol(true);
           PawnW1.SetSta(true);
           PawnW1.SetHorN(0);
           PawnW1.SetVer(1);
           PawnW1.SetMovPast(false);
           PosTab[0,1] = PawnW1;
       
           PawnW2.SetCol(true);
           PawnW2.SetSta(true);
           PawnW2.SetHorN(1);
           PawnW2.SetVer(1);
           PawnW2.SetMovPast(false);
           PosTab[1,1] = PawnW2;
       
           PawnW3.SetCol(true);
           PawnW3.SetSta(true);
           PawnW3.SetHorN(2);
           PawnW3.SetVer(1);
           PawnW3.SetMovPast(false);
           PosTab[2,1] = PawnW3;
       
           PawnW4.SetCol(true);
           PawnW4.SetSta(true);
           PawnW4.SetHorN(3);
           PawnW4.SetVer(1);
           PawnW4.SetMovPast(false);
           PosTab[3,1] = PawnW4;
       
           PawnW5.SetCol(true);
           PawnW5.SetSta(true);
           PawnW5.SetHorN(4);
           PawnW5.SetVer(1);
           PawnW5.SetMovPast(false);
           PosTab[4,1] = PawnW5;
       
           PawnW6.SetCol(true);
           PawnW6.SetSta(true);
           PawnW6.SetHorN(5);
           PawnW6.SetVer(1);
           PawnW6.SetMovPast(false);
           PosTab[5,1] = PawnW6;
       
           PawnW7.SetCol(true);
           PawnW7.SetSta(true);
           PawnW7.SetHorN(6);
           PawnW7.SetVer(1);
           PawnW7.SetMovPast(false);
           PosTab[6,1] = PawnW7;
       
           PawnW8.SetCol(true);
           PawnW8.SetSta(true);
           PawnW8.SetHorN(7);
           PawnW8.SetVer(1);
           PawnW8.SetMovPast(false);
           PosTab[7,1] = PawnW8;

       //PawnWhite-----------------------------------------------------------------------------------------------------------

       //PawnBlack-----------------------------------------------------------------------------------------------------------
        

           PawnB1.SetCol(false);
           PawnB1.SetSta(true);
           PawnB1.SetHorN(0);
           PawnB1.SetVer(6);
           PawnB1.SetMovPast(false);
           PosTab[0,6] = PawnB1;

           PawnB2.SetCol(false);
           PawnB2.SetSta(true);
           PawnB2.SetHorN(1);
           PawnB2.SetVer(6);
           PawnB2.SetMovPast(false);
           PosTab[1,6] = PawnB2;
       
           PawnB3.SetCol(false);
           PawnB3.SetSta(true);
           PawnB3.SetHorN(2);
           PawnB3.SetVer(6);
           PawnB3.SetMovPast(false);
           PosTab[2,6] = PawnB3;

           PawnB4.SetCol(false);
           PawnB4.SetSta(true);
           PawnB4.SetHorN(3);
           PawnB4.SetVer(6);
           PawnB4.SetMovPast(false);
           PosTab[3,6] = PawnB4;
       
           PawnB5.SetCol(false);
           PawnB5.SetSta(true);
           PawnB5.SetHorN(4);
           PawnB5.SetVer(6);
           PawnB5.SetMovPast(false);
           PosTab[4,6] = PawnB5;
       
           PawnB6.SetCol(false);
           PawnB6.SetSta(true);
           PawnB6.SetHorN(5);
           PawnB6.SetVer(6);
           PawnB6.SetMovPast(false);
           PosTab[5,6] = PawnB6;
       
           PawnB7.SetCol(false);
           PawnB7.SetSta(true);
           PawnB7.SetHorN(6);
           PawnB7.SetVer(6);
           PawnB7.SetMovPast(false);
           PosTab[6,6] = PawnB7;
       
           PawnB8.SetCol(false);
           PawnB8.SetSta(true);
           PawnB8.SetHorN(7);
           PawnB8.SetVer(6);
           PawnB8.SetMovPast(false);
           PosTab[7,6] = PawnB8;
        }
       //PawnBlack-----------------------------------------------------------------------------------------------------------

       public void Movement(int GetHorMovN , int GetVerMov , int GetSelHorN , int GetSelVer , int[,] MovPos , bool GetColPly , Player PlyG)
        {

        PosTab[GetSelHorN , GetSelVer].MovementPossible(GetSelHorN , GetSelVer , PosTab , MovPos , GetColPly);
        PlyG.Play();
        GetHorMovN = PlyG.GetHorMovN();
        GetVerMov = PlyG.GetVerMov();

        if(MovPos[GetHorMovN , GetVerMov] == 1 || MovPos[GetHorMovN , GetVerMov] == 2)
        {

            PosTab[GetHorMovN , GetVerMov] = PosTab[GetSelHorN , GetSelVer];
            PosTab[GetSelHorN , GetSelVer] = null;
            PosTab[GetHorMovN , GetVerMov].SetMovPast(true);
            PosTab[GetHorMovN , GetVerMov].SetHorN(GetHorMovN);
            PosTab[GetHorMovN , GetVerMov].SetVer(GetVerMov);

        }

        if(MovPos[GetHorMovN , GetVerMov] == 3 && PosTab[GetSelHorN , GetSelVer].GetCol() == true)
        {

            PosTab[2 , 0] = PosTab[GetSelHorN , GetSelVer];
            PosTab[GetSelHorN , GetSelVer] = null;
            PosTab[2 , 0].SetMovPast(true);
            PosTab[2 , 0].SetHorN(2);
            PosTab[2 , 0].SetVer(0);

            PosTab[3 , 0] = PosTab[0 , 0];
            PosTab[0 , 0] = null;
            PosTab[3 , 0].SetMovPast(true);
            PosTab[3 , 0].SetHorN(3);
            PosTab[3 , 0].SetVer(0);

        }

        if(MovPos[GetHorMovN , GetVerMov] == 4 && PosTab[GetSelHorN , GetSelVer].GetCol() == true)
        {

            PosTab[6 , 0] = PosTab[GetSelHorN , GetSelVer];
            PosTab[GetSelHorN , GetSelVer] = null;
            PosTab[6 , 0].SetMovPast(true);
            PosTab[6 , 0].SetHorN(6);
            PosTab[6 , 0].SetVer(0);

            PosTab[5 , 0] = PosTab[7 , 0];
            PosTab[7 , 0] = null;
            PosTab[5 , 0].SetMovPast(true);
            PosTab[5 , 0].SetHorN(5);
            PosTab[5 , 0].SetVer(0);

        }

        if(MovPos[GetHorMovN , GetVerMov] == 3 && PosTab[GetSelHorN , GetSelVer].GetCol() == false)
        {

            PosTab[2 , 7] = PosTab[GetSelHorN , GetSelVer];
            PosTab[GetSelHorN , GetSelVer] = null;
            PosTab[2 , 7].SetMovPast(true);
            PosTab[2 , 7].SetHorN(2);
            PosTab[2 , 7].SetVer(7);

            PosTab[3 , 7] = PosTab[0 , 7];
            PosTab[0 , 7] = null;
            PosTab[3 , 7].SetMovPast(true);
            PosTab[3 , 7].SetHorN(3);
            PosTab[3 , 7].SetVer(7);

        }

        if(MovPos[GetHorMovN , GetVerMov] == 4 && PosTab[GetSelHorN , GetSelVer].GetCol() == false)
        {

            PosTab[6 , 7] = PosTab[GetSelHorN , GetSelVer];
            PosTab[GetSelHorN , GetSelVer] = null;
            PosTab[6 , 7].SetMovPast(true);
            PosTab[6 , 7].SetHorN(6);
            PosTab[6 , 7].SetVer(7);

            PosTab[5 , 7] = PosTab[7 , 7];
            PosTab[7 , 7] = null;
            PosTab[5 , 7].SetMovPast(true);
            PosTab[5 , 7].SetHorN(5);
            PosTab[5 , 7].SetVer(7);

        }

        MovPosNulo(MovPos);

        }
       
    }
}