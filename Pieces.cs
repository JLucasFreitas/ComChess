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

    protected int Check(int PosVerfHor , int PosVerfVer , Pieces[,] PosTab , int[,] MovPos , bool GetColPly)
    {
    int Exit = 0;
    if(PosTab[PosVerfHor , PosVerfVer] == null)
        MovPos[PosVerfHor , PosVerfVer] = 1;
    else
    {
        if(PosTab[PosVerfHor , PosVerfVer].GetCol() == GetColPly)
            Exit = 1;
        else
        {
            if(PosTab[PosVerfHor , PosVerfVer] is King)
                Exit = 2;
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

    
    public void Movement(int GetHorMovN , int GetVerMov , int GetSelHorN , int GetSelVer , Pieces[,]PosTab , int[,] MovPos , bool GetColPly , Player PlyG)
    {

        PosTab[GetSelHorN , GetSelVer].MovementPossible(GetSelHorN , GetSelVer , PosTab , MovPos , GetColPly);
        PlyG.Play();
        GetHorMovN = PlyG.GetHorMovN();
        GetVerMov = PlyG.GetVerMov();

        if(MovPos[GetHorMovN , GetVerMov] == 1 || MovPos[GetHorMovN , GetVerMov] == 2)
        {

            PosTab[GetHorMovN , GetVerMov] = PosTab[GetSelHorN , GetSelVer];
            PosTab[GetSelHorN , GetSelVer] = null;
            PosTab[GetHorMovN , GetVerMov].SetMovPast(true);
            PosTab[GetHorMovN , GetVerMov].SetHorN(GetHorMovN);
            PosTab[GetHorMovN , GetVerMov].SetVer(GetVerMov);

        }

        if(MovPos[GetHorMovN , GetVerMov] == 3 && PosTab[GetSelHorN , GetSelVer].GetCol() == true)
        {

            PosTab[2 , 0] = PosTab[GetSelHorN , GetSelVer];
            PosTab[GetSelHorN , GetSelVer] = null;
            PosTab[2 , 0].SetMovPast(true);
            PosTab[2 , 0].SetHorN(2);
            PosTab[2 , 0].SetVer(0);

            PosTab[3 , 0] = PosTab[0 , 0];
            PosTab[0 , 0] = null;
            PosTab[3 , 0].SetMovPast(true);
            PosTab[3 , 0].SetHorN(3);
            PosTab[3 , 0].SetVer(0);

        }

        if(MovPos[GetHorMovN , GetVerMov] == 4 && PosTab[GetSelHorN , GetSelVer].GetCol() == true)
        {

            PosTab[6 , 0] = PosTab[GetSelHorN , GetSelVer];
            PosTab[GetSelHorN , GetSelVer] = null;
            PosTab[6 , 0].SetMovPast(true);
            PosTab[6 , 0].SetHorN(6);
            PosTab[6 , 0].SetVer(0);

            PosTab[5 , 0] = PosTab[7 , 0];
            PosTab[7 , 0] = null;
            PosTab[5 , 0].SetMovPast(true);
            PosTab[5 , 0].SetHorN(5);
            PosTab[5 , 0].SetVer(0);

        }

        if(MovPos[GetHorMovN , GetVerMov] == 3 && PosTab[GetSelHorN , GetSelVer].GetCol() == false)
        {

            PosTab[2 , 7] = PosTab[GetSelHorN , GetSelVer];
            PosTab[GetSelHorN , GetSelVer] = null;
            PosTab[2 , 7].SetMovPast(true);
            PosTab[2 , 7].SetHorN(2);
            PosTab[2 , 7].SetVer(7);

            PosTab[3 , 7] = PosTab[0 , 7];
            PosTab[0 , 7] = null;
            PosTab[3 , 7].SetMovPast(true);
            PosTab[3 , 7].SetHorN(3);
            PosTab[3 , 7].SetVer(7);

        }

        if(MovPos[GetHorMovN , GetVerMov] == 4 && PosTab[GetSelHorN , GetSelVer].GetCol() == false)
        {

            PosTab[6 , 7] = PosTab[GetSelHorN , GetSelVer];
            PosTab[GetSelHorN , GetSelVer] = null;
            PosTab[6 , 7].SetMovPast(true);
            PosTab[6 , 7].SetHorN(6);
            PosTab[6 , 7].SetVer(7);

            PosTab[5 , 7] = PosTab[7 , 7];
            PosTab[7 , 7] = null;
            PosTab[5 , 7].SetMovPast(true);
            PosTab[5 , 7].SetHorN(5);
            PosTab[5 , 7].SetVer(7);

        }

    }

}

}