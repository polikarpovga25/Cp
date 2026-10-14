using System.Collections.Generic;
using UnityEngine;

public class BurgerTask : MonoBehaviour
{
    void Start()
    {
        string burgerResult;

        CheckBurger("огурец", "сыр", "котлета", "кетчуп", out burgerResult);
        Debug.Log($"первый бургер: {burgerResult}");

        CheckBurger("булочка с кунжутом", "специальный соус", "две котлеты", "булочка с кунжутом", out burgerResult);
        Debug.Log($"второй бургер: {burgerResult}");

        CheckBurger("сыр", "кетчуп", "котлета", "лук", out burgerResult);
        Debug.Log($"третий бургер: {burgerResult}");
    }

    public void CheckBurger(string ing1, string ing2, string ing3, string ing4, out string result)
    {
        List<string> input = new List<string> { ing1, ing2, ing3, ing4 };

        List<string> cheeseburgerRecipe = new List<string> { "сыр", "кетчуп", "котлета", "огурец" };
        List<string> bigMacRecipe = new List<string> { "специальный соус", "булочка с кунжутом", "две котлеты", "булочка с кунжутом" };

        bool isCheeseburger = true;
        List<string> tempInputCheese = new List<string>(input);
        foreach (string ingredient in cheeseburgerRecipe)
        {
            if (tempInputCheese.Contains(ingredient))
            {
                tempInputCheese.Remove(ingredient);
            }
            else
            {
                isCheeseburger = false;
                break;
            }
        }
        if (isCheeseburger && tempInputCheese.Count == 0)
        {
            result = "чизбургер";
            return;
        }

        bool isBigMac = true;
        List<string> tempInputMac = new List<string>(input);
        foreach (string ingredient in bigMacRecipe)
        {
            if (tempInputMac.Contains(ingredient))
            {
                tempInputMac.Remove(ingredient);
            }
            else
            {
                isBigMac = false;
                break;
            }
        }
        if (isBigMac && tempInputMac.Count == 0)
        {
            result = "биг мак";
            return;
        }

        result = "хз что за блюдо";
    }
}
