using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private float flashTime;
    [SerializeField] private GameObject bloodEffect;
    [SerializeField] private GameObject dropCoin;
    [SerializeField] private GameObject floatingDamage;
    [SerializeField] private AudioClip HurtSound;
    [SerializeField] private GameObject WinUI;

    private Animator animator;



    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {
            if (gameObject.CompareTag("Boss"))
            {
			    Invoke("DestroyBoss", 2f);
            }
            else
            {
                Destroy(gameObject);
                Instantiate(dropCoin, transform.position, Quaternion.identity);
            }
 
        }
    }

    public void TakeDamage(int playerDamage)
    {
        GameObject damageText = Instantiate(floatingDamage, transform.position, Quaternion.identity) as GameObject;
        damageText.transform.GetChild(0).GetComponent<TextMesh>().text = playerDamage.ToString();
        health -= playerDamage;
        FlashColor(flashTime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        GameController.cameraShake.ShakeCamera();

        SoundController.FindSoundController().PlaySound(HurtSound);
       
    }

    public void BossTakeDamage(int playerDamage)
    {
        GameObject damageText = Instantiate(floatingDamage, transform.position, Quaternion.identity) as GameObject;
        damageText.transform.GetChild(0).GetComponent<TextMesh>().text = playerDamage.ToString();
        health -= playerDamage;
        FlashColor(flashTime);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        GameController.cameraShake.ShakeCamera();
        animator.SetTrigger("Hurt");
        SoundController.FindSoundController().PlaySound(HurtSound);
    }

    void FlashColor(float time)
    {
        spriteRenderer.color = Color.red;
        Invoke("ResetColor", time);
    }

    void ResetColor()
    {
        spriteRenderer.color = originalColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetType() == typeof(PolygonCollider2D))
        {
            playerHealth.TakeDamage(damage);
        }
    }

    void DestroyBoss()
    {
        Destroy(gameObject);
        WinUI.SetActive(true);
        Time.timeScale = 0f;
    }
}

