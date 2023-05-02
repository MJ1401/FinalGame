using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTesting : MonoBehaviour
{

    public static Dictionary<string, int> score_evi = new Dictionary<string, int>();

    public int eviScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int FindEviScore() {
        eviScore = 0;
        foreach (var v in score_evi.Values) {
            eviScore += v;
        }
        return eviScore;
    }

    public void AddScoring(string evi, int n) {
        if (!score_evi.ContainsKey(evi)) {
            score_evi.Add(evi, n);
        } 
    }

    public void RemoveScoring(string evi) {
        if (score_evi.ContainsKey(evi)) {
            score_evi.Remove(evi);
        }
    }
}
