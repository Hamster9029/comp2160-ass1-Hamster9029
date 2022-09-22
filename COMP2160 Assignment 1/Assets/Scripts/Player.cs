using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public SpriteRenderer player;

    private Rect flightRect;

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
        flightRect.xMin = bottomLeft.x + player.bounds.extents.x;
        flightRect.xMax = topRight.x - player.bounds.extents.x;
        flightRect.yMin = bottomLeft.y + player.bounds.extents.y;
        flightRect.yMax = topRight.y - player.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        // get the axis which the player is moving
        float dx = Input.GetAxis(InputAxes.Horizontal);
        float dy = Input.GetAxis(InputAxes.Vertical);

        // normalise the Vector2 direction
        Vector2 direction = new Vector2(dx, dy).normalized;

        // move player
        transform.Translate(direction * speed * Time.deltaTime);

        // clamp to stay on screen
        transform.localPosition = flightRect.Clamp(transform.localPosition);
    }

    // other collider triggered player's collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        // return the other collider
        GameObject other = collider.gameObject;

        // compares the other collider with the layermask called
        if (!Layers.Instance.player.Contains(other) && !Layers.Instance.coin.Contains(other) && !Layers.Instance.bullet.Contains(other))
        {
            Die();
        }
    }

    private void Die()
    {
        // destroy the player
        Destroy(gameObject);

        // call GameManager
        GameManager.Instance.Die();
    }
}
