using System;
namespace ComChess
{
    public class King : Pieces
    {
        // Responsável por identificar as casas dominadas pelas peças adversárias
        Analisador CasasDominadas = new Analisador();

        // Remove dos movimentos possíveis do Rei as casas que também estão marcadas como dominadas pelo adversário
        void EvitarXeque(int[,] MovementPossible , Pieces[,] PositionTab , bool ColorPlayer)
        {
            int[,] CasasDominadasTemporarias = CasasDominadas.CasasDominadas(PositionTab , ColorPlayer);

            int VerticalKingMovementPossible = 0;

            // Percorre todas as posições dos dois arrays
            for(int HorizontalKingMovementPossible = 0 ; VerticalKingMovementPossible <= 7 ; HorizontalKingMovementPossible++)
            {
                // Caso uma casa possível para o Rei também esteja dominada,remove essa casa dos movimentos possíveis
                if(CasasDominadasTemporarias[HorizontalKingMovementPossible , VerticalKingMovementPossible] == MovementPossible[HorizontalKingMovementPossible , VerticalKingMovementPossible])
                MovementPossible[HorizontalKingMovementPossible , VerticalKingMovementPossible] = 0;

                if(HorizontalKingMovementPossible == 7)
                {
                VerticalKingMovementPossible++;
                HorizontalKingMovementPossible = -1;
                }
            }
        }

        // Verifica a possibilidade de realizar o roque para os dois lados
        void KingRoque(int SelectionHorizontalN , int SelectionVertical , Pieces[,] PositionTab , int[,] MovementPossible)
        {
        int PositionVerifyfHorizontal = SelectionHorizontalN;
        int PositionVerifyfVertical = SelectionVertical;
        bool QuebrarRoque = true;

        // Percorre uma direção procurando uma Torre que ainda não tenha se movimentado. Caso encontre uma casa ocupada por outra peça, interrompe a verificação
        void VerifyRoque(ref int PositionVerifyfHorizontal , int PositionVerifyfVertical , int i , ref bool QuebrarRoque)
        {
            // Define qual tipo de roque foi encontrado de acordo com a direção
            if(InTab(PositionVerifyfHorizontal + i , PositionVerifyfVertical) && PositionTab[PositionVerifyfHorizontal + i , PositionVerifyfVertical] is Rook && PositionTab[PositionVerifyfHorizontal + i , PositionVerifyfVertical].MovementPast == false)
            if(i == 1){
                MovementPossible[6 , PositionVerifyfVertical] = 4;
                QuebrarRoque = false;}
            else{
                MovementPossible[2 , PositionVerifyfVertical] = 3;
                QuebrarRoque = false;}

            // Continua procurando enquanto as casas entre o Rei e a Torre estiverem vazias
            else if(InTab(PositionVerifyfHorizontal + i , PositionVerifyfVertical) && PositionTab[PositionVerifyfHorizontal + i , PositionVerifyfVertical] == null)
                PositionVerifyfHorizontal = PositionVerifyfHorizontal + i;
            else
                QuebrarRoque = false;
        }

        // O roque só é verificado caso o Rei ainda não tenha se movimentado
        if(PositionTab[PositionVerifyfHorizontal , PositionVerifyfVertical].MovementPast == false){
            // Verifica o lado direito
            while(QuebrarRoque)
            {
            VerifyRoque(ref PositionVerifyfHorizontal , PositionVerifyfVertical , 1 , ref QuebrarRoque);
            }
            // Reinicia as variáveis para verificar o lado esquerdo
            QuebrarRoque = true;
            PositionVerifyfHorizontal = SelectionHorizontalN;
            while(QuebrarRoque)
            {
            VerifyRoque(ref PositionVerifyfHorizontal , PositionVerifyfVertical , -1 , ref QuebrarRoque);
            }}
        }

        // Calcula os movimentos possíveis do Rei nas oito casas ao seu redor,remove posições dominadas e verifica a possibilidade de roque
        public override void MovementPossible(int SelectionHorizontalN , int SelectionVertical , Pieces[,]PositionTab , int[,] MovementPossible , bool ColorPlayer)        
        {
            int PositionVerifyfHorizontal = SelectionHorizontalN;
            int PositionVerifyfVertical = SelectionVertical;

             // Diagonais
            Directions(1 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(1 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(-1 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(-1 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);

            // Horizontais e verticais
            Directions(1 , 0 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(0 , -1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(-1 , 0 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);
            Directions(0 , 1 , PositionVerifyfHorizontal , PositionVerifyfVertical , PositionTab , MovementPossible , ColorPlayer);

            EvitarXeque(MovementPossible , PositionTab , ColorPlayer);

            KingRoque(SelectionHorizontalN , SelectionVertical , PositionTab , MovementPossible);
        }

        // Cria uma cópia independente do Rei mantendo seu estado atual
        public override Pieces ClonePiece()
        {
            Pieces PieceClonada = new King();
            PieceClonada.CollorPiece = this.CollorPiece;
            PieceClonada.HorizontalPieceN = this.HorizontalPieceN;
            PieceClonada.VerticalPiece = this.VerticalPiece;
            PieceClonada.MovementPast = this.MovementPast;

            return PieceClonada;
        }

        // Símbolo utilizado para representar o Rei no tabuleiro
        public override char Symbol => 'K';
    }
}