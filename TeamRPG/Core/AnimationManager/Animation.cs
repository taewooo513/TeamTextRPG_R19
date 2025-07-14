using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Core.AnimationManager
{
    public class Animation
    {
        int x, y;
        int frameCount = 0;
        float nowTimer = 0;
        float frameTime = 0;
        private List<String>[] strs;
        bool isLoop;
        ConsoleColor color;
        public Animation(List<String>[] _strs, int _x, int _y, float _frame, bool _isLoop = false, ConsoleColor _color = ConsoleColor.Magenta)
        {
            frameCount = 0;
            x = _x;
            y = _y;
            strs = _strs;
            frameTime = _frame;
            isLoop = _isLoop;
            color = _color;
        }

        public void Update()
        {
            nowTimer += TimerManager.GetInstance().GetMillisecond();
            if (nowTimer > frameTime)
            {
                if (frameCount >= strs.Length && isLoop)
                {
                    frameCount = 0;
                }
                else if (frameCount >= strs.Length)
                {
                    ReleaseEvenet();
                }
                else
                {
                    frameCount++;
                    nowTimer = 0;
                }
            }
        }

        public void Render()
        {
            for (int i = 0; i < strs[frameCount].Count; i++)
            {
                TextIOManager.GetInstance().OutputText(strs[frameCount][i], x, y, color);
            }
        }

        protected void ReleaseEvenet()
        {
            AnimationManager.GetInstance().ReleaseAnimation(this);
        }
    }
}
