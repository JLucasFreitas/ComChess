using System;

namespace ComChess
{

public abstract class Pieces

{
    // Armazena a posição e o estado atual da peça
    public char HorizontalPiece {get; set;}
    public int HorizontalPieceN {get; set;}
    public int VerticalPiece {get; set;}
    public bool CollorPiece {get; set;} //True = White | False = Black
    public bool MovementPast {get; set;} // True = já se moveu | False = ainda não se moveu
    public abstract char Symbol {get ;}// Símbolo utilizado para representar a peça no tabuleiro

    // Converte a posição horizontal de letra para número
    void Trans()
    {
    HorizontalPieceN = HorizontalPiece - 'a';
    }


    // Define os movimentos possíveis da peça.Cada tipo de peça implementa sua própria lógica de movimentação
    public abstract void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,]PositionTab , int[,] MovementPossible , bool ColorPlayer);

    // Verifica uma posição e determina se ela pode ser ocupada pela peça.Também informa se um movimento contínuo deve continuar ou parar
    protected int Check(int PositionVerifyfHorizontal , int PositionVerifyfVertical , Pieces[,] PositionTab , int[,] MovementPossible , bool ColorPlayer)
    {
    int Exit = 0;

    // Casa vazia: movimento permitido
    if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical] == null)
        MovementPossible[PositionVerifyfHorizontal , PositionVerifyfVertical] = 1;
    else
    {
        // Peça da mesma cor: bloqueia o movimento
        if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical].CollorPiece == ColorPlayer)
            Exit = 1;
        else
        {
            // Identifica quando a peça adversária encontrada é o Rei
            if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical] is King)
                Exit = 2;
            
            // Peça adversária: permite a captura e encerra o movimento contínuo
            else
            {
                MovementPossible[PositionVerifyfHorizontal , PositionVerifyfVertical] = 1;
                Exit = 1;
            }
        }
    }
            return Exit;
    }

    // Percorre continuamente uma direção até encontrar o limite do tabuleiro ou alguma peça
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

    // Verifica uma única posição em determinada direção
    protected void Directions(int HorizontalDirections , int VerticalDirections , int PositionVerifyfHorizontal , int PositionVerifyfVertical , Pieces[,] PositionTab , int[,] MovementPossible , bool ColorPlayer)
    {
        PositionVerifyfHorizontal = PositionVerifyfHorizontal + HorizontalDirections;
        PositionVerifyfVertical = PositionVerifyfVertical + VerticalDirections;

        if(InTab(PositionVerifyfHorizontal , PositionVerifyfVertical))
            Check(PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
    }

    // Verifica se uma posição está dentro dos limites do tabuleiro
    protected bool InTab(int HorizontalVerify , int VerticalVerify)
    {
        return HorizontalVerify >= 0 && HorizontalVerify <= 7 && VerticalVerify >= 0 && VerticalVerify <= 7;
    }

    // Cria uma cópia independente da peça.Cada tipo de peça é responsável por clonar seus próprios atributos
    public abstract Pieces ClonePiece();

}

}