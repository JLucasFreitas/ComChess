using System;

namespace ComChess
{
    // Classe para controlar o fluxo da partida 
    public class Partida
    {
    Player PlayerWhite = new Player();
    Player PlayerBlack = new Player();
    int[,] MovementPossible = new int [8,8];
    int[,] MovementPossibleNulo = new int[8,8];
    Tabuleiro TabMov = new Tabuleiro();

    //Define a cor do jogador branco
    void PlayerWhiteMetodo()
    {
        PlayerWhite.ColorPlayer = true;
    }

    //Define a cor do jogador preto
    void PlayerBlackMetodo()
    {
        PlayerBlack.ColorPlayer = false;
    }
    
    //Executa o turno do jodador branco
    void PlayerWhiteMov()
    {
        PlayerWhite.SelectPiece(TabMov.PositionTab);
        TabMov.Movement(0 ,  0 , PlayerWhite.SelectionHorizontalN , PlayerWhite.SelectionVertical , MovementPossible , PlayerWhite.ColorPlayer , PlayerWhite);
    }

    //Executa o turno do jodador preto
    void PlayerBlackMov()
    {
        PlayerBlack.SelectPiece(TabMov.PositionTab);
        TabMov.Movement(0 ,  0 , PlayerBlack.SelectionHorizontalN , PlayerBlack.SelectionVertical , MovementPossible , PlayerBlack.ColorPlayer , PlayerBlack);
    }

    //Posiciona a posição inicial das peças e executa o fluxo da partida 
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