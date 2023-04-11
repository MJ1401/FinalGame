using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{

    public GameObject userInterface;
    public GameObject openedNotebook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void openingJournal()
    {
        userInterface.SetActive(false);
        openedNotebook.SetActive(true);
    }

    public void closingJournal()
    {
        userInterface.SetActive(true);
        openedNotebook.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
