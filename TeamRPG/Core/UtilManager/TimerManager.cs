using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Core.UtilManager
{
    public class TimerManager : Singleton<TimerManager>
    {
        Stopwatch timer;
        float nowMilSecond;
        float milSecond;
        int frame;
        float deletaTime;
        public void Init()
        {
            nowMilSecond = 0;
            milSecond = 0;
            frame = 0;
            deletaTime = 0;

            timer = new Stopwatch();
            timer.Start();
        }
        public int GetFrame()
        {
            return frame;
        }

        public void Update()
        {
            nowMilSecond = timer.ElapsedMilliseconds;
            deletaTime = nowMilSecond - milSecond;
            deletaTime /= 1000;
            milSecond = nowMilSecond;
            frame = (int)(1f / deletaTime);
        }
        public float GetMillisecond()
        {
            return deletaTime;
        }


    }
}
