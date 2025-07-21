using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;

namespace TeamRPG.Core
{
    public class FileIOManager : Singleton<FileIOManager> // 저장해야할것 스테이터스 경험치량 스테이지 정보 아이템 소지정보
    {
        public List<string>[]? LoadItemList()
        {
            string _path = @"../../../ItemList.txt";
            List<string>[] strings;
            try
            {
                List<String> content = File.ReadLines(_path).ToList();

                strings = new List<string>[content.Count];

                for (int i = 0; i < content.Count; i++)
                {
                    strings[i] = new List<String>();
                }
                int index = 0;
                content.ForEach(s =>
                {
                    s.Split(new char[] { ',' }).ToList().ForEach(e =>
                    {
                        strings[index].Add(e);
                    });
                    index++;
                });
                Console.Write("");
                return strings;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public void SaveGame(Player player)
        {
            List<String> strs = new List<string>();
            strs.Add(player.name.ToString());
            strs.Add(player.baseStatus.HP.ToString());
            strs.Add(player.baseStatus.MP.ToString());
            strs.Add(player.baseStatus.Tenacity.ToString());
            strs.Add(player.baseStatus.MinAttack.ToString());
            strs.Add(player.baseStatus.MaxAttack.ToString());
            strs.Add(player.baseStatus.Agility.ToString());
            strs.Add(player.baseStatus.Luck.ToString());
            strs.Add(player.baseStatus.stress.ToString());
            strs.Add(player.baseStatus.currentHp.ToString());
            strs.Add(player.baseStatus.currentMp.ToString());
            strs.Add(player.Gold.ToString());
            strs.Add(EnemyManager.EnemyManager.GetInstance().CycleCount.ToString());
            strs.Add(player.traitNum.ToString());
            strs.Add(PlayerManager.GetInstance().environment);
            strs.Add(((int)player.race).ToString());
            strs.Add(player.eArmor == null ? "": player.eArmor.Name);
            strs.Add(player.eWeapon== null ? "" : player.eWeapon.Name);
            FileInput(strs, "PlayerStatus");
            List<String> strs2 = new List<string>();

            player.Inventory.ItemDictionary.ToList().ForEach(
                e => { e.Value.ForEach(e2 => { strs2.Add(e2.Name); }); }
                );
            FileInput(strs2, "ItemList");

        }
        public String StrsMerge(List<String> strs) // 문자열 배열 합치기
        {
            String result = "";
            int a = 0;
            strs.ForEach(str =>
            {
                result += str;
                a++;
                if (a < strs.Count)
                {
                    result += ",";
                }
            });
            return result;
        }
        public void FileInput(List<String> strs, string name)
        {
            string _path = $"../../../{name}.txt";

            if (File.Exists(_path))
            {
                File.WriteAllText(_path, StrsMerge(strs));
            }
            else
            {
                StreamWriter textWrite = File.CreateText(_path);
                File.WriteAllText(_path, StrsMerge(strs));
                textWrite.Dispose();
            }
        }
        public List<String> GetLoadFile(string name)
        {
            List<String> result = new List<String>();
            string _path = $"../../../{name}.txt";

            try
            {
                String content = File.ReadAllText(_path);
                result = content.Split(new char[] { ',' }).ToList();
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public bool IsFileCheck(string str) // 이름별로 파일 분류되게끔 있는지 확인
        {
            string _path = $"../../../{str}.txt";
            if (File.Exists(_path))
            {
                return true;
            }
            else
            {
                StreamWriter textWrite = File.CreateText(_path);
                textWrite.Dispose();
                return false;
            }
        }
    }
}
