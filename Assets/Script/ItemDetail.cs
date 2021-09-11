using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetail : MonoBehaviour
{
    // アイテムの情報を貰ってる
    public ItemType itemType;

    // 拾ったアイテムの情報を戻り値で返してる
    public ItemType GetItem()
    {
        return itemType;
    }
}
