using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject leftLight;
    [SerializeField] GameObject rightLight;

    public float health;
    public float maxHealth;
    public Image healthBar;
    Animator animator;

    BossAttackScript bossAttackScript;

    // Start is called before the first frame update
    void Start()
    {
        bossAttackScript = FindObjectOfType<BossAttackScript>();
        animator = GetComponent<Animator>();

        maxHealth = health;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.fillAmount -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        bossAttackScript.canMove = false;
        Debug.Log(bossAttackScript.canMove);
        leftLight.gameObject.SetActive(false);
        rightLight.gameObject.SetActive(false);
        animator.SetBool("isDead", true);
        Invoke("LoadNextScene", 1.5f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(4);
    }
}
