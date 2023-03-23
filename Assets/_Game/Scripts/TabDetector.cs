using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabDetector : MonoBehaviour
{
    private bool tapControl = false;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectTap();
    }

    private void DetectTap(){
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position),Vector2.zero);
            if(hit.collider != null){
                tapControl = false;
                TapObject(hit);
            }
        }
    }

    private void TapObject(RaycastHit2D hit){
        if(hit.collider.gameObject.CompareTag("Enemy") && !tapControl){
            tapControl = true;
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
            enemy.GetComponent<BoxCollider2D>().enabled = false;
            enemy.PlayAudio(tapControl);
            enemy.Death();
        }
    }
}
