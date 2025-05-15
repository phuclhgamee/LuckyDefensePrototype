using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LuckyDenfensePrototype
{
    public class Tile: MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Canvas TileUICanvas;
        [SerializeField] private Button MergeButton;
        [SerializeField] private Button SellButton;
        [SerializeField] private Event CloseTileUIEvent;
        
        [NonSerialized] public List<Guardian> standingGuardians;
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

        public void OnPointerClick(PointerEventData eventData)
        {
            CloseTileUIEvent.Raise();
            Debug.Log("OnPointerClick");
            if (standingGuardians.Count > 0)
            {
                TileUICanvas.gameObject.SetActive(true);
            }
        }

        public void OnEnableMergeButton()
        {
            MergeButton.interactable = true;
            if (standingGuardians.Count < Const.MaxGuardiansInATile || standingGuardians[0].rarity == Rarity.Legendary)
            {
                MergeButton.interactable = false;
            }
        }

        public void CloseTileUI()
        {
            TileUICanvas.gameObject.SetActive(false);
        }
        
        public void ClearAllStandingGuardians()
        {
            standingGuardians.Clear();
            foreach (Transform child in transform)
            {
                if(child.GetComponent<Guardian>() != null)
                    Destroy(child.gameObject);
            }
        }
    }
}