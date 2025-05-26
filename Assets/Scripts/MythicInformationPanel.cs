using LuckyDefensePrototype;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDenfensePrototype
{
    public class MythicInformationPanel : MonoBehaviour
    {
        [SerializeField] private GuardianManager guardianManager;
        
        [SerializeField] private VerticalLayoutGroup mythButtonListContainer;
        [SerializeField] private MythicInformationButton mythInfoButtonPrefab;

        [SerializeField] private MythicRecipeContainer RecipeContainer;
        [SerializeField] private MythicRecipeUIItem RecipeUIPrefab;

        private void OnEnable()
        {
            ClearChildTransforms(mythButtonListContainer.transform);
            foreach (MythicGuardian myth in guardianManager.mythicGuardians)
            {
                MythicInformationButton mythicInformationButton = Instantiate(mythInfoButtonPrefab, mythButtonListContainer.transform);
                mythicInformationButton.Initialize(myth, OnMythButtonClick);
            }
        }
        
        private void ClearChildTransforms(Transform t)
        {
            foreach (Transform child in t)
            {
                Destroy(child.gameObject);
            }
        }

        private void OnMythButtonClick(MythicGuardian mythicGuardian)
        {
            RecipeContainer.Initialize(mythicGuardian);
        }
    }
}