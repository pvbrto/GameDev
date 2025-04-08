using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string dialogueLines;
    [SerializeField] private AudioClip ClickSFX;

    private bool isPlayerInTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInTrigger && Input.GetKeyDown(KeyCode.N) && dialogueBox.activeInHierarchy == false)
        {
            SoundController.FindSoundController().PlaySound(ClickSFX);
            dialogueBox.SetActive(true);
            dialogueText.text = dialogueLines;
            
        }
        else if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.N) && dialogueBox.activeInHierarchy == true)
        {
            SoundController.FindSoundController().PlaySound(ClickSFX);
            dialogueBox.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInTrigger = false;
            dialogueBox.SetActive(false);
        }
    }
}
