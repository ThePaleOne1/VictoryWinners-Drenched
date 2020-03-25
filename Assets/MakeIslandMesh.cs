﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeIslandMesh : MonoBehaviour
{
    [SerializeField] bool makeMeshOnStart = false;

    // Start is called before the first frame update
    void Start()
    {
        if (makeMeshOnStart)
        {
            MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];

            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                

                i++;
            }
            transform.GetComponent<MeshFilter>().mesh = new Mesh();
            transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
            
        }
    }
}
