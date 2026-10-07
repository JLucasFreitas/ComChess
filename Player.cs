using System;

namespace ComChess
{

public class Player
    {
        // Armazena as informações e posições escolhidas pelo jogador
        public bool ColorPlayer {get; set;}
        public char SelectionHorizontal {get; set;}
        public char HorizontalMovement {get; set;}
        public int SelectionVertical {get; set;}
        public int VerticalMovement {get; set;}
        public int SelectionHorizontalN {get; set;}
        public int HorizontalMovementN {get; set;}
        public string NamePlayer {get; set;}

        // Lê a posição da peça que o jogador deseja selecionar e converte a coordenada horizontal de letra para número
        public void Select()
        {
            System.Console.WriteLine("Digite a Horizontal da peça que você quer mexer");
            SelectionHorizontal = char.Parse(Console.ReadLine().ToLower());

            System.Console.WriteLine("Digite a Vertical da peça que voçe quer mexer");
            SelectionVertical = int.Parse(Console.ReadLine());

            SelectionHorizontalN = SelectionHorizontal - 'a';

            // Verifica se a posição selecionada está dentro do tabuleiro
            if(SelectionHorizontalN < 0 || SelectionHorizontalN > 7 || SelectionVertical < 0 || SelectionVertical > 7)
            {
                System.Console.WriteLine("Selecione uma posição válida");
                Select();
            }
        }

        // Lê a posição de destino escolhida pelo jogador e converte a coordenada horizontal de letra para número
        public void Play()
        {
            System.Console.WriteLine("Digite a Horizontal da posição que você quer mexer");
            HorizontalMovement = char.Parse(Console.ReadLine().ToLower());

            System.Console.WriteLine("Digite a Vertical da posição que voçe quer mexer");
            VerticalMovement = int.Parse(Console.ReadLine());

            HorizontalMovementN = HorizontalMovement - 'a';

            // Verifica se a posição de destino está dentro do tabuleiro
            if(HorizontalMovementN < 0 || HorizontalMovementN > 7 || VerticalMovement < 0 || VerticalMovement > 7)
            {
                System.Console.WriteLine("Selecione uma posição válida");
                Play();
            }
        }

        // Permite ao jogador escolher para qual peça o peão será promovido
        public int PromotionSelect()
        {
            int SelectPiecePromotion = 0;

            System.Console.WriteLine("Escolha a peça para qual voçê quer transformar 1 - Torre 2 - Bispo 3 - Cavalo 4 - Rainha");

            SelectPiecePromotion = int.Parse(Console.ReadLine());

            // Retorna a escolha caso ela esteja entre as opções disponíveis
            if(SelectPiecePromotion >= 1 && SelectPiecePromotion <= 4)
            {
                return SelectPiecePromotion;
            }

            // Caso a escolha seja inválida, solicita uma nova seleção
            return PromotionSelect();
        }

        // Garante que a posição escolhida contenha uma peça pertencente ao jogador atual
        public void SelectPiece(Pieces[,] PositionTab)
        {
        int i = 0;
        do
        {
        Select();

        // Impede a seleção de uma casa vazia
        if(PositionTab[SelectionHorizontalN , SelectionVertical] == null)
        {
            Console.WriteLine("Escolha uma posição não nula");
            i = 1; 
        }

        // Impede a seleção de uma peça adversária
        else if(PositionTab[SelectionHorizontalN , SelectionVertical].CollorPiece != ColorPlayer)
        {
            Console.WriteLine("Escolha uma peça da mesma cor");
            i = 1;
        }
        else
        i = 0;
        }while(i == 1);

        }

    }

}