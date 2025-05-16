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
                Guardian guardian = tile.standingGuardians[0];
                float range = guardian.range;
                float diameter = range * 2f;
                transform.position = tile.transform.position;
                rangeCircleImage.rectTransform.sizeDelta = new Vector2(diameter, diameter);
            }
        }
    }
}