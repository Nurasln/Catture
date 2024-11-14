using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackScript : MonoBehaviour
{
    public bool canAttack;
    public bool isAttacking;
    public bool isAttackEnd;
    public bool canMove = true;
    private int attackCount;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject leftPosition;
    [SerializeField] GameObject rightPosition;
    [SerializeField] GameObject targetLowPosition;

    [SerializeField] float secondAttackDelay = 1f;
    [SerializeField] float resetDelay = 4f;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float descendSpeed = 2f;
    [SerializeField] int bossHealth = 100;

    PlayerMovement playerMovement;

    Animator animator;
    BoxCollider2D boxCollider2D;

    Vector2 initialPosition;
    float initialYPosition;
    Vector2 targetPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        GetComponent<AudioSource>().Play();
        initialPosition = transform.position;
        initialYPosition = transform.position.y;

        playerMovement = FindObjectOfType<PlayerMovement>();
        targetPosition = initialPosition;
    }

    void Update()
    {
        if (!canMove)
        {
            return; // canMove false ise tüm hareket ve saldırı işlemlerini durdur
        }

        if (canMove && !playerMovement.isDead && bossHealth >= 50)
        {
            AttackingPath1();
        }
        else if (canMove && !playerMovement.isDead && bossHealth < 50)
        {
            AttackingPath2();
        }
        else
        {
            canAttack = false;
            isAttacking = false;
        }

        // Hareketi sadece canMove true olduğunda yap
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void AttackingPath1()
    {
        if (canAttack && !isAttacking && attackCount < 2)
        {
            if (transform.position.x > Player.transform.position.x)
            {
                targetPosition = new Vector2(leftPosition.transform.position.x, initialYPosition);
            }
            else if (Player.transform.position.x > transform.position.x)
            {
                targetPosition = new Vector2(rightPosition.transform.position.x, initialYPosition);
            }
            Attack1();
        }
        else if (isAttackEnd && attackCount < 2)
        {
            isAttackEnd = false;
            if (transform.position.x > Player.transform.position.x)
            {
                targetPosition = new Vector2(leftPosition.transform.position.x, initialYPosition);
            }
            else if (Player.transform.position.x > transform.position.x)
            {
                targetPosition = new Vector2(rightPosition.transform.position.x, initialYPosition);
            }
            Invoke("StartNextAttack", secondAttackDelay);
        }
    }

    void Attack1()
    {
        boxCollider2D.enabled = false;
        animator.SetBool("isAttacking", true);
        isAttacking = true;
        attackCount++;
    }

    void TakeDamage()
    {
        targetPosition = targetLowPosition.transform.position;
        boxCollider2D.enabled = true;
        Invoke("ResetAttackCycle", resetDelay);
    }

    void OnAnimationEnd()
    {
        animator.SetBool("isAttacking", false);
        isAttacking = false;
        canAttack = false;
        isAttackEnd = true;
    }

    void StartNextAttack()
    {
        boxCollider2D.enabled = false;
        animator.SetBool("isAttacking", true);
        isAttacking = true;
        attackCount++;
        Invoke("TakeDamage", 5f);
    }

    void ResetAttackCycle()
    {
        targetPosition = new Vector2(initialPosition.x, initialYPosition);
        attackCount = 0;
        canAttack = true;
        isAttacking = false;
        isAttackEnd = false;
    }

    void AttackingPath2()
    {
        // Boss canı 50'nin altındayken uygulanacak saldırı yolu için burası boş bırakıldı
    }
}
