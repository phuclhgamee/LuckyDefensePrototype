using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDenfensePrototype
{
    public class UICanvas : MonoBehaviour
    {
        [SerializeField] GameOverPanel gameOverPanel;
        [SerializeField] MythicInformationPanel mythicInformationPanel;
        [SerializeField] GameOverPanel victoryPanel;
        [SerializeField] Button openMythicPanelButton;

        private void Awake()
        {
            openMythicPanelButton.onClick.RemoveAllListeners();
            openMythicPanelButton.onClick.AddListener(OpenMythicInformationPanel);  
        }
        public void OpenGameOverPanel()
        {
            Time.timeScale = 0f;
            gameOverPanel.gameObject.SetActive(true);
        }

        public void OpenVictoryPanel()
        {
            Time.timeScale = 0f;
            victoryPanel.gameObject.SetActive(true);
        }
        public void OpenMythicInformationPanel()
        {
            mythicInformationPanel.gameObject.SetActive(true);
        }

        public void CloseMythicPanel()
        {
            mythicInformationPanel.gameObject.SetActive(false);
        }
    }
}

