using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDenfensePrototype
{
    public class MergeButton : MonoBehaviour
    {
        [SerializeField] private GuardianManager guardianManager;
        [SerializeField] private TileManager tileManager;
        [SerializeField] private Tile tile;
        
        [Header("Events")]
        [SerializeField] private Event OnEnableMergeButtonEvent;
        [SerializeField] private Event OnCloseTileUIEvent;
        [SerializeField] private Event AvailableMythicDisplayEvent;
        private Button mergeButton;

        private void Awake()
        {
            mergeButton = GetComponent<Button>();
        }
        public void OnEnable()
        {
            OnEnableMergeButtonEvent.Raise();
        }
        
        public void OnClick()
        {
            Guardian guardianPrefab = guardianManager.GetMergeGuardian(tile.standingGuardians);
            
            foreach (Guardian g in tile.standingGuardians)
                guardianManager.summonedGuardians.Remove(g);
            tile.ClearAllStandingGuardians();
            
            Tile mergedTile = tileManager.GetSummonedTile(guardianPrefab);
            Guardian mergeGuardian = Instantiate(guardianPrefab,tileManager.GetSummonedPosition(mergedTile) 
                ,Quaternion.identity,mergedTile.transform);
            guardianManager.summonedGuardians.Add(mergeGuardian);
            mergeGuardian.Tile = mergedTile;
            mergedTile.standingGuardians.Add(mergeGuardian);
            AvailableMythicDisplayEvent.Raise();
            OnCloseTileUIEvent.Raise();
        }
    }
}

