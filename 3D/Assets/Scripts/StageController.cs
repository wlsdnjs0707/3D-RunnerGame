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
        // 스테이지가 뒤로 이동
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;

        // 화면 밖으로 나간 스테이지 삭제 & 새로운 스테이지 생성
        if (transform.position.z <= -30)
        {
            spawner.GetComponent<StageSpawn>().SpawnArea();
            Destroy(gameObject);
        }
    }
}
