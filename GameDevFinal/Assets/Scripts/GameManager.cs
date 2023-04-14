using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}

    public static Dictionary<string, bool> evidence = new Dictionary<string, bool>();

    public static Dictionary<string, int> used_evidence = new Dictionary<string, int>();

    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;

    public TextMeshProUGUI totalText;
    private int total;

    public TextMeshProUGUI dateText;
    private static int days = 1;
    private static int month = 9;

    public GameObject failureScreen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        total = 0;
        foreach (var evi in used_evidence.Values) {
            total += evi;
        }
        totalText.text = "Score: " + total.ToString();
        dateText.text = "Date: " + month + "/" + days.ToString() + "/1811";
        if (days >= 30) {
            DeadlineMissed();
            days = 1;
            month = month + 1;
        }
    }

    public void DeadlineMissed() {
        failureScreen.SetActive(true);
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
        if (!evidence.ContainsKey(evi)) {
            evidence.Add(evi, true);
        } else {
            print("Already Added Evidence");
        }
    }

    public static void RemoveAllEvidence() {
        evidence.Clear();
    }

    public static void AddUsedEvidence(string evi, int score) {
        if (!used_evidence.ContainsKey(evi)) {
            used_evidence.Add(evi, score);
        } else {
            print("Already Added Evidence");
        }
    }

    public static void DeleteUsedEvidence(string evi) {
        if (used_evidence.ContainsKey(evi)) {
            used_evidence.Remove(evi);
        } else {
            print("That evidence is not being used");
        }
    }

    public static void RemoveAllUsedEvidence() {
        used_evidence.Clear();
    }

    public void AddDays(int n) {
        days = n + days;
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
        RemoveAllUsedEvidence();
        StartCoroutine(LoadYourAsyncScene(scene));
    }

}
