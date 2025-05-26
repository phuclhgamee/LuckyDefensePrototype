using LuckyDefensePrototype;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDenfensePrototype
{
    public class MythicRecipeContainer : MonoBehaviour
    {
        [SerializeField] private Image mythIcon;
        [SerializeField] public GridLayoutGroup gridLayoutGroup;
        [SerializeField] private MythicRecipeUIItem mythRecipeUIPrefab;

        public void Initialize(MythicGuardian mythicGuardian)
        {
            mythIcon.sprite = mythicGuardian.mythicData.sprite;
            ClearAllChildren();
            foreach (Guardian g in mythicGuardian.mythicData.requiredGuardians)
            {
                MythicRecipeUIItem item = Instantiate(mythRecipeUIPrefab, gridLayoutGroup.transform);
                item.Initialize(g);
            }
        }

        private void ClearAllChildren()
        {
            foreach (Transform child in gridLayoutGroup.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}