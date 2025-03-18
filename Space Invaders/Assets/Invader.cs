using UnityEngine;

public class Invader : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int stepCount = 0;
    private int maxSteps = 20;
    private float stepSize = 0.2f;
    private float moveTimer = 0.0f;
    private float moveInterval = 0.9f;  // Tempo inicial entre movimentos
    private float minMoveInterval = 0.2f; // Velocidade mínima permitida
    private float speedDecreaseFactor = 0.9f; // Redução progressiva da velocidade
    private float missileChance = 0.02f;

    public GameObject missilePrefab;

    private bool movingRight = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveInterval)
        {
            Move();
            moveTimer = 0.0f;

            if (Random.value < missileChance)
            {
                FireMissile();
            }
        }
    }

    void Move()
    {
        transform.position += (movingRight ? Vector3.right : Vector3.left) * stepSize;
        stepCount++;

        if (stepCount >= maxSteps)
        {
            stepCount = 0;
            movingRight = !movingRight;
            MoveDown();
        }
    }

    void MoveDown()
    {
        transform.position += Vector3.down * 0.2f;
        
        // Reduz o intervalo do movimento de forma progressiva, mas não abaixo do limite mínimo
        moveInterval = Mathf.Max(moveInterval * speedDecreaseFactor, minMoveInterval);
        
        if (transform.position.y <= -4.5f)
        {
            GameOver();
        }
    }

    void FireMissile()
    {
        GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
        missile.GetComponent<Missile>().Initialize(Vector2.down);
    }

    void GameOver()
    {
        Debug.Log("Game Over! O jogador perdeu.");
        Time.timeScale = 0;
    }
}