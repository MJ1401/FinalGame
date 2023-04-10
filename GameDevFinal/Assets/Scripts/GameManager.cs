using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}

    private static Dictionary<GameObject, bool> evidence = new Dictionary<GameObject, bool>();
    private int pieces_of_evidence = 8;

    // public GameObject dialogBox;
    // public TextMeshProUGUI dialogText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print(evidence);
        foreach (var evi in evidence.Keys) { // Learned from https://forum.unity.com/threads/c-dictionary-loop.337804/
            evi.SetActive(true);
        }
    }

    // public void DialogShow(string text) {
    //     dialogBox.SetActive(true);
    //     StopAllCoroutines();
    //     StartCoroutine(TypeText(text));
    // }

    // public void DialogHide(){
    //     dialogBox.SetActive(false);
    // }

    // IEnumerator TypeText(string text) {
    //     dialogText.text = "";
    //     foreach(char c in text.ToCharArray()) {
    //         dialogText.text += c;
    //         yield return new WaitForSeconds(0.02f);
    //     }
    // }

    public void AddEvidence(GameObject evi) {
        evidence.Add(evi, true);
        // DontDestroyOnLoad(evi);
    }

    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            // Destroy(gameObject);
        }
    }

    IEnumerator LoadYourAsyncScene(string scene) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while(!asyncLoad.isDone) {
            yield return null;
        }
        // DialogHide();
        // if(scene != "Menu") {
        //     mainScreen.SetActive(false);
        // }
    }

    public void ChangeScene(string scene){
        print(scene);
        StartCoroutine(LoadYourAsyncScene(scene));
    }

}
