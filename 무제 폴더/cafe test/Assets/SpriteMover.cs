using UnityEngine;

public class SpriteMover : MonoBehaviour
{
     public Vector3 targetPosition;  // 이동할 목표 위치
    public float speed = 5f;        // 이동 속도
    private Animator animator;      // 애니메이터 컴포넌트

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator 가져오기
    }

    void Update()
    {
        MoveToTarget();  // 목표 위치로 이동하는 함수 실행
    }

    void MoveToTarget()
    {
        // 현재 위치에서 목표 위치로 한 프레임 동안 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // 이동 방향의 속도 계산
        float velocity = (targetPosition - transform.position).magnitude;

        // 애니메이터의 xVelocity 파라미터 업데이트
        animator.SetFloat("xVelocity", velocity > 0 ? 1f : 0f);
    }
}
