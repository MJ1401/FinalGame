using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}

    public static Dictionary<string, int[]> evidence = new Dictionary<string, int[]>();

    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DialogShow(string text) {
        dialogBox.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(TypeText(text));
    }

    public void DialogHide(){
        dialogBox.SetActive(false);
    }

    IEnumerator TypeText(string text) {
        dialogText.text = "";
        foreach(char c in text.ToCharArray()) {
            dialogText.text += c;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public static void AddEvidence(string evi) {
        int[] hold = new int[1];
        hold[0] = 0;
        if (!evidence.ContainsKey(evi)) {
            evidence.Add(evi, hold);
        } else {
            print("Already Added Evidence");
        }
    }

    public static void NewAddEvidence(string evi, int truth, int rating, int sold) {
        int[] data = new int[3];
        data[0] = truth;
        data[1] = rating;
        data[2] = sold;
        if (!evidence.ContainsKey(evi)) {
            evidence.Add(evi, data);
        } else {
            print("Already Added Evidence");
        }
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
