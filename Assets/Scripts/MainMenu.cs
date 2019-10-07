using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Audio()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1);
        //DontDestroyOnLoad(this.gameObject);
        
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void BackToMenu()
    {
        
        SceneManager.LoadScene(0);
        Game.isPaused = false;



    }

    public void BackToMenu1()
    {
        SceneManager.LoadScene(0);
        
    }

    
}
