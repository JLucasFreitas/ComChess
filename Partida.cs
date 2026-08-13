using System;

namespace ComChess
{
    public class Partida
    {
    Tabuleiro Campo = new Tabuleiro();
    Player PlyW = new Player();
    Player PlyB = new Player();
    bool[,] MovPos = new bool [8,8]; 

    int SelHor;
    int SelVer;
    int HorMov;
    int VerMov;

    
    void PlayerWhite()
    {
        PlyW.SerColPly(true);
        SelHor = PlyW.GetSelHorN();
        SelVer = PlyW.GetSelVer();
        HorMov = PlyW.GetHorMovN();
        VerMov =PlyW.GetVerMov();
    }

    void PlayerBlack()
    {
        PlyB.SerColPly(false);
        SelHor = PlyB.GetSelHorN();
        SelVer = PlyB.GetSelVer();
        HorMov = PlyB.GetHorMovN();
        VerMov = PlyB.GetVerMov();
    }
    
    void Mover(int GetSelHorN , int GetSelVer)
        {
            Pieces Peca = Campo.GetPosTab()[GetSelHorN , GetSelVer];

            if(Campo.GetPosTab()[GetSelHorN , GetSelVer] == null)
            {
                System.Console.WriteLine("Selecione uma posição valida");
                Select();
            }
            else if(Peca.GetCol() != true )
            {
                Console.WriteLine("Selecione uma peça de mesma cor");
                Select();
            }
            else 
            {
            Play();
            }
        }
    

    }
}