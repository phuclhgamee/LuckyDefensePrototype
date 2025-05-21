using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData data;
        [SerializeField] private SkeletonAnimation skeletonAnimation;
        private float currentHealth;

        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
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
            skeletonAnimation.state.SetAnimation(0,EnemyAnimation.Idle,true);
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
                    , data.speed * Time.deltaTime);
                if (velocity.x < 0)
                {
                    transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                else if (velocity.x > 0)
                {
                    transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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
            var entry = skeletonAnimation.state.SetAnimation(0, "Die", false);
            entry.Complete += (trackEntry) =>
            {
                gameObject.SetActive(false);
            };
        }
        
    }
}