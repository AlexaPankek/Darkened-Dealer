using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject pauseMenuGO;
    private PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = pauseMenuGO.GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(pauseMenu.isPaused)
            {
                pauseMenu.ResumeGame();
            }
            else
            {
                pauseMenu.PauseGame();
            }


        }
    }
}
