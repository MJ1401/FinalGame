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
    Color target = new Color(1f, 0f, 0f, 0.3f);
    private bool wasClicked = false;

    public string evidence;
    public int score;

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
            target = new Color(1f, 0f, 0f, 0.3f);
            wasClicked = false;
            GameManager.DeleteUsedEvidence(evidence);
        } else {
            target = new Color(0f, 1f, 0f, 0.3f);
            wasClicked = true;
            GameManager.AddUsedEvidence(evidence, score);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // target = Color.blue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!wasClicked) {
            target = new Color(1f, 0f, 0f, 0.3f);
        }
    }

    public void OnMouseUp() {
    print("Mouse Up Test");
    }
}