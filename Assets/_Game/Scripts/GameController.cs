using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;

    [HideInInspector] public int enemyCount ,totalScore , highScore;
    
    private UIController uIController;

    public Transform allEnemiesParent;

    private Spawner spawner;


    [SerializeField]private AudioSource music;
    
    private void Awake() {
        uIController = FindObjectOfType<UIController>();
        spawner = FindObjectOfType<Spawner>();
        highScore = GetHighScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        ActiveDesactiveSpawner(false);
        music.volume = 0.5f;
    }

    public void Restart(){
        Time.timeScale = 1f;
        ActiveDesactiveSpawner(true);
        enemyCount = 0;
        totalScore = 0;
        uIController.txtScore.text = totalScore.ToString();
        DestroyAllEnemies();
    }

    public void StartGame(){
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString();
        ActiveDesactiveSpawner(true);
        music.volume = 0.25f;
    }

    public void BackToMainMenu(){
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString();
        ActiveDesactiveSpawner(false);
        spawner.gameObject.GetComponent<Spawner>().enabled = false;
        music.volume = 0.5f;
        DestroyAllEnemies();
    }

    public void DestroyAllEnemies(){
        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SaveScore(){
        if(totalScore>highScore){
            highScore = totalScore;
            PlayerPrefs.SetInt("highscore",highScore);
            uIController.txtHighScore.text = "Highscore: "+highScore.ToString();
        }
    }

    public int GetHighScore(){
            highScore =  PlayerPrefs.GetInt("highscore",0);
            return highScore;
    }

    public void DestroyEnemy(Collider2D target){
            enemyCount++;
            if(enemyCount < 5){
                uIController.imageLifes[enemyCount - 1 ].gameObject.SetActive(false);
            }else{
                uIController.imageLifes[enemyCount - 1 ].gameObject.SetActive(false);
                uIController.panelGameOver.gameObject.SetActive(true);
                SaveScore();
                DestroyAllEnemies();
                GameOver(); 
            }
            Destroy(target.gameObject);
    }

    public void GameOver(){
        Time.timeScale = 0f;
        ActiveDesactiveSpawner(false);
        uIController.txtFinalScore.text = "Score: "+totalScore.ToString();
    }

    public void ActiveDesactiveSpawner(bool active){
        spawner.gameObject.GetComponent<Spawner>().enabled = active;

    }
}
