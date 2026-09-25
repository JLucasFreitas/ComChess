using System;
namespace ComChess
{
    public class King : Pieces
    {
        Analisador CasasDominadas = new Analisador();

        void EvitarXeque(int[,] MovPos , Pieces[,] PosTab , bool ColPly)
        {
            int[,] CasasDominadasTemporarias = CasasDominadas.CasasDominadas(PosTab , ColPly);

            int VerticalKingMovementPossible = 0;
        for(int HorizontalKingMovementPossible = 0 ; VerticalKingMovementPossible <= 7 ; HorizontalKingMovementPossible++)
        {
            if(CasasDominadasTemporarias[HorizontalKingMovementPossible , VerticalKingMovementPossible] == MovPos[HorizontalKingMovementPossible , VerticalKingMovementPossible])
            MovPos[HorizontalKingMovementPossible , VerticalKingMovementPossible] = 0;

            if(HorizontalKingMovementPossible == 7)
            {
            VerticalKingMovementPossible++;
            HorizontalKingMovementPossible = -1;
            }
        }
        }

        void KingRoque(int SelHorN , int SelVer , Pieces[,] PosTab , int[,] MovPos)
        {
        int PosVerfHor = SelHorN;
        int PosVerfVer = SelVer;
        bool QuebrarRoque = true;

        void VerifyRoque(ref int PosVerfHor , int PosVerfVer , int i , ref bool QuebrarRoque)
        {
            if(InTab(PosVerfHor + i , PosVerfVer) && PosTab[PosVerfHor + i , PosVerfVer] is Rook && PosTab[PosVerfHor + i , PosVerfVer].MovPast == false)
            if(i == 1){
                MovPos[6 , PosVerfVer] = 4;
                QuebrarRoque = false;}
            else{
                MovPos[2 , PosVerfVer] = 3;
                QuebrarRoque = false;}
            else if(InTab(PosVerfHor + i , PosVerfVer) && PosTab[PosVerfHor + i , PosVerfVer] == null)
                PosVerfHor = PosVerfHor + i;
            else
                QuebrarRoque = false;
        }

        if(PosTab[PosVerfHor , PosVerfVer].MovPast == false){
            while(QuebrarRoque)
            {
            VerifyRoque(ref PosVerfHor , PosVerfVer , 1 , ref QuebrarRoque);
            }
            QuebrarRoque = true;
            PosVerfHor = SelHorN;
            while(QuebrarRoque)
            {
            VerifyRoque(ref PosVerfHor , PosVerfVer , -1 , ref QuebrarRoque);
            }}
        }

        public override void MovementPossible(int SelHorN , int SelVer , Pieces[,]PosTab , int[,] MovPos , bool ColPly)        
        {
            int PosVerfHor = SelHorN;
            int PosVerfVer = SelVer;

            Directions(1 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(1 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(-1 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(-1 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(1 , 0 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(0 , -1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(-1 , 0 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);
            Directions(0 , 1 , PosVerfHor , PosVerfVer , PosTab , MovPos , ColPly);

            EvitarXeque(MovPos , PosTab , ColPly);

            KingRoque(SelHorN , SelVer , PosTab , MovPos);
        }
    }
}