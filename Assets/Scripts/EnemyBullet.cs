using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float life = 3f;
    public TutorialPlayer playerScript;

    private void Awake()
    {
        //GameObject player = GameObject.Find("player");
        //playerScript = player.GetComponent<TutorialPlayer>();
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            //playerScript.isAlive = false;

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
