using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
     private Rigidbody2D rb2d;
     

    public GameObject missilePrefab;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (Random.Range(0, 2) == 0)
        {
            
        FireMissile();
        }
    }


    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= -5.5f)
        {
            Destroy(gameObject);
            ScoreManager.Instance.AddPoints(-20);
        }

       
    }

    void FireMissile()
    {
        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
        missile.GetComponent<Missile>().Initialize(Vector2.left);
    }

    void GameOver()
    {
        Debug.Log("Game Over! O jogador perdeu.");
        Time.timeScale = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage();
            Destroy(gameObject);
        }
       
    }
}