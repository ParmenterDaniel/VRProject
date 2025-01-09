using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddPapersCollected : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    public AudioSource audioSource;
    public AudioClip clip;

    public void collectPaper()
    {
        if (gameManager != null)
        {
            gameManager.GetComponent<GameVariables>().collectPaper();
            Destroy(gameObject);
        }
        if(audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
