using System.Collections;
using UnityEngine;

public class SpawnCollectable : MonoBehaviour
{
    [SerializeField]
    private GameObject collectable;
    [SerializeField]
    private GridSpawner gridSpawner;
    private int maxColumn;
    private int maxRow;
    public float timeOfPizza =10.0f;
    private float nextSpawnTime=0f;
    [SerializeField]
    private bool canSpawn =true;
    [SerializeField]
    private float waitTimeBeforeNextCollectableSpawn =2.0f;
    // Start is called before the first frame update
    void Start()
    {
        gridSpawner = GetComponent<GridSpawner>();
        maxColumn = gridSpawner.columns;
        maxRow = gridSpawner.rows;
        StartCoroutine(SpawnCollectableObject());
    }


    IEnumerator SpawnCollectableObject(){
        while(true){
            Vector3 randomCoordinate = FindRandomValidPositionForSpawn();
            GameObject obj=Instantiate(collectable,randomCoordinate,Quaternion.identity);
            float collectableLifeTime = obj.GetComponent<CollectableScript>().lifeTime;
            Debug.Log(collectableLifeTime);
            yield return new WaitForSeconds(collectableLifeTime + waitTimeBeforeNextCollectableSpawn);
        }
    }

    //Returns a valid random coordinate which is valid
    Vector3 FindRandomValidPositionForSpawn(){
        Vector3 randomValidCoordinate =transform.position;
        while(true){
            int randomRow = Random.Range(0,maxRow);
            int randomCol = Random.Range(0,maxColumn);
            GameObject objAtRandomPosition = gridSpawner.GetTileAt(randomRow,randomCol);
            TileColorChanger tileColorChanger = objAtRandomPosition.GetComponent<TileColorChanger>();
        
            if(objAtRandomPosition && !tileColorChanger.isTileGreen){
                randomValidCoordinate = new Vector3(randomCol,0,randomRow);
                break;
            }
        }
        return randomValidCoordinate;
    }

    
}
