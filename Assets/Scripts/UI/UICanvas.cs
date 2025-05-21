using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class UICanvas : MonoBehaviour
    {
        [SerializeField] GameOverPanel gameOverPanel;

        public void OpenGameOverPanel()
        {
            Time.timeScale = 0f;
            gameOverPanel.gameObject.SetActive(true);
        }
    }
}

