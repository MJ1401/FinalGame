using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceManager : MonoBehaviour
{

    public bool evidence1;
    public bool evidence2;

    // Start is called before the first frame update
    void Start()
    {
        evidence1 = false;
        evidence2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(evidence1);
    }

    public void UnlockEvidence1() {
        evidence1 = true;
    }

    public void UnlockEvidence2() {
        evidence2 = true;
    }
}
