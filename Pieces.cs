using System;

namespace ComChess
{

public abstract class Pieces

{

    public char HorizontalPiece {get; set;}
    public int HorizontalPieceN {get; set;}
    public int VerticalPiece {get; set;}
    public bool CollorPiece {get; set;} //True = White | False = Black
    public bool MovementPast {get; set;} //True = Move | False = No move
    public abstract char Symbol {get ;}
    void Trans()
    {
    HorizontalPieceN = HorizontalPiece - 'a';
    }

    public abstract void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,]PositionTab , int[,] MovementPossible , bool ColorPlayer);

    protected int Check(int PositionVerifyfHorizontal , int PositionVerifyfVertical , Pieces[,] PositionTab , int[,] MovementPossible , bool ColorPlayer)
    {
    int Exit = 0;
    if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical] == null)
        MovementPossible[PositionVerifyfHorizontal , PositionVerifyfVertical] = 1;
    else
    {
        if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical].CollorPiece == ColorPlayer)
            Exit = 1;
        else
        {
            if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical] is King)
                Exit = 2;
            else
            {
                MovementPossible[PositionVerifyfHorizontal , PositionVerifyfVertical] = 1;
                Exit = 1;
            }
        }
    }
            return Exit;
    }

    protected void DirectionsContinuos(int HorizontalDirections , int VerticalDirections , int PositionVerifyfHorizontal , int PositionVerifyfVertical , Pieces[,] PositionTab , int[,] MovementPossible , bool ColorPlayer)
    {

        while(InTab(PositionVerifyfHorizontal + HorizontalDirections , PositionVerifyfVertical + VerticalDirections))
        {
        PositionVerifyfHorizontal = PositionVerifyfHorizontal + HorizontalDirections;
        PositionVerifyfVertical = PositionVerifyfVertical + VerticalDirections;

        if(Check(PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer) != 0)
            break;
        }
    }

    protected void Directions(int HorizontalDirections , int VerticalDirections , int PositionVerifyfHorizontal , int PositionVerifyfVertical , Pieces[,] PositionTab , int[,] MovementPossible , bool ColorPlayer)
    {
        PositionVerifyfHorizontal = PositionVerifyfHorizontal + HorizontalDirections;
        PositionVerifyfVertical = PositionVerifyfVertical + VerticalDirections;

        if(InTab(PositionVerifyfHorizontal , PositionVerifyfVertical))
            Check(PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
    }

    protected bool InTab(int HorizontalVerify , int VerticalVerify)
    {
        return HorizontalVerify >= 0 && HorizontalVerify <= 7 && VerticalVerify >= 0 && VerticalVerify <= 7;
    }

    public abstract Pieces ClonePiece();

}

}