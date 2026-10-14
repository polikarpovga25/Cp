using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopTask : MonoBehaviour
{
    public TextMeshProUGUI[] itemNamesUI;
    public TextMeshProUGUI[] itemPricesUI;
    public TextMeshProUGUI totalSumUI;
    public Button nextDayButton;

    private string[] products = { "яблоки", "молоко", "хлеб" };
    private float[] prices = { 100f, 80f, 50f };
    private int currentDisplayIndex = 0;

    void Start()
    {
        if (nextDayButton != null)
        {
            nextDayButton.onClick.AddListener(OnNextDayButtonClick);
        }

        ProcessCart(products, prices);
    }

    public void ProcessCart(string[] names, float[] costArray)
    {
        float totalSum = 0f;

        for (int i = 0; i < names.Length; i++)
        {
            currentDisplayIndex = i;

            Debug.Log($"стоимость товара {names[i]}: {costArray[i]}");

            DisplayItem(name: names[i]);
            DisplayItem(price: costArray[i]);

            totalSum += costArray[i];
        }

        Debug.Log($"итоговая сумма корзины: {totalSum}");
        if (totalSumUI != null)
        {
            totalSumUI.text = $"итого: {totalSum} руб.";
        }
    }

    public void DisplayItem(string name = null, float price = -1f)
    {
        if (name != null)
        {
            if (currentDisplayIndex < itemNamesUI.Length && itemNamesUI[currentDisplayIndex] != null)
            {
                itemNamesUI[currentDisplayIndex].text = name;
            }
        }

        if (price >= 0f)
        {
            if (currentDisplayIndex < itemPricesUI.Length && itemPricesUI[currentDisplayIndex] != null)
            {
                itemPricesUI[currentDisplayIndex].text = $"{price} руб.";
            }
        }
    }

    public void OnNextDayButtonClick()
    {
        for (int i = 0; i < prices.Length; i++)
        {
            prices[i] *= 2;
        }

        ProcessCart(products, prices);
    }

    void OnDestroy()
    {
        if (nextDayButton != null)
        {
            nextDayButton.onClick.RemoveListener(OnNextDayButtonClick);
        }
    }
}
