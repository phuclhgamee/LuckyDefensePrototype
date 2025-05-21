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

        public Enemy Target { get; set; }
        protected bool isAttacking;
        private Vector3 previousDirection = Vector3.zero;
        
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
                Flip();
            }
            else
            {
                Flip();
            }
            
        }
        // private void CoolDownAttack()
        // {
        //     if (attackCooldown <= 0f)
        //     {
        //         Attack();
        //         attackCooldown = attackSpeed;
        //     }
        //     else 
        //     {
        //         attackCooldown -= Time.deltaTime;
        //     }
        // }
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

        public void Flip()
        {
            if (ToTargetDirection().x < 0)
            {
                transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        public Vector3 ToTargetDirection()
        {
            if (Target != null)
            {
                return Tile.transform.position - Target.transform.position;
            }
            return Vector3.zero;
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

