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

    // スタート時に変数にコンポーネントを格納
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void TurnOffTrigger()
    {
        animator.SetBool("Run", false);
    }


    void Update()
    {
        switch(state)
        {
            case STATE.WANDER:
                TurnOffTrigger();

                if (Random.Range(0,500) < 5)
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
        }
    }
}
