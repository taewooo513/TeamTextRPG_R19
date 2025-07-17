using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EncounterManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.UI;
using TeamRPG.Game.Object.Data;

namespace TeamRPG.Game.Scene
{
    using Scene = Core.SceneManager.Scene;
    public class EncounterScene : Scene
    {
        private Menu currentMenu;

        private EncounterData currentEncounterData;
        private RawText encounterImage;
        private RawText description;
        private RawText comment;
        private Menu selectionMenu;
        private Menu resultMenu;

        private Player player;

        public void Init()
        {
            player = PlayerManager.GetInstance().GetPlayer();
            SoundManager.GetInstance().PlaySound("RandomEncounterSound4", 0.4f);
            InitEncounterData();
            InitUI();
        }

        public void Update()
        {
            UpdateUI();
            InputMenu();
        }

        public void Render()
        {

        }

        void InputMenu()
        {
            KeyInputManager keyInputManager = KeyInputManager.GetInstance();

            if (keyInputManager.GetKeyDown(ConsoleKey.LeftArrow) || keyInputManager.GetKeyDown(ConsoleKey.A))
                currentMenu.MoveUp();
            else if (keyInputManager.GetKeyDown(ConsoleKey.RightArrow) || keyInputManager.GetKeyDown(ConsoleKey.D))
                currentMenu.MoveDown();
            else if (keyInputManager.GetKeyDown(ConsoleKey.Enter) || keyInputManager.GetKeyDown(ConsoleKey.Spacebar))
            {
                // 선택지 선택
                currentMenu.Select();
            }
        }

        void InitEncounterData()
        {
            currentEncounterData = EncounterManager.GetInstance().GetRandomEncounterData();
            // currentEncounterData = EncounterManager.GetInstance().GetEncounterData("버섯");
        }

        void InitUI()
        {
            string image = currentEncounterData.Image != string.Empty ? currentEncounterData.Image : "";

            encounterImage = new RawText(image, UIManager.HalfWidth, UIManager.HalfHeight, HorizontalAlign.Center, VerticalAlign.Middle);
            description = new RawText(currentEncounterData.Description, UIManager.HalfWidth, Console.WindowHeight - 5, HorizontalAlign.Center, VerticalAlign.Top);
            comment = new RawText(currentEncounterData.Comment, 30, UIManager.HalfHeight - 5, HorizontalAlign.Center, VerticalAlign.Top);
            selectionMenu = new Menu(60, Console.WindowHeight - 3, DirectionType.Horizontal);

            for (int i = 0; i < currentEncounterData.Selections.Count; i++)
            {
                EncounterSelection encounterSelection = currentEncounterData.Selections[i];
                MenuItem item = selectionMenu.AddItem("", () => { }); // 빈 아이템 추가
                item.Text = encounterSelection.MenuText; // 초기 텍스트 설정
                int index = i;
                item.OnSelect = () =>
                {
                    encounterSelection.Select(player);
                    OnSelectMenu(player, currentEncounterData.Selections[index]);
                };

                item.IsEnabled = encounterSelection.HasRequiredItems;
            }

            resultMenu = new Menu(60, Console.WindowHeight - 3, DirectionType.Horizontal);
            resultMenu.AddItem("", () => { });

            selectionMenu.IsVisible = true;
            resultMenu.IsVisible = false;

            currentMenu = selectionMenu;
        }

        void UpdateUI()
        {
            encounterImage.X = UIManager.HalfWidth;
            encounterImage.Y = UIManager.HalfHeight;
            description.X = UIManager.HalfWidth;
            description.Y = Console.WindowHeight - 3;
            comment.X = 30;
            comment.Y = UIManager.HalfHeight - 5;
            selectionMenu.X = 60;
            selectionMenu.Y = Console.WindowHeight - 1;
            resultMenu.X = 60;
            resultMenu.Y = Console.WindowHeight - 1;
        }

        public void OnSelectMenu(Player player, EncounterSelection selection)
        {
            currentMenu = resultMenu;

            selectionMenu.IsVisible = false;
            resultMenu.IsVisible = true;

            // encounterImage.SetText(selection.Result.Image);

            resultMenu.GetItem(0).OnSelect = () =>
            {
                selection.Result.OnExit?.Invoke(player);
                resultMenu.GetItem(0).Text = selection.Result.MenuText;
                comment.SetText(selection.Result.Comment);
                description.SetText(selection.Result.Description); 
            };

            resultMenu.GetItem(0).Text = selection.Result.MenuText;
            comment.SetText(selection.Result.Comment);
            description.SetText(selection.Result.Description);
        }

        public void Release()
        {
            UIManager.GetInstance().ClearUI();
            SoundManager.GetInstance().StopSound("RandomEncounterSound4");
        }
    }
}
