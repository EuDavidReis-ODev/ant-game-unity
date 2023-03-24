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
    
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        uIController = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart(){
        enemyCount = 0;
        totalScore = 0;
        uIController.txtScore.text = totalScore.ToString();
        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
