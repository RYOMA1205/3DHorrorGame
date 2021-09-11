using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool[] haveItems;

    // 型名の最後に[]をつけることで配列にできる
    public ItemDetail[] itemPrefabs;

    public Transform leftBottomTran;
    public Transform rightTopTran;

    void Start()
    {
        // アイテムをランダムな位置に生成
        // ここでメソッドを実行する
        CreateRandomItems();
    }

    public void CreateRandomItems()
    {
        for (int i = 0; i < itemPrefabs.Length; i++)
        {
            // ランダムな位置を決める
            float X = Random.Range(leftBottomTran.position.x, rightTopTran.position.x);
            float Z = Random.Range(leftBottomTran.position.z, rightTopTran.position.z);

            Vector3 RandomPos = new Vector3(X, 1.2f, Z);

            // ランダムな位置に生成する
            Instantiate(itemPrefabs[i], RandomPos, Quaternion.identity);
        }
    }

    // publicのメソッドは外部のスクリプトからも実行できる
    // 今回はFPSControllerでItemを拾ってそのアイテムに
    // アタッチされているItemDetailで設定しているItemTypeを
    // 引数としてもらう
    public void UpdateHaveItems(ItemType getItemType)
    {
        haveItems[(int)getItemType] = true;
    }
}
