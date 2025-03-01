using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject numPrefab;
    public GameObject powerPrefab;
    public GameObject speedPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WhenDelRandonCreate(GameObject hit)
{
    Destroy(hit); // 销毁传递进来的碰撞对象

    // 在原地随机生成后三个游戏对象中的一个
    GameObject[] prefabs = { numPrefab, powerPrefab, speedPrefab ,null};
    int randomIndex = Random.Range(0, prefabs.Length);
    GameObject randomPrefab = prefabs[randomIndex];
    if (randomPrefab != null)
    {
        Instantiate(randomPrefab, hit.transform.position, Quaternion.identity);
    }
}

}
