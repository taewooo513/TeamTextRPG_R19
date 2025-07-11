using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            SceneManager.GetInstance().ChangeScene("TestScene");
            TextIOManager.GetInstance().Init(150, 60);
            TimerManager.GetInstance().Init();

        }
        public void Update()
        {
            SceneManager.GetInstance().Update();
            TimerManager.GetInstance().Update();
        }
        public void Render()
        {
            SceneManager.GetInstance().Render();
            TextIOManager.GetInstance().DrawText();
        }
        public void Release()
        {
        }
    }
}
