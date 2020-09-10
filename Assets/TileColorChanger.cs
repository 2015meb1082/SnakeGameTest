using UnityEngine;

public class TileColorChanger : MonoBehaviour
{

    public bool isTileGreen =false;

    private void OnTriggerEnter(Collider other) {
        //If player enters the trigger
        if(other.gameObject.CompareTag("Player")){
            transform.GetComponent<Renderer>().material.color = Color.green;
            isTileGreen =true;
        }
    }
}
