using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject mainMenuPanel;
    void Start(){
        instructionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void Play(){
        SceneManager.LoadScene(1);
        
    }
    public void Instructions(){
        instructionsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void Exit(){
        Application.Quit();
    }
    public void Back(){
        SceneManager.LoadScene(0);
    }
}