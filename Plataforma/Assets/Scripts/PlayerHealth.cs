using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] private int health;
	[SerializeField] private float HurtFlashTime;

	[SerializeField] private float InvincibilityTime;

	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private PolygonCollider2D polygonCollider2D;
	private float LastTime;

	// Start is called before the first frame update
	void Start()
	{
		
		HealthBarUI.maxHealth = health;
		HealthBarUI.currentHealth = health;
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		polygonCollider2D = GetComponent<PolygonCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{   

	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health < 0)
		{
			health = 0;
		}

		HealthBarUI.currentHealth = health;
			
		if (health <= 0)
		{
			health = 0;
			animator.SetTrigger("Die");
			Debug.Log("Player is dead");
			Invoke("DestroyPlayer", 1f);
		}

		FlashColor(HurtFlashTime);
		polygonCollider2D.enabled = false;
		StartCoroutine(Invincibility());
	}

	IEnumerator Invincibility()
	{
		yield return new WaitForSeconds(InvincibilityTime);
		polygonCollider2D.enabled = true;
	}

	void DestroyPlayer()
	{
		Destroy(gameObject);
		GameOver.PlayerIsDead = true;
	}

	void FlashColor(float HurtFlashTime)
	{
		spriteRenderer.color = Color.red;
		//animator.SetBool("Hurt", true);
		Invoke("ResetColor", HurtFlashTime);
	}

	void ResetColor()
	{
		spriteRenderer.color = Color.white;
		
	}
}
