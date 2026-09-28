using System;

namespace ComChess
{

public class Player
    {
        public bool ColorPlayer {get; set;}
        public char SelectionHorizontal {get; set;}
        public char HorizontalMovement {get; set;}
        public int SelectionVertical {get; set;}
        public int VerticalMovement {get; set;}
        public int SelectionHorizontalN {get; set;}
        public int HorizontalMovementN {get; set;}
        public string NamePlayer {get; set;}

        public void Select()
        {
            System.Console.WriteLine("Digite a Horizontal da peça que voçe quer mexer");
            SelectionHorizontal = char.Parse(Console.ReadLine().ToLower());

            System.Console.WriteLine("Digite a Vertical da peça que voçe quer mexer");
            SelectionVertical = int.Parse(Console.ReadLine());

            SelectionHorizontalN = SelectionHorizontal - 'a';

            if(SelectionHorizontalN < 0 || SelectionHorizontalN > 7 || SelectionVertical < 0 || SelectionVertical > 7)
            {
                System.Console.WriteLine("Selecione uma posição valida");
                Select();
            }
        }

        public void Play()
        {
            System.Console.WriteLine("Digite a Horizontal da posição que voçe quer mexer");
            HorizontalMovement = char.Parse(Console.ReadLine().ToLower());

            System.Console.WriteLine("Digite a Vertical da posição que voçe quer mexer");
            VerticalMovement = int.Parse(Console.ReadLine());

            HorizontalMovementN = HorizontalMovement - 'a';

            if(HorizontalMovementN < 0 || HorizontalMovementN > 7 || VerticalMovement < 0 || VerticalMovement > 7)
            {
                System.Console.WriteLine("Selecione uma posição valida");
                Play();
            }
        }

        public int PromotionSelect()
        {
            int SelectPiecePromotion = 0;

            System.Console.WriteLine("Escolha a peça para qual voçê quer transformar 1 - Torre 2 - Bispo 3 - Cavalo 4 - Rainha");

            SelectPiecePromotion = int.Parse(Console.ReadLine());

            if(SelectPiecePromotion >= 1 && SelectPiecePromotion <= 4)
            {
                return SelectPiecePromotion;
            }

            return PromotionSelect();
        }

        public void SelectPiece(Pieces[,] PositionTab)
        {
        int i = 0;
        do
        {
        Select();
        if(PositionTab[SelectionHorizontalN , SelectionVertical] == null)
        {
            Console.WriteLine("Escolha uma posição não nula");
            i = 1; 
        }

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