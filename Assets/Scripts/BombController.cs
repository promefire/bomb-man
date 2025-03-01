using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BombController : MonoBehaviour
{

    Rigidbody2D rbody;
    private int power;             // 炸弹的范围
    // private float bombBoomTime = 2f;      // 炸弹的爆炸时间

    private float Timer ;
    public TomatoController tc ;
    public GameObject boomEffect;

    Wall wallScript;
    // wallScript = GameObject.FindObjectOfType<Wall>();

    public void Init(int power, int bombBoomTime){
        this.power = power;
        tc = FindObjectOfType<TomatoController>();
        tc.ChangeCurBombNum(-1);
        wallScript = GameObject.FindObjectOfType<Wall>();
        StartCoroutine("DealyBoom",bombBoomTime);

    }
    IEnumerator DealyBoom(int time){
        yield return new WaitForSeconds(time);
        Instantiate(boomEffect,transform.position,Quaternion.identity);
        // Boom(Vector2.left);
        // Boom(Vector2.right);
        // Boom(Vector2.up);
        // Boom(Vector2.down);
        // Destroy(this.gameObject);

        Vector2 explosionPosition = transform.position;
        Vector2[] directions = new Vector2[]
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };
        // 在每个方向上检测受影响的对象
// foreach (Vector2 direction in directions)
// {
//     bool blocked = false; // 是否被阻挡的标志位

//     for (int i = 1; i <= power; i++)
//     {
//         Vector2 pos = explosionPosition + direction * i;
//         RaycastHit2D hit = Physics2D.Raycast(pos, direction, 1f);

//         if (hit.collider != null)
//         {
//             Debug.Log("hit.collider 不为空")
//             if (hit.collider.CompareTag("iceCube"))
//             {
//                 Debug.Log("有冰块！！！");
//                 wallScript.WhenDelRandonCreate(hit.collider.gameObject);
//                 Destroy(hit.collider.gameObject); // 销毁冰块
//             }
//             else
//             {
//                 // 如果遇到其他类型的碰撞体，则标记为被阻挡
//                 blocked = true;
//             }
//             break; // 跳出循环，不再继续检测该方向上的碰撞体
//         }
//         else if (i == power)
//         {
//             blocked = true; // 如果到达炸弹范围的边界仍未遇到碰撞体，则标记为被阻挡
//         }
//     }

//     if (!blocked)
//     {
//         Boom(direction);
//     }
// }


foreach (Vector2 direction in directions)
    {
        bool blocked = false; // 是否被阻挡的标志位

        for (int i = 1; i <= power; i++)
        {
            Vector2 pos = explosionPosition + direction * i;
            RaycastHit2D hit = Physics2D.Raycast(pos, direction, 1f);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("iceCube"))
                {
                    Debug.Log("有冰块！！！");
                    wallScript.WhenDelRandonCreate(hit.collider.gameObject);
                    // Destroy(hit.collider.gameObject); // 销毁冰块
                }
                else
                {
                    // 如果遇到其他类型的碰撞体，则标记为被阻挡
                    blocked = true;
                }
                break; // 跳出循环，不再继续检测该方向上的碰撞体
            }
            else if (i == power)
            {
                blocked = true; // 如果到达炸弹范围的边界仍未遇到碰撞体，则标记为被阻挡
            }
        }

        if (!blocked)
        {
            Boom(direction);
        }
    }

    Destroy(this.gameObject);
    tc.ChangeCurBombNum(1);
}


    // private void Boom(Vector2 dir){
    //     for(int i = 1;i <= power;i++){
    //         Vector2 pos = (Vector2)transform.position + dir * i;
    //         GameObject effect = Instantiate(boomEffect);
    //         effect.transform.position = pos;   
    //     }
    // }
    private void Boom(Vector2 dir)
{
    for (int i = 1; i <= power; i++)
    {
        Vector2 pos = (Vector2)transform.position + dir * i;

        // 进行射线检测，判断是否遇到冰块
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, 1f);
        if (hit.collider != null && hit.collider.CompareTag("iceCube"))
        {
            Debug.Log("有冰块！！！");
            wallScript.WhenDelRandonCreate(hit.collider.gameObject);
            Destroy(hit.collider.gameObject); // 销毁冰块
            break; // 停止在该方向上的爆炸特效生成
        }

        GameObject effect = Instantiate(boomEffect);
        effect.transform.position = pos;
    }
}








    // void Start()
    // {
    //     Timer = 0;
    //     rbody = GetComponent<Rigidbody2D>();
    //     // tomatoController = GetComponent<TomatoController>();
    //     tc = FindObjectOfType<TomatoController>();
    //     tc.ChangeCurBombNum(-1);
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     Timer += Time.deltaTime;
    //     if(Timer > bombBoomTime){
    //         //炸！！ 特效
    //         Destroy(this.gameObject,0);
    //         tc.ChangeCurBombNum(1);
    //     }
    // }



}
