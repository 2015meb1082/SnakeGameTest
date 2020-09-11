using UnityEngine;

public class TileColorChanger : MonoBehaviour
{
    [SerializeField]
    private GridSpawner gridSpawner;
    
    private void Start() {
        gridSpawner = FindObjectOfType<GridSpawner>();    
    }

    public bool isTileGreen =false;

    private void OnTriggerEnter(Collider other) {
        //If player enters the trigger
        if(other.gameObject.CompareTag("Player") && gridSpawner){
            transform.GetComponent<Renderer>().material.color = Color.green;
            isTileGreen =true;
            gridSpawner.tilesList.Remove(gameObject);
        }
    }
}
