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

    // UIにアイテムのアイコンを生成する処理を追加する用
    [SerializeField]
    private ItemIconDetail itemIconDetailPrefab;

    [SerializeField]
    private List<ItemIconDetail> itemIconDetailsList = new List<ItemIconDetail>();

    [SerializeField]
    private Transform itemIconDetailTran;

    void Start()
    {
        // アイテムをランダムな位置に生成
        // ここでメソッドを実行する
        CreateRandomItems();

        // 処理追加
        // UIにアイテムアイコンの作成
        CreateItemIconDetails();
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

    
    public void UpdateHaveItems(ItemType getItemType, bool isSwitch = true)  // <= 第２引数を追加
    {
        haveItems[(int)getItemType] = isSwitch;                              // <= 代入する値を引数の情報に変更

        // ☆処理を追加
        if (isSwitch)
        {
            Debug.Log("アイテム取得 : " + getItemType.ToString());

            // 獲得したアイテムのアイコンを表示
            //itemIconDetailsList.Find(x => x.ItemNo == (int)getItemType).TransparentDisplayItemIcon(1.0f);

            // 獲得したアイテムのアイコンの透明度を戻す
            itemIconDetailsList.Find(Matrix4x4 => Matrix4x4.ItemNo == (int)getItemType).TransparentDisplayItemIcon(1.0f);
        }
        else
        {
            Debug.Log("アイテム喪失 : " + getItemType.ToString());
        }
    }

    private void CreateItemIconDetails()
    {
        // アイテム数だけ繰り返す
        for (int i = 0; i < haveItems.Length; i++)
        {
            // アイテムのアイコン作成
            ItemIconDetail itemIconDetail = Instantiate(itemIconDetailPrefab, itemIconDetailTran, false);

            // アイコンの設定
            itemIconDetail.SetUpItemIconDetail(i);

            // Listにアイコンを追加
            itemIconDetailsList.Add(itemIconDetail);
        }
    }
}
