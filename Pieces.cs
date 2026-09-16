using System;

namespace ComChess

{

public abstract class Pieces

{

    private char Hor;
    private int HorN;
    private int Ver;
    private bool Col; //True = White | False = Black
    private bool Sta; //True = Live | False = Dead
    private bool MovPast; //True = Move | False = No move
    void Trans()
    {
    HorN = Hor - 'a';
    }

    public bool GetCol()
    {
    return Col;
    } 
    public void SetCol(bool Collor)
    {
    Col = Collor;
    }
    public bool GetSta()
    {
        return Sta;
    }
    public void SetSta(bool State)
    {
    Sta = State;
    }
    public char GetHor()
    {
        return Hor;
    }
    public void SetHor(char Horizontal)
    {
    Hor = Horizontal;
    }
    public int GetHorN()
    {
    return HorN;
    }
    public void SetHorN(int HorizontalNum)
    {
    HorN = HorizontalNum;
    }
    public int GetVer()
    {
    return Ver;
    } 
    public void SetVer(int Vertical)
    {
    Ver = Vertical;
    }
    public bool GetMovPast()
    {
    return MovPast;
    }
    public void SetMovPast(bool MovimentoAnterior)
    {
    MovPast = MovimentoAnterior;
    }

    public abstract void MovementPossible(int GetSelHorN , int GetSelVer , Pieces[,]PosTab , int[,] MovPos , bool GetColPly);

    protected int Check(int GetSelHorN , int GetSelVer , int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , int[,] MovKing , bool GetColPly)
    {
    int Exit = 0;
    if(PosTab[PosVerfHor , PosVerfVer] == null)
        if(PosTab[GetSelHorN , GetSelVer] is King){
            MovKing[PosVerfHor , PosVerfVer] = 5;}
        MovPos[PosVerfHor , PosVerfVer] = 1;
    else
    {
        if(PosTab[PosVerfHor , PosVerfVer].GetCol() == GetColPly)
            Exit = 1;
        else
        {
            if(PosTab[PosVerfHor , PosVerfVer] is King)
                {
                     if(PosTab[PosVerfHor , PosVerfVer].GetCol() == true)
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

    protected void InTab(int PosVerfHor , int PosVerfVer , Pieces[,]PosTab , int[,] MovPos , bool GetColPly)
    {
    if(PosVerfHor >= 0 && PosVerfHor <= 7 && PosVerfVer >= 0 && PosVerfVer <= 7)
        {
        Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly);
        }
    }

}

}