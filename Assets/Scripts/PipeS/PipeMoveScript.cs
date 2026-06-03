using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone = -45;

    void Start()
    {
        GameSettings.ApplySelectedMode();
        moveSpeed = GameSettings.birdSpeed;
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
/*using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = GameSettings.birdSpeed;
    public float deadZone = -45;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
       //moveSpeed = GameSettings.birdSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
*/
