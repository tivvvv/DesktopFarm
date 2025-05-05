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
        float x = Random.Range(-2.5F, 0.7F);
        chickenObj.transform.localPosition = new Vector3(x, 2, 0);
    }

    private void CreateChick()
    {
        GameObject chickObj = Instantiate(chick, Animals);
        float x = Random.Range(-2.5F, 0.7F);
        chickObj.transform.localPosition = new Vector3(x, 2, 0);
    }

    private void CreateCalf()
    {
        GameObject calfObj = Instantiate(calf, Animals);
        float x = Random.Range(-2.5F, 0.7F);
        calfObj.transform.localPosition = new Vector3(x, 2, 0);
    }

    private void CreateCow()
    {
        GameObject cowObj = Instantiate(cow, Animals);
        float x = Random.Range(-2.5F, 0.7F);
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
        PlayerPrefs.Save();
    }

    public void Load()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        chickenNum = PlayerPrefs.GetInt("ChickenNum", 1);
        chickNum = PlayerPrefs.GetInt("ChickNum", 1);

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
    }

    public void ClearSave()
    {
        ClearSaveUI.SetActive(true);
    }

    public void ClearSaveYes()
    {
        ClearSaveUI.SetActive(false);
        money = 0;
        chickNum = 1;
        chickenNum = 1;
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
}
