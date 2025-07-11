using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Core.UtilManager
{
    public class TimerManager : Singleton<TimerManager>
    {
        float nowMilSecond;
        float milSecond;
        int frame;

        public void Init()
        {
            frame = 0;
            milSecond = 0;
        }
        public int GetFrame()
        {
            return frame;
        }

        public void Update()
        {
            DateTime t = DateTime.Now;
            nowMilSecond = t.Minute * 1000 * 1000 + t.Second * 1000 + t.Millisecond;
        }
        public float GetMillisecond()
        {
            milSecond = nowMilSecond - milSecond;
            return milSecond;
        }
        public float GetSecond()
        {
            DateTime t = DateTime.Now;
            float d = t.Second;
            return d;
        }
    }
}
