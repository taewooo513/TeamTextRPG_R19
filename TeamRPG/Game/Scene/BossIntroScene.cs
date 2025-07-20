using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using TeamRPG.Game.Object.UI;
using TeamRPG.Core.UtilManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Game.Object.Enemy;


namespace TeamRPG.Game.Scene
{
    using Scene = Core.SceneManager.Scene;

    public class BossIntroScene : Scene
    {
        private Stopwatch stopwatch = new Stopwatch();
        private float dialogueLineDelay = 2.5f; // 대화 지연 시간
        private float dialogueCharDelay = 0.1f; // 대화 지연 시간

        private List<string> comments = new List<string>
        {
            "결국 여기까지 왔는가...",
            "감히 일주일짜리 과제를 이렇게까지 마개조하다니...",
            "더 괴상한걸 만들기전에 처단하겠다!"
        };

        public string image = """
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⡿⣾⢿⢿⣯⣿⣻⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣷⣿⡻⡸⡱⣿⣾⣿⣽⡧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢽⣾⢿⢣⢧⢱⡹⡞⡷⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢣⢣⢋⠎⠎⢪⠹⡸⡸⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠱⡡⡡⡡⡡⢂⠅⠌⠌⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢊⠆⡕⢌⠢⡡⡑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡮⣳⢜⣔⢕⣔⣧⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⡠⠰⡰⡕⣝⣿⣯⢮⣻⢮⣟⣮⣿⡽⡨⡢⢂⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⡃⢆⠪⡨⠪⡪⣺⣷⣿⣿⣺⣽⣷⣿⣷⢏⢎⢎⢢⢑⠔⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡐⢕⢸⢐⢱⠨⡊⡢⢣⣿⣿⣿⢿⡿⣿⢿⣻⢕⠕⡅⡕⡐⢅⠪⡨⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡐⢌⠕⢕⢕⢸⠨⡊⡌⡆⣿⣷⢿⣟⣿⣟⣿⢿⢸⢨⠢⣣⠱⡡⡱⢨⢂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠪⡢⢹⡘⡎⡢⡣⡣⢪⢘⣺⣿⣻⣿⣽⣯⣿⢿⢨⢢⢣⢣⢣⢃⢎⢪⢐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢄⢃⢎⢢⢊⢇⢕⢱⢸⢸⢨⢺⣯⣿⢷⣿⣽⣾⣿⢪⢪⢪⢪⢪⠪⡊⡌⡢⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⠨⠢⡑⡜⢌⡇⡕⡕⡅⡇⡕⣕⣿⣟⣿⣯⣿⣽⣿⡇⡇⣇⢯⢪⢨⠢⡊⢔⠔⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢇⢕⠩⡲⣱⢱⢕⢕⠜⡜⡌⡎⡮⣿⣯⣿⡾⣿⣽⣾⣿⢸⢜⣜⢎⢆⠣⣊⢢⢑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢐⠔⡢⠱⡨⢪⢳⢱⢸⢘⢌⢎⢪⢺⣟⣷⣿⣻⣿⣽⣿⣻⣧⢳⢕⡯⣪⠕⡢⡑⡢⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢔⡑⡌⡪⡐⢕⠠⡣⡣⡑⡅⢇⠧⣻⣟⣿⢾⣿⣻⡿⣿⣿⣿⣝⡵⣯⢣⢑⠔⢌⢢⢁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡣⠪⡰⡐⠜⡄⠐⡕⡱⠨⡊⡆⡇⣿⣻⣽⣿⣯⡿⣿⣿⣿⣿⣿⣞⡿⡨⡂⢕⢡⠪⡐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣨⣆⡆⢎⢌⠂⢠⢷⡸⡨⢢⠱⣘⣾⣿⣿⣿⣾⣿⣿⣿⣻⣿⣿⣿⢏⠆⣊⠢⡡⡱⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣷⣯⠯⠢⡑⡰⢹⣵⣽⡹⢷⢵⡸⡸⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⢔⢑⡐⡑⢌⢢⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣺⣿⡿⡏⢜⠨⡂⣊⢪⣿⣿⣿⣿⣾⣾⣵⣿⣿⣿⣿⣽⣿⡿⣯⣿⣾⣿⣇⠷⣑⠺⢼⡰⣽⣟⣿⢷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣺⣿⣿⢹⡰⡱⡨⡢⣒⣿⣯⣿⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⡢⢑⠌⡫⣺⣿⣿⣻⡿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⢿⣿⣺⡸⡱⡝⣜⢴⣿⣿⢾⣿⣽⡿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣻⣿⢸⢠⢑⢌⠢⣺⣿⣟⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠃⠋⠃⠋⠊⠋⠋⠙⠙⠉⠋⠙⠙⠉⠋⠋⠙⠉⠋⠋⠙⠙⠙⠀⠃⠁⠁⠑⠉⠋⠋⠋⠋⠙⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            """;

        private Menu actionMenu;
        private RawText commentText;
        private RawText imageText;

        private float nextDialogueTime = 0;
        private float currentDialogueTime = 0;
        private bool onClear = false;

        Queue<char> dialogueQueue = new Queue<char>();

        public void Init()
        {
            if (!stopwatch.IsRunning)
                stopwatch.Start();

            dialogueQueue = new();
            if (dialogueQueue.Count == 0)
            {
                if (comments.Count > 0)
                {
                    string comment = comments[0];
                    comments.RemoveAt(0);

                    foreach (char c in comment)
                        dialogueQueue.Enqueue(c);
                }
            }

            actionMenu = new Menu(UIManager.HalfWidth, Console.WindowHeight - 5);
            actionMenu.AddItem("전투개시", () =>
            {
                Enemy enemy = new Boss(UIManager.HalfHeight, 5, "");
                EnemyManager.GetInstance().AddInitialEnemy(enemy, eEnemyNum.eBoss);
                SceneManager.GetInstance().ChangeScene("GameScene");
            });
            actionMenu.HorizontalAlign = HorizontalAlign.Center;

            imageText = new RawText(image, UIManager.HalfWidth, 5, HorizontalAlign.Center, VerticalAlign.Top);
            commentText = new RawText("", 10, UIManager.HalfHeight - 5);
        }

        public void Release()
        {
            stopwatch.Stop();
            stopwatch.Reset();
            UIManager.GetInstance().ClearUI();
        }

        public void Render()
        {

        }

        public void Update()
        {
            InputMenu();
            DialogueComments();
        }

        void DialogueComments()
        {
            currentDialogueTime = stopwatch.ElapsedMilliseconds / 1000f;
            if (currentDialogueTime < nextDialogueTime) return;
            if (onClear)
            {
                commentText.SetText("");
                onClear = false;
            }

            if (dialogueQueue.Count == 0)
            {
                if (comments.Count == 0) return;

                string comment = comments[0];
                comments.RemoveAt(0);

                foreach (char c in comment)
                    dialogueQueue.Enqueue(c);

                nextDialogueTime = currentDialogueTime + dialogueLineDelay;
                onClear = true;
            }
            else
            {
                char nextChar = dialogueQueue.Dequeue();
                commentText.SetText(commentText.GetText() + nextChar);
                if(nextChar != ' ');
                    nextDialogueTime = currentDialogueTime + dialogueCharDelay;
            }
        }

        void InputMenu()
        {
            var inputManager = KeyInputManager.GetInstance();

            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.LeftArrow))
                actionMenu.MoveUp();
            else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.RightArrow))
                actionMenu.MoveDown();
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
                actionMenu.Select();
        }
    }
}
