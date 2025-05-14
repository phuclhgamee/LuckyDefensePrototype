using System;
using System.Linq;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class RarityDisplay : MonoBehaviour
    {
        [SerializeField] private Guardian guardian;
        [SerializeField] private SkeletonRenderer skeletonRenderer;
        
        public void Start()
        {
            var skeleton = skeletonRenderer.skeleton;
            var slot = skeleton.Slots.First();
            if (slot != null)
            {
                Debug.Log(slot.Data.Name);
                //slot.Attachment.Color = Color.red;
            }
        }
    }
}