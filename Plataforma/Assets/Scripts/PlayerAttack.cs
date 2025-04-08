using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int attackDamage;
    [SerializeField] private float time;    
    [SerializeField] private float startAttackTime;    
    [SerializeField] private AudioClip AttackSound;
    
    private Animator animator;
    private PolygonCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            SoundController.FindSoundController().PlaySound(AttackSound);
            animator.SetTrigger("Attack");
            StartCoroutine(StartAttack());
        }
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startAttackTime);
        collider2D.enabled = true;
        StartCoroutine(DisableCollider());
    }

    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<Enemy>().BossTakeDamage(attackDamage);
        }

    }
}
