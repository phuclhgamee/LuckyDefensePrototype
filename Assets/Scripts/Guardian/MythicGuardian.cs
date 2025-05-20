using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class MythicGuardian : Guardian
    {
        [SerializeField] public Guardian[] requiredGuardians;
        [SerializeField] public Sprite sprite;

        public bool CanBeSummoned(List<Guardian> summonedGuardians)
        {
            List<Guardian> existedGuardians = new List<Guardian>(summonedGuardians);
            foreach (Guardian guardian in requiredGuardians)
            {
                var g = existedGuardians.FirstOrDefault(x=>x.GetType() == guardian.GetType());
                if(g != null)
                    existedGuardians.Remove(g);
                else
                    return false;
                
            }
            return true;
        }
        
        
    }
}