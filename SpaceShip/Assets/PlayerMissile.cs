using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Se sair da tela, destruir o míssil
        if (transform.position.x >= 5.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ScoreManager.Instance.AddPoints(10);
            Destroy(other.gameObject); 
            Destroy(gameObject);       
        }
        // if (other.CompareTag("Type1"))
        // {
        //     ScoreManager.Instance.AddPoints(10);
        //     Destroy(other.gameObject); // Destrói o inimigo
        //     Destroy(gameObject);       // Destrói o míssil
        // }
        // if (other.CompareTag("Type2"))
        // {
        //     ScoreManager.Instance.AddPoints(20);
        //     Destroy(other.gameObject); // Destrói o inimigo
        //     Destroy(gameObject);       // Destrói o míssil
        // }
        // if (other.CompareTag("Type3"))
        // {
        //     ScoreManager.Instance.AddPoints(30);
        //     Destroy(other.gameObject); // Destrói o inimigo
        //     Destroy(gameObject);       // Destrói o míssil
        // }
        // if (other.CompareTag("Type4"))
        // {
        //     ScoreManager.Instance.AddPoints(30);
        //     Destroy(other.gameObject); // Destrói o inimigo
        //     Destroy(gameObject);       // Destrói o míssil
        // }
        // if (other.CompareTag("Boss"))
        // {
        //     ScoreManager.Instance.AddPoints(50);
        //     Destroy(other.gameObject); // Destrói o inimigo
        //     Destroy(gameObject);       // Destrói o míssil
        // }
    }
}