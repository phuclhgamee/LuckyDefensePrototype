using System;
using System.Collections;
using System.Collections.Generic;
using LuckyDenfensePrototype;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefensePrototype
{
    public class ResourceUIPanel : MonoBehaviour
    {
        public Button openMythInfoPanelButton;
        public MythicInformationPanel mythicInformationPanel;

        private void OnEnable()
        {
            openMythInfoPanelButton.onClick.RemoveAllListeners();
            openMythInfoPanelButton.onClick.AddListener(()=>OpenMythInfoPanel());
        }

        private void OpenMythInfoPanel()
        {
            mythicInformationPanel.gameObject.SetActive(true);
        }
    }
}

