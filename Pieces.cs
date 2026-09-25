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
                Exit = 2;
            else
            {
                MovPos[PosVerfHor , PosVerfVer] = 1;
                Exit = 1;
            }
        }
    }
            return Exit;
    }

    protected void DirectionsContinuos(int HorizontalDirections , int VerticalDirections , int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool ColPly)
    {

        while(InTab(PosVerfHor + HorizontalDirections , PosVerfVer + VerticalDirections))
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

        if(InTab(PosVerfHor , PosVerfVer))
            Check(PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
    }

    protected bool InTab(int HorizontalVerify , int VerticalVerify)
    {
        return HorizontalVerify >= 0 && HorizontalVerify <= 7 && VerticalVerify >= 0 && VerticalVerify <= 7;
    }
}

}