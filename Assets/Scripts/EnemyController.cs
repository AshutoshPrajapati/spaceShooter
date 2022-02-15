using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float rotate_speed = 50f;
    public bool canMove = true;
    public bool canShoot;
    public bool canRotate;
    public float bound_y = -11f;
    public Transform attack_point;
    public GameObject bullet_Prefeb;
    // Start is called before the first frame update
    void Start()
    {
        if (canRotate)
        {
            if(Random.Range(0, 2) > 0)
            {
                rotate_speed = Random.Range(rotate_speed, rotate_speed + 20f);
                rotate_speed *= -1f;
            }
        }

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();
    }
   void Move()
    {
       if (canMove)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.y < bound_y)

                gameObject.SetActive(false);

        }
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_speed * Time.deltaTime), Space.World);
        }
    }
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
    void StartShooting()
    {
        GameObject bullet = Instantiate(bullet_Prefeb, attack_point.position, Quaternion.identity);
        bullet.GetComponent<BulletShoot>().is_EnemyBullet = true;

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            canMove = false;

            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }
            Invoke("TurnOffGameObject", 0.01f);
        }
    }
}
