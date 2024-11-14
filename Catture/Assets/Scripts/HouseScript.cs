using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    [SerializeField] GameObject E_Image;
    [SerializeField] ParticleSystem candiesParticule;

    bool isPlayerInRange = false;
    bool isPlayerTakeCandy = false;

    void Start()
    {
        candiesParticule = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (isPlayerInRange == true && !isPlayerTakeCandy)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("You entered the house");
                GetComponent<AudioSource>().Play();
                E_Image.SetActive(false);
                candiesParticule.Play();
                isPlayerTakeCandy = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isPlayerTakeCandy)
        {
            E_Image.SetActive(true);
            isPlayerInRange = true;
        }

        else
        {
            E_Image.SetActive(false);
            isPlayerInRange = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            E_Image.SetActive(false);
            isPlayerInRange = false;
        }
    }
}
