
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string levelToLoad;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    { }
    //if we press the escape key
    public void OnPause(InputValue value)
    {
        if (isPaused == false)
        {
            //pause the game
            Time.timeScale = 0;
            //show our pause menu canvas
            GetComponent<Canvas>().enabled = true;
            isPaused = true;
        }

    }




    public void OnResume(InputValue value)
    {
        if (isPaused == true)
        {
            //unpause the game
            Time.timeScale = 1;
            GetComponent<Canvas>().enabled = false;
            isPaused = false;
        }
    }
    //continue playing the game... somehow?
    public void OnMainMenu(InputValue value)
    {
        if (isPaused == true)
        {
            //unpause the game
            Time.timeScale = 1;
            //load the main menu scene
            SceneManager.LoadScene(levelToLoad);
            isPaused = false;
        }
    }
}
   
