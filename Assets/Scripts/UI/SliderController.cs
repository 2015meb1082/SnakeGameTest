using UnityEngine.EventSystems;
using UnityEngine;

//Using the Event system interfaces to check if a UI element is clicked
// Since we are only using graphic raycaster on canvas
public class SliderController : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public float rotateSpeed=100.0f;
    private Vector3 axis;
    [SerializeField]
    private RectTransform rectTransform;
    
    private void Start() {
        rectTransform = GetComponent<RectTransform>();   
        axis =  new Vector3(0,0,1);
    }

    private void Update() {

        /*
        float angle = rotateSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(angle, axis); 
        */


    }

    private void SetRotation(PointerEventData data){
        rectTransform.rotation *= Quaternion.AngleAxis(-rotateSpeed,axis); 
    }


    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        Debug.Log(name + " Game Object Click in Progress");
        
    }

    public void OnDrag(PointerEventData pointerEventData)
    {   

        Debug.Log("Position "+ pointerEventData.position);
        
        SetRotation(pointerEventData);
    }

    
        
    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        Debug.Log(name + " No longer being clicked");
    }

}
