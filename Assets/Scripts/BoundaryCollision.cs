using UnityEngine;

public class BoundaryCollision : MonoBehaviour
{
    [SerializeField]
    private LayerMask collisionMask; 
    private void Start() {
        Debug.Log(Vector3.Reflect(new Vector3(-1,0,0),new Vector3(1,0,0)));
    }

    private void Update(){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(ray,out hit,0.5f,collisionMask)){
            Debug.Log("hello");
            Debug.DrawLine(transform.position, hit.point,Color.red);
            Vector3 planeNormal = hit.normal;
            Vector3 reflectedDir  = Vector3.Reflect(ray.direction,planeNormal);
            float rot = Mathf.Atan2(reflectedDir.x,reflectedDir.z)*Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0,rot,0);
        }
    }

}
