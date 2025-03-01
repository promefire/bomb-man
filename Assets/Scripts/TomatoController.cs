using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TomatoController : MonoBehaviour
{

    public float speed = 5f;
    public int bombNum ;
    public int bombPower;
    public int curBombNum;
    public float bombBoomTime = 2f;


    private Animator anim;//获取动画组件 

    public GameObject bombPrefab;

    private   Vector2 lookDirection = new Vector2(1,0);//默认朝右  

    Rigidbody2D rbody;//刚体组件
    // Start is called before the first frame update
    void Start()
    {
        bombNum = 1;
        bombPower = 2;
        curBombNum = bombNum;

        

        anim = GetComponent<Animator>();

        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");//控制水平
        float moveY = Input.GetAxisRaw("Vertical");//W:1,S:-1;
        Vector2 moveVector = new Vector2(moveX,moveY);
        if(moveVector.x != 0 || moveVector.y != 0 ){
            lookDirection = moveVector;
        }
        anim.SetFloat("moveX",lookDirection.x);
        anim.SetFloat("moveY",lookDirection.y);
        // anim.SetFloat("Speed",moveVector.magnitude);//取向量长度



        Vector2 position = rbody.position;
        position += moveVector * speed *Time.deltaTime;
        rbody.MovePosition(position);//更新刚体位置
        CreateBomb();
        
   
    }

    public void CreateBomb(){
         if(Input.GetKeyDown(KeyCode.Space) && curBombNum > 0 ){
        GameObject bomb = Instantiate(bombPrefab,rbody.position,Quaternion.identity);//参数分别是对象、位置、方向（默认方向）
        bomb.GetComponent<BombController>().Init(bombPower,2);
        }
    }

    public void ChangeCurBombNum(int amount){
        curBombNum = Math.Clamp(curBombNum += amount,0,bombNum);
    }


    public void ChangeNum(int amount){
        bombNum += amount;
        curBombNum += amount;
    }

    public void ChangeSpeed(float amount){
        speed += amount;
    }

    public void ChangePower(int amount){
        bombPower += amount;
    }


    

}
