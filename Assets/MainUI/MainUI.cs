using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public int money = 0;

    public TextMeshProUGUI moneyText;

    public TextMeshProUGUI animalText;

    public int chickNum = 0;

    public int chickenNum = 0;

    private void Update()
    {
        moneyText.text = money.ToString();
        animalText.text = (chickNum + chickenNum).ToString();
    }
}
