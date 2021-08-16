using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // 変数の宣言(アニメーター、AI)
    Animator animator;
    NavMeshAgent agent;

    public float walkingSpeed;

    // 列挙型の作成
    enum STATE {WANDER, CHASE};
    STATE state = STATE.WANDER;

    // 変数の宣言(プレイヤーオブジェクト格納 : 走るスピード)
    GameObject target;
    public float runSpeed;

    // 列挙型にコード追加記述

    // スタート時に変数にコンポーネントを格納
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void TurnOffTrigger()
    {
        animator.SetBool("Run", false);
    }

    // プレイヤーとの距離関数を作成
    float DistanceToPlayer()
    {
        return Vector3.Distance(target.transform.position, transform.position);
    }

    // 発見判定関数作成
    bool CanSeePlayer()
    {
        if (DistanceToPlayer() < 15)
        {
            return true;
        }

        return false;
    }

    // 見失ったか判定する関数
    bool ForGetPlayer()
    {
        if (DistanceToPlayer() > 20)
        {
            return true;
        }

        return false;
    }


    void Update()
    {
        switch(state)
        {
            case STATE.WANDER:
                TurnOffTrigger();

                if (CanSeePlayer())
                {
                    state = STATE.CHASE;
                }
                else if (Random.Range(0, 500) < 5)
                {
                    state = STATE.WANDER;
                }


                if (!agent.hasPath)
                {
                    float newX = transform.position.x + Random.Range(-5, 5);
                    float newZ = transform.position.z + Random.Range(-5, 5);

                    Vector3 NextPos = new Vector3(newX, transform.position.y, newZ);

                    agent.SetDestination(NextPos);
                    agent.stoppingDistance = 0;

                    TurnOffTrigger();

                    agent.speed = walkingSpeed;
                    animator.SetBool("Walk", true);
                }

                if (Random.Range(0, 500) < 5)
                {
                    agent.ResetPath();
                }
                break;

            case STATE.CHASE:

                agent.SetDestination(target.transform.position);
                agent.stoppingDistance = 3;

                TurnOffTrigger();

                agent.speed = runSpeed;
                animator.SetBool("Run", true);

                if (ForGetPlayer())
                {
                    agent.ResetPath();
                    state = STATE.WANDER;
                }

                break;
        }
    }
}
