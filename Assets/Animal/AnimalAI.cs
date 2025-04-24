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

    // 鸡蛋
    public GameObject egg;
    // 下蛋计时器
    public float eggTimer = 0;
    // 下蛋周期
    public float eggPeriod = 5;

    private Animator ani;
    private Rigidbody2D rb;
    private Transform Eggs;

    void Start()
    {
        period = 3;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Eggs = GameObject.Find("Main Scene").transform.Find("Eggs");
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

        eggTimer += Time.fixedDeltaTime;
        if (eggTimer >= eggPeriod)
        {
            eggTimer = 0;
            GameObject eggObj = Instantiate(egg, Eggs);
            eggObj.transform.position = transform.position;
        }
    }
}
