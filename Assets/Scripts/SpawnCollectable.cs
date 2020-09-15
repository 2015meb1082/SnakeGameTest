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
    private float searchValidPosition = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        gridSpawner = GetComponent<GridSpawner>();
        maxColumn = gridSpawner.columns;
        maxRow = gridSpawner.rows;
        StartCoroutine(SpawnCollectableObject());
    }


    IEnumerator SpawnCollectableObject(){
        while(!GameManager.Instance.gameOver){
            Vector3 randomCoordinate = FindRandomValidPositionForSpawn();
            GameObject obj=Instantiate(collectable,randomCoordinate,Quaternion.identity);
            float collectableLifeTime = obj.GetComponent<CollectableScript>().lifeTime;
            Debug.Log(collectableLifeTime);
            yield return new WaitForSeconds(collectableLifeTime + waitTimeBeforeNextCollectableSpawn);
        }
    }

    //Returns a valid random coordinate if found else by default return a random coordinate 
    Vector3 FindRandomValidPositionForSpawn(){

        Vector3 randomValidCoordinate = new Vector3(Random.Range(0, maxColumn), 0, Random.Range(0, maxRow));
        while (searchValidPosition>0){
            int randomRow = Random.Range(0,maxRow-1);
            int randomCol = Random.Range(0,maxColumn-1);
            GameObject objAtRandomPosition = gridSpawner.GetTileAt(randomRow,randomCol);
            TileColorChanger tileColorChanger = objAtRandomPosition.GetComponent<TileColorChanger>();

            if (objAtRandomPosition && !tileColorChanger.isTileGreen)
            {
                randomValidCoordinate = new Vector3(randomCol, 0, randomRow);
            }

            searchValidPosition -= Time.deltaTime;
        }

        return randomValidCoordinate;
    }

    
}
