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

    public void audio()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(this.gameObject);
    }
        
}
