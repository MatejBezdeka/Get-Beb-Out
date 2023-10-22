using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playBtn;
    public Button exitBtn;
    public Button soundBtn;
    void Start()
    {
        playBtn.onClick.AddListener(PlayButton);
    }
    void PlayButton() {
        SceneManager.LoadScene("Scenes/MapScene");
        
        //switch to next scene
    }
    void ExitButton()
    {
        Application.Quit();
    }
}
