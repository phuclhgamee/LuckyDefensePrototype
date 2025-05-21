using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Guardian : MonoBehaviour
    {
        [SerializeField] protected SkeletonAnimation skeletonAnimation;

        [Header("Stat")] public Rarity rarity;
        public RangedType rangedType;
        public GuardianType guardianType;
        public float range;
        public float attackSpeed;
        public float damage;
        public Tile Tile { get; set; }

        public Enemy Target;
        private float attackCooldown = 0f;
        protected bool isAttacking;
        void Start()
        {
            Initialize();
        }

        void Update()
        {
            if (Target == null)
            {
                EnemyDetection();
            }
            else if(!isAttacking)
            {
                Attack();
            }
        }

        private void CoolDownAttack()
        {
            if (attackCooldown <= 0f)
            {
                Attack();
                attackCooldown = attackSpeed;
            }
            else 
            {
                attackCooldown -= Time.deltaTime;
            }
        }
        public void EnemyDetection()
        {
            Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(Tile.transform.position, range, LayerMask.GetMask("Enemy"));
            if (enemyColliders.Length > 0)
            {
                SetTargetEnemy(enemyColliders.ToList());
            }
        }

        public void SetTargetEnemy(List<Collider2D> enemyColliders)
        {
            float minDistance = 99999f;
            Enemy targetEnemy =null;
            foreach (Collider2D c in enemyColliders)
            {
                Enemy e = c.GetComponent<Enemy>();
                if (e != null)
                {
                    float distance = Vector3.Distance(Tile.transform.position, e.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        targetEnemy = e;
                    }
                }
            }

            Target = targetEnemy;
        }
        protected virtual void Attack()
        {
            isAttacking = true;
        }

        public virtual void Initialize()
        {
            
        }
        
    }
    
    public enum Rarity { Common, Rare, Epic, Legendary, Mythic }
    
    public enum RangedType{ Ranged, Melee}
    
    public enum GuardianType{ Human, Robot, Element, Devil}
}

