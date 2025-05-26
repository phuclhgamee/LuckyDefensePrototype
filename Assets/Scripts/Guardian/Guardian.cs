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
        [SerializeField] private GameObject visual;
        [Header("Anim")]
        [SerializeField] protected SkeletonAnimation skeletonAnimation;
        
        [SerializeField, SpineAnimation] protected string idleAnim;
        [SerializeField, SpineAnimation] protected string walkAnim;
        [SerializeField, SpineAnimation] protected string deathAnim;
        [SerializeField, SpineAnimation] protected string attackAnim;

        [Header("Stat")] public Rarity rarity;
        public RangedType rangedType;
        public GuardianClass guardianClass;
        public GuardianType guardianType;
        public float range;
        public float attackSpeed;
        public float damage;
        
        [Header("UI")]
        [SerializeField] public SkeletonDataAsset graphic;
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
                visual.transform.localScale = new Vector3(-Math.Abs(visual.transform.localScale.x), visual.transform.localScale.y, visual.transform.localScale.z);
            }
            else
            {
                visual.transform.localScale = new Vector3(Math.Abs(visual.transform.localScale.x), visual.transform.localScale.y, visual.transform.localScale.z);
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
        public void Attack()
        {
            isAttacking = true;
            float duration = skeletonAnimation.Skeleton.Data.FindAnimation(attackAnim)?.Duration ?? 0f;
            float desiredDuration = 1f / attackSpeed;
            float timeScale = duration/ desiredDuration;
            skeletonAnimation.timeScale = timeScale;
            var entry = skeletonAnimation.state.SetAnimation(0,attackAnim,false);
            
            Debug.Log(timeScale);
            entry.Complete += (trackEntry) =>
            {
                Target.CurrentHealth -= damage;
                
                if (Vector3.Distance(Tile.transform.position, Target.transform.position) > range || !Target.gameObject.activeInHierarchy)
                {
                    Target = null;
                }
                if (Target == null)
                {
                    skeletonAnimation.state.SetAnimation(0, idleAnim, true);
                }
                isAttacking = false;
            };
        }
        public void Initialize()
        {
            skeletonAnimation.state.SetAnimation(0,idleAnim,true);
        }
        
    }
    
    public enum Rarity { Common, Rare, Epic, Legendary, Mythic }
    
    public enum RangedType{ Ranged, Melee}
    
    public enum GuardianClass{ Human, Robot, Element, Devil}

    public enum GuardianType
    {
        ArcherCommon, KnightCommon, WukongCommon, NinjaCommon, FarmerCommon,
        ArcherRare, KnightRare, WizardRare, DruidRare, FarmerRare,
        NinjaEpic, HerculesEpic, WukongEpic, WizardEpic, KnightEpic,
        GOWLegend, ValkyrieLegend, BuddaLegend, NezhaLegend,
        WukongKingMythic, BuddaSuperMythic, DruidMythic, FarmerSuperMythic,GOW3Mythic, GOWSuperMythic,
        HerculesSuperMythic, NezhaSuperMythic, NinjaSuperMythic, ValkyrieSuperMythic, Valkyrie3Mythic
    }
}

