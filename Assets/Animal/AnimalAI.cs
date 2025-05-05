using UnityEngine;

public class AnimalAI : MonoBehaviour
{
    // 计时器
    public float timer = 0;
    // 是否闲置
    public bool isIdle = true;
    // 状态周期
    public float period;
    // 移动速度
    public float speed;

    // 生产物
    public GameObject product;
    // 生产计时器
    public float productTimer = 0;
    // 生产周期
    public float productPeriod = 2;

    private Animator ani;
    private Rigidbody2D rb;
    private Transform Products;

    void Start()
    {
        period = 3;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Products = GameObject.Find("Main Scene").transform.Find("Products");
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        period = Random.Range(1, 10);
        if (timer >= period)
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

        productTimer += Time.fixedDeltaTime;
        if (productTimer >= productPeriod)
        {
            productTimer = 0;
            GameObject productObj = Instantiate(product, Products);
            productObj.transform.position = transform.position;
        }
    }
}
