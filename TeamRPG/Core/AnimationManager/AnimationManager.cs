using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Core.AnimationManager
{
    public class AnimationManager : Singleton<AnimationManager>
    {
        private List<Animation> animations;

        public AnimationManager()
        {
            animations = new List<Animation>();
        }

        ~AnimationManager()
        {
            animations.Clear();
        }
        public void AddAnimation(List<String>[] _strs, int _x, int _y, float _frame, bool _isLoop, ConsoleColor _color = ConsoleColor.Magenta)
        {
            //animations.Add(new Animation(_strs, _x, _y, _frame, _isLoop, _color));
        }

        public void Update()
        {
            animations?.ForEach(a => a.Update());
        }

        public void Render()
        {
            animations?.ForEach(a => a.Render());
        }

        public void ReleaseAnimation(Animation animation)
        {
            animations.Remove(animation);
        }
    }
}
