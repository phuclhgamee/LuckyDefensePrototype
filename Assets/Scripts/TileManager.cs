using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LuckyDenfensePrototype
{
    [CreateAssetMenu(fileName = "TileManager", menuName = "Manager/TileManager")]
    public class TileManager : ScriptableObject
    {
        [SerializeField] private GuardianManager guardianManager;
        [NonSerialized] public List<Tile> Tiles;

        public void Initialize()
        {
            Tiles = new List<Tile>();
        }

        public Tile GetSummonedTile(Guardian guardian)
        {
            var summonedGuardian = guardianManager.summonedGuardians;
            var existedGuardian = summonedGuardian
                .FirstOrDefault(x=>x.GetType() == guardian.GetType()
                                   && x.Tile.standingGuardians.Count != Const.MaxGuardiansInATile );

            if (existedGuardian !=null)
            {
                return existedGuardian.Tile;
            }
            
            return Tiles.Where(x => (x.standingGuardians == null || x.standingGuardians.Count == 0))
                .FirstOrDefault();
        }

        public Vector3 GetSummonedPosition(Tile tile)
        {
            if (tile.standingGuardians.Count == 1)
            {
                return tile.transform.position + new Vector3(tile.Width/10,0,0);
            }
            else if (tile.standingGuardians.Count == 2)
            {
                return tile.transform.position + new Vector3(-tile.Width/10,-tile.Height/10,0);
            }
            
            return tile.transform.position + new Vector3(-tile.Width/10,tile.Height/10, 0);
        }
    }
}