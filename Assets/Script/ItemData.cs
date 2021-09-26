using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    // MonoBehaviourを継承していないスクリプトはゲームオブジェクトにアタッチできない
    // StartやUpdate,ontriggerなどもつけれない
    // だから基本アイテムの情報管理とかを行う時に外す
    public int itemNo;

    public Sprite itemSprite;

    public ItemType itemType;
    

}
