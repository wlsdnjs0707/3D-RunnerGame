using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("StageSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        // ���������� �ڷ� �̵�
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;

        // ȭ�� ������ ���� �������� ���� & ���ο� �������� ����
        if (transform.position.z <= -30)
        {
            spawner.GetComponent<StageSpawn>().SpawnArea();
            Destroy(gameObject);
        }
    }
}
