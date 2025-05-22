using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LuckyDenfensePrototype
{
    public class GameOverPanel : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Button restartButton;
        
        [Header("Reset components")]
        [SerializeField] private IntegerVariable currentWaveVariable;
        [SerializeField] private TileManager tileManager;
        [SerializeField] private GuardianManager guardianManager;

        private void OnEnable()
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(()=>OnClickRestartButton());
        }

        private void OnClickRestartButton()
        {
            currentWaveVariable.Value = 0;
            StopAllCoroutines();
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}