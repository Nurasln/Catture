using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainHouseEntry : MonoBehaviour
{
    [SerializeField] GameObject F_image;
    bool isFrontDoor;

    private void Update() 
    {
        if (isFrontDoor)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "DoorCollider")
        {
            F_image.SetActive(true);
            isFrontDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "DoorCollider")
        {
            F_image.SetActive(false);
            isFrontDoor = false;
        }
    }
}
