using System;
using System.Collections.Generic;
using System.Linq;
using LuckyDefensePrototype;
using LuckyDenfensePrototype;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "GuardianManager", menuName = "Manager/GuardianManager")]
    public class GuardianManager : ScriptableObject
    {
        [SerializeField] private Guardian[] possibleSummonGuardians;
        [SerializeField] private Guardian[] mythicGuardians;
        
        [NonSerialized] public List<Guardian> summonedGuardians;

        public void Initialize()
        {
            summonedGuardians = new List<Guardian>();
        }

        public Guardian GetGuardianByRarity(Rarity rarity)
        {
            var guardian = possibleSummonGuardians
                .Where(x => x.rarity == rarity)
                .OrderBy(_ => Random.value)
                .FirstOrDefault();
            
            return guardian;
        }
    }
}