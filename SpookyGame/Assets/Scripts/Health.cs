using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public bool isDead = false;
    PlayerMovement playerMovement;

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    
    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health) 
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i <numOfHearts)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }

        if(health <= 0)
        {
            isDead = true;
            Invoke("LoadNextScene", 3f);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(5);
    }
}
