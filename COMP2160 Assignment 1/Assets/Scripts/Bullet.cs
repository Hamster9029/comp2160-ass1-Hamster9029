using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public Vector2 direction;

    public SpriteRenderer player;

    private float maxHeight;
    private float minHeight;
    private float maxWidth;
    private float minWidth;

    // Start is called before the first frame update
    void Start()
    {
        // get the camera rect
        // note this assumes the window is aligned with the world x/y axes
        Camera camera = Camera.main;
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));

        // find the player component
        player = transform.Find("Circle").GetComponent<SpriteRenderer>();

        // shrink the box by the size of the sprite
        maxHeight = topRight.y -  player.bounds.extents.y;
        minHeight = bottomLeft.y + player.bounds.extents.y;
        maxWidth = topRight.x - player.bounds.extents.x;
        minWidth = bottomLeft.x + player.bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        // move bullet
        transform.Translate(direction * speed * Time.deltaTime);

        // destroy bullet when off screen
        if(transform.position.y > maxHeight || transform.position.y < minHeight || transform.position.x > maxWidth || transform.position.x < minWidth)
        {
            Destroy(gameObject);
        }
    }

    // other collider triggered bullet's collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        // compares collider with gameObject tags
        if (collider.gameObject.tag == "player" || collider.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
