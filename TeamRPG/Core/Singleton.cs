using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Core
{
    public class Singleton<T> where T : new()
    {
        private static T instance;

        static public T GetInstance()
        {
            if (instance == null)
            {
                instance = new T(); // 이거는 인스턴스가 없으면 새로 생성해주는코드입니다 매니저를호출했는데 없으면 안되니까요
            }
            return instance;
        }
    }
}
