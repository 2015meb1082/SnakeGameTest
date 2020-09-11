using UnityEngine.EventSystems;
using UnityEngine;

//Using the Event system interfaces to check if a UI element is clicked
// Since we are only using graphic raycaster on canvas
public class SliderController : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public float rotateSpeed=10f;
    private Vector3 axis;
    [SerializeField]
    private RectTransform rectTransform;

    private float initialPixelPosition;
    private float lastX;
    public bool moveClockWise;
    public bool canMove=false;

    [SerializeField]
    private Camera mainCamera;
    
    private void Start() {
        
        mainCamera = Camera.main;
        Debug.Log("Hello from Slider controller script");
        rectTransform = GetComponent<RectTransform>();   
        axis =  new Vector3(0,0,1);
        initialPixelPosition = mainCamera.WorldToScreenPoint(rectTransform.position).x;
    }


    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        Debug.Log(name + " Game Object Click in Progress"); 
        lastX = initialPixelPosition;
    }

    public void OnDrag(PointerEventData pointerEventData)
    {   
        canMove=true;
        // If difference is positive or not
        if(pointerEventData.position.x - lastX>=0){
            rectTransform.Rotate(axis,-rotateSpeed,Space.Self); 
            moveClockWise =true;
        }else{
            rectTransform.Rotate(axis,rotateSpeed,Space.Self);
            moveClockWise =false;
        }
        
        lastX = pointerEventData.position.x;
    }

  
    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        canMove=false;
        Debug.Log(name + " No longer being clicked");
        rectTransform.rotation = Quaternion.identity;
        lastX =initialPixelPosition;

    }

}
