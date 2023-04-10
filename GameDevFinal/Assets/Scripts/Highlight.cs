using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highlight : MonoBehaviour
{

    [SerializeField] private Image myImage;
    [SerializeField] private Color myColor;
    private Color startcolor;

    private void Start() {

    }
    
    public void OnMouseEnter() {
        print("IM mouse over");
        startcolor = myImage.color;
        myImage.color = myColor;
    }

    public void OnMouseExit() {
        print("I'm mouse exit");
        myImage.color = startcolor;
    }
}
