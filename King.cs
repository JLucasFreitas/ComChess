using System;
namespace ComChess
{
    public class King : Pieces
    {
        Analisador CasasDominadas = new Analisador();

        void EvitarXeque(int[,] MovementPossible , Pieces[,] PositionTab , bool ColorPlayer)
        {
            int[,] CasasDominadasTemporarias = CasasDominadas.CasasDominadas(PositionTab , ColorPlayer);

            int VerticalKingMovementPossible = 0;
        for(int HorizontalKingMovementPossible = 0 ; VerticalKingMovementPossible <= 7 ; HorizontalKingMovementPossible++)
        {
            if(CasasDominadasTemporarias[HorizontalKingMovementPossible , VerticalKingMovementPossible] == MovementPossible[HorizontalKingMovementPossible , VerticalKingMovementPossible])
            MovementPossible[HorizontalKingMovementPossible , VerticalKingMovementPossible] = 0;

            if(HorizontalKingMovementPossible == 7)
            {
            VerticalKingMovementPossible++;
            HorizontalKingMovementPossible = -1;
            }
        }
        }

        void KingRoque(int SelectionHorizontalN , int SelectionVertical , Pieces[,] PositionTab , int[,] MovementPossible)
        {
        int PositionVerifyfHorizontal = SelectionHorizontalN;
        int PositionVerifyfVertical = SelectionVertical;
        bool QuebrarRoque = true;

        void VerifyRoque(ref int PositionVerifyfHorizontal , int PositionVerifyfVertical , int i , ref bool QuebrarRoque)
        {
            if(InTab(PositionVerifyfHorizontal + i , PositionVerifyfVertical) && PositionTab[PositionVerifyfHorizontal + i , PositionVerifyfVertical] is Rook && PositionTab[PositionVerifyfHorizontal + i , PositionVerifyfVertical].MovementPast == false)
            if(i == 1){
                MovementPossible[6 , PositionVerifyfVertical] = 4;
                QuebrarRoque = false;}
            else{
                MovementPossible[2 , PositionVerifyfVertical] = 3;
                QuebrarRoque = false;}
            else if(InTab(PositionVerifyfHorizontal + i , PositionVerifyfVertical) && PositionTab[PositionVerifyfHorizontal + i , PositionVerifyfVertical] == null)
                PositionVerifyfHorizontal = PositionVerifyfHorizontal + i;
            else
                QuebrarRoque = false;
        }

        if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical].MovementPast == false){
            while(QuebrarRoque)
            {
            VerifyRoque(ref PositionVerifyfHorizontal , PositionVerifyfVertical , 1 , ref QuebrarRoque);
            }
            QuebrarRoque = true;
            PositionVerifyfHorizontal = SelectionHorizontalN;
            while(QuebrarRoque)
            {
            VerifyRoque(ref PositionVerifyfHorizontal , PositionVerifyfVertical , -1 , ref QuebrarRoque);
            }}
        }

        public override void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,]PositionTab , int[,] MovementPossible , bool ColorPlayer)        
        {
            int PositionVerifyfHorizontal = SelectionHorizontalN;
            int PositionVerifyfVertical = SelectionVertical;

            Directions(1 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(1 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(-1 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(-1 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(1 , 0 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(0 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(-1 , 0 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(0 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);

            EvitarXeque(MovementPossible , PositionTab , ColorPlayer);

            KingRoque(SelectionHorizontalN , SelectionVertical , PositionTab , MovementPossible);
        }
    }
}