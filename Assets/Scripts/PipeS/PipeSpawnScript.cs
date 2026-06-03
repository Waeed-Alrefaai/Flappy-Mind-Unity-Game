using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject coinPrefab;
    public float spawnRate;
    //public float spawnRate = GameSettings.pipeGap;
    private float timer = 0;
    public float heightOffset = 10;

    void Start()
{
    GameSettings.ApplySelectedMode();
    spawnRate = GameSettings.pipeGap;
    spawnPipe();
}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
/*    void Start()
    {
        //spawnRate = GameSettings.pipeGap;
        spawnPipe();
    }*/

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        } 
        else
        {
            spawnPipe();
            timer = 0;
        }
           
    }

    void spawnPipe()
{
    float lowestPoint = transform.position.y - heightOffset;
    float highestPoint = transform.position.y + heightOffset;

    float randomY = Random.Range(lowestPoint, highestPoint);

    // إنشاء الأنابيب
    GameObject pipeInstance = Instantiate(
        pipe,
        new Vector3(transform.position.x, randomY, 0),
        transform.rotation
    );

    // =========================
    // كوين بين الأنابيب
    // =========================
    Transform middle = pipeInstance.transform.Find("Middle");

    if (middle != null)
    {
        GameObject middleCoin = Instantiate(
            coinPrefab,
            new Vector3(middle.position.x, middle.position.y, 0),
            Quaternion.identity
        );

        CoinMoveScript middleCoinMove = middleCoin.GetComponent<CoinMoveScript>();
        if (middleCoinMove != null)
        {
            //middleCoinMove.moveSpeed = 2f;
            middleCoinMove.moveSpeed = GameSettings.birdSpeed;
            middleCoinMove.deadZone = -45f;
        }
    }

    // =========================
    // كوين عشوائي بعيد عن الأنابيب
    // =========================
    float randomCoinY = Random.Range(lowestPoint, highestPoint);

    // يمنع العشوائي يكون قريب من فتحة/مكان الأنبوب
    while (Mathf.Abs(randomCoinY - randomY) < 2.5f)
    {
        randomCoinY = Random.Range(lowestPoint, highestPoint);
    }

    GameObject randomCoin = Instantiate(
        coinPrefab,
        new Vector3(transform.position.x, randomCoinY, 0),
        Quaternion.identity
    );
// هذي تحرك الكونز
    CoinMoveScript randomCoinMove = randomCoin.GetComponent<CoinMoveScript>();
    if (randomCoinMove != null)
    {
        randomCoinMove.moveSpeed = 8f;
        //randomCoinMove.moveSpeed = GameSettings.birdSpeed;
        randomCoinMove.deadZone = -20f;
    }
}

    
}
