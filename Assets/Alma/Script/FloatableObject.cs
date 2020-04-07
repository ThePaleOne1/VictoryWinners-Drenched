using Drenched;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatableObject : MonoBehaviour
{
    // Properties
    public float AirDrag = 1;
    public float WaterDrag = 10;
    public Transform[] FloatPoints;

    // Components
    [SerializeField]
    public Rigidbody RB;
    public OceanScript Ocean;

    // Water LIne
    [SerializeField]
    public float Waterline;
    public Vector3[] WaterLinePoints;

    // Help Vectors
    [SerializeField]
    public Vector3 centerOffset;

    public Vector3 Center { get { return transform.position + centerOffset; } }

    // Start is called before the first frame update
    void Awake()
    {

        Ocean = FindObjectOfType<OceanScript>();
        RB = GetComponent<Rigidbody>();
        RB.useGravity = false;

        WaterLinePoints = new Vector3[FloatPoints.Length];
        for (int i = 0; i < FloatPoints.Length; i++)
            WaterLinePoints[i] = FloatPoints[i].position;
        centerOffset = PhysicsHelper.GetCenter(WaterLinePoints) - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
