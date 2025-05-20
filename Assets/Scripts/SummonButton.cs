using System.Collections;
using System.Collections.Generic;
using LuckyDenfensePrototype;
using UnityEngine;
using UnityEngine.UI;
using Event = LuckyDenfensePrototype.Event;

namespace LuckyDefensePrototype
{
    public class SummonButton : MonoBehaviour
    {
        [SerializeField] Button summonButton;
        [SerializeField] private Text priceText;
        [SerializeField] private GuardianManager guardianManager;
        [SerializeField] private SummonPercentageManager summonPercentageManager;
        [SerializeField] private TileManager tileManager;
        
        [Header("Events")]
        [SerializeField] private Event AvailableMythicDisplayEvent;
        public void OnClick()
        {
            Rarity rarity = summonPercentageManager.GetSummonRarity();
            Guardian guardianPrefab = guardianManager.GetGuardianByRarity(rarity);
            Tile tile = tileManager.GetSummonedTile(guardianPrefab);
            Guardian newGuardian = Instantiate(guardianPrefab,tileManager.GetSummonedPosition(tile),Quaternion.identity
                ,tile.transform);
            tile.standingGuardians.Add(newGuardian);
            guardianManager.summonedGuardians.Add(newGuardian);
            newGuardian.Tile = tile;
            AvailableMythicDisplayEvent.Raise();
        }
    }
}

