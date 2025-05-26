using Spine.Unity;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class MythicRecipeUIItem : MonoBehaviour
    {
        [SerializeField] private SkeletonGraphic graphic;

        public void Initialize(Guardian guardian)
        {
            graphic.Clear();
            graphic.skeletonDataAsset = guardian.graphic; 
            graphic.Initialize(true);
        }
    }
}