using System.Collections.Generic;
using LuckyDenfensePrototype;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "Wave/WaveData")]
    public class WaveData : ScriptableObject
    {
        public Enemies[] enemies;
        public float secondsForNextWave;
        public bool isBossWave;
        //event được raise khi 1 wave end
    }
    [System.Serializable]
    public class Enemies
    {
        public Enemy enemy;
        public int number;
        public float timeBetweenSpawn;

        
    }
}