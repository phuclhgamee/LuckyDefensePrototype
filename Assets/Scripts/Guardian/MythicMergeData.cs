using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    [CreateAssetMenu(menuName = "MythicMergeData/Data")]
    public class MythicMergeData : ScriptableObject
    {
        public Guardian[] requiredGuardians;
        public Sprite sprite;
        
        public bool CanBeSummoned(List<Guardian> summonedGuardians)
        {
            List<Guardian> existedGuardians = new List<Guardian>(summonedGuardians);
            foreach (Guardian guardian in requiredGuardians)
            {
                var g = existedGuardians.FirstOrDefault(x=>x.guardianType == guardian.guardianType);
                if(g != null)
                    existedGuardians.Remove(g);
                else
                    return false;
                
            }
            return true;
        }
    }
}