using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddPapersCollected : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;

    public void collectPaper()
    {
        if (gameManager != null)
        {
            gameManager.GetComponent<GameVariables>().collectPaper();
            Destroy(gameObject);
        }
    }
}
