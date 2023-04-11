using UnityEngine;
using UnityEngine.EventSystems; // 1
using UnityEngine.UI;
 

// https://answers.unity.com/questions/1095047/detect-mouse-events-for-ui-canvas.html
public class Highlight : MonoBehaviour
    , IPointerClickHandler // 2
    , IPointerEnterHandler
    , IPointerExitHandler
// ... And many more available!
{
    Image sprite;
    Color target = Color.red;
    private bool wasClicked = false;

    void Awake()
    {
        sprite = GetComponent<Image>();
    }

    void Update()
    {
        if (sprite)
            sprite.color = Vector4.MoveTowards(sprite.color, target, Time.deltaTime * 10);
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        print("I was clicked");
        if (wasClicked) {
            target = Color.red;
            wasClicked = false;
        } else {
            target = Color.green;
            wasClicked = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // target = Color.blue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!wasClicked) {
            target = Color.red;
        }
    }

    public void OnMouseUp() {
    print("Mouse Up Test");
    }
}