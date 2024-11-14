using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackStarter : MonoBehaviour
{
    BossAttackScript bossAttackScript;

    void Start() 
    {
        bossAttackScript = FindObjectOfType<BossAttackScript>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            bossAttackScript.canAttack = true;
        }
    }
}
