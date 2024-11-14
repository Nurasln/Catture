using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneManager : MonoBehaviour
{
    [SerializeField] int whichIndexGonnaload;
    [SerializeField] float delayTime;


    void Start()
    {
        Invoke("LoadNextScene", delayTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(whichIndexGonnaload);
    }
}
