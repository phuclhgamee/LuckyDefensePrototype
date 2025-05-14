using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Tile: MonoBehaviour
    {
        public float Height { get; set; }
        public float Width { get; set; }

        public void Init(float cellWidth, float cellHeight)
        {
            Height = cellHeight;
            Width = cellWidth;
        }
    }
}