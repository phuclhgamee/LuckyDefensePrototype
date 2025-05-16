using System;
using System.Collections;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    [CreateAssetMenu(fileName = "WaveLevel", menuName = "Wave/WaveLevel")]
    public class WaveLevel : ScriptableObject
    {
        public WaveData[] waves;
        public IntegerVariable limitNumberOfCreeps;
        
    }
}