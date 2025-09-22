using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 플레이어의 Rigidbody 컴포넌트 (물리 엔진 제어용)
    private Rigidbody playerRigidbody;
    // 이동 속도 (Inspector에서 조절 가능)
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        // 이 스크립트가 붙은 오브젝트에서 Rigidbody 컴포넌트 가져오기
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 키보드 입력을 받아 이동 처리

        // 좌우 방향키(A/D, ←/→) 입력값 (-1 ~ 1)
        float xInput = Input.GetAxis("Horizontal");
        // 상하 방향키(W/S, ↑/↓) 입력값 (-1 ~ 1)
        float zInput = Input.GetAxis("Vertical");

        // 입력값에 속도 곱해서 실제 이동 속도 계산
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // 새로운 속도 벡터 생성 (y축은 0으로 고정)
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        // Rigidbody에 속도 적용 (즉각적으로 방향 전환)
        playerRigidbody.velocity = newVelocity;

        /*
        // 아래는 AddForce 방식 예시(참고용, 현재 미사용)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        */
    }
    public void Die()
    {
        // 플레이어 오브젝트를 비활성화 (죽었을 때 호출)
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
