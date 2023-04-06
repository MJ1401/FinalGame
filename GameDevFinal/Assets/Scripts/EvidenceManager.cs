using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvidenceManager : MonoBehaviour
{

    public bool evidence1;
    public bool evidence2;
    public bool evidence3;
    public bool evidence4;
    public bool evidence5;
    public bool evidence6;
    public bool evidence7;
    public bool evidence8;

    // Start is called before the first frame update
    void Start()
    {
        evidence1 = false;
        evidence2 = false;
        evidence3 = false;
        evidence4 = false;
        evidence5 = false;
        evidence6 = false;
        evidence7 = false;
        evidence8 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockEvidence1() {
        evidence1 = true;
    }

    public void UnlockEvidence2() {
        evidence2 = true;
    }

    public void UnlockEvidence3() {
        evidence3 = true;
    }

    public void UnlockEvidence4() {
        evidence4 = true;
    }

    public void UnlockEvidence5() {
        evidence5 = true;
    }

    public void UnlockEvidence6() {
        evidence6 = true;
    }

    public void UnlockEvidence7() {
        evidence7 = true;
    }

    public void UnlockEvidence8() {
        evidence8 = true;
    }
}
