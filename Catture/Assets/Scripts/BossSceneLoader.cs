using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossSceneLoader : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "NextSceneTrigger")
        {
            SceneManager.LoadScene(3);
        }
    }
}
