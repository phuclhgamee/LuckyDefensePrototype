using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace LuckyDenfensePrototype
{
    public class RangeDisplayUI : MonoBehaviour
    {
        [SerializeField] private Tile tile;
        [SerializeField] private Image rangeCircleImage;
        [SerializeField] private Canvas canvas;
        public void RangeSetup()
        {
            if (tile.standingGuardians.Count > 0)
            {
                transform.position = tile.transform.position;
                Guardian guardian = tile.standingGuardians[0];
                float range = guardian.range;
                float diameter = range * 2f;
                
                Vector3 canvasScale = canvas.transform.localScale;
                Debug.Log(canvasScale);
                float correctedDiameter = diameter / canvasScale.x;
                
                rangeCircleImage.rectTransform.sizeDelta = new Vector2(correctedDiameter, correctedDiameter);
                
            }
        }
    }
}