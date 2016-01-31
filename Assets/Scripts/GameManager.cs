using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
        {
            var sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "MainMenu")
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (Input.GetButtonDown(Buttons.A))
        {
            var sceneName = SceneManager.GetActiveScene().name;
            if(sceneName == "MainMenu")
            {
                SceneManager.LoadScene("Playground");
            }
        }
    }
}
