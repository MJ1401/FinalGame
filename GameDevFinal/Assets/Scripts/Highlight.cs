using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highlight : MonoBehaviour
{

    private Image myImage;
    private Color startcolor;

    private void Start() {

    }
    
    public void OnMouseEnter() {
        startcolor = GetComponent<Image>().color;
        GetComponent<Image>().color = Color.red;
    }

    public void OnMouseExit() {
        GetComponent<Image>().color = startcolor;
    }
}
