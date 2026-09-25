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
            if(PosTab[SelHorN , SelVer].MovPast == false)
            {
                int j = 0;
                int i = 1;
                for(int k = 0 ; k < 2 ; k++)
                {
                while(true)
                {
                    PosVerfHor = PosVerfHor + i;
                    if(InTab(PosVerfHor , PosVerfVer)){
                    if(PosTab[PosVerfHor , PosVerfVer] == null)
                    continue;
                    else
                    break;}

                    else
                    break;
                }
                if(InTab(PosVerfHor , PosVerfVer) && PosTab[PosVerfHor , PosVerfVer] is Rook)
                {
                    if(PosTab[PosVerfHor , PosVerfVer].MovPast == false)
                    {
                        if(PosVerfHor == 0){
                        PosVerfVer = SelVer;
                        PosVerfHor = SelHorN;
                        MovPos[PosVerfHor , PosVerfVer - 2] = 3;
                        }

                        else{
                        PosVerfVer = SelVer;
                        PosVerfHor = SelHorN;
                        MovPos[PosVerfHor , PosVerfVer + 2] = 4;
                        }
                    }
                }
                    if(PosVerfHor == 7)
                    {
                    i = -1;
                    j = 7;

                    PosVerfHor = SelHorN;
                    PosVerfVer = SelVer;
                    }
                }
            }
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