using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUi : MonoBehaviour
{
    
    public int money;
    [SerializeField] private TextMeshProUGUI moneyText;
    // Start is called before the first frame update

    #region singleton

    private static MoneyUi instance;
    public static MoneyUi Instance => instance;
    
    

    private MoneyUi()
    {
        money = 100;
        
    }
    private void Awake()
    {
        if (instance == null)
        {
            Destroy(instance);
        }

        instance = this;
    }

    #endregion

   

    void Start()
    {
       // moneyText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //moneyText.text = " money: $" + money;
    }

    
    //pass in a modifier for the money. If you earn money it should be positive
    //and if you spend money it should be negative
    //Will return false if spending that money would set you into the negative
    //Otherwise will set the money, change the ui, and return true
    public bool updateMoney(int modifier)
    {
        if (money + modifier < 0)
        {
            return false;
        }

        money += modifier;
        moneyText.text = " money: $" + money;
        return true;
    }
}
