using UnityEngine;

public class GetProduct : MonoBehaviour
{

    public MainUI mainUI;

    public int money = 10;

    void Start()
    {
        mainUI = GameObject.Find("MainUI").GetComponent<MainUI>();
    }
    public void ClickProduct()
    {
        mainUI.money += money;
        Destroy(gameObject);
    }
}
