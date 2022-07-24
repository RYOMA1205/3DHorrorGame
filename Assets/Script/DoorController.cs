using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    // 移動とか回転の処理をするときにDOTweenを使う(transform変数を通して)

    // ドアの開閉判断用の変数
    public bool isDoorOpen;

    public void OpeningDoor()
    {
        // falseの時はドアが閉じている状態
        if (isDoorOpen == false)
        {
            // DOTweenなどでドアを回転させる
            // DOTweenは二つ引数を入れる
            // 第一引数は目標値、第二引数は目標地に行くまでの時間
            transform.DORotate(new Vector3(0, 75, 0), 1.0f);
            Debug.Log("ドアを開ける");

            isDoorOpen = true;
        }
        // trueの時はドアが開いている状態
        else
        {
            transform.DORotate(new Vector3(0, 0, 0), 1.0f);
            Debug.Log("ドアを閉める");

            isDoorOpen = false;
        }
    }
}
