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
        
        public List<Tile> Tiles;

        public void Initialize()
        {
            Tiles = new List<Tile>();
            Tiles.Clear();
        }

        public Tile GetSummonedTile(Guardian guardian)
        {
            var summonedGuardian = guardianManager.summonedGuardians;
            var existedGuardian = summonedGuardian.FirstOrDefault(x=>x.GetType() == guardian.GetType());

            if (existedGuardian !=null)
            {
                return existedGuardian.Tile;
            }

            Tile tile = Tiles.Where(x => (x.standingGuardians == null || x.standingGuardians.Count == 0))
                .OrderBy(_ => Random.value)
                .FirstOrDefault();
            
            return tile;
        }
    }
}