using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GridSpawner gridSpawner;
    private void Start() {
        transform.position = gridSpawner.GridCenter() + new Vector3(0,10,0);
        Camera camera = GetComponent<Camera>();
        camera.orthographicSize = gridSpawner.rows/2;
    }   

}
