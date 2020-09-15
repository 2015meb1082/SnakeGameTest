using UnityEngine;
using System.Collections.Generic;
public class GridSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject gridTile;
    [SerializeField]
    private GameObject tileObjectsHolder;
    public int rows=10;
    public int columns =10;
    public int tileOffset =1;

    public List<GameObject> tilesList;
    public int tilesCount;
    // Start is called before the first frame update
    void Start()
    {
        tilesList = new List<GameObject>();
        SpawnGrid();
        tilesCount = tilesList.Count;
    }

    //Spawn Grid  O(rows X Columns) - Time complexity
    private void SpawnGrid(){
        for(int r=0;r<rows;r++){
            //Color randomRowColor = Random.ColorHSV(0f,1.0f,0.73f,0.73f,1.0f,1.0f,1.0f,1.0f);
            for(int c=0;c<columns;c++){
                Vector3 position = new Vector3(r*tileOffset,0,c*tileOffset);
                SpawnTile(position);
            }
        }
    }

    //Spawn Tile at position
    private void SpawnTile(Vector3 position){
        GameObject obj = Instantiate(gridTile,position,Quaternion.identity);
        obj.transform.parent = tileObjectsHolder.transform;
        tilesList.Add(obj);
        Debug.Log("Tiles list Count initially: "+tilesList.Count);
    }

    // Get the tile at a particular rowNumber and columnNumber
    public GameObject GetTileAt(int rowNumber,int columNumber){
        if(rowNumber>=rows || columNumber>=columns){
            Debug.LogWarning("Row number invalid");
            return null;
        }
        
        if(tilesList.Count!=0){
            int index = rowNumber*columns + columNumber;
            GameObject obj =tilesList[index];
            //obj.GetComponent<Renderer>().material.color = Color.red;
            return obj;
        }
        Debug.Log("Empty List");
        return null;
    }

#region SpawnTile Override
    //Override for Spawn Tile in case we want random row color
    private void SpawnTile(Vector3 position,Color randomRowColor){
        GameObject obj = Instantiate(gridTile,position,Quaternion.identity);
        obj.transform.parent = tileObjectsHolder.transform;
        obj.GetComponent<Renderer>().material.color = randomRowColor;
    }
#endregion

    //To find the grid center
    public Vector3 GridCenter(){
        float x= (rows%2==0)?(rows/2 - tileOffset/2f):rows/2;
        float z= (columns%2==0)?(columns/2 - tileOffset/2f):columns/2;
        return new Vector3(x,0,z);
    }
}
