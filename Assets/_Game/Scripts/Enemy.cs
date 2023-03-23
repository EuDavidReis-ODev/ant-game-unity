using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    private Animator enemyAnimator;

    [SerializeField] private GameObject[] sprites;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        sprites[0] = this.transform.GetChild(0).gameObject;
        sprites[1] = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
        AnimationSpeed();
    }

    private void Moviment(){
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }

    private void AnimationSpeed(){
        enemyAnimator.SetFloat("Speed",speed);
    }

    public void Death(){
        speed = 0f;
        sprites[0].gameObject.SetActive(false);
        sprites[1].gameObject.SetActive(true);
        Destroy(this.gameObject,Random.Range(2.5f,5f));
    }
}
