using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Core.ImageManager
{
    internal class ImageManager : Singleton<ImageManager>
    {
        private Dictionary<string, string> iamgeDictionary = new();

        public void Init()
        {
            // 초기화 작업
            iamgeDictionary.Clear();

            // 이미지들 추가
        }

        public void AddImage(string key, string imageText)
        {
            if (!iamgeDictionary.ContainsKey(key))
            {
                iamgeDictionary.Add(key, imageText);
            }
        }

        public string GetImage(string key)
        {
            if (iamgeDictionary.TryGetValue(key, out string imageText))
                return imageText;
            else
                return string.Empty;
        }

    }
}
