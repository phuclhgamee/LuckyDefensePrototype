using System;
using System.Collections;
using System.Collections.Generic;
using LuckyDefensePrototype;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation skeletonAnimation;
        [SerializeField, SpineAnimation] private string moveAnimation;
        [SerializeField, SpineAnimation] private string deadAnimation;
        
        [SerializeField] private EnemyData data;
        [SerializeField] private IntegerVariable enemyCount;
        [SerializeField] private GameObject visual;
        
        [Header("UI")]
        [SerializeField] private HealthBar healthBar;
        private float currentHealth;

        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
                healthBar.SetHealth(currentHealth/data.heath);
                if (currentHealth <= 0)
                {
                    Die();
                }
            }
        }
        public float Speed { get; set; }
        
        private List<Transform> rotateDestinations = new();
        private int currentDestination;
        private Vector3 velocity;
        private Vector3 lastPosition;
        public void Initialize(List<Transform> destinations)
        {
            rotateDestinations = destinations;
            currentDestination = 0;
            velocity = Vector3.zero;
            lastPosition = transform.position;
            CurrentHealth = data.heath;
            Speed = data.speed;
            StartCoroutine(Move());
            skeletonAnimation.state.SetAnimation(0,moveAnimation,true);
        }

        void Update()
        {
            velocity = (transform.position - lastPosition) / Time.deltaTime;
            lastPosition = transform.position;
        }
        IEnumerator Move()
        {
            while (true)
            {
                Transform target = rotateDestinations[currentDestination];
                transform.position = Vector3.MoveTowards(transform.position, target.position
                    , Speed * Time.deltaTime);
                if (velocity.x < 0)
                {
                    visual.transform.localScale = new Vector3(-Math.Abs(visual.transform.localScale.x), visual.transform.localScale.y, visual.transform.localScale.z);
                }
                else if (velocity.x > 0)
                {
                    visual.transform.localScale = new Vector3(Math.Abs(visual.transform.localScale.x), visual.transform.localScale.y, visual.transform.localScale.z);
                }
                if (Vector3.Distance(transform.position, target.position) < 0.01f)
                {
                    currentDestination = (currentDestination + 1) % rotateDestinations.Count;
                }
                yield return null;
            }
        }

        public void Die()
        {
            Speed = 0;
            var entry = skeletonAnimation.state.SetAnimation(0, deadAnimation, false);
            entry.Complete += (trackEntry) =>
            {
                gameObject.SetActive(false);
                enemyCount.Value--;
                BossKilled();
            };
        }

        protected virtual void BossKilled()
        {
            
        }
    }
}