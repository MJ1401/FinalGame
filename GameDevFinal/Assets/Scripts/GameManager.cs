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

    public GameObject Title;
    public GameObject InvesArea;
    public GameObject PostQuakeInves;
    public GameObject Credits;

    public TextMeshProUGUI totalText;
    private int total;


    public TextMeshProUGUI dateText;
    private int days = 1;
    private int month = 9;

    public static GameObject failureScreen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoreUpdate() {
        total = 0;
        foreach (var evi in used_evidence.Values) {
            total += evi;
        }
        totalText.text = "Score: " + total.ToString();
    }

    public void DateUpdate() {
        dateText.text = "Date: " + month + "/" + days.ToString() + "/1811";
        if (days >= 30) {
            DeadlineMissed();
            days = 1;
            month = month + 1;
        }
    }

    public static void DeadlineMissed() {
        failureScreen.SetActive(true);
    }

    public void ResetScene() {
        RemoveAllEvidence();
        RemoveAllUsedEvidence();
        days = 1;
        month = 9;
        ScoreUpdate();
        DateUpdate();
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
        // ScoreUpdate();
    }

    public static void DeleteUsedEvidence(string evi) {
        if (used_evidence.ContainsKey(evi)) {
            used_evidence.Remove(evi);
        } else {
            print("That evidence is not being used");
        }
        // ScoreUpdate();
    }

    public static void RemoveAllUsedEvidence() {
        used_evidence.Clear();
        // ScoreUpdate();
    }

    public void AddDays(int n) {
        days = n + days;
        // DateUpdate();
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
        //Play audio here
        yield return new WaitForSeconds(1.0f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while(!asyncLoad.isDone) {
            yield return null;
        }
        // DialogHide();
        // if(scene != "Menu") {
        //     mainScreen.SetActive(false);
        // }
    }

    public void ChangeUI(string UI) {
        if (UI == "TitleScreen") {
            dialogBox.SetActive(false);
            Title.SetActive(true);
            InvesArea.SetActive(false);
            PostQuakeInves.SetActive(false);
            Credits.SetActive(false);
        } else if (UI == "InvestigativeArea") {
            dialogBox.SetActive(false);
            Title.SetActive(false);
            InvesArea.SetActive(true);
            PostQuakeInves.SetActive(false);
            Credits.SetActive(false);
        } else if (UI == "GN_Test" || UI == "SampleScene") {
            dialogBox.SetActive(false);
            Title.SetActive(false);
            InvesArea.SetActive(false);
            PostQuakeInves.SetActive(false);
            Credits.SetActive(false);
        } else if (UI == "Credits") {
            dialogBox.SetActive(false);
            Title.SetActive(false);
            InvesArea.SetActive(false);
            PostQuakeInves.SetActive(false);
            Credits.SetActive(true);
        } else if (UI == "PostQuake") {
            dialogBox.SetActive(false);
            Title.SetActive(false);
            InvesArea.SetActive(false);
            PostQuakeInves.SetActive(true);
            Credits.SetActive(false);
        } else {
            dialogBox.SetActive(false);
            Title.SetActive(true);
            InvesArea.SetActive(false);
            PostQuakeInves.SetActive(false);
            Credits.SetActive(false);
        }
    }

    public void ChangeScene(string scene){
        print(scene);
        RemoveAllUsedEvidence();
        dialogBox.SetActive(false);
        Title.SetActive(false);
        InvesArea.SetActive(false);
        PostQuakeInves.SetActive(false);
        Credits.SetActive(false);
        StartCoroutine(LoadYourAsyncScene(scene));
    }

}
