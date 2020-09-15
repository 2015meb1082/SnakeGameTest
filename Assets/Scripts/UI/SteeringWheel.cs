using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class SteeringWheel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private bool wheelBeingHeld = false;
    [SerializeField]
    private float wheelAngle;
    [SerializeField]
    private float lastWheelAngle;

    [SerializeField]
    private float maxSteerAngle = 200.0f;
    [SerializeField]
    private float wheelResetSpeed = 400.0f;
    
    [SerializeField]
    private Vector2 wheelCenter;

    [SerializeField]
    private RectTransform wheelRectTransform;

    public float smoothedInput;

    private void Update()
    {
        //If wheel is not held down and wheel angle is >0
        if (!wheelBeingHeld && wheelAngle != 0) {
            float deltaAngle = wheelResetSpeed * Time.deltaTime;
            if (Mathf.Abs(deltaAngle) > Mathf.Abs(wheelAngle))
            {
                wheelAngle = 0;
            }
            else if (wheelAngle > 0)
            {
                wheelAngle -= deltaAngle;
            }
            else {
                wheelAngle += deltaAngle;
            }
        }

        wheelRectTransform.eulerAngles = new Vector3(0,0,-wheelAngle);
        smoothedInput = wheelAngle / maxSteerAngle;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On Pointer down");
        wheelBeingHeld = true;
        wheelCenter = RectTransformUtility.WorldToScreenPoint(eventData.pressEventCamera, wheelRectTransform.position);
        lastWheelAngle = Vector2.Angle(Vector2.up, (eventData.position - wheelCenter));    
    }
    public void OnDrag(PointerEventData eventData)
    {
        float newWheelAngle = Vector2.Angle(Vector2.up, (eventData.position - wheelCenter));

        if ((eventData.position - wheelCenter).sqrMagnitude >= 400f) {
            //If drag is right of the wheel center
            if (eventData.position.x > wheelCenter.x)
            {
                wheelAngle += newWheelAngle - lastWheelAngle;
            }
            else
            {
                wheelAngle -= newWheelAngle - lastWheelAngle;
            }
        }
        
        wheelAngle = Mathf.Clamp(wheelAngle, -maxSteerAngle, maxSteerAngle);
        lastWheelAngle = newWheelAngle;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnDrag(eventData);
        wheelBeingHeld = false;
        Debug.Log("On Pointer Up");
    }
}
