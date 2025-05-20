using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class AvailableMythicPanel : MonoBehaviour
    {
        [SerializeField] private GuardianManager guardianManager;
        [SerializeField] private MythicSummonButton mythicUIButtonPrefab;

        public void OnDisplayMythicAvailable()
        {
            ClearAllChildren();
            foreach (MythicGuardian mythGuardian in guardianManager.mythicGuardians)
            {
                if (mythGuardian.CanBeSummoned(guardianManager.summonedGuardians))
                {
                    MythicSummonButton mythicSummonButton = Instantiate(mythicUIButtonPrefab, transform);
                    mythicSummonButton.Initialize(mythGuardian);
                }
            }
        }

        public void ClearAllChildren()
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<MythicSummonButton>() != null)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}