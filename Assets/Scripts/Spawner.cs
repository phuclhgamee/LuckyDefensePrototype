using System.Collections;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private WaveLevel waveLevel;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private bool isBoosWave;
        private float timer;

        private void Start()
        {
            StartCoroutine(SpawnAllWave());
        }
        
        IEnumerator SpawnEnemy(Enemies enemies)
        {
            for (int i = 0; i < enemies.number; i++)
            {
                Instantiate(enemies.enemy, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(enemies.timeBetweenSpawn);
            }
        }

        IEnumerator SpawnWave(WaveData wave)
        {
            timer = wave.timer;
            foreach (Enemies enemies in wave.enemies)
            {
                StartCoroutine(SpawnEnemy(enemies));
                
            }
            yield return new WaitUntil(()=>timer <= 0f);
        }

        IEnumerator SpawnAllWave()
        {
            foreach (WaveData wave in waveLevel.waves)
            {
                StartCoroutine(SpawnWave(wave));
            }

            yield return null;
        }
    }
}