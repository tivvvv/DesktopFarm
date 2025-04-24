using UnityEngine;

public class GetEgg : MonoBehaviour
{

    public MainUI mainUI;

    void Start()
    {
        mainUI = GameObject.Find("MainUI").GetComponent<MainUI>();
    }
    public void clickEgg()
    {
        mainUI.money += 10;
        Destroy(gameObject);
    }
}
