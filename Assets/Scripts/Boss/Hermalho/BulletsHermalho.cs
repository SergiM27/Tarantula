using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsHermalho : MonoBehaviour {

    [Header("ProjectileSettings")]
    public int numberOfProjectiles;
    public float projectileSpeed;
    public GameObject projectilePrefab;

    [Header("PrivateVariables")]
    private Vector3 startPoint;
    private const float radius = 1;

    public AudioClip shoot;

    private void Start()
    {
        InvokeRepeating("Shoot", 0.0f, 5.0f);
    }

    private void SpawnProjectiles(int _Number)
    {
        float angleStep = 360f / _Number;
        float angle = 0f;

        for (int i = 0; i <= _Number -1; i++)
        {
            float projectileDirXPosition = startPoint.x + Mathf.Sin ((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDir = (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject projectile = Instantiate(projectilePrefab, startPoint, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDir.x, projectileMoveDir.y);
            projectile.gameObject.name = "HermalhoBullet";

            angle += angleStep;
        }
    }

    private void Shoot()
    {
        SoundManager.instance.PlaySingle(shoot);
        startPoint = transform.position;
        SpawnProjectiles(numberOfProjectiles);
    }

}
