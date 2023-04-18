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

    Vector3 offset;

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

        // 공 회전
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);

    }

    private void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    IEnumerator scoring()
    {
        while (true)
        {
            score += 1;
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnMouseDrag()
    {

        if (2.0f <= transform.position.x && transform.position.x <= 18.0f)
        {
            transform.position = new Vector3((MouseWorldPosition() + offset).x, transform.position.y, transform.position.z);

            if (transform.position.x < 2.0f)
            {
                transform.position = new Vector3(2.0f, transform.position.y, transform.position.z);
            }

            if (transform.position.x > 18.0f)
            {
                transform.position = new Vector3(18.0f, transform.position.y, transform.position.z);
            }
        }
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
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
