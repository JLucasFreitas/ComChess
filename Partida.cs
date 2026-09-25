using System;

namespace ComChess
{
    public class Partida
    {
    Player PlyW = new Player();
    Player PlyB = new Player();
    int[,] MovPos = new int [8,8];
    int[,] MovPosNulo = new int[8,8];
    Tabuleiro TabMov = new Tabuleiro();

    void PlayerWhite()
    {
        PlyW.ColPly = true;
    }

    void PlayerBlack()
    {
        PlyB.ColPly = false;
    }
    
    void PlayerWhiteMov(Pieces[,]PosTab , int SelHorN , int SelVer , int HorMovN , int VerMov , bool ColPly , Player PlyG)
    {
        PlyG = PlyW;
        PlyG.SelectPiece(PosTab);
        TabMov.Movement(HorMovN ,  VerMov , SelHorN , SelVer , MovPos , ColPly , PlyG);
    }

    void PlayerBlackMov(Pieces[,]PosTab , int SelHorN , int SelVer , int HorMovN , int VerMov , bool ColPly , Player PlyG)
    {
        PlyG = PlyB;
        PlyG.SelectPiece(PosTab);
        TabMov.Movement(HorMovN ,  VerMov , SelHorN , SelVer , MovPos , ColPly , PlyG);
    }



    }
}