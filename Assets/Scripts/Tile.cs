using System.Collections.Generic;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class Tile: MonoBehaviour
    {
        public List<Guardian> standingGuardians;
        public float Height { get; set; }
        public float Width { get; set; }

        public void Init(float cellWidth, float cellHeight)
        {
            Height = cellHeight;
            Width = cellWidth;
        }

        private void OnEnable()
        {
            standingGuardians = new List<Guardian>();
        }
    }
}