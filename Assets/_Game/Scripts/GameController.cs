using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;

    public int enemyCount;
    public int totalScore;
    
    private UIController uIController;

    public Transform allEnemiesParent;

    private Spawner spawner;
    
    private void Awake() {
        uIController = FindObjectOfType<UIController>();
        spawner = FindObjectOfType<Spawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        spawner.gameObject.GetComponent<Spawner>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart(){
        enemyCount = 0;
        totalScore = 0;
        uIController.txtScore.text = totalScore.ToString();
        DestroyAllEnemies();
    }

    public void StartGame(){
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled = true;
    }

    public void BackToMainMenu(){
        totalScore = 0;
        enemyCount = 0;
        uIController.txtScore.text = totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled = false;
        DestroyAllEnemies();
    }

    public void DestroyAllEnemies(){
        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }


}
