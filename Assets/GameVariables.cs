using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    // Start is called before the first frame update
    public int numPapersCollected = 0;
    public GameObject endingWall;
    private bool end = false;
    public bool isHiding = false;

    public void collectPaper()
    {
        numPapersCollected++;
    }
    public void hide()
    {
        isHiding = !isHiding;
    }
    private void Update()
    {
        if (end)
            return;

        if (numPapersCollected >= 5)
        {
            end = true;
            if(endingWall != null)
                Destroy(endingWall);
        }
    }
}
