using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class changeText : MonoBehaviour
{
    public TextMeshPro textMesh;
    public GameVariables gameVariables;
    public int maxPapers = 5;

    // Update is called once per frame
    void Update()
    {
        int numPapers = gameVariables.numPapersCollected;
        textMesh.text = "Total Papers: " + numPapers + " " + "/ " + maxPapers;
    }
}
