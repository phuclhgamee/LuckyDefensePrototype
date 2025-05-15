using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class GridSpawner : MonoBehaviour
    {   
        [SerializeField] private Tile tilePrefab;
        [SerializeField] private RectTransform gridSample;
        [SerializeField] private Transform spawnPoint;
        
        [SerializeField] private TileManager tileManager;
        [SerializeField] private GuardianManager guardianManager;
        
        [Header("Grid Config")]
        public int columns = 6;
        public int rows = 3;
        public float width;
        public float height;

        void Start()
        {
            Initialize();
            tileManager.Initialize();
            guardianManager.Initialize();
            SpawnTiles();
        }
        private void Initialize()
        {
            Vector3[] corners = new Vector3[4];
            gridSample.GetWorldCorners(corners);
            //Debug.Log(corners[0]+","+corners[1]+","+corners[2]+","+corners[3]);
            width = Vector3.Distance(corners[0], corners[3]);
            height = Vector3.Distance(corners[0], corners[1]);
            
            //spawnPoint = corners[0];
            tilePrefab.Height = height;
            tilePrefab.Width = width;
        }
        void SpawnTiles()
        {
            float cellWidth = width / columns;
            float cellHeight = height / rows;
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    Vector3 spawnPos = spawnPoint.position+ new Vector3(col * cellWidth + cellWidth / 2f,-( row * cellHeight + cellHeight / 2f),0);
                    
                    Tile tile = Instantiate(tilePrefab, spawnPos, Quaternion.identity, transform);
                    tile.transform.localScale = new Vector3(0.8f,0.6f,1f);
                    
                    tile.Init(cellWidth, cellHeight);
                    tileManager.Tiles.Add(tile);
                }
            }
        }
        
    }
}

