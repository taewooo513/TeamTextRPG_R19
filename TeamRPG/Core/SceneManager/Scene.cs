using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Core.SceneManager
{
    public interface Scene // interface 함수 대가리만 구현은 다른 클래스에서 상속받을거임 상속받으면 구현 해야함
    {
        public void Init(); // 초기화 여기서
        public void Update(); // 업데이트 연산 ex키입력받는등
        public void Render(); // 여기서 텍스트만
        public void Release(); // 씬전환할때 삭제 되야하는것
       
    }
}
