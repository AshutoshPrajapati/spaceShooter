using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float min_x = -2.7f, max_x = 2.7f;
    [SerializeField]
    public GameObject player_Bullet;
    [SerializeField]
    public Transform attack_point;
    public GameObject ui;
    public Text scoreText;
    int score = 0;
    // Start is called before the first frame update

    public float screenOffset = 5;

    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
        MoveWithMousePos();
    }

    public void MovePlayer()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if (temp.x > max_x)
                temp.x = max_x;
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.x < min_x)
                temp.x = min_x;
            transform.position = temp;
        }
    }

    void MoveWithMousePos()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(pos.x);
        float xPos = Mathf.Clamp(pos.x+screenOffset,-3, 3);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

    }
    void Attack()
    {
        //if(Input.GetMouseButtonDown(0))
        //  Instantiate(player_Bullet, attack_point.position, Quaternion.identity);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(player_Bullet, attack_point.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Enemy" )
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            ui.SetActive(true);

        }
    }
}
