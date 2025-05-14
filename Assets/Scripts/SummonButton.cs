using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using LuckyDenfensePrototype;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDefensePrototype
{
    public class SummonButton : MonoBehaviour
    {
        [SerializeField] Button summonButton;
        [SerializeField] private Text priceText;
        [SerializeField] private GuardianManager guardianManager;
        [SerializeField] private SummonPercentageManager summonPercentageManager;
        [SerializeField] private TileManager tileManager;

        public void OnClick()
        {
            Rarity rarity = summonPercentageManager.GetSummonRarity();
            Guardian guardianPrefab = guardianManager.GetGuardianByRarity(rarity);
            Tile tile = tileManager.GetSummonedTile(guardianPrefab);
            Guardian newGuardian = Instantiate(guardianPrefab,tile.transform.position,Quaternion.identity);
            tile.standingGuardians.Add(newGuardian);
            guardianManager.summonedGuardians.Add(newGuardian);
            newGuardian.Tile = tile;
            // Debug.Log("newGuardian type: " + newGuardian.GetType());
            // Debug.Log("summonedGuardians type: " + guardianManager.summonedGuardians.GetType());
        }
    }
}

