using UnityEngine;

public class BoundaryBoxSpawner : MonoBehaviour
{
    private GridSpawner gridSpawner;
    //Since there is mismatch of size between default cube and given box
    [SerializeField]
    private float boxSizeCorrectiveMultiplier=4.0f;
    [SerializeField]
    private GameObject boundaryBoxPrefab;
    
    // Start is called once at the game start
    private void Start() {
        gridSpawner = GetComponent<GridSpawner>();    
        GameObject boxObject = Instantiate(boundaryBoxPrefab,Vector3.zero, Quaternion.identity);
        ResizeAndRepositionBoundarBox(boxObject);
    }   
    //For resizing and repositioning the bounding box
    private void ResizeAndRepositionBoundarBox(GameObject boxObject){

        //Calculate grid center with offset in mind
        Vector3 gridCenter = gridSpawner.GridCenter();
        Vector3 YScale =new Vector3(0,100,0);
        Vector3 boxNewScale = new Vector3(gridSpawner.rows,0,gridSpawner.columns)*boxSizeCorrectiveMultiplier + YScale;
        boxObject.transform.position = gridCenter;
        boxObject.transform.localScale = boxNewScale;
        boxObject.transform.parent = transform;
    } 

}
