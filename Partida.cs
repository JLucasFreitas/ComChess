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
    
    //Executa o turno do jogador branco
    void PlayerWhiteMov()
    {
        bool JogadaInvalida;
        do{
        PlayerWhite.SelectPiece(TabMov.PositionTab);
        JogadaInvalida = TabMov.Movement(0 ,  0 , PlayerWhite.SelectionHorizontalN , PlayerWhite.SelectionVertical , MovementPossible , PlayerWhite.ColorPlayer , PlayerWhite);}
        while(JogadaInvalida);
    }

    //Executa o turno do jodador preto
    void PlayerBlackMov()
    {
        bool JogadaInvalida;
        do{
        PlayerBlack.SelectPiece(TabMov.PositionTab);
        JogadaInvalida = TabMov.Movement(0 ,  0 , PlayerBlack.SelectionHorizontalN , PlayerBlack.SelectionVertical , MovementPossible , PlayerBlack.ColorPlayer , PlayerBlack);}
        while(JogadaInvalida);
    }

    void SelecionarNome()
    {
        PlayerWhite.SelectName(1);
        PlayerBlack.SelectName(2);

        while(string.Equals(PlayerWhite.NamePlayer, PlayerBlack.NamePlayer, StringComparison.OrdinalIgnoreCase)){
            Console.WriteLine("Selecione um nome diferente");
            PlayerBlack.SelectName(2);
        }
    }

    //Posiciona as peças em suas posições iniciais e executa o fluxo da partida 
    void Fluxo()
    {
        PlayerWhiteMetodo();
        PlayerBlackMetodo();

        SelecionarNome();

        TabMov.TabStart();
        TabMov.MostrarTabuleiro();

        while(true)
        {
            Console.WriteLine($"Vez de {PlayerWhite.NamePlayer}");
            PlayerWhiteMov();
            TabMov.MostrarTabuleiro();

            Console.WriteLine($"Vez de {PlayerBlack.NamePlayer}");
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