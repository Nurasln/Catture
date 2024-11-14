using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSoundEffect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "BossDamageRange")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
