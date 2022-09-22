using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public SpriteRenderer enemy;

    public Player target;

    public Bullet bulletPrefab;
    public Coin coinPrefab;

    private Rect flightRect;

    private Vector2 playerDirection;

    private float timer;
    private int counter;
    private bool shootable;

    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));

        enemy = transform.Find("Triangle").GetComponent<SpriteRenderer>();

        flightRect.xMin = bottomLeft.x - enemy.bounds.extents.x * 2;
        flightRect.xMax = topRight.x + enemy.bounds.extents.x * 2;
        flightRect.yMin = bottomLeft.y - enemy.bounds.extents.y * 2;
        flightRect.yMax = topRight.y + enemy.bounds.extents.y * 2;

        counter = 1;
        shootable = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // destroy if enemy is outside of rectangle size
        if (transform.position.y > flightRect.yMax || transform.position.y < flightRect.yMin || transform.position.x > flightRect.xMax || transform.position.x < flightRect.xMin)
        {
            Destroy(gameObject);
        }

        // calls shoot method every frame
        if(GameObject.FindWithTag("Player") != null)
        {
            Shoot();
        }
    }

    // other collider triggered enemy's collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;
        if (!Layers.Instance.enemy.Contains(other) && !Layers.Instance.enemyBullet.Contains(other) && !Layers.Instance.coin.Contains(other))
        {
            Die();
        }
    }

    private void Die()
    {
        // spawns coinPrefab and destroy enemy
        Coin coin = Instantiate(coinPrefab);
        coin.transform.position = transform.position;
        Destroy(gameObject);
    }

    // checks if the player can shoot to spawn bulletPrefab
    private void Shoot()
    {
        if(shootable == false && counter == 1)
        {
            timer = Random.Range(1, 3);
            shootable = true;
        }

        else if (shootable == true && timer <= 0)
        {
            target = GameObject.FindObjectOfType<Player>();
            playerDirection = (target.transform.position - transform.position).normalized;

            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = playerDirection;

            shootable = false;
            counter--;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
