using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using LuckyDenfensePrototype;
using TMPro;
using UnityEngine;

namespace LuckyDefensePrototype2
{
    public class WaveTimerPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI waveText;
        [SerializeField] private TextMeshProUGUI creepsText;

        [SerializeField] private Spawner enemySpawner;
        
        public void UpdateTimerText()
        {
            timerText.text = FormatTime(enemySpawner.Timer);
        }

        public void UpdateWaveText(int wave)
        {
            waveText.text = $"Wave {wave.ToString()}";
        }

        public void UpdateCreepsText(int creeps)
        {
            creepsText.text = $"{creeps.ToString()} / {enemySpawner.waveLevel.limitNumberOfCreeps.Value.ToString()}";
        }
        
        public string FormatTime(float seconds)
        {
            if (seconds >= 0)
            {
                int totalSeconds = Mathf.FloorToInt(seconds);
                int minutes = totalSeconds / 60;
                int secs = totalSeconds % 60;
                return $"{minutes:D2}:{secs:D2}";
            }

            return "00:00";
        }
    }
}

