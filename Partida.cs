using System;

namespace ComChess
{
    public class Partida
    {
    Player PlyW = new Player();
    Player PlyB = new Player();
    int[,] MovPos = new int [8,8];
    int[,] MovPosNulo = new int[8,8];
    Tabuleiro TabMov = new Tabuleiro();
    Pieces PieceCheck = new Pieces();


    void PlayerWhite()
    {
        PlyW.SetColPly(true);
    }

    void PlayerBlack()
    {
        PlyB.SetColPly(false);
    }
    
    void PlayerWhiteMov(Pieces[,]PosTab , int GetSelHorN , int GetSelVer , int GetHorMovN , int GetVerMov , bool GetColPly , Player PlyG)
    {

        PlyG = PlyW;

        PlyG.SelectPiece(PosTab);

        TabMov.Movement(GetHorMovN ,  GetVerMov , GetSelHorN , GetSelVer , MovPos , GetColPly , PlyG);

    }

    void PlayerBlackMov(Pieces[,]PosTab , int GetSelHorN , int GetSelVer , int GetHorMovN , int GetVerMov , bool GetColPly , Player PlyG)
    {

        PlyG = PlyB;

        PlyG.SelectPiece(PosTab);

        TabMov.Movement(GetHorMovN ,  GetVerMov , GetSelHorN , GetSelVer , MovPos , GetColPly , PlyG);

    }

    void Fluxo()
    {

        while(XequeMate == false)
        {

            PlayerWhiteMov(PosTab , GetSelHorN , GetSelVer , GetHorMovN , GetVerMov , GetColPly , PlyG);

            PlayerBlackMov(PosTab , GetSelHorN , GetSelVer , GetHorMovN , GetVerMov , GetColPly , PlyG);

        }

    }

    bool VerfXeque(int GetSelHorN , int GetSelVer , Pieces[,]PosTab , int PosVerfHor , int PosVerfVer , bool GetColPly)
    {

        int VerfXequeHor = 0;
        int VerfXequeVer = 0;
        bool Exit;

        while(VerfXequeVer <= 7)
        {

            PosTab[VerfXequeHor , VerfXequeVer].MovementPossible(GetSelHorN , GetSelVer , PosTab , MovPos , GetColPly);
            if(Check(PosVerfHor , PosVerfVer , PosTab , MovPos , GetColPly) != 1){
                Exit = true;
                return Exit;}

            VerfXequeHor++;
            if(VerfXequeHor == 8)
            {
            VerfXequeVer++; 
            VerfXequeHor = 0;
            }

        }

        if(Exit != true){
        Exit = false;
        return Exit;}

    }


    static void Main()
    {   
        Partida PartMov = new Partida();
        Tabuleiro TabStart = new Tabuleiro();

        TabStart.TabStart();

    }
 
    }
}