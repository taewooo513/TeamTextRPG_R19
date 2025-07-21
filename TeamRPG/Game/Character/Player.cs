using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Enemy;
using TeamRPG.Game.Object.Item;
using TeamRPG.Game.Object.UI;

namespace TeamRPG.Game.Character
{
    public class Player
    {
        public Armor? eArmor;
        public Weapon? eWeapon;

        public bool isPlayerTurn = false;
        private bool isAttack;
        private int attackIndex;
        private bool isSkill;
        private List<Skill> skills;
        public Stopwatch timer;
        public int selectE = 0;
        private bool isDefens = false;
        public bool isCheat = false;
        public string name { get; private set; }
        public Trait trait;
        bool isDie = false;
        public Box itemBoxUI;
        public Race race { get; private set; }
        public int level { get; private set; } = 1;
        public int traitNum = 0;
        public int currentExp { get; private set; } = 0;
        public int expToNextLevel => ExpTable.GetExpToNextLevel(level);

        public Status baseStatus { get; private set; }
        public Status currentStatus { get; private set; }

        public List<Status> equipments = new List<Status>();
        // public List<Item> Inventory { get; set; } = new List<Item>();
        public Inventory Inventory = new();
        Stopwatch playerDieStopWatch;
        int dieY = 0;
        bool isItemBag = false;
        public int Gold { get; set; } = 100000;
        private int selectNum = 0;
        public Player()
        {
            isItemBag = false;
            itemBoxUI = new Box(8, 6, 16, 10);
            itemBoxUI.IsVisible = false;
            isDie = false;
            dieY = 0;
            timer = new Stopwatch();

            Inventory = new Inventory();
            playerDieStopWatch = new Stopwatch();
            eArmor = null;
            eWeapon = null;
        }
        public Player(string _name, Race _race)
        {
            isItemBag = false;
            itemBoxUI = new Box(8, 6, 16, 10);
            itemBoxUI.IsVisible = false;
            isDie = false;
            dieY = 0;
            timer = new Stopwatch();
            name = _name;
            race = _race;
            baseStatus = StatusFactory.GetStatusByRace(race);
            skills = StatusFactory.GetSkillsByRace(race);
            currentStatus = baseStatus;
            Inventory = new Inventory();
            playerDieStopWatch = new Stopwatch();
            eArmor = null;
            eWeapon = null;
        }

        public void GainExp(int _exp, ref string str)
        {
            if (level >= ExpTable.maxLevel)
            {
                //Console.WriteLine("최대 레벨입니다");
                str += "";
                return;
            }
            int lastLv = level;
            currentExp += _exp;

            while (currentExp >= expToNextLevel && level < ExpTable.maxLevel)
            {
                currentExp -= expToNextLevel;
                LevelUp(ref str);
            }
            if (lastLv != level)
            {
                str += $"현재 레벨: {level}";
            }
        }

        public void LevelUp(ref string str)
        {
            if (level >= ExpTable.maxLevel)
            {
                str += "";
                //Console.WriteLine("최대 레벨입니다");
                return;
            }

            level++;
            str += $" 레벨업 ";

            baseStatus.HP += 2;
            baseStatus.currentHp += 2;
            //baseStatus.MinAttack += 2;
            //baseStatus.MaxAttack += 2;

            RecalculateCurrentStatus();
        }
        public void GetReword(int amount, int _exp)
        {
            AddGold(amount);
            string str = "";
            GainExp(_exp, ref str);

            PlayerManager.GetInstance().GetPlayer().currentStatus.stress += 20;
            PlayerManager.GetInstance().gameMsg = $"{amount}원, {_exp}exp를 획득하였다." + str + $"\n   스트레스 수치가 {PlayerManager.GetInstance().GetPlayer().currentStatus.stress} 입니다.";

            RecalculateCurrentStatus();
        }
        public void AddGold(int amount)
        {
            Gold += amount;
            if (Gold < 0)
            {
                Gold = 0; // 금액이 음수가 되지 않도록 조정
            }
        }

        public void PlusAttack(int amount)
        {
            baseStatus.MinAttack += amount;
            baseStatus.MaxAttack += amount;
            RecalculateCurrentStatus();
        }


        public void HitPlayer(int _dmg)
        {
            if (isCheat == true)
            {

            }
            else
            {
                baseStatus.currentHp -= _dmg;
            }
        }

        public void HealPlayer(int amount)
        {
            baseStatus.currentHp += amount;
            if (baseStatus.currentHp > currentStatus.HP)
            {
                baseStatus.currentHp = currentStatus.HP; // 최대 HP를 초과하지 않도록 조정
            }
        }

        public void EquipItem(Status equip)
        {
            equipments.Add(equip);
            RecalculateCurrentStatus();
        }

        public void UnequipItem(Status equip)
        {
            equipments.Remove(equip);
            RecalculateCurrentStatus();
        }

        public void RecalculateCurrentStatus()
        {
            int previousStress = currentStatus?.stress ?? 0; // null-safe 체크

            Status totalEquip = new Status(0, 0, 0, 0, 0, 0, 0, 0, 0);
            foreach (var equip in equipments)
            {
                totalEquip = totalEquip.Add(equip);
            }

            currentStatus = baseStatus.Add(totalEquip);
            currentStatus.stress = previousStress; // 스트레스 복원
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {name}");
            Console.WriteLine($"종족: {race}");
            Console.WriteLine($"레벨: {level}");
            Console.WriteLine($"기본 스탯: {baseStatus}");
            Console.WriteLine($"장비 개수: {equipments.Count}");
            Console.WriteLine($"현재 스탯: {currentStatus}");
            Console.WriteLine("");
        }
        public void Update()
        {

            if (isDie == false && isItemBag == false)
            {
                if (isAttack == false && isSkill == false)
                    SelectPlayButton();
                else if (isAttack == true)
                    SelectAttackButton();
                else if (isAttack == false && isSkill == true)
                    SelectSkillButton();
                if (baseStatus.currentHp <= 0)
                {
                    baseStatus.currentHp = 0;
                    playerDieStopWatch.Start();
                    PlayerManager.GetInstance().gameMsg = "플레이어가 패배했다. 눈앞이 흐려진다.";
                }
            }
            else if (isItemBag == true)
            {
                ItemBagUpdate();
            }

            if (playerDieStopWatch.ElapsedMilliseconds > 300)
            {
                dieY += 1;
                playerDieStopWatch.Restart();
            }
            if (dieY == 14)
            {
                SceneManager.GetInstance().ChangeScene("DiedScene");
            }
        }
        public void PlayerImageRender()
        {
            switch (race)
            {
                case Race.HalfElf:
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⠛⠁⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 11 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⢤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⡿⠁⠀⠀⠀⠀⠀⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 10 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠈⢿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 9 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠙⠈⠛⠷⣤⣀⠀⠀⠀⠀⠀⠀⠀⣼⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 8 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠳⣦⣀⠀⠀⠀⣼⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 7 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠻⢦⣴⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 6 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠌⠙⢿⡿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 5 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢌⠐⠈⠀⠀⠙⠃⠉⠻⢶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 4 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⡌⠠⢁⠂⠀⠀⠀⠀⠂⠀⠉⠻⠶⣤⡀⠀⠀⠀⠀⠀⣀⠄⣰⢢⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 3 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠊⠐⠀⠂⠀⡀⠂⠄⠂⠀⠀⠀⠀⠀⠉⠙⠷⣤⡀⣀⠀⠈⠻⣷⡡⢂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 2 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⢂⠈⠀⠀⠄⠂⣜⣩⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠑⢦⣉⠒⡀⠀⠁⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 1 + dieY);
                    break;
                case Race.Human:
                    TextIOManager.GetInstance().OutputSmartText("⡤⠤⠠⠤⠠⢄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 11 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠈⠲⡕⣗⣷⢶⣄⡍⡒⠔⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 10 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠈⠪⢺⢸⡪⡻⡻⢶⢦⣬⡑⠢⢄⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 9 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠈⠘⠙⠜⠕⡕⡯⡻⡶⣦⣉⡒⠔⢄⡀⡀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 8 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠁⠃⠣⠓⢯⢻⡲⡬⣌⠢⠢⣀⡀⠀⠀⣰⡫⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 7 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠊⠪⠫⠺⡤⡌⣓⢼⣱⢀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 6 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢉⡪⡳⠱⢡⠱⡑⢕⠔⢔⠈⠄⢄⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 5 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣄⡲⣹⠁⠀⠀⠑⡕⡅⡣⡑⠡⠌⠂⡅⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 4 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠉⢪⠂⠀⠀⠀⡸⡐⢕⠸⡈⡅⡂⢌⠆⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 3 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢎⢌⢪⢨⠀⠪⡢⠣⡑⢄⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 2 + dieY);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡸⡐⡱⢨⠢⠁⠈⢎⢪⢘⠔⡄⠀", 70, TextIOManager.GetInstance().winHeight - 1 + dieY);
                    break;
            }

        }
        public void PlayerTurnSetting()
        {
            PlayerManager.GetInstance().gameMsg = "플레이어의 턴";
            isPlayerTurn = true;
            selectE = 0; //이젠 무슨코드를 짜는지도모르겠다
        }
        public void UIRender()
        {
            PlayerImageRender();

            if (isItemBag == true)
            {
                ItemBagUI();
            }
            if (EnemyManager.GetInstance().GetEnemyList().Count != 0)
            {
                if (EnemyManager.GetInstance().GetEnemyList()[selectE].isExSkill == false)
                {
                    StateBox();
                    TextIOManager.GetInstance().OutputText(name, 7, 33);

                    if (isSkill == false)
                    {
                        PlaySelectUI();
                    }
                    else
                    {
                        SkillSelectUI();
                    }
                    HpBarRender();
                    MpBarRender();
                    if (isAttack == true)
                    {
                        EnemyManager.GetInstance().GetEnemyList()[attackIndex].SelectEnemy();
                    }
                }
            }
            else
            {
                StateBox();
                TextIOManager.GetInstance().OutputText(name, 7, 33);

                if (isSkill == false)
                {
                    PlaySelectUI();
                }
                else
                {
                    SkillSelectUI();
                }
                HpBarRender();
                MpBarRender();
                if (isAttack == true)
                {
                    if (EnemyManager.GetInstance().GetEnemyList().Count != 0)
                    {
                        EnemyManager.GetInstance().GetEnemyList()[attackIndex].SelectEnemy();
                    }
                }
            }
        }

        private void ItemBagUpdate()
        {
            List<List<Item>> items = new List<List<Item>>();
            var itemList = Inventory.ItemDictionary.ToList();
            List<List<Item>> conitems = new List<List<Item>>(); // 소비템만 따로때서 새로운리스트로 괴장히 비효율적으로보이긴하는데 쩔수
            itemList.ForEach(tem =>
            {
                if (tem.Value[0].Type == ItemType.Consumable)
                {
                    conitems.Add(tem.Value);
                }
            });

            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.DownArrow) && selectNum < conitems.Count)
            {
                selectNum++;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow) && selectNum > 0)
            {
                selectNum--;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Escape))
            {
                selectNum = 2;
                isItemBag = false;
                itemBoxUI.IsVisible = false;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                if (itemList.Count == 0)
                {
                    return;
                }
                itemList.ForEach(item =>
                {
                    items.Add(item.Value);
                });
                var selectedItem = items[selectNum][0];
                switch (selectedItem.Type)
                {
                    case Object.Item.ItemType.Consumable:
                        if (selectedItem.Name == "회복 포션")
                        {
                            Inventory.RemoveItem(selectedItem.Name, 1);
                            baseStatus.currentHp += 30;
                            PlayerManager.GetInstance().gameMsg = "회복 포션을 사용하여 체력을 30회복하였습니다.";
                        }
                        else if (selectedItem.Name == "마나 포션")
                        {
                            Inventory.RemoveItem(selectedItem.Name, 1);
                            baseStatus.currentMp += 20;
                            PlayerManager.GetInstance().gameMsg = "마나 포션을 사용하여 마나를 20회복하였습니다.";

                        }
                        else if (selectedItem.Name == "엘릭서")
                        {
                            Inventory.RemoveItem(selectedItem.Name, 1);
                            baseStatus.currentHp += 30; // 나중에 부활
                            baseStatus.currentMp += 10;
                            PlayerManager.GetInstance().gameMsg = "엘릭서를 사용하였습니다.";
                        }
                        break;
                }
                selectNum = 1;
                isItemBag = false;
                itemBoxUI.IsVisible = false;
            }
        }
        private void ItemBagUI()
        {
            int y = 0;
            foreach (var item in Inventory.ItemDictionary.ToList())
            {
                if (item.Value[0].Type == ItemType.Consumable)
                {
                    TextIOManager.GetInstance().OutputSmartText(item.Key + " x" + item.Value.Count, 11, y + 7);
                    if (selectNum == y)
                    {
                        TextIOManager.GetInstance().OutputText4Byte("▶", 9, y + 7);
                    }
                    y++;
                }
            }

        }
        private void SelectSkillButton()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.DownArrow) && selectNum < 3)
            {
                selectNum++;
            }
            else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow) && selectNum > 0)
            {
                selectNum--;
            }
            else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                if (selectNum == 3)
                {
                    isSkill = false;
                    selectNum = 0;
                }
                else if (skills[selectNum].mpCost <= baseStatus.currentMp)
                {
                    isAttack = true;
                }
                else
                {
                    PlayerManager.GetInstance().gameMsg = "마나가 부족합니다.";
                }
            }
        }
        private void SelectPlayButton()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.DownArrow) && selectNum < 3)
            {
                selectNum++;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow) && selectNum > 0)
            {
                selectNum--;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                switch (selectNum)
                {
                    case 0:
                        isAttack = true;
                        break;
                    case 1:
                        itemBoxUI.IsVisible = true;
                        isItemBag = true;
                        break;
                    case 2:
                        isSkill = true;
                        break;
                }
                selectNum = 0;
            }
        }
        private void SelectAttackButton()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.RightArrow) && attackIndex < EnemyManager.GetInstance().GetEnemyList().Count - 1)
            {
                attackIndex++;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.LeftArrow) && attackIndex > 0)
            {
                attackIndex--;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Escape))
            {
                isAttack = false;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                if (isSkill == true)
                {
                    Random rd = new Random();
                    EnemyManager.GetInstance().GetEnemyList()[attackIndex].HitEnemy(skills[selectNum].power);
                    baseStatus.currentMp -= skills[selectNum].mpCost;
                    switch (selectNum)
                    {
                        case 0:
                            switch (race)
                            {
                                case Race.Human:
                                    SoundManager.GetInstance().PlaySound("strike", 0.5f);
                                    break;
                                case Race.Dwarf:
                                    SoundManager.GetInstance().PlaySound("발구르기", 0.5f);
                                    break;
                                case Race.HalfElf:
                                    SoundManager.GetInstance().PlaySound("heal", 0.5f);
                                    break;
                            }

                            break;
                        case 1:
                            switch (race)
                            {
                                case Race.Human:
                                    SoundManager.GetInstance().PlaySound("blow", 0.5f);
                                    break;
                                case Race.Dwarf:
                                    SoundManager.GetInstance().PlaySound("지진", 0.5f);
                                    break;
                                case Race.HalfElf:
                                    SoundManager.GetInstance().PlaySound("wind", 0.5f);
                                    break;
                            }
                            break;
                        case 2:
                            switch (race)
                            {
                                case Race.Human:
                                    SoundManager.GetInstance().PlaySound("attack", 0.5f);
                                    break;
                                case Race.Dwarf:
                                    SoundManager.GetInstance().PlaySound("화산강림", 0.5f);
                                    break;
                                case Race.HalfElf:
                                    SoundManager.GetInstance().PlaySound("rain", 0.5f);
                                    break;
                            }
                            break;
                    }
                    if (baseStatus.currentMp < 0)
                    {
                        baseStatus.currentMp = 0;
                    }
                    if (skills[selectNum].power == 0)
                    {
                        baseStatus.currentHp += skills[selectNum].heal;
                        if (currentStatus.HP > baseStatus.currentHp)
                        {
                            baseStatus.currentHp = currentStatus.HP;
                        }
                        PlayerManager.GetInstance().gameMsg = $" !!! {skills[selectNum].name} !!! 체력을 {skills[selectNum].heal}회복하였습니다.";
                    }
                    else
                    {
                        PlayerManager.GetInstance().gameMsg = $" !!! {skills[selectNum].name} !!! {EnemyManager.GetInstance().GetEnemyList()[attackIndex].GetName()}에게 {skills[selectNum].power}의 데미지를 입혔습니다.";
                    }
                    selectNum = 0;
                }
                else
                {
                    Random rd = new Random();
                    int dmg = rd.Next(currentStatus.MinAttack, currentStatus.MaxAttack);
                    bool isCri = rd.Next(0, 100) < currentStatus.Luck;
                    PlayerManager.GetInstance().gameMsg = "";
                    if (isCri == false)
                    {
                        PlayerManager.GetInstance().gameMsg = "크리티컬!! ";
                        dmg = (int)(dmg * 1.1f);
                        switch (race)
                        {
                            case Race.Human:
                                SoundManager.GetInstance().PlaySound("SwordNormaCritical", 0.5f);
                                break;
                            case Race.Dwarf:
                                SoundManager.GetInstance().PlaySound("HammerNormaCritical", 0.5f);
                                break;
                            case Race.HalfElf:
                                SoundManager.GetInstance().PlaySound("ArrowNormalCritical", 0.5f);
                                break;
                        }
                    }
                    else
                    {
                        Random rd2 = new Random();

                        switch (race)
                        {
                            case Race.Human:
                                if (rd2.Next(0, 2) == 1)
                                {
                                    SoundManager.GetInstance().PlaySound("SwordNorma", 0.5f);
                                }
                                else
                                {
                                    SoundManager.GetInstance().PlaySound("SwordNorma2", 0.5f);
                                }
                                break;
                            case Race.Dwarf:
                                if (rd2.Next(0, 2) == 1)
                                {
                                    SoundManager.GetInstance().PlaySound("HammerNorma", 0.5f);
                                }
                                else
                                {
                                    SoundManager.GetInstance().PlaySound("HammerNorma2", 0.5f);
                                }
                                break;
                            case Race.HalfElf:
                                if (rd2.Next(0, 2) == 1)
                                {
                                    SoundManager.GetInstance().PlaySound("ArrowNormal", 0.5f);
                                }
                                else
                                {
                                    SoundManager.GetInstance().PlaySound("ArrowNormal2", 0.5f);
                                }
                                break;

                        }
                    }
                    if (isCheat == false)
                    {
                        EnemyManager.GetInstance().GetEnemyList()[attackIndex].HitEnemy(dmg);
                    }
                    else
                    {
                        EnemyManager.GetInstance().GetEnemyList()[attackIndex].HitEnemy(100);
                    }
                    PlayerManager.GetInstance().gameMsg += $" {EnemyManager.GetInstance().GetEnemyList()[attackIndex].GetName()}에게 {dmg}의 데미지를 입혔습니다.";

                    var weapon = this.eWeapon;
                    if (weapon != null && !weapon.IsBroken)
                    {
                        //weapon.ReduceDurability(1);
                        weapon.Use(this);
                        PlayerManager.GetInstance().gameMsg += $" \n    {weapon.Name}의 내구도가 1 감소하였습니다.";
                        // 옵션: 내구도 0이 되면 메시지 출력
                        if (weapon.IsBroken)
                        {
                            PlayerManager.GetInstance().gameMsg += $" \n    {weapon.Name}의 내구도가 모두 소모되어 사용할 수 없습니다!";
                        }
                    }

                    selectNum = 0;
                }
                timer.Start();
                attackIndex = 0;
                selectE = 0;
                isPlayerTurn = false;
                isAttack = false;
                isSkill = false;
            }
        }
        private void AttackSelectUI()
        {
            if (isAttack == true)
            {
                switch (selectNum) // 얘때문에 버그나는데 얘를 안써도 상관없는코드라서 이거 제가짯어요
                {
                    case 0:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 30, 20);
                        break;
                    case 1:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 10, 22);
                        break;
                    case 2:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 8, 24);
                        break;
                    case 3:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 11, 26);
                        break;
                }
            }
        }
        private void SkillSelectUI()
        {
            TextIOManager.GetInstance().OutputSmartText(skills[0].name, 11, 20);
            TextIOManager.GetInstance().OutputSmartText(skills[1].name, 11, 22);
            TextIOManager.GetInstance().OutputSmartText(skills[2].name, 11, 24);
            TextIOManager.GetInstance().OutputSmartText("뒤로가기", 11, 27);
            if (isItemBag == false)
                switch (selectNum)
                {
                    case 0:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 8, 20);
                        break;
                    case 1:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 8, 22);
                        break;
                    case 2:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 8, 24);
                        break;
                    case 3:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 8, 27);
                        break;
                }
        }
        private void PlaySelectUI()
        {
            TextIOManager.GetInstance().OutputSmartText("Attack", 15, 20);
            TextIOManager.GetInstance().OutputSmartText("Item", 13, 22);
            TextIOManager.GetInstance().OutputSmartText("Skill", 11, 24);
            if (isItemBag == false)
                switch (selectNum)
                {
                    case 0:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 12, 20);
                        break;
                    case 1:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 10, 22);
                        break;
                    case 2:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 8, 24);
                        break;
                }
        }
        private void HpBarRender()
        {
            for (int i = 1; i <= currentStatus.HP / 10; i++)
            {
                int val = currentStatus.HP / 10 * i;
                if (10 * i <= baseStatus.currentHp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("■", 5 + 2 * i, 35);
                }
                else if (baseStatus.currentHp % 10 != 0)
                {
                    TextIOManager.GetInstance().OutputText4Byte("□", 5 + 2 * i, 35);
                    break;
                }
            }
        }

        private void MpBarRender()
        { //머리가 굳었어요 
            for (int i = 1; i <= currentStatus.MP / 10; i++)
            {
                int val = currentStatus.MP / 10 * i;
                if (10 * i <= baseStatus.currentMp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("■", 5 + 2 * i, 37);
                }
                else if (baseStatus.currentMp % 10 != 0)
                {
                    TextIOManager.GetInstance().OutputText4Byte("□", 5 + 2 * i, 37);
                    break;
                }
            }
            TextIOManager.GetInstance().OutputText4Byte(baseStatus.currentMp.ToString(), 1, 39);
        }
        private void StateBox()
        {
            int uiX = 0;
            int uiX2 = 0;

            TextIOManager.GetInstance().OutputText("┌", 4, 34);
            for (int i = 1; i <= currentStatus.HP / 10 * 2; i++)
            {
                TextIOManager.GetInstance().OutputText("─", 4 + i, 34);
                TextIOManager.GetInstance().OutputText("─", 4 + i, 36);
                uiX++;

            }
            TextIOManager.GetInstance().OutputText("┐", 4 + uiX + 2, 34);
            TextIOManager.GetInstance().OutputText("│", 4, 35);
            TextIOManager.GetInstance().OutputText("│", 4 + uiX + 2, 35);
            TextIOManager.GetInstance().OutputText("├", 4, 36);
            if (currentStatus.HP == currentStatus.MP)
            {
                TextIOManager.GetInstance().OutputText("┤", 4, 36);
            }
            else
            {
                int temp = Math.Abs(currentStatus.HP / 10 - currentStatus.MP / 10);
                if (currentStatus.HP > currentStatus.MP)
                {
                    TextIOManager.GetInstance().OutputText("┘", 4 + currentStatus.HP / 10 * 2 + 2, 36);
                    TextIOManager.GetInstance().OutputText("┬", 4 + (currentStatus.HP / 10 - temp) * 2 + 2, 36);
                }
                else
                {
                    TextIOManager.GetInstance().OutputText("┐", 4 + currentStatus.HP / 10 * 2 + 2, 36);
                    TextIOManager.GetInstance().OutputText("┴", 4 + (currentStatus.MP / 10 - temp) * 2 + 2, 36);
                }
            }
            for (int i = 1; i <= currentStatus.MP / 10 * 2; i++)
            {
                uiX2++;
                TextIOManager.GetInstance().OutputText("─", 4 + i, 38);
            }
            TextIOManager.GetInstance().OutputText("└", 4, 38);
            TextIOManager.GetInstance().OutputText("┘", 4 + currentStatus.MP / 10 * 2 + 2, 38);

            TextIOManager.GetInstance().OutputText("│", 4, 37);
            TextIOManager.GetInstance().OutputText("│", 4 + currentStatus.MP / 10 * 2 + 2, 37);
        }

        public Trait RandomTrait()
        {
            List<Trait> allTraits = new List<Trait>();
            allTraits.AddRange(TraitDatabase.commonTraits);
            allTraits.AddRange(TraitDatabase.GetTraitsByRace(this.race));
            Random rand = new Random();
            traitNum = rand.Next(allTraits.Count);
            this.trait = allTraits[traitNum];

            this.trait.ApplyEffect(this);
            RecalculateCurrentStatus();
            return this.trait;
        }

        public void LoadToFileGetStatus(List<String> strs, ref string a, ref string b)
        {
            PlayerManager.GetInstance().SetPlayer(this);
            name = strs[0];
            baseStatus = new Status(int.Parse(strs[1]), int.Parse(strs[2]), int.Parse(strs[4]), int.Parse(strs[5]), int.Parse(strs[6]), int.Parse(strs[3]), int.Parse(strs[7]), int.Parse(strs[9]), int.Parse(strs[10]));
            Gold = int.Parse(strs[11]);
            EnemyManager.GetInstance().CycleCount = int.Parse(strs[12]);

            int traitNumber = int.Parse(strs[13]);
            race = (Race)int.Parse(strs[15]);
            //race = _race
            List<Trait> allTraits = new List<Trait>();
            allTraits.AddRange(TraitDatabase.commonTraits);
            allTraits.AddRange(TraitDatabase.GetTraitsByRace(this.race));
            this.trait = allTraits[traitNumber];

            this.trait.ApplyEffect(this);
            RecalculateCurrentStatus();
            PlayerManager.GetInstance().environment = strs[14];
            a = strs[16];
            b = strs[17];

            //baseStatus = StatusFactory.GetStatusByRace(race);
            skills = StatusFactory.GetSkillsByRace(race);
            TextIOManager.GetInstance().OutputSmartText($"특성 : {trait.name}", 40, 2);
            currentStatus = baseStatus;
        }
        public void LoadToItemList(List<String> strs)
        {
            strs.ForEach(e => PlayerManager.GetInstance().GetPlayer().Inventory.AddItem(e));
        }
    }
}
/*
        List<String> strs = new List<string>();
         0   strs.Add(player.name.ToString());
         1   strs.Add(player.baseStatus.HP.ToString());
         2   strs.Add(player.baseStatus.MP.ToString());
         3   strs.Add(player.baseStatus.Tenacity.ToString());
         4   strs.Add(player.baseStatus.MinAttack.ToString());
         5   strs.Add(player.baseStatus.MaxAttack.ToString());
         6   strs.Add(player.baseStatus.Agility.ToString());
         7   strs.Add(player.baseStatus.Luck.ToString());
         8   strs.Add(player.baseStatus.stress.ToString());
         9   strs.Add(player.baseStatus.currentHp.ToString());
         10   strs.Add(player.baseStatus.currentMp.ToString());
         11   strs.Add(player.Gold.ToString());
         12   strs.Add(EnemyManager.EnemyManager.GetInstance().CycleCount.ToString());
         13   strs.Add(player.traitNum.ToString());
         14   strs.Add(PlayerManager.GetInstance().environment);
         15   strs.Add(player.race.ToString());
        16 armor
        17 wepon
 */
