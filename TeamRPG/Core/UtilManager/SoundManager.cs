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
        Dictionary<String, FMOD.Sound> d_sounds;
        Dictionary<String, FMOD.Channel> d_channels;
        FMOD.System system;
        FMOD.Sound[] l_sounds;
        FMOD.Channel[] l_channels;
        FMOD.ChannelGroup group = new ChannelGroup();
        public void Init()
        {
            system = new FMOD.System();
            FMOD.Factory.System_Create(out system);
            var err = system.init(100, FMOD.INITFLAGS.NORMAL, 0);

            d_sounds = new Dictionary<string, Sound>();
            d_channels = new Dictionary<string, FMOD.Channel>();

            l_sounds = new FMOD.Sound[100];
            l_channels = new FMOD.Channel[100];
        }

        public void Update()
        {
            system.update();
        }
        public void AddSound(String key, String path, bool isBackGround, bool isLoop)
        {
            Sound val;
            if (d_sounds.TryGetValue(key, out val) == false)
            {
                if (isLoop == true)
                {
                    if (isBackGround == true)
                    {
                        system.createStream(path, FMOD.MODE.LOOP_NORMAL, out val);
                    }
                    else
                    {
                        system.createSound(path, FMOD.MODE.LOOP_NORMAL, out val);
                    }
                }
                else
                {
                    system.createSound(path, FMOD.MODE.DEFAULT, out val);
                }
                d_sounds.Add(key, val);
            }
        }

        public void PlaySound(String key, float volume)
        {
            FMOD.Sound? sd = null;
            int a = 0;
            foreach (var item in d_sounds)
            {
                a++;
                if (item.Key == key)
                {
                    sd = item.Value;
                    break;
                }
            }
            if (sd != null)
            {
                system.playSound((Sound)sd, group, false, out l_channels[a]);
                l_channels[a].setVolume(volume);
            }
        }
        public void StopSound(String key)
        {
            FMOD.Sound? sd = null;
            int a = 0;
            foreach (var item in d_sounds)
            {
                a++;
                if (item.Key == key)
                {
                    l_channels[a].stop();
                }
            }
        }
    }
}
