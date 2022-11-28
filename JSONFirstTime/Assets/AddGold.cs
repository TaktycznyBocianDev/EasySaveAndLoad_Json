using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddGold : MonoBehaviour
{
    [SerializeField] Text text;
    public int goldAmount;


    private void Start()
    {
        goldAmount = 0;
    }

    public void IncreaseGold()
    {
        goldAmount++;
        text.text = "Gold: " + goldAmount.ToString();
    }

    public void SetGoldAmount(int goldAmount)
    {
        this.goldAmount = goldAmount;
        text.text = "Gold: " + goldAmount.ToString();
    }
}
