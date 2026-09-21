using System;

namespace ComChess
{

public abstract class Pieces

{

    public char Hor {get; set;}
    public int HorN {get; set;}
    public int Ver {get; set;}
    public bool Col {get; set;} //True = White | False = Black
    public bool MovPast {get; set;} //True = Move | False = No move
    void Trans()
    {
    HorN = Hor - 'a';
    }

    public abstract void MovementPossible(int SelHorN , int SelVer , Pieces[,]PosTab , int[,] MovPos , bool ColPly);

    protected int Check(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool ColPly)
    {
    int Exit = 0;
    if(PosTab[PosVerfHor , PosVerfVer] == null)
        MovPos[PosVerfHor , PosVerfVer] = 1;
    else
    {
        if(PosTab[PosVerfHor , PosVerfVer].Col == ColPly)
            Exit = 1;
        else
        {
            if(PosTab[PosVerfHor , PosVerfVer] is King)
                {
                     if(PosTab[PosVerfHor , PosVerfVer].Col == true)
                        Exit = 2;
                    else
                        Exit = 3;
                }
            else
            {
                MovPos[PosVerfHor , PosVerfVer] = 2;
                Exit = 1;
            }
        }
    }
            return Exit;
    }

    protected void InTab(int PosVerfHor , int PosVerfVer , Pieces[,]PosTab , int[,] MovPos , bool ColPly)
    {
    if(PosVerfHor >= 0 && PosVerfHor <= 7 && PosVerfVer >= 0 && PosVerfVer <= 7)
        {
        Check(PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
        }
    }

    protected void DirectionsContinuos(int HorizontalDirections , int VerticalDirections , int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool ColPly)
    {

        while(PosVerfHor + HorizontalDirections >= 0 && 
        PosVerfHor+ HorizontalDirections <= 7 && 
        PosVerfVer + VerticalDirections >= 0 && 
        PosVerfVer + VerticalDirections <= 7)
        {
        PosVerfHor = PosVerfHor + HorizontalDirections;
        PosVerfVer = PosVerfVer + VerticalDirections;

        if(Check(PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly) != 0)
            break;
        }
    }

    protected void Directions(int HorizontalDirections , int VerticalDirections , int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool ColPly)
    {
        PosVerfHor = PosVerfHor + HorizontalDirections;
        PosVerfVer = PosVerfVer + VerticalDirections;

        InTab(PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
    }
}

}