using UnityEngine;

public class TileColorChanger : MonoBehaviour
{
    public bool stateGreen=false;
    private void OnTriggerEnter(Collider other) {
        //If player enters the trigger
        if(other.gameObject.CompareTag("Player")){
            transform.GetComponent<Renderer>().material.color = Color.green;
            stateGreen =true;
        }
    }
}
