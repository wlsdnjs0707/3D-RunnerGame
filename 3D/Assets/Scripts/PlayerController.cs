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

    // �� ũ��
    [SerializeField]
    private float ballScale = 0.1f;

    // �� ũ�� ����
    private float ballScaleLimit = 1.5f;

    // Ŀ���� �ӵ�
    [SerializeField]
    private float expandSpeed = 0.05f;

    // ȸ��
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

        // �� �������� ũ�� Ŀ��
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

        // ȭ�� ������ �� ������ ����
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
            // ȭ��� ���� ��ǥ ���� ���
            transform.position = new Vector3((((touchPoint.x * 9.0f) / 540) + 1), transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹 ���� (��ֹ� ������Ʈ Collider�� Is Trigger �Ӽ� On)
        if (other.gameObject.tag == ("Obstacle"))
        {
            isGamePlay = false;

            // ������ ���߰� UI ���
            ScoreText2.text = string.Format($"SCORE : {score}");
            Time.timeScale = 0;
            GameOverUI.SetActive(true);
            ScoreUI.SetActive(false);
        }
    }
}
