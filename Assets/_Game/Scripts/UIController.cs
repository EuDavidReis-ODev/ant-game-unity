using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    public TMP_Text txtScore,txtHighScore, txtFinalScore;

    public Image[] imageLifes;

    [SerializeField] private GameObject panelGame, panelPause, panelMainMenu;

    public GameObject panelGameOver;

    private GameController gameController;

    public GameObject allLifes;

    private void Awake() {
        gameController = FindObjectOfType<GameController>();
        txtHighScore.text = "Highscore: "+gameController.GetHighScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    public void UpdateScore(int score){
        txtScore.text = score.ToString();
    }

    public void ButtonPause(){
        Time.timeScale = 0f;
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
    }

    public void ButtonResume(){
        Time.timeScale = 1f;
        panelPause.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
    }

    public void ButtonRestart(){
        Time.timeScale = 1f;
        panelPause.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.Restart(); 
        panelGameOver.gameObject.SetActive(false);
        RefillLifes();
    }

    public void BackToMainMenu(){
        Time.timeScale = 1f;
        panelPause.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        gameController.BackToMainMenu();
        RefillLifes();
    }

    public void ButtonStart(){
        panelMainMenu.SetActive(false);
        panelGame.SetActive(true);
        gameController.StartGame();
    }

    public void ButtonExitGame(){
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskBack",true);
    }

    public void RefillLifes(){
        foreach (Transform child in allLifes.transform)
        {
            child.gameObject.SetActive(true);
        }  
    }

    private void Initialize(){
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
    }
}
