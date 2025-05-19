using UnityEngine;

namespace LuckyDenfensePrototype
{
    [CreateAssetMenu(menuName = "Enemies/Data", fileName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public float speed;
        public float heath;
    }
}