using System.Collections;
using System.Linq;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] public WaveLevel waveLevel;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private Transform[] enemyRotateDestinations;
        
        [SerializeField] private IntegerVariable EnemyCount;
        [SerializeField] private IntegerVariable CurrentWave;

        [SerializeField] private Event UpdateTimerTextEvent;
        [SerializeField] private Event GameOverEvent;
        
        private float _timer;
        private bool isBossWaveCleared =false;
        public float Timer
        {
            get => _timer;
            set
            {
                _timer = value;
                UpdateTimerTextEvent.Raise();
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnAllWave());
        }

        private void Update()
        {
            Timer -= Time.deltaTime;
            if (EnemyCount.Value >= waveLevel.limitNumberOfCreeps.Value)
            {
                GameOverEvent.Raise();
            }
        }
        IEnumerator SpawnEnemy(Enemies enemies)
        {
            for (int i = 0; i < enemies.number; i++)
            {
                Enemy enemy = Instantiate(enemies.enemy, spawnPosition.position, Quaternion.identity);
                enemy.Initialize(enemyRotateDestinations.ToList());
                EnemyCount.Value++;
                yield return new WaitForSeconds(enemies.timeBetweenSpawn);
            }
        }

        IEnumerator SpawnWave(WaveData wave)
        {
            Timer = wave.secondsForNextWave;
            if (wave.isBossWave)
            {
                isBossWaveCleared = false;
            }
            foreach (Enemies enemies in wave.enemies)
            {
                yield return StartCoroutine(SpawnEnemy(enemies));
            }
            yield return new WaitUntil(()=>Timer <= 0f);
            CurrentWave.Value++;
        }

        IEnumerator SpawnAllWave()
        {
            foreach (WaveData wave in waveLevel.waves)
            {
                yield return StartCoroutine(SpawnWave(wave));
                if (wave.isBossWave && Timer <= 0f)
                {
                    if (!isBossWaveCleared)
                    {
                        GameOverEvent.Raise();
                    }
                }
            }
        }

        public void OnBossKillEventListener()
        {
            Timer = 3f;
            isBossWaveCleared = true;
        }
    }
}