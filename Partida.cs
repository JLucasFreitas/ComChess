using System;

namespace ComChess
{
    public class Partida
    {
    Player PlayerWhite = new Player();
    Player PlayerBlack = new Player();
    int[,] MovementPossible = new int [8,8];
    int[,] MovementPossibleNulo = new int[8,8];
    Tabuleiro TabMov = new Tabuleiro();

    void PlayerWhiteMetodo()
    {
        PlayerWhite.ColorPlayer = true;
    }

    void PlayerBlackMetodo()
    {
        PlayerBlack.ColorPlayer = false;
    }
    
    void PlayerWhiteMov()
    {
        PlayerWhite.SelectPiece(TabMov.PositionTab);
        TabMov.Movement(0 ,  0 , PlayerWhite.SelectionHorizontalN , PlayerWhite.SelectionVertical , MovementPossible , PlayerWhite.ColorPlayer , PlayerWhite);
    }

    void PlayerBlackMov()
    {
        PlayerBlack.SelectPiece(TabMov.PositionTab);
        TabMov.Movement(0 ,  0 , PlayerBlack.SelectionHorizontalN , PlayerBlack.SelectionVertical , MovementPossible , PlayerBlack.ColorPlayer , PlayerBlack);
    }

    void Fluxo()
    {
        PlayerWhiteMetodo();
        PlayerBlackMetodo();

        TabMov.TabStart();
        TabMov.MostrarTabuleiro();

        while(true)
        {
            PlayerWhiteMov();
            TabMov.MostrarTabuleiro();

            PlayerBlackMov();
            TabMov.MostrarTabuleiro();
        }
    }

    static void Main(string[] args)
    {
        Partida Iniciar = new Partida();

        Iniciar.Fluxo();
    }

    }
}