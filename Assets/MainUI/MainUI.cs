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

    public int calfNum = 0;

    public int cowNum = 0;

    public float saveTimer = 0;

    public Transform Animals;

    public GameObject StoreUI;

    public GameObject chick;

    public GameObject chicken;

    public GameObject calf;

    public GameObject cow;

    public GameObject ExitUI;

    public List<GameObject> hiddenObjects;

    public GameObject MainScene;

    public GameObject ClearSaveUI;

    private Transform Products;

    private void Start()
    {
        Load();
        Products = GameObject.Find("Main Scene").transform.Find("Products");
    }

    private void Update()
    {
        moneyText.text = money.ToString();
        animalText.text = (chickNum + chickenNum + calfNum + cowNum).ToString();
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
        CreateChick();
        chickNum++;
    }

    public void BuyChicken()
    {
        if (money < 100)
        {
            return;
        }
        money -= 100;
        CreateChicken();
        chickenNum++;
    }

    public void BuyCalf()
    {
        if (money < 300)
        {
            return;
        }
        money -= 300;
        CreateCalf();
        calfNum++;
    }

    public void BuyCow()
    {
        if (money < 500)
        {
            return;
        }
        money -= 500;
        CreateCow();
        cowNum++;
    }

    private void CreateChicken()
    {
        GameObject chickenObj = Instantiate(chicken, Animals);
        float x = Random.Range(-2.5F, 0.8F);
        chickenObj.transform.localPosition = new Vector3(x, 2, 0);
    }

    private void CreateChick()
    {
        GameObject chickObj = Instantiate(chick, Animals);
        float x = Random.Range(-2.5F, 0.8F);
        chickObj.transform.localPosition = new Vector3(x, 2, 0);
    }

    private void CreateCalf()
    {
        GameObject calfObj = Instantiate(calf, Animals);
        float x = Random.Range(-2.5F, 0.8F);
        calfObj.transform.localPosition = new Vector3(x, 2, 0);
    }

    private void CreateCow()
    {
        GameObject cowObj = Instantiate(cow, Animals);
        float x = Random.Range(-2.5F, 0.8F);
        cowObj.transform.localPosition = new Vector3(x, 2, 0);
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
        PlayerPrefs.SetInt("CalfNum", calfNum);
        PlayerPrefs.SetInt("CowNum", cowNum);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        chickenNum = PlayerPrefs.GetInt("ChickenNum", 1);
        chickNum = PlayerPrefs.GetInt("ChickNum", 1);
        calfNum = PlayerPrefs.GetInt("CalfNum", 0);
        cowNum = PlayerPrefs.GetInt("CowNum", 0);

        if (chickenNum > 1)
        {
            for (int i = 0; i < chickenNum - 1; i++)
            {
                CreateChicken();
            }
        }

        if (chickNum > 1)
        {
            for (int i = 0; i < chickNum - 1; i++)
            {
                CreateChick();
            }
        }

        if (calfNum > 0)
        {
            for (int i = 0; i < calfNum; i++)
            {
                CreateCalf();
            }
        }

        if (cowNum > 0)
        {
            for (int i = 0; i < cowNum; i++)
            {
                CreateCow();
            }
        }
    }

    public void ClearSave()
    {
        ClearSaveUI.SetActive(true);
    }

    public void ClearSaveYes()
    {
        ClearSaveUI.SetActive(false);
        money = 100;
        chickNum = 1;
        chickenNum = 1;
        calfNum = 0;
        cowNum = 0;
        foreach (Transform item in Animals)
        {
            Destroy(item.gameObject);
        }
        CreateChicken();
        CreateChick();
        Save();
    }

    public void ClearSaveNo()
    {
        ClearSaveUI.SetActive(false);
    }

    public void Zoom()
    {
        if (MainScene.transform.localScale.x < 1)
        {
            MainScene.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            MainScene.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
    }


    public void CollectAll()
    {
        for (int i = 0; i < Products.childCount; i++)
        {
            GameObject product = Products.GetChild(i).gameObject;
            money += GetProductValue(product.name);
            Destroy(product);
        }
    }

    private int GetProductValue(string productName)
    {
        Debug.Log(productName);
        if (productName.Contains("Egg"))
        {
            return 10;
        }
        else if (productName.Contains("Milk"))
        {
            return 25;
        }
        return 0;
    }
}
