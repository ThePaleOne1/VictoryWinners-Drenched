using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTerrainBlocky : MonoBehaviour
{
    
    [SerializeField] TerrainData terrainData;
    // Start is called before the first frame update
    void Start()
    {
        
        float[,] heights = terrainData.GetInterpolatedHeights(0,0,10000,10000,0.00001f,0.00001f);

        for (int i = 0; i < heights.Length - 2; ++i)
        {
            print("old: " + heights[i, i]);
            float y = heights[i, i];
            heights[i, i] = Mathf.RoundToInt(y);
            print("new: " + heights[i, i]);
        }

        terrainData.SetHeights(0, 0, heights);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
