using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string newGameLevel = "level";

    public void NewGameButton()
    {
        GetComponent<AudioSource>().Play();
        Invoke("LoadNextScene",1.5f);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
