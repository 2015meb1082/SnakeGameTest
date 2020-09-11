using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject inGamePanel;
    [SerializeField]
    private GameObject pausePanel;

    public int score;
    public bool gameOver;

    #region Singleton
    public GameManager Instance;
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

        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void GameOver(){
        gameOver=true;
        gameOverPanel.SetActive(true);
    }
    public void PauseGame(){
        pausePanel.SetActive(true);
        Time.timeScale =0;
    }
    public void ResumeGame(){
        pausePanel.SetActive(false);
        Time.timeScale =1;
    }
    public void RestartGame(){
        SceneManager.LoadScene(0);
    }

}
