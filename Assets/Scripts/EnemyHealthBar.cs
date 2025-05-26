using LuckyDenfensePrototype;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefensePrototype
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image fillImage;
        
        public void SetHealth(float normalized)
        {
            if (normalized >= 0)
            {
                fillImage.transform.localScale = new Vector3(normalized, 1, 1);
            }
            else
            {
                fillImage.transform.localScale = new Vector3(0, 1, 1);
            }
        }
    }
}