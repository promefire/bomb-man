using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumCollectible : MonoBehaviour
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
        //检测一下与草莓碰撞的物体有没有挂载playercontroller脚本
        TomatoController pc = other.GetComponent<TomatoController>();
        if(pc != null){
            
            pc.ChangeNum(1);   
            // Instantiate(collectEffect,transform.position,Quaternion.identity);
            // AudioManager.instance.AudioPlay(collectClip);//播放音效/
            Destroy(this.gameObject);
            
            Debug.Log("玩家炸弹数加一");
        }
    }
}
