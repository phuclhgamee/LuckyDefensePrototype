using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using Random = UnityEngine.Random;

namespace LuckyDenfensePrototype
{
    [CreateAssetMenu(fileName = "GuardianManager", menuName = "Manager/GuardianManager")]
    public class GuardianManager : ScriptableObject
    {
        [SerializeField] private Guardian[] possibleSummonGuardians;
        [SerializeField] public Guardian[] mythicGuardians;
        
        public List<Guardian> summonedGuardians;

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

        public Guardian GetMergeGuardian(List<Guardian> guardians)
        {
            Rarity[] rarities = Enum.GetValues(typeof(Rarity)) as Rarity[];
            int index = Array.IndexOf(rarities, guardians[0].rarity);
            var mergedRarity = rarities[index+1];

            return GetGuardianByRarity(mergedRarity);
        }
    }
}