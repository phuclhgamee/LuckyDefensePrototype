using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class MythicGuardian : Guardian
    {
        [SerializeField] protected Guardian[] requiredGuardians;
        [SerializeField] public Sprite sprite;

        public bool CanBeSummoned(List<Guardian> summonedGuardians)
        {
            return requiredGuardians.ToList().Any(itemA => summonedGuardians.Contains(itemA));
        }
    }
}