using LuckyDenfensePrototype;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "Wave/WaveData")]
    public class WaveData : ScriptableObject
    {
        public Enemies[] enemies;
        public float timer;
        public bool isBossWave;
    }
    [System.Serializable]
    public class Enemies
    {
        public Enemy enemy;
        public int number;
        public float timeBetweenSpawn;
    }
}