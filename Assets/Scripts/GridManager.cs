using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class GridManager : MonoBehaviour
    {   
        [SerializeField] private Tile tilePrefab;
        [SerializeField] private RectTransform gridSample;
        
        [SerializeField] private Transform spawnPoint;
        
        [Header("Grid Config")]
        public int columns = 6;
        public int rows = 3;
        public float width;
        public float height;

        void Start()
        {
            Init();
            SpawnTiles();
        }
        private void Init()
        {
            Vector3[] corners = new Vector3[4];
            gridSample.GetWorldCorners(corners);
            Debug.Log(corners[0]+","+corners[1]+","+corners[2]+","+corners[3]);
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
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Vector3 spawnPos = spawnPoint.position+ new Vector3(col * cellWidth + cellWidth / 2f, row * cellHeight + cellHeight / 2f,0);
                    
                    Tile tile = Instantiate(tilePrefab, spawnPos, Quaternion.identity, transform);
                    tile.transform.localScale = new Vector3(cellWidth,cellHeight,1f);

                    tile.Init(cellWidth, cellHeight);
                }
            }
        }
        
    }
}

