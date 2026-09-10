using System;

namespace ComChess
{
    public class Partida
    {
    Player PlyW = new Player();
    Player PlyB = new Player();
    int[,] MovPos = new int [8,8];
    int[,] MovPosNulo = new int[8,8];


    void PlayerWhite()
    {
        PlyW.SetColPly(true);
        SelHor = PlyW.GetSelHorN();
        SelVer = PlyW.GetSelVer();
        HorMov = PlyW.GetHorMovN();
        VerMov =PlyW.GetVerMov();
    }

    void PlayerBlack()
    {
        PlyB.SetColPly(false);
        SelHor = PlyB.GetSelHorN();
        SelVer = PlyB.GetSelVer();
        HorMov = PlyB.GetHorMovN();
        VerMov = PlyB.GetVerMov();
    }
    
    void PlayerWhiteMov(Pieces[,]PosTab , int GetSelHorN , int GetSelVer)
    {

        PlyW.Select();
        PlyW.GetSelHorN();
        PlyW.GetSelVer();
        if(PosTab[GetSelHorN , GetSelVer] == null)
        {
            Console.WriteLine("Escolha uma posição não nula");
            PlayerWhiteMov(PosTab , GetSelHorN , GetSelVer);
        }

        if(PosTab[GetSelHorN , GetSelVer].GetCol() != PlyW.GetColPly())
        {
            Console.WriteLine("Escolha uma peça da mesma cor");
            PlayerWhiteMov(PosTab , GetSelHorN , GetSelVer);
        }



    }


    static void Main()
    {

    }
 
    }
}