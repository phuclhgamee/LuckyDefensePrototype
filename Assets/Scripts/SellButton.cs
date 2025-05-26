using System.Linq;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class SellButton : MonoBehaviour
    {
        [SerializeField] private TileManager tileManager;
        [SerializeField] private GuardianManager guardianManager;
        [SerializeField] private Tile tile;
        
        [Header("Events")]
        [SerializeField] private Event OnEnableMergeButtonEvent;
        [SerializeField] private Event OnCloseTileUIEvent;
        
        public void OnClick()
        {
            Guardian g = tile.standingGuardians.Last();
            tile.ClearGuardian(g);
            guardianManager.summonedGuardians.Remove(g);
            //tile.standingGuardians.Remove(g);
            // for (int i = 0; i < tile.transform.childCount; i++)
            // {
            //     if (i == tile.transform.childCount - 1)
            //     {
            //         Destroy(tile.transform.GetChild(i).gameObject);
            //     }
            // }
            OnCloseTileUIEvent.Raise();
        }
    }
}