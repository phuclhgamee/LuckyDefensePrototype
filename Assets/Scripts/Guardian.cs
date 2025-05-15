using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Guardian : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation skeletonAnimation;
        
        public Rarity rarity;

        public Tile Tile;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
    
    public enum Rarity { Common, Rare, Epic, Legendary, Mythic }
}

