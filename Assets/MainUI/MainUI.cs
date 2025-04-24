using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public int money = 0;

    public TextMeshProUGUI moneyText;

    private void Update()
    {
        moneyText.text = money.ToString();
    }
}
