using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour
{
    public GameObject Planet;

    public float speed = 4;
    public float jumpH = 1.2f;
    public bool isAlive = true;

    float gravity = 100;
    bool OnGround = false;

    float distanceToGround;
    Vector3 groundNormal;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;


    }

    // Update is called once per frame
    void Update()
    {
        //movement

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, 0);

        //Local rotation

        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

        //Jump

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    rb.AddForce(transform.up * 40000 * jumpH * Time.deltaTime);
        //}

        //GroundControl

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            distanceToGround = hit.distance;
            groundNormal = hit.normal;

            if (distanceToGround <= 0.2f)
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }
        }

        //Gravity

        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        if(!OnGround)
        {
            rb.AddForce(gravDirection * -gravity);
        }

        //

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        transform.rotation = toRotation;

    }
}
