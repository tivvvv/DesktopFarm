using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public int money = 100;

    public TextMeshProUGUI moneyText;

    public TextMeshProUGUI animalText;

    public int chickNum = 0;

    public int chickenNum = 0;

    public float saveTimer = 0;

    public Transform Animals;

    public GameObject StoreUI;

    public GameObject chick;

    public GameObject chicken;

    public GameObject ExitUI;

    public List<GameObject> hiddenObjects;

    public GameObject MainScene;

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        moneyText.text = money.ToString();
        animalText.text = (chickNum + chickenNum).ToString();
    }

    private void FixedUpdate()
    {
        saveTimer += Time.fixedDeltaTime;
        if (saveTimer >= 30)
        {
            saveTimer = 0;
            Save();
        }
    }

    public void CloseStore()
    {
        StoreUI.SetActive(false);
    }

    public void OpenStore()
    {
        StoreUI.SetActive(true);
    }

    public void BuyChick()
    {
        if (money < 50)
        {
            return;
        }

        money -= 50;
        GameObject chickObj = Instantiate(chick, Animals);
        float x = Random.Range(-2.5F, 0.7F);
        chickObj.transform.localPosition = new Vector3(x, 2, 0);
        chickNum++;
    }
    public void BuyChicken()
    {
        if (money < 100)
        {
            return;
        }
        money -= 100;
        GameObject chickenObj = Instantiate(chicken, Animals);
        float x = Random.Range(-2.5F, 0.7F);
        chickenObj.transform.localPosition = new Vector3(x, 2, 0);
        chickenNum++;
    }

    public void Hide()
    {
        if (MainScene.activeSelf)
        {
            foreach (GameObject item in hiddenObjects)
            {
                item.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject item in hiddenObjects)
            {
                item.SetActive(true);
            }
        }
    }

    public void Quit()
    {
        Save();
        ExitUI.SetActive(true);
    }

    public void QuitYes()
    {
        Application.Quit();
    }

    public void QuitNo()
    {
        ExitUI.SetActive(false);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("ChickenNum", chickenNum);
        PlayerPrefs.SetInt("ChickNum", chickNum);
        PlayerPrefs.Save();
    }

    public void Load()
    {

    }

    public void ClearSave()
    {

    }
}
