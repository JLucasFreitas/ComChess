using System;

namespace ComChess

{

public abstract class Pieces

{

    private char Hor;
    private int Ver;
    private bool Col; //True = White | False = Black
    private bool Sta; //True = Live | False = Dead

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
    public int GetVer()
    {
        return Ver;
    } 
    public void SetVer(int Vertical)
    {
        Ver = Vertical;
    }

    public abstract void Movimentar(char HorMov , int VerMov);

}

}