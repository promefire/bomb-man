using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour
{
        public TomatoController tc ;
    //当动画播放完，就destroy

    void Start(){
        tc = FindObjectOfType<TomatoController>();
    }
    public void AniFin(){
        Destroy(gameObject);
        tc.ChangeCurBombNum(1);
    }
}
