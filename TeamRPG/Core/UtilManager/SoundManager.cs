using FMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
namespace TeamRPG.Core.UtilManager
{

    public class SoundManager : Singleton<SoundManager>
    {
        Dictionary<String, FMOD.Sound> sounds;
        Dictionary<String, FMOD.Channel> channels;
        FMOD.System system;
        FMOD.Sound sound;
        FMOD.Channel channel;
        FMOD.ChannelGroup group = new ChannelGroup();
        public void Init()
        {
            system = new FMOD.System();
            FMOD.Factory.System_Create(out system);
            var err = system.init(100, FMOD.INITFLAGS.NORMAL, 0);

            sounds = new Dictionary<string, Sound>();
            channels = new Dictionary<string, FMOD.Channel>();
        }

        public void Update()
        {
            system.update();
        }
        public void AddSound(String key, String path)
        {
            Sound val;
            if (sounds.TryGetValue(key, out val) == false)
            {
                RESULT res = system.createSound(path, FMOD.MODE.LOOP_OFF, out val);
                sounds.Add(key, val);
            }
        }

        public void PlaySound(String key, int volume, bool isLoop = false)
        {
            FMOD.Channel ch;

            system.playSound(sounds[key], group, isLoop, out ch);
            channel.setVolume(volume);
        }
    }
}
