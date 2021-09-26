using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CreateAssetMenuは属性情報
// Unity内で右クリックした時に出てくる情報を増やせる
[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Create ItemDataSO")]
public class ItemDataSO : ScriptableObject
{
    // リストにして複数のアイテムデータを管理できる様にする
    // ScriptableObjectを使うことでデータベースを作れる
    public List<ItemData> itemDatasList = new List<ItemData>();
}
