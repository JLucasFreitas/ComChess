using System;
namespace ComChess
{
    public class Analisador
    {
    // Verifica se uma posição está dentro dos limites do tabuleiro
    protected bool InTab(int HorizontalVerify , int VerticalVerify)
    {
        return HorizontalVerify >= 0 && HorizontalVerify <= 7 && VerticalVerify >= 0 && VerticalVerify <= 7;
    }

    // Marca as duas casas diagonais atacadas por um peão adversário
    void CasasDominadasPawnVerify(int CasasDominadasHorizontal , int CasasDominadasVertical , Pieces[,] PositionTab , int[,] CasasDominadasTemporarias)
    {
        int DefineCollor = 0;

        // Define o sentido de ataque do peão de acordo com sua cor
        if(PositionTab[CasasDominadasHorizontal , CasasDominadasVertical].CollorPiece == true)
        DefineCollor = 1;
        else{
        DefineCollor = -1;}

        // Verifica e marca a diagonal direita
        if(InTab(CasasDominadasHorizontal + 1 , CasasDominadasVertical + DefineCollor))
            CasasDominadasTemporarias[CasasDominadasHorizontal + 1 , CasasDominadasVertical + DefineCollor] = 1;

        // Verifica e marca a diagonal esquerda
        if(InTab(CasasDominadasHorizontal - 1 , CasasDominadasVertical + DefineCollor))
            CasasDominadasTemporarias[CasasDominadasHorizontal - 1 , CasasDominadasVertical + DefineCollor] = 1;
    }

    // Transfere as casas marcadas no array temporário para o array final de casas dominadas
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

    // Marca todas as casas adjacentes ao Rei adversário como casas dominadas
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

    // Percorre o tabuleiro procurando peças adversárias e gera um array com as casas dominadas por elas
    public int[,] CasasDominadas( Pieces[,] PositionTab , bool ColorPlayer)
        {
        int[,] CasasDominadasArray = new int[8,8];
        int[,] CasasDominadasTemporarias = new int[8,8];
        int CasasDominadasVertical = 0;

        for(int CasasDominadasHorizontal = 0 ; CasasDominadasVertical <= 7 ; CasasDominadasHorizontal++)
        {
            // Analisa apenas peças adversárias ao jogador atual
            if(PositionTab[CasasDominadasHorizontal , CasasDominadasVertical] != null && PositionTab[CasasDominadasHorizontal , CasasDominadasVertical].CollorPiece != ColorPlayer)
            {
                // Peões precisam de tratamento próprio,pois suas casas atacadas são diferentes do movimento para frente
                if(PositionTab[CasasDominadasHorizontal , CasasDominadasVertical] is Pawn)
                CasasDominadasPawnVerify(CasasDominadasHorizontal , CasasDominadasVertical , PositionTab , CasasDominadasTemporarias);

                // O Rei também é tratado separadamente para considerar apenas suas casas adjacentes
                else if(PositionTab[CasasDominadasHorizontal , CasasDominadasVertical] is King)
                {
                    CasasDominadasKingVerify(CasasDominadasHorizontal , CasasDominadasVertical , CasasDominadasTemporarias);
                }

                // Para as demais peças, utiliza sua própria lógica de movimentos
                else{ 
                PositionTab[CasasDominadasHorizontal , CasasDominadasVertical].MovementPossible(CasasDominadasHorizontal , CasasDominadasVertical , PositionTab , CasasDominadasTemporarias , PositionTab[CasasDominadasHorizontal , CasasDominadasVertical].CollorPiece);}
            }

            if(CasasDominadasHorizontal == 7)
            {
            CasasDominadasVertical++;
            CasasDominadasHorizontal = -1;
            }
        }

        // Gera e retorna o array final de casas dominadas
        CasasDominadasValores(CasasDominadasTemporarias , CasasDominadasArray);
        return CasasDominadasArray;
        }
    }
}