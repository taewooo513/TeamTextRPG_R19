using System;
using System.Collections.Generic;
using TeamRPG.Game.Object.UI;

namespace TeamRPG.Core.UtilManager
{
    public class UIManager : Singleton<UIManager>
    {
        private List<UIElement> uiElements;

        public static int HalfWidth
        {
            get
            {
                return Console.WindowWidth / 2;
            }
        }

        public static int HalfHeight
        {
            get
            {
                return Console.WindowHeight / 2;
            }
        }

        public UIManager()
        {
            uiElements = new();
        }

        public void AddUIElement(UIElement element)
        {
            if (element == null) return;
            uiElements?.Add(element);
        }

        public void RemoveUIElement(UIElement element)
        {
            if (element == null) return;
            uiElements?.Remove(element);
        }

        public void DrawUI()
        {
            foreach (var element in uiElements)
            {
                element?.Draw();
            }
        }

        public void ClearUI()
        {
            uiElements?.Clear();
        }
    }
}
