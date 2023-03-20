using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject ScoreUI;
    public TMP_Text ScoreText;
    public TMP_Text ScoreText2;

    private Vector3 touchPoint;
    private int score;

    public bool isGamePlay = true;

    // 공 크기
    [SerializeField]
    private float ballScale = 0.1f;

    // 공 크기 제한
    private float ballScaleLimit = 1.5f;

    // 커지는 속도
    [SerializeField]
    private float expandSpeed = 0.05f;

    // 회전
    private float rotateSpeed = 300.0f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(scoring());
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePlay == false)
        {
            return;
        }

        ScoreText.text = string.Format($"SCORE : {score}");

        // 공 굴릴수록 크기 커짐
        transform.localScale = Vector3.one * ballScale;

        if (ballScale < ballScaleLimit)
        {
            ballScale += Time.deltaTime * expandSpeed;
        }

        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);

        if (Application.isMobilePlatform)
        {
            OnMobilePlatform();
        }
        else
        {
            OnPCPlatform();
        }

    }

    IEnumerator scoring()
    {
        while (true)
        {
            score += 1;
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnMobilePlatform()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            touchPoint = touch.position;

            OnDragX();
        }
    }

    private void OnPCPlatform()
    {
        if (Input.GetMouseButton(0))
        {
            touchPoint = Input.mousePosition;

            OnDragX();
        }
    }

    private void OnDragX()
    {
        if(isGamePlay==false)
        {
            return;
        }

        // 화면 밖으로 못 나가게 제한
        if (transform.position.x<1)
        {
            transform.position = new Vector3(1, transform.position.y, transform.position.z);
        }
        else if (transform.position.x>19)
        {
            transform.position = new Vector3(19, transform.position.y, transform.position.z);
        }
        else
        {
            // 화면과 게임 좌표 비율 계산
            transform.position = new Vector3((((touchPoint.x * 9.0f) / 540) + 1), transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌 판정 (장애물 오브젝트 Collider의 Is Trigger 속성 On)
        if (other.gameObject.tag == ("Obstacle"))
        {
            isGamePlay = false;

            // 게임을 멈추고 UI 출력
            ScoreText2.text = string.Format($"SCORE : {score}");
            Time.timeScale = 0;
            GameOverUI.SetActive(true);
            ScoreUI.SetActive(false);
        }
    }
}
