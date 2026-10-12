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
        public string SelectPosition{get; set;}
        public string MovementPosition{get; set;}

        // Lê a posição da peça que o jogador deseja selecionar e converte a coordenada horizontal de letra para número
        public void Select()
        {
            Console.WriteLine("Digite a posição da peça , no formato letra/número l0 , que você quer mecher");
            SelectPosition = Console.ReadLine();

            if(SelectPosition == null){
                Console.WriteLine("Digite uma posição não nula");
                Select();
            }

            else if(SelectPosition.Length == 2)
            {
            int Horizontal = char.ToLower(SelectPosition[0]) - 'a';
            int Vertical = SelectPosition[1] - '1';

                // Verifica se a posição selecionada está dentro do tabuleiro
                if(Horizontal >= 0 && Horizontal <= 7 && Vertical >= 0 && Vertical <= 7){
                SelectionHorizontalN = Horizontal;
                SelectionVertical = Vertical;}

                else{
                    Console.WriteLine("Digite uma posição que esteja dentro do tabuleiro");
                    Select();
                }
            }
            else{
                Console.WriteLine("Digite a posição no formato LetraNumero Ex: e2");
                Select();
            }
        }

        // Lê a posição de destino escolhida pelo jogador e converte a coordenada horizontal de letra para número
        public void Play()
        {
            Console.WriteLine("Digite a posição do tabuleiro , no formato letra/número l0 , para onde você quer mecher");
            MovementPosition = Console.ReadLine();

            if(SelectPosition == null){
                Console.WriteLine("Digite uma posição não nula");
                Play();
            }

            else if(SelectPosition.Length == 2)
            {
            int Horizontal = char.ToLower(MovementPosition[0]) - 'a';
            int Vertical = MovementPosition[1] - '1';

                // Verifica se a posição selecionada está dentro do tabuleiro
                if(Horizontal >= 0 && Horizontal <= 7 && Vertical >= 0 && Vertical <= 7){
                HorizontalMovementN = Horizontal;
                VerticalMovement = Vertical;}

                else{
                    Console.WriteLine("Digite uma posição que esteja dentro do tabuleiro");
                    Play();
                }
            }
            else{
                Console.WriteLine("Digite a posição no formato LetraNumero Ex: e2");
                Play();
            }
        }

        // Permite ao jogador escolher para qual peça o peão será promovido
        public int PromotionSelect()
        {
            int SelectPiecePromotion = 0;

            System.Console.WriteLine("Escolha a peça para qual você quer transformar 1 - Torre | 2 - Bispo | 3 - Cavalo | 4 - Rainha");

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

        public void SelectName(int NumeroPlayer)
        {
            Console.WriteLine("Digite o nome do jogador");
            NamePlayer = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(NamePlayer)){
                NamePlayer = $"Jogador {NumeroPlayer}";
            }
        } 

    }

}