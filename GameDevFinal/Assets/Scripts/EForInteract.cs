using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EForInteract : MonoBehaviour {

    public string text;

    private bool canCollectClue;

    public string evidence_name;

    private bool dialogShown = false;

    public void OnTriggerEnter2D(Collider2D collider2D) {
        print("Entered..");
        print("Press E to Interact.");
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)) {
            if (collider2D.gameObject.CompareTag("Player")) {
                // GameManager.Instance.DialogShow(text);
                canCollectClue = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            // GameManager.Instance.DialogHide();
            canCollectClue = false;
        }
    }

    void Start() {

    }

    void Update() {
        if (canCollectClue && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogShown)
            {
                GameManager.Instance.DialogShow(text);
                dialogShown = true;
            }
            else
            {
                collect();
                GameManager.Instance.DialogHide();
                dialogShown = false;
            }
        }
    }

    private void collect() {
        // set text to something like "can I help you? and can repeat"
        // add evidence to collection
        GameManager.AddEvidence(evidence_name);
        print("Evidence collected");
    }


}
