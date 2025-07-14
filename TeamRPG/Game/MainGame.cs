using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.AnimationManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Scene;
using static System.Net.Mime.MediaTypeNames;

namespace TeamRPG.Game
{
    public class MainGame // 여기선 씬선언 제외 사용하지마세요
    {
        public void Init() // 씬선언 여기서 하세요
        {
            SceneManager.GetInstance().Init();
            SceneManager.GetInstance().AddScene("TestScene", new TestScene());
            SceneManager.GetInstance().AddScene("UITestScene", new UITestScene());
            SceneManager.GetInstance().ChangeScene("UITestScene");
            TextIOManager.GetInstance().Init(100, 29);
            TimerManager.GetInstance().Init();
            SoundManager.GetInstance().Init();
            SoundManager.GetInstance().AddSound("Test", "Test.mp3");
            SoundManager.GetInstance().PlaySound("Test",50);
        }
        public void Update()
        {
            SceneManager.GetInstance().Update();
            TimerManager.GetInstance().Update();
            AnimationManager.GetInstance().Update();
            SoundManager.GetInstance().Update();
        }
        public void Render()
        {
            SceneManager.GetInstance().Render();
            AnimationManager.GetInstance().Render();
            TextIOManager.GetInstance().DrawText();
            UIManager.GetInstance().DrawUI();



            //Console.WriteLine(TimerManager.GetInstance().GetMillisecond().ToString());
            //Console.WriteLine(TimerManager.GetInstance().GetFrame().ToString());
        }
        public void Release()
        {
        }
    }
}
