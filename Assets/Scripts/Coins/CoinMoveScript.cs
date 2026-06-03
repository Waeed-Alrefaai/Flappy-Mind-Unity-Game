using UnityEngine;

public class CoinMoveScript : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float deadZone = -45f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
