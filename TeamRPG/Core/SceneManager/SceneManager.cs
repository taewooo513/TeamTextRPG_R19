using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.QuestManager;
using TeamRPG.Core.UtilManager;
using static System.Formats.Asn1.AsnWriter;

namespace TeamRPG.Core.SceneManager
{
    public class SceneManager : Singleton<SceneManager>
    {
        Scene nowScene;
        Scene nextScene;
        Dictionary<String, Scene> d_Scenes;

        public void Init()
        {
            d_Scenes = new Dictionary<string, Scene>();
        }
        public void AddScene(String key, Scene scene)
        {
            if (d_Scenes.ContainsKey(key))
            {
                Debug.WriteLine("중복키");
            }
            else
            {
                d_Scenes.Add(key, scene);// 씬 받아서 딕셔너리에 추가
            }
        }

        public Scene? ChangeScene(String key)
        {
            Scene val;
            d_Scenes.TryGetValue(key, out val);
            if (val == null)
            {
                Console.WriteLine("{0} key값 잘못됨", key); 
            }
            else
            {
                nextScene = val; // 씬 변경하면 다음 씬에 저장 
            }
            return val;
        }

        public void Update()
        {
            if (nextScene != null)
            {
                //변경된씬이 있으면 실행
                if (nowScene != null)
                {
                    //현재 실행중인 씬이있으면 
                    // 현재씬을 제거해주고 이것저것 다제거
                    nowScene.Release();
                    Console.Clear();
                    UIManager.GetInstance().ClearUI();
                    EnemyManager.EnemyManager.GetInstance().ClearEnemy();
                }
                nowScene = nextScene;
                nextScene = null;
                nowScene.Init();
                // 현재씬을에 다음씬을 받고 다음씬을 비워준다
                // 현재씬 초기화
            }
            if (nowScene != null)
            {
                // 만약 현재씬이 있으면 업데이트
                nowScene.Update();
            }
        }

        public void Render()
        {
            if (nowScene != null)
            {
                // 만약 현재씬이 있으면 렌더

                nowScene.Render();
            }
        }

        public Scene GetScene(String key)
        {
            Scene val;
            d_Scenes.TryGetValue(key, out val);
            if (val == null)
            {
                Console.WriteLine("{0} key값 잘못됨", key);
            }
            return val;
        }
    }
}
