using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Bullet bulletPrefab;

    public SpriteRenderer player;

    public float shootCooldown;
    private float shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        // find the player component
        player = transform.Find("Circle").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        // internal timer
        shootTimer -= Time.deltaTime;

        // get the axis which the player is shooting
        float dx = Input.GetAxisRaw(InputAxes.HorizontalShoot);
        float dy = Input.GetAxisRaw(InputAxes.VerticalShoot);

        // create new Vector2 to indicate direction
        Vector2 direction = new Vector2(dx, dy);

        if(Input.GetButton("HorizontalShoot") && shootTimer <= 0 || Input.GetButton("VerticalShoot") && shootTimer <= 0)
        {
            shootTimer = shootCooldown;
            position.x += player.bounds.extents.x * dx;
            position.y += player.bounds.extents.y * dy;
            Bullet bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            bullet.GetComponent<Bullet>().direction = direction;
        }
    }
}
