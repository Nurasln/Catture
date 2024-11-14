using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmokeSound : MonoBehaviour
{
    [SerializeField] float delayTime = 0f;
    
    void Start()
    {
        GetComponent<AudioSource>().Play();

        Invoke("LoadLastScene", delayTime);
    }

    void LoadLastScene()
    {
        SceneManager.LoadScene(8);
    }

   
}
