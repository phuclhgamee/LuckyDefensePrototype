using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LuckyDenfensePrototype
{
    public class Tile: MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        [Header("UI")]
        [SerializeField] private Canvas TileUICanvas;
        [SerializeField] private Button MergeButton;
        [SerializeField] private Button SellButton;
        [SerializeField] private RangeDisplayUI rangeDisplayUI;
        [Header("Managers")]
        [SerializeField] private TileManager tileManager;
        
        [Header("Events")]
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
        public void OnEnableMergeButton()
        {
            MergeButton.interactable = true;
            if (standingGuardians.Count < Const.MaxGuardiansInATile || standingGuardians[0].rarity == Rarity.Legendary)
            {
                MergeButton.interactable = false;
            }
            rangeDisplayUI.RangeSetup();
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
        public void OnPointerClick(PointerEventData eventData)
        {
            CloseTileUIEvent.Raise();
            Debug.Log("OnPointerClick");
            if (standingGuardians.Count > 0)
            {
                TileUICanvas.gameObject.SetActive(true);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
            if (standingGuardians.Count > 0)
            {
                tileManager.PointerDownTile = this;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("OnPointerUp");
            if (tileManager.PointerDownTile != null)
            {
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
                Collider2D collider = Physics2D.OverlapCircle(worldPosition, 0.001f, LayerMask.GetMask("Tile"));
                if (collider != null)
                {
                    Tile tile = collider.gameObject.GetComponent<Tile>();
                    if (tile != null)
                    {
                        if (tile != this)
                        {
                            tileManager.PointerUpTile = tile;
                            tileManager.SwapGuardianTilePosition();
                        }
                    }
                    tileManager.PointerDownTile = null;
                    tileManager.PointerUpTile = null;
                }
            }
        }
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if (standingGuardians.Count > 0)
            {
                Gizmos.DrawWireSphere(transform.position, standingGuardians[0].range);
            }
        }
    }
}