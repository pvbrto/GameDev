using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
   [SerializeField] private AudioClip CoinPickUpSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            SoundController.FindSoundController().PlaySound(CoinPickUpSFX);
            CoinUI.currentCoinAmount += 1;
            Destroy(gameObject);
        }
    }
}
