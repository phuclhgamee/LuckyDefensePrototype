using System.Collections.Generic;
using LuckyDenfensePrototype;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "SummonPercentageManager", menuName = "Manager/SummonPercentageManager")]
    public class SummonPercentageManager : ScriptableObject
    {
        public List<SummonPercentageData> SummonPercentageDatas;

        public Rarity GetSummonRarity()
        {
            float totalProportion = 0;
            foreach(SummonPercentageData data in SummonPercentageDatas) 
                totalProportion += data.percentage;
            
            float random = UnityEngine.Random.Range(0f, totalProportion);

            foreach (SummonPercentageData data in SummonPercentageDatas)
            {
                random -= data.percentage;
                if(random <= 0f)
                    return data.rarity;
            }
            return Rarity.Common;
        }
    }
    [System.Serializable]
    public class SummonPercentageData
    {
        public Rarity rarity;
        public float percentage;
    }
}