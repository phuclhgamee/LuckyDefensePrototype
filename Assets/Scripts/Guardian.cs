using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Guardian : MonoBehaviour
    {
        public Rarity rarity;
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

