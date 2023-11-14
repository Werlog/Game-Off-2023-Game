using System;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;
    [SerializeField] private float despawnTime;
    private Transform shootPointTr;
    private void Start()
    {
        shootPointTr = shootPoint.GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject spawnedBullet = Instantiate(bullet, shootPointTr.position, pistol.GetComponent<Transform>().rotation);
            spawnedBullet.GetComponent<Rigidbody2D>().AddForce(shootPointTr.right * speed, ForceMode2D.Impulse);
            Destroy(spawnedBullet, despawnTime);
        }
    }
}
