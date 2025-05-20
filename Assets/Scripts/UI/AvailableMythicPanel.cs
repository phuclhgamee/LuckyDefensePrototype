using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class AvailableMythicPanel : MonoBehaviour
    {
        [SerializeField] private GuardianManager guardianManager;
        [SerializeField] private MythicButton mythicUIButtonPrefab;

        public void OnDisplayMythicAvailable()
        {
            foreach (MythicGuardian mythGuardian in guardianManager.mythicGuardians)
            {
                if (mythGuardian.CanBeSummoned(guardianManager.summonedGuardians))
                {
                    MythicButton mythicButton = Instantiate(mythicUIButtonPrefab, transform);
                    mythicButton.Initialize(mythGuardian);
                }
            }
        }
    }
}