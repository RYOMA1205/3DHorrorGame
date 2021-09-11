using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool[] haveItems;

    // publicのメソッドは外部のスクリプトからも実行できる
    // 今回はFPSControllerでItemを拾ってそのアイテムに
    // アタッチされているItemDetailで設定しているItemTypeを
    // 引数としてもらう
    public void UpdateHaveItems(ItemType getItemType)
    {
        haveItems[(int)getItemType] = true;
    }
}
