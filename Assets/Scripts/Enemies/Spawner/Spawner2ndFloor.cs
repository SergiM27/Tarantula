using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2ndFloor : MonoBehaviour
{
    int type;
    public GameObject slimeGreen;
    public GameObject slimeYellow;
    public GameObject bat;

    float spawnTime=8.0f;
    private void OnEnable()
    {
        InvokeRepeating("SpawnMonster",spawnTime,spawnTime);
    }

    private void OnDisable()
    {
        CancelInvoke("SpawnMonster");
    }

    void SpawnMonster()
    {
        type = Random.Range(0, 4);
        switch (type)
        {
            case 0:
                Instantiate(slimeGreen, transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(slimeYellow, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(bat, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(bat, transform.position, Quaternion.identity);
                break;
        }
    }
}
