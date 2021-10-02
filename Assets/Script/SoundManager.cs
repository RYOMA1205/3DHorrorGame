using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMType
{
    ChaseBGM,WanderBGM
}

// RepuireConponent������typeof�̊��ʂ̒��Ŏw�肵���R���|�[�l���g��X�N���v�g�������I�ɃA�^�b�`���Ă����
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    // �V���O���g���N���X�ׂ̈̕ϐ�
    // �V���O���g���N���X�͕������݂�����̂ݑ��݂���
    public static SoundManager instance;

    // CD�̖���
    public AudioClip[] bgms;

    // CD�v���C���[�̖���
    public AudioSource bgmPlayer;

    // �V���O���g���N���X���쐬���邽�߂̏���
    private void Awake()
    {
        // ���g���󂩊m�F���ċ�Ȃ玩�g�̃X�N���v�g������
        if (instance == null)
        {
            instance = this;

            // �V�[���J�ڂ��Ă��j�󂳂�Ȃ��Q�[���I�u�W�F�N�g������
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// BGM���Đ�����(��p��)
    /// clip��AudioSource���̉�����o�^����ꏊ
    /// </summary>
    /// <param name="nextBGMType"></param>
    public void PlayBGM(BGMType nextBGMType)
    {
        bgmPlayer.clip = bgms[(int)nextBGMType];
        bgmPlayer.Play();
    }
}
