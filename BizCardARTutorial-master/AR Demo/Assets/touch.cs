using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour {

    public string tag = " ";
    public string EnterTrigger = " ";
    public string StayTrigger = " ";
    public string ExitTrigger = " ";

    //進入碰撞器的函數
    void OnTRiggerEnter(Collider col)
    //Collider col爲函數的參數，代表進入碰撞器的物體的信息
    {
        //判斷進入碰撞器的物體是否爲另一個模型，如果是
        if (col.gameObject.tag.CompareTo(tag) == 0)
        {
            //則播放自身動畫組件中的“獲取的動畫”
            gameObject.GetComponent<Animator>().Play(EnterTrigger);

            //給一個物體添加Audio Source組件：去掉Play On Awake,勾選Loop
            //兩個碰撞器接觸時開始播放音效
           // gameObject.GetComponent<AudioSource>().Play();
        }
    }

    //停留在碰撞器中的函數
    void OnTriggerStay(Collider col)
    {
        //判斷進入碰撞器的物體是否爲另一個模型，如果是
        if (col.gameObject.tag.CompareTo(tag) == 0)
        {
            //則播放自身動畫組件中的“獲取的動畫”
            gameObject.GetComponent<Animator>().Play(StayTrigger);
    
            //讓物體朝向碰撞到的模型位置
            gameObject.transform.LookAt(col.transform.position);
        }
    }

    //離開碰撞器中的函數
    void OnTriggerExit(Collider col)
    {
        //判斷離開碰撞器的物體是否爲另一個模型，如果是
        if (col.gameObject.tag.CompareTo(tag) == 0)
        {
            //則播放自身動畫組件中的“獲取的動畫”(也就是初始動畫)
            gameObject.GetComponent<Animator>().Play(ExitTrigger);

            //兩個碰撞器接離開時停止播放音效
            //gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
