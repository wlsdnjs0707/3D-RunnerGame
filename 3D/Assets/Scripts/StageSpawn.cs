using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawn : MonoBehaviour
{
    // �������� ������ �迭
    [SerializeField]
    private GameObject[] stagePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        SpawnArea();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnArea()
    {
        GameObject clone = null;

        // ���ο� �������� ����
        clone = Instantiate(stagePrefabs[Random.Range(0, stagePrefabs.Length)]);
        clone.transform.position = new Vector3(10,0,40);
    }
}
