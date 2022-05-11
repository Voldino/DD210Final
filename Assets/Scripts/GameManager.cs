using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TutorialPlayer player;
    GameObject pauseMenu;

    // Start is called before the first frame update

    private void Awake()
    {
        player = GetComponent<TutorialPlayer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isAlive == false){
            pauseMenu.SetActive(true);
        }
    }
}
