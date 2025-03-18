using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 3;
    public float speed = 5.0f;
    public GameObject missilePrefab;

    public static Player Instance;

    private float minX = -8.5f; // Limite esquerdo
    private float missileCoolDown = 0.5f;
    private float maxX = 8.5f;  // Limite direito

    void Awake()
    {
        // Check if there is no instance already and set this one as the instance.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireMissile();
        }
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // A/D ou ← →
        transform.position += Vector3.right * moveInput * speed * Time.deltaTime;

        // Limitar a posição do player na tela
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            transform.position.z
        );
    }

    void FireMissile()
    {
        if (Time.time < missileCoolDown) return;
        missileCoolDown = Time.time + 0.5f;
        Instantiate(missilePrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
    }

    public void TakeDamage()
    {
        health--;
        Debug.Log("Vida do jogador: " + health);

        if (health <= 0)
        {
            Debug.Log("O jogador foi derrotado!");
            SceneManager.LoadScene("Lose");
        }
    }
}