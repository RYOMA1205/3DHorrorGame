using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMType
{
    ChaseBGM,WanderBGM
}

// RepuireConponent属性はtypeofの括弧の中で指定したコンポーネントやスクリプトを自動的にアタッチしてくれる
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    // シングルトンクラスの為の変数
    // シングルトンクラスは複数存在せず一つのみ存在する
    public static SoundManager instance;

    // CDの役割
    public AudioClip[] bgms;

    // CDプレイヤーの役割
    public AudioSource bgmPlayer;

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

    /// <summary>
    /// BGMを再生する(専用の)
    /// clipはAudioSource内の音源を登録する場所
    /// </summary>
    /// <param name="nextBGMType"></param>
    public void PlayBGM(BGMType nextBGMType)
    {
        bgmPlayer.clip = bgms[(int)nextBGMType];
        bgmPlayer.Play();
    }
}
