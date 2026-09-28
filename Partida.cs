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
    
    void PlayerWhiteMov(Pieces[,] PositionTab , int SelectionHorizontalN , int SelectionVertical , int HorizontalMovementN , int VerticalMovement , bool ColorPlayer , Player PlyG)
    {
        PlyG = PlayerWhite;
        PlyG.SelectPiece(PositionTab);
        TabMov.Movement(HorizontalMovementN ,  VerticalMovement , SelectionHorizontalN , SelectionVertical , MovementPossible , ColorPlayer , PlyG);
    }

    void PlayerBlackMov(Pieces[,] PositionTab , int SelectionHorizontalN , int SelectionVertical , int HorizontalMovementN , int VerticalMovement , bool ColorPlayer , Player PlyG)
    {
        PlyG = PlayerBlack;
        PlyG.SelectPiece(PositionTab);
        TabMov.Movement(HorizontalMovementN ,  VerticalMovement , SelectionHorizontalN , SelectionVertical , MovementPossible , ColorPlayer , PlyG);
    }



    }
}