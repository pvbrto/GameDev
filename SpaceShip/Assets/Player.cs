using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 3;
    public float speed = 5.0f;
    public GameObject missilePrefab;

    public static Player Instance;

    private float minY = -3.15f; // Limite esquerdo
    private float missileCoolDown = 0.2f;
    private float maxY = 3.15f;  // Limite direito

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
        float moveInput = Input.GetAxis("Vertical"); 
        transform.position += Vector3.up * moveInput * speed * Time.deltaTime;

        // Limitar a posição do player na tela
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );
    }

    void FireMissile()
    {
        if (Time.time < missileCoolDown) return;
        missileCoolDown = Time.time + 0.1f;
        Instantiate(missilePrefab, transform.position + Vector3.right * 0.5f, Quaternion.identity);
    }

    public void TakeDamage()
    {
        health--;
        Debug.Log("Vida do jogador: " + health);

        if (health <= 0)
        {
            Debug.Log("O jogador foi derrotado!");
            SceneManager.LoadScene("Lose");
            //Time.timeScale = 0;
        }
    }
}