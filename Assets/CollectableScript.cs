using System;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    
    public float lifeTime =5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            //Increase the score
            InGameUI.Instance.IncreaseScore();
            Destroy(gameObject);
        }
    }
    
}
