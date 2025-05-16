using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Guardian : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation skeletonAnimation;

        [Header("Stat")] public Rarity rarity;
        public RangedType rangedType;
        public GuardianType guardianType;
        public float range;
        public float attackSpeed;
        public Tile Tile { get; set; }

        // Update is called once per frame
        void Update()
        {

        }

        public void EnemyDetection()
        {
            Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, range, LayerMask.GetMask("Enemy"));
            if (enemyColliders.Length > 0)
            {
                
            }
        }

        
    }
    
    public enum Rarity { Common, Rare, Epic, Legendary, Mythic }
    
    public enum RangedType{ Ranged, Melee}
    
    public enum GuardianType{ Human, Robot, Element, Devil}
}

