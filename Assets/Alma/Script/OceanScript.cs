using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanScript : MonoBehaviour
{
    public int Dimensions = 10;
    public float UVScale = 2f;
    public Octave[] Octaves;

    protected MeshFilter MeshFilter;
    protected Mesh mesh;
    


    // Start is called before the first frame update
    void Start()
    {
        //Mesh Setup
        mesh = new Mesh();
        mesh.name = gameObject.name;

        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTries();
        mesh.RecalculateBounds();

        MeshFilter = gameObject.AddComponent<MeshFilter>();
        MeshFilter.mesh = mesh;
               
    }

    private Vector3[] GenerateVertices()
    {
        var verts = new Vector3[(Dimensions + 1) * (Dimensions + 1)];

        
        for (int x = 0; x <= Dimensions; x++)
            for (int z = 0; z <= Dimensions; z++)
                verts[index(x, z)] = new Vector3(x, 0, z);

        return verts;
    }

    private int index(int x, int z)
    {
        return x * (Dimensions + 1) + z;
    }

    private int[] GenerateTries()
    {
        var tries = new int[mesh.vertices.Length * 6];

        
        for(int x = 0; x < Dimensions; x++)
        {
            for(int z = 0; z < Dimensions; z++)
            {
                tries[index(x, z) * 6 + 0] = index(x, z);
                tries[index(x, z) * 6 + 1] = index(x + 1, z + 1);
                tries[index(x, z) * 6 + 2] = index(x + 1, z);
                tries[index(x, z) * 6 + 3] = index(x, z);
                tries[index(x, z) * 6 + 4] = index(x, z + 1);
                tries[index(x, z) * 6 + 5] = index(x + 1 , z + 1);
            }
        }
        return tries;
    }

    // Update is called once per frame
    void Update()
    {
       var verts = mesh.vertices;
            for (int x = 0; x <= Dimensions; x++)
            {
                for (int z = 0; z <= Dimensions; z++)
                {
                    var y = 0f;
                    for (int o = 0; o < Octaves.Length; o++)
                    {
                        if (Octaves[o].alternate)
                        {
                            var perl = Mathf.PerlinNoise((x * Octaves[o].scale.x) / Dimensions, (z * Octaves[o].scale.y) / Dimensions) * Mathf.PI * 2f;
                            y += Mathf.Cos(perl + Octaves[o].speed.magnitude * Time.time) * Octaves[o].height;
                        }
                        else
                        {
                            var perl = Mathf.PerlinNoise((x * Octaves[o].scale.x + Time.time * Octaves[o].speed.x) / Dimensions, (z * Octaves[o].scale.y + Time.time * Octaves[o].speed.y) / Dimensions) - 0.5f;
                            y += perl * Octaves[o].height;
                        }
                    }

                    verts[index(x, z)] = new Vector3(x, y, z);
                }
            }
            mesh.vertices = verts;
            mesh.RecalculateNormals();
        
    }

    [Serializable]
    public struct Octave
    {
        public Vector2 speed;
        public Vector2 scale;
        public float height;
        public bool alternate;
    }

}
