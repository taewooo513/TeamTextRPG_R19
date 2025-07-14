using TeamRPG.Game;

namespace TeamRPG
{
    internal class Program
    {
        static MainGame mg;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // 한글 출력 인코딩 설정
            mg = new MainGame();
            mg.Init();

            while (true)
            {
                mg.Update();
                mg.Render();
            }

            mg.Release();
        }
    }
}
