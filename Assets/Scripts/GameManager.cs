using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject inGamePanel;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GridSpawner gridSpawner;
    public int score;
    public bool gameOver;

    public int greenTileCounter=0;
    
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private float gameOverCheckWaitingTime=0.1f;

    #region Singleton
    public static GameManager Instance;
    private void Awake() {
        if(Instance!=null){
            Destroy(gameObject);
        }else{
            //DontDestroyOnLoad()
            Instance=this;
        }
    }
    #endregion

    private void Start(){
        gridSpawner = FindObjectOfType<GridSpawner>();
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale =1;
    }

    //Update is called every frame
    private void Update()
    {
        //Check here if count of green tiles is equal to tilesList size ,i.e all tiles are green or not
        if (greenTileCounter == gridSpawner.tilesCount) {
            GameOver();
        }
    }

    public void IncreaseScore(){
        score+=1;
        scoreText.text =score.ToString();
    }

    public void GameOver(){
        Time.timeScale =0.5f;
        gameOver=true;
        gameOverPanel.SetActive(true);
    }
    public void PauseGame(){
        pausePanel.SetActive(true);
        gameOverPanel.SetActive(false);
        Time.timeScale =0;
    }
    public void ResumeGame(){
        pausePanel.SetActive(false);
        Time.timeScale =1;
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale =1;
    }

}
