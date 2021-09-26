using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    [Header("所持しているアイテムの List")]
    public List<ItemData> itemDatasList = new List<ItemData>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// アイテム用 List にアイテムを追加
    /// </summary>
    /// <param name="itemData"></param>
    public void AddItemDataList(ItemData itemData)
    {
        // 所持しているアイテムか確認する
        if (itemDatasList.Exists(x => x.itemType == itemData.itemType))
        {
            return;
        }

        // 所持していないアイテムのみ追加
        itemDatasList.Add(itemData);
    }

    public void RemoveItemDatasList(ItemData itemData)
    {
        itemDatasList.Remove(itemData);
    }
}
