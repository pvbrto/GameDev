using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 6.0f;
    private Vector2 direction;

    public void Initialize(Vector2 dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Se tocar a parte inferior da tela, destrói o míssil
        if (transform.position.y <= -5.0f) // Ajuste conforme o limite inferior
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.GetComponent<Player>().TakeDamage();
            Destroy(gameObject);
        }
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}