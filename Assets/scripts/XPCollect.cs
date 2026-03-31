using UnityEngine;

public class XPCollect : MonoBehaviour
{
    public int xpValue = 10;
    public float moveSpeed = 5f;

    private Transform player;
    private PlayerMagnet magnet;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        magnet = player.GetComponent<PlayerMagnet>();
    }

    void Update()
    {
        if (player == null || magnet == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= magnet.magnetRange)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerXP playerXP = collision.GetComponent<PlayerXP>();

            if (playerXP != null)
            {
                playerXP.AddXP(xpValue);
            }

            Destroy(gameObject);
        }
    }
}