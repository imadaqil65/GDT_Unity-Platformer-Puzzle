using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            BackToMain();
        }
    }

    public void GameStart(){
        SceneManager.LoadScene(1);
    }
    private void BackToMain(){
        //if(SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene(0);
    }

    public void Selectlevel(int level){
        SceneManager.LoadScene("Level"+level);
    }

    public void Quit(){
        Application.Quit();
    }
}
