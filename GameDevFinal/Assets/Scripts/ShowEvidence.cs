using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEvidence : MonoBehaviour
{

    public EvidenceManager evidenceManager;
    public GameObject evidence;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (evidenceManager.evidence1) {
            EvidenceAppear();
        }
    }

    public void EvidenceAppear() {
        print("I here now");
        evidence.SetActive(true);
    }
}
