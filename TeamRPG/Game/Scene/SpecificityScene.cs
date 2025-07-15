using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Scene
{
    internal class SpecificityScene : Core.SceneManager.Scene
    {
        public virtual void Init()
        {
        }

        public virtual void Release()
        {
        }

        public virtual void Render()
        {
            DrawMap();
        }

        public virtual void Update()
        {
        }

        protected virtual void DrawMap()
        {

        }

    }
}
