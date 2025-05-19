using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData data;
        
        private List<Transform> rotateDestinations = new();
        private int currentDestination;
        public void Initialize(List<Transform> destinations)
        {
            rotateDestinations = destinations;
            currentDestination = 0;
            StartCoroutine(Move());
        }
        IEnumerator Move()
        {
            while (true)
            {
                Transform target = rotateDestinations[currentDestination];
                transform.position = Vector3.MoveTowards(transform.position, target.position
                    , data.speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, target.position) < 0.01f)
                {
                    currentDestination = (currentDestination + 1) % rotateDestinations.Count;
                }
                yield return null;
            }
        }
        
    }
}