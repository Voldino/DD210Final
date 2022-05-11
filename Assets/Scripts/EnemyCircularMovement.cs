using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class EnemyCircularMovement : MonoBehaviour
{
    public float minPushForce = 1.0f;
    public float maxPushForce = 200.0f;
    public float actualPushForce;
    public float minRadius = 7.0f;
    public float maxRadius = 20.0f;
    public float actualRadius;
    public float minStartDegree = .0f;
    public float maxStartDegree = 360.0f;
    public float actualStartDegree;
    public GameObject RotatePoint;

    Rigidbody PhysicsSystem;
    bool onConnection = true;

    private void Awake()
    {
        RotatePoint = GameObject.Find("RotateReferencePoint");

        actualPushForce = Random.Range(minPushForce, maxPushForce);
        Debug.Log("F value is " + actualPushForce);

        actualRadius = Random.Range(minRadius, maxRadius);
        Debug.Log("R value is " + actualRadius);

        actualStartDegree = Random.Range(minStartDegree, maxStartDegree);
        Debug.Log("Theta value is " + actualStartDegree);

    }
    void Start()
    {
        PhysicsSystem = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) == true)
        {
            onConnection = false;
            float V = Mathf.Sqrt((actualPushForce * actualRadius) / PhysicsSystem.mass);
            PhysicsSystem.velocity = gameObject.transform.right * V;
        }
    }

    private void FixedUpdate()
    {
        if (onConnection == true)
        {
            // Find Velocity =>  Velocity = SquareRoot( Force * Radius ) / Mass.
            float V = Mathf.Sqrt((actualPushForce * actualRadius) / PhysicsSystem.mass);

            // Find T  =>  T = ( 2 * PI * Radius ) / Velocity
            float T = (2 * Mathf.PI * actualRadius) / V;

            // Find Radian  =>  ChangedRadian = ( 2 * PI * t ) / T
            float CurrentTime = Time.timeSinceLevelLoad;
            float ChangedRadian = (2 * Mathf.PI * CurrentTime) / T;

            // Convert ChangedRadian to ChangedDegree
            float ChangedDegree = ChangedRadian * 180.0f / Mathf.PI;
            float FinalDegree = actualStartDegree + ChangedDegree;

            // Convert FinalDegree to FinalRadian
            float FinalRadian = FinalDegree * Mathf.PI / 180.0f;

            // Calculate Changed Position
            float ChangedPos_X = actualRadius * Mathf.Cos(FinalRadian);
            float ChangedPos_Y = actualRadius * Mathf.Sin(FinalRadian);

            // Apply Changed Position to this Object.
            gameObject.transform.position = RotatePoint.transform.position + new Vector3(ChangedPos_X, ChangedPos_Y, 0);

            // Apply Angle Z -> 90 Degree from Degree to Center.
            gameObject.transform.eulerAngles = new Vector3(0, 0, FinalDegree + 90.0f);
        }
    }
}
