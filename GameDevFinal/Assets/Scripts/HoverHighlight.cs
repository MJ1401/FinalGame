using UnityEngine;
 using UnityEngine.EventSystems; // 1
 using UnityEngine.UI;

 public class HoverHighlight : MonoBehaviour
    , IPointerEnterHandler
     , IPointerExitHandler
 // ... And many more available!
 {
     Image sprite;
     Color target = Color.white;
 
     void Awake()
     {
         sprite = GetComponent<Image>();
     }
 
     void Update()
     {
         if (sprite)
             sprite.color = Vector4.MoveTowards(sprite.color, target, Time.deltaTime * 10);
     }
 
    //  public void OnPointerClick(PointerEventData eventData) // 3
    //  {
    //      print("I was clicked");
    //      target = Color.blue;
    //  }
 
    //  public void OnDrag(PointerEventData eventData)
    //  {
    //      print("I'm being dragged!");
    //      target = Color.magenta;
    //  }
 
     public void OnPointerEnter(PointerEventData eventData)
     {
        print("hover");
        Outline o = GetComponent<Outline>();
        o.enabled = true;
        //target = Color.yellow;
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
        Outline o = GetComponent<Outline>();
        o.enabled = false;
         target = Color.white;
     }
 }