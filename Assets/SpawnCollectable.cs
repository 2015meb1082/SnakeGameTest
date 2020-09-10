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
    private bool canSpawn=true;
    // Start is called before the first frame update
    void Start()
    {
        gridSpawner = GetComponent<GridSpawner>();
        maxColumn = gridSpawner.columns;
        maxRow = gridSpawner.rows;
    }

    private void Update() {
        if(Time.time> nextSpawnTime ){
            nextSpawnTime = Time.time +timeOfPizza;
            canSpawn =true;
        }

        int randomRow =Random.Range(0,maxRow);
        int randomColumn =Random.Range(0,maxColumn);
        GameObject randomObj = gridSpawner.GetTileAt(randomRow,randomColumn);
        if(!randomObj && !randomObj.GetComponent<TileColorChanger>().stateGreen && canSpawn){
            // Spawn the collectable there
            SpawnCollectableAt(randomRow,randomColumn);
        }
        
    }

    // Update is called once per frame
    void SpawnCollectableAt(int randomRow,int randomColumn)
    {
        canSpawn=false;
        GameObject collectableObj = Instantiate(collectable,new Vector3(randomColumn,0,randomRow),Quaternion.identity);
        Destroy(collectable,timeOfPizza);    
    }    
    
}
