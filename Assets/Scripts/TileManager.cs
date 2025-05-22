using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public Tile PointerDownTile { get; set; }
        public Tile PointerUpTile { get; set; }
        
        public void Initialize()
        {
            Tiles = new List<Tile>();
        }

        public Tile GetSummonedTile(Guardian guardian)
        {
            var summonedGuardian = guardianManager.summonedGuardians;
            
            var existedGuardian = summonedGuardian
                .FirstOrDefault(x=>x.guardianType == guardian.guardianType
                                   && x.Tile.standingGuardians.Count != Const.MaxGuardiansInATile);

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

        public Vector3 GetSwapPosition(Tile tile, int index)
        {
            if (index == 1)
            {
                return tile.transform.position + new Vector3(tile.Width/10,0,0);
            }
            else if (index == 2)
            {
                return tile.transform.position + new Vector3(-tile.Width/10,-tile.Height/10,0);
            }
            
            return tile.transform.position + new Vector3(-tile.Width/10,tile.Height/10, 0);
        }
        public void SwapGuardianTilePosition()
        {
            if (PointerUpTile != null && PointerDownTile != null)
            {
                SwapList<Guardian>(PointerUpTile.standingGuardians, PointerDownTile.standingGuardians);
                
                for (int i =0; i< PointerUpTile.standingGuardians.Count; i++)
                {
                    PointerUpTile.standingGuardians[i].Tile = PointerUpTile;
                    PointerUpTile.standingGuardians[i].transform.SetParent(PointerUpTile.transform);
                    PointerUpTile.standingGuardians[i].transform.position = GetSwapPosition(PointerUpTile, i);
                }

                for (int i =0; i< PointerDownTile.standingGuardians.Count; i++)
                {
                    PointerDownTile.standingGuardians[i].Tile = PointerDownTile;
                    PointerDownTile.standingGuardians[i].transform.SetParent(PointerDownTile.transform);
                    PointerDownTile.standingGuardians[i].transform.position = GetSwapPosition(PointerDownTile, i);
                }
            }
        }
        
        void SwapList<T>(List<T> listA, List<T> listB)
        {
            List<T> temp = new List<T>(listA);

            listA.Clear();
            listA.AddRange(listB);

            listB.Clear();
            listB.AddRange(temp);
        }
    }
}