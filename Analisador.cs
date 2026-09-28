using System;
namespace ComChess
{
    public class Analisador
    {
    protected bool InTab(int HorizontalVerify , int VerticalVerify)
    {
        return HorizontalVerify >= 0 && HorizontalVerify <= 7 && VerticalVerify >= 0 && VerticalVerify <= 7;
    }

    void CasasDominadasPawnVerify(int CasasDominadasHorizontal , int CasasDominadasVertical , Pieces[,] PositionTab , int[,] CasasDominadasTemporarias)
    {
        int DefineCollor = 0;
        if(PositionTab[CasasDominadasHorizontal , CasasDominadasVertical].CollorPiece == true)
        DefineCollor = 1;
        else{
        DefineCollor = -1;}
        if(InTab(CasasDominadasHorizontal + 1 , CasasDominadasVertical + DefineCollor))
            CasasDominadasTemporarias[CasasDominadasHorizontal + 1 , CasasDominadasVertical + DefineCollor] = 1;
        if(InTab(CasasDominadasHorizontal - 1 , CasasDominadasVertical + DefineCollor))
            CasasDominadasTemporarias[CasasDominadasHorizontal - 1 , CasasDominadasVertical + DefineCollor] = 1;
    }

    void CasasDominadasValores(int[,] CasasDominadasTemporarias , int[,] CasasDominadasArray)
    {
        int CasasDominadasVertical = 0;
        for(int CasasDominadasHorizontal = 0 ; CasasDominadasVertical <= 7 ; CasasDominadasHorizontal++)
        {
            if(CasasDominadasTemporarias[CasasDominadasHorizontal , CasasDominadasVertical] == 1)
            CasasDominadasArray[CasasDominadasHorizontal , CasasDominadasVertical] = 1;

            if(CasasDominadasHorizontal == 7)
            {
            CasasDominadasVertical++;
            CasasDominadasHorizontal = -1;
            }
        }
    }

    void CasasDominadasKingVerify(int CasasDominadasHorizontal , int CasasDominadasVertical , int[,] CasasDominadasTemporarias)
    {
        if(InTab(CasasDominadasHorizontal + 1 , CasasDominadasVertical + 1))
            CasasDominadasTemporarias[CasasDominadasHorizontal + 1 , CasasDominadasVertical + 1] = 1;
        if(InTab(CasasDominadasHorizontal - 1 , CasasDominadasVertical - 1))
            CasasDominadasTemporarias[CasasDominadasHorizontal - 1 , CasasDominadasVertical - 1] = 1;
        if(InTab(CasasDominadasHorizontal + 1 , CasasDominadasVertical ))
            CasasDominadasTemporarias[CasasDominadasHorizontal + 1 , CasasDominadasVertical] = 1;
        if(InTab(CasasDominadasHorizontal - 1 , CasasDominadasVertical))
            CasasDominadasTemporarias[CasasDominadasHorizontal - 1 , CasasDominadasVertical ] = 1;
        if(InTab(CasasDominadasHorizontal + 1 , CasasDominadasVertical - 1))
            CasasDominadasTemporarias[CasasDominadasHorizontal + 1 , CasasDominadasVertical - 1] = 1;
        if(InTab(CasasDominadasHorizontal - 1 , CasasDominadasVertical + 1))
            CasasDominadasTemporarias[CasasDominadasHorizontal - 1 , CasasDominadasVertical + 1] = 1;
        if(InTab(CasasDominadasHorizontal , CasasDominadasVertical + 1))
            CasasDominadasTemporarias[CasasDominadasHorizontal , CasasDominadasVertical + 1] = 1;
        if(InTab(CasasDominadasHorizontal , CasasDominadasVertical - 1))
            CasasDominadasTemporarias[CasasDominadasHorizontal , CasasDominadasVertical - 1] = 1;
    }

    public int[,] CasasDominadas( Pieces[,] PositionTab , bool ColorPlayer)
        {
        int[,] CasasDominadasArray = new int[8,8];
        int[,] CasasDominadasTemporarias = new int[8,8];
        int CasasDominadasVertical = 0;

        for(int CasasDominadasHorizontal = 0 ; CasasDominadasVertical <= 7 ; CasasDominadasHorizontal++)
        {
            if(PositionTab[CasasDominadasHorizontal , CasasDominadasVertical] != null && PositionTab[CasasDominadasHorizontal , CasasDominadasVertical].CollorPiece != ColorPlayer)
            {
                if(PositionTab[CasasDominadasHorizontal , CasasDominadasVertical] is Pawn)
                CasasDominadasPawnVerify(CasasDominadasHorizontal , CasasDominadasVertical , PositionTab , CasasDominadasTemporarias);

                else if(PositionTab[CasasDominadasHorizontal , CasasDominadasVertical] is King)
                {
                    CasasDominadasKingVerify(CasasDominadasHorizontal , CasasDominadasVertical , CasasDominadasTemporarias);
                }

                else{ 
                PositionTab[CasasDominadasHorizontal , CasasDominadasVertical].MovementPossible(CasasDominadasHorizontal , CasasDominadasVertical , PositionTab , CasasDominadasTemporarias , PositionTab[CasasDominadasHorizontal , CasasDominadasVertical].CollorPiece);}
            }

            if(CasasDominadasHorizontal == 7)
            {
            CasasDominadasVertical++;
            CasasDominadasHorizontal = -1;
            }
        }
        CasasDominadasValores(CasasDominadasTemporarias , CasasDominadasArray);
        return CasasDominadasArray;
        }
    }
}