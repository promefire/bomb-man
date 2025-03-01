using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        TomatoController pc = other.GetComponent<TomatoController>();
        if(pc != null){
            
            pc.ChangeSpeed(1);   
            // Instantiate(collectEffect,transform.position,Quaternion.identity);
            // AudioManager.instance.AudioPlay(collectClip);//播放音效/
            Destroy(this.gameObject);
            
            Debug.Log("玩家速度加一");
        }
    }
}
