using UnityEngine;

public class BoundaryCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BoundaryBox")){
            ReflectSnake();
        }
    }
    private void ReflectSnake(){
        Vector3 currentEulerAngles = transform.eulerAngles;
        //Some bug is there. My calculation here is little off. Running out of time, will work later if time permits
        float finalYRotationInDegrees = 180-(currentEulerAngles.y%360f);
        Quaternion finalRotation =Quaternion.Euler(0,finalYRotationInDegrees,0);
        transform.rotation =finalRotation;
    }
}
