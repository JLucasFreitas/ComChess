using System;
using System.Reflection;
using System.Reflection.Metadata;

namespace ComChess
{

public class Player
    {
        private bool ColPly;
        private char SelHor;
        private int SelVer;
        private int SelHorN;

        void Jogada()
        {
            System.Console.WriteLine("Digite a Horizontal da peça que voçe quer mexer");
            SelHor = char.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a Vertical da peça que voçe quer mexer");
            SelVer = int.Parse(Console.ReadLine().ToLower());

            SelHorN = SelHor - 'a';
            if(SelHorN > 7 || SelHorN < 0 || SelVer > 7 || SelVer < 0)
            {
                System.Console.WriteLine("Posição invalida");
            }
        }
        public int GetSelVer()
        {
            return SelVer;
        }
        public int GetSelHorN()
        {
            return SelHorN;
        }
        public bool GetColPly()
        {
            return ColPly;
        } 
        public void SetColp(bool CollorPly)
        {
            ColPly = CollorPly;
        }
    }

}