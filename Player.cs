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
            }
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