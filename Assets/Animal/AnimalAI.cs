using UnityEngine;

public class AnimalAI : MonoBehaviour
{
    // 计时器
    public float timer = 0;
    // 是否闲置
    public bool isIdle = true;
    // 状态持续时间
    public float ttl;
    // 移动速度
    public float speed;

    private Animator ani;
    private Rigidbody2D rb;

    void Start()
    {
        ttl = 3;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        ttl = Random.Range(1, 10);
        if (timer >= ttl)
        {
            timer = 0;
            isIdle = !isIdle;
            int ran = Random.Range(0, 2);
            if (ran == 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        if (isIdle)
        {
            ani.SetBool("isMove", false);
        }
        else
        {
            ani.SetBool("isMove", true);
            if (transform.localScale.x > 0)
            {
                rb.linearVelocity = new Vector2(-1 * speed, 0);
            }
            else
            {
                rb.linearVelocity = new Vector2(speed, 0);
            }
        }
    }
}
