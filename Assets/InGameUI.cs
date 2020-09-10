using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private int score =0;
    public static InGameUI Instance;

#region Singleton
    private void Awake(){

        if(Instance!=null){
            Destroy(gameObject);
        }else{
            Instance =this;
        }
    }
#endregion

    public void IncreaseScore(){
        score+=1;
        scoreText.text =score.ToString();
    }
    
}
