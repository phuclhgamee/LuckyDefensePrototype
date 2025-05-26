using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace LuckyDenfensePrototype
{
    public class RangeDisplayUI : MonoBehaviour
    {
        [SerializeField] private Tile tile;
        [SerializeField] private Image rangeCircleImage;

        public void RangeSetup()
        {
            if (tile.standingGuardians.Count > 0)
            {
                transform.position = tile.transform.position;
                Guardian guardian = tile.standingGuardians[0];
                float range = guardian.range;
                
                Camera cam = Camera.main;
                
                Vector3 worldPosCenter = tile.transform.position;
                
                Vector3 worldPosEdge = worldPosCenter + Vector3.right * range;
                
                Vector3 screenCenter = cam.WorldToScreenPoint(worldPosCenter);
                Vector3 screenEdge = cam.WorldToScreenPoint(worldPosEdge);
                
                float diameterInPixels = Vector2.Distance(screenCenter, screenEdge) * 2f * 3.65f;
                Debug.Log("Diameter: "+diameterInPixels);
                rangeCircleImage.rectTransform.sizeDelta = new Vector2(diameterInPixels, diameterInPixels);
            }
        }
    }
}