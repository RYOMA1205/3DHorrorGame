using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    // シングルトンクラスの為の変数
    public static DataBaseManager instance;

    // スクリプタブル・オブジェクト(データベース)を登録する
    public ItemDataSO itemDataSO;

    // シングルトンクラスを作成するための処理
    private void Awake()
    {
        // 中身が空か確認して空なら自身のスクリプトを入れる
        if (instance == null)
        {
            instance = this;

            // シーン遷移しても破壊されないゲームオブジェクトを作れる
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
