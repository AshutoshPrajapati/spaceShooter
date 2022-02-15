using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletShoot : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 3f;
    [HideInInspector]
    public bool is_EnemyBullet = false;
    public Text scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        if (is_EnemyBullet)
            speed *= -1f;

        Invoke("DeactivateGameObject", deactivate_Timer);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Enemy"|| collision.tag == "Bullet" || collision.tag == "Player")
        {
            gameObject.SetActive(false);
            score += 1;
            scoreText.text = score.ToString();
        }
    }
}
