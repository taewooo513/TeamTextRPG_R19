using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EnemyManager;
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
                d_Scenes.Add(key, scene);
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
                nextScene = val;
            }
            return val;
        }

        public void Update()
        {
            if (nextScene != null)
            {
                if (nowScene != null)
                {
                    nowScene.Release();
                    Console.Clear();
                    UIManager.GetInstance().ClearUI();
                    EnemyManager.EnemyManager.GetInstance().ClearEnemy();
                }
                nowScene = nextScene;
                nextScene = null;
                nowScene.Init();
            }
            if (nowScene != null)
            {
                nowScene.Update();
            }
        }

        public void Render()
        {
            if (nowScene != null)
            {
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
