using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace LuckyDenfensePrototype
{
    public class MythicSummonButton : MonoBehaviour
    {
        [SerializeField] private GuardianManager guardianManager;
        [SerializeField] private TileManager tileManager;

        [SerializeField] private Event AvailableMythicDisplayEvent;
        public Image image;
        public Button button;
        public void Initialize(MythicGuardian mythicGuardian)
        {
            image.sprite = mythicGuardian.mythicData.sprite;
            button.onClick.AddListener(()=>OnClick(mythicGuardian));
        }

        public void OnClick(MythicGuardian mythicGuardian)
        {
            foreach (Guardian guardian in mythicGuardian.mythicData.requiredGuardians)
            {
                var existedGuardian = guardianManager.summonedGuardians
                    .FirstOrDefault(x=>x.guardianType == guardian.guardianType);
                if (existedGuardian != null)
                {
                    existedGuardian.Tile.ClearGuardian(existedGuardian);
                    guardianManager.summonedGuardians.Remove(existedGuardian);
                }
            }
            
            Tile mythicSummonTile = tileManager.GetSummonedTile(mythicGuardian);
            Guardian newMythicGuardian = Instantiate(mythicGuardian, mythicSummonTile.transform);
            newMythicGuardian.Tile = mythicSummonTile;
            mythicSummonTile.standingGuardians.Add(newMythicGuardian);
            guardianManager.summonedGuardians.Add(newMythicGuardian);
            
            AvailableMythicDisplayEvent.Raise();
        }
    }
}

