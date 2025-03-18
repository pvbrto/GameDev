using UnityEngine;
using System.Collections;

public class BossShip : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade da nave chefe
    public float minSpawnTime = 5f; // Tempo mínimo para reaparecer
    public float maxSpawnTime = 10f; // Tempo máximo para reaparecer
    
    private float despawnX = 9f; // Posição X onde a nave desaparece
    private bool isActive = false; // Controle de movimento

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {
        if (isActive)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        // Se atingir o limite direito, aguarda antes de reaparecer
        if (transform.position.x >= despawnX)
        {
            isActive = false;
            transform.position = new Vector3(-15f, 4.5f, 0f); // Sai um pouco da tela antes de reaparecer
            StartCoroutine(SpawnRoutine());
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (true) // Garante que sempre reaparece
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // Define posição inicial no canto superior esquerdo
            transform.position = new Vector3(-9f, 4.5f, 0f);
            isActive = true; // Ativa o movimento
        }
    }
}