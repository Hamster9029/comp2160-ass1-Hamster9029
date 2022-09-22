using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyPrefab;

    private Rect flightRect;

    public float respawnCooldown;
    public float minRespawnCooldown;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // get the camera rect
        // note this assumes the window is aligned with the world x/y axes
        Camera camera = Camera.main;
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));

        // extends the box by the size of 1
        flightRect.xMin = bottomLeft.x - 1;
        flightRect.xMax = topRight.x + 1;
        flightRect.yMin = bottomLeft.y - 1;
        flightRect.yMax = topRight.y + 1;
    }

    // Update is called once per frame
    void Update()
    {
        // internal timer
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = respawnCooldown;
            // increase the rate which the enemy spawns
            if(respawnCooldown > minRespawnCooldown)
            {
                respawnCooldown -= 0.5f;
            }

            // clamp to stay on screen
            transform.localPosition = flightRect.Clamp(transform.localPosition);

            // randomise to generate rectangle corners and return points
            int i = Random.Range(0, 4);
            Vector2 p0 = flightRect.Corner(i);
            Vector2 p1 = flightRect.Corner(i + 1);
            Vector2 p2 = flightRect.Corner(i + 2);
            Vector2 p3 = flightRect.Corner(i + 3);

            // randomise a point between p0 and p1
            int x1 = (int)Random.Range(p0.x, p1.x);
            int y1 = (int)Random.Range(p0.y, p1.y);

            // randomise a point between p2 and p3
            int x2 = (int)Random.Range(p2.x, p3.x);
            int y2 = (int)Random.Range(p2.y, p3.y);

            // create new Vector2, more simplistic to use and call
            Vector2 coord1 = new Vector2(x1, y1);
            Vector2 coord2 = new Vector2(x2, y2);

            // create/spawn enemyPrefab at coord1 location and rotate to coord2's location
            Instantiate(enemyPrefab, coord1, Quaternion.FromToRotation(Vector2.up,coord2 - coord1));
        }
    }
}
