using System;
using LuckyDenfensePrototype;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefensePrototype
{
    public class MythicInformationButton : MonoBehaviour
    {
        [SerializeField] Image image;
        [SerializeField] Button button;

        public void Initialize(MythicGuardian mythicGuardian, Action<MythicGuardian> onClick)
        {
            image.sprite = mythicGuardian.mythicData.sprite;
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(()=>onClick(mythicGuardian));
        }
        
    }
}