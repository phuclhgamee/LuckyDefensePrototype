using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDenfensePrototype
{
    public class MythicButton : MonoBehaviour
    {
        public Image image;

        public void Initialize(MythicGuardian mythicGuardian)
        {
            image.sprite = mythicGuardian.sprite;
        }
    }
}

