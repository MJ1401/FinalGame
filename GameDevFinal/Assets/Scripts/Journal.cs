using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{

    public static Journal Instance {get; private set;}

    public GameObject userInterface;
    public GameObject openedNotebook;
    public GameObject informationOne;
    private static bool infoOne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void openingJournal()
    {
        userInterface.SetActive(false);
        openedNotebook.SetActive(true);
        if(infoOne == true){
            informationOne.SetActive(true);
        }
    }

    public void closingJournal()
    {
        userInterface.SetActive(true);
        openedNotebook.SetActive(false);
    }

    public static void addToJournal(string evid){
        print("Made it to addToJournal");
        print(evid);
        if(evid == "informationOne"){
            print("Passed the check");
            infoOne = true;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
