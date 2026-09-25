using System;

namespace ComChess
{

public class Player
    {
        public bool ColPly {get; set;}
        public char SelHor {get; set;}
        public char HorMov {get; set;}
        public int SelVer {get; set;}
        public int VerMov {get; set;}
        public int SelHorN {get; set;}
        public int HorMovN {get; set;}
        public string Name {get; set;}

        public void Select()
        {
            System.Console.WriteLine("Digite a Horizontal da peça que voçe quer mexer");
            SelHor = char.Parse(Console.ReadLine().ToLower());

            System.Console.WriteLine("Digite a Vertical da peça que voçe quer mexer");
            SelVer = int.Parse(Console.ReadLine());

            SelHorN = SelHor - 'a';

            if(SelHorN < 0 || SelHorN > 7 || SelVer < 0 || SelVer > 7)
            {
                System.Console.WriteLine("Selecione uma posição valida");
                Select();
            }
        }

        public void Play()
        {
            System.Console.WriteLine("Digite a Horizontal da posição que voçe quer mexer");
            HorMov = char.Parse(Console.ReadLine().ToLower());

            System.Console.WriteLine("Digite a Vertical da posição que voçe quer mexer");
            VerMov = int.Parse(Console.ReadLine());

            HorMovN = HorMov - 'a';

            if(HorMovN < 0 || HorMovN > 7 || VerMov < 0 || VerMov > 7)
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

        public void SelectPiece(Pieces[,]PosTab)
        {
        int i = 0;
        do
        {
        Select();
        if(PosTab[SelHorN , SelVer] == null)
        {
            Console.WriteLine("Escolha uma posição não nula");
            i = 1; 
        }

        else if(PosTab[SelHorN , SelVer].Col != ColPly)
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