using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject completeCanvas;
    int activeScene;
    bool is_Paused = false;

    void Awake(){
        activeScene = SceneManager.GetActiveScene().buildIndex;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update(){
    if (Input.GetKeyDown(KeyCode.Escape))
        TogglePause();
    if (completeCanvas.activeSelf && Input.GetButtonDown("Submit"))
        Continue();
    }

    private void TogglePause(){
        is_Paused = !is_Paused;
        pauseCanvas.SetActive(is_Paused);
        Time.timeScale = is_Paused ? 0 : 1;
        //player.GetComponent<Movement>().enabled = !is_Paused;
    }

    public void ResetGame(){
        SceneManager.LoadScene(activeScene);
        Time.timeScale = 1f;
    }

    public void Continue(){
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1){
            Time.timeScale = 1;
            SceneManager.LoadScene(activeScene + 1);
        }
        else{
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        } 
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void Home(){
        SceneManager.LoadScene(1);
    }
}
