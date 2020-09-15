using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed =6.0f;
    [SerializeField]
    private float rotationSpeed =50.0f;
    private Vector3 axisToRotatePlayerAbout;
    [SerializeField]
    private GridSpawner gridSpawner;
    public float playerYOffset =2.0f;
    [SerializeField]
    private SteeringWheel steeringWheel;
    private void Start() {
        gridSpawner = FindObjectOfType<GridSpawner>();
        transform.position = gridSpawner.GridCenter() + new Vector3(0,playerYOffset,0);
        axisToRotatePlayerAbout = Vector3.up;
            
    }
    private void Update() {
        transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);

        if (steeringWheel.smoothedInput !=0) {
            RotatePlayer();
        }
        
    }

    public void RotatePlayer(){
        float degreesMovePerSecond = steeringWheel.smoothedInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(axisToRotatePlayerAbout * degreesMovePerSecond, Space.Self);
    }

    #region Console Rotation Code
    private void ConsoleInputRotatePlayer(){
        float inputX = Input.GetAxisRaw("Horizontal");
        float degreesMovePerSecond = rotationSpeed*Time.deltaTime;
        if(inputX>0){
            //Rotate clockwise
            //transform.Rotate function actually does exactly same job for us.
            //transform.rotation *= Quaternion.AngleAxis(degreesMovePerSecond,Vector3.up);
            transform.Rotate(axisToRotatePlayerAbout,degreesMovePerSecond,Space.Self);
        }else if(inputX<0){
            //Rotate Anticlockwise
            transform.Rotate(axisToRotatePlayerAbout,-degreesMovePerSecond,Space.Self);
        }
        
    }
    #endregion
}


