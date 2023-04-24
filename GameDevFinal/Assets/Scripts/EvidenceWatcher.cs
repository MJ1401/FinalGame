using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceWatcher : MonoBehaviour
{

    public GameObject[] evidence;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowEvidence();
    }

    public void ShowEvidence() {
        foreach (var evi in evidence) {
            if (GameManager.evidence.ContainsKey(evi.name)) { // Learned from https://code-maze.com/csharp-detect-dictionary-key-exists/
                evi.SetActive(true);
            } else {
                evi.SetActive(false);
            }
        }
    }
}
