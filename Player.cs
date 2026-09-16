using System;
using System.Reflection;
using System.Reflection.Metadata;

namespace ComChess
{

public class Player
    {
        private bool ColPly;
        private char SelHor;
        private char HorMov;
        private int SelVer;
        private int VerMov;
        private int SelHorN;
        private int HorMovN;
        private string Name;

        public void Select()
        {
            System.Console.WriteLine("Digite a Horizontal da peça que voçe quer mexer");
            SelHor = char.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Vertical da peça que voçe quer mexer");
            SelVer = int.Parse(Console.ReadLine().ToLower());

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
            HorMov = char.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Vertical da posição que voçe quer mexer");
            VerMov = int.Parse(Console.ReadLine().ToLower());

            HorMovN = HorMov - 'a';

            if(SelHorN < 0 || SelHorN > 7 || SelVer < 0 || SelVer > 7)
            {
                System.Console.WriteLine("Selecione uma posição valida");
                Play();
            }
        }

        public void SelectPiece(Pieces[,]PosTab)
        {
        int i = 0;
        do
        {
        Select();
        if(PosTab[GetSelHorN() , GetSelVer()] == null)
        {
            Console.WriteLine("Escolha uma posição não nula");
            i = 1; 
        }

        else if(PosTab[GetSelHorN() , GetSelVer()].GetCol() != GetColPly())
        {
            Console.WriteLine("Escolha uma peça da mesma cor");
            i = 1;
        }
        else
        i = 0;
        }while(i == 1);

        }


        public int GetSelVer()
        {
            return SelVer;
        }
        public int GetVerMov()
        {
            return VerMov;
        }
        public int GetSelHorN()
        {
            return SelHorN;
        }
        public int GetHorMovN()
        {
            return HorMovN;
        }
        public bool GetColPly()
        {
            return ColPly;
        } 
        public void SetColPly(bool CollorPly)
        {
            ColPly = CollorPly;
        }
    }

}