using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productInfo : MonoBehaviour
{
    public string nameProduct;

   public List<float> cost;
   public List<float> revenue;
   public int amountSoldStart;
    public int amountSoldNow;
    public int lvlProduct;

   [SerializeField] float productExpericeneNow; //Produktens nuvarande Xp innan den lvl upp
   [SerializeField] List<float> experienceToLvlUp;
    
    //Produckt Lvl. Intervall hur mycket XP som erhålls för varje krona
    [SerializeField] float minXPFromEachMoney;
    [SerializeField] float maxXPFromEachMoney;

    //Antal sålda. Intervall hur mycket XP som erhålls för varje krona
    [SerializeField] float minXPFromEachMoneyAmountSold;
    [SerializeField] float maxXPFromEachMoneyAmountSold;

    private void Start()
    {
        amountSoldNow = amountSoldStart;
    }

    public void addExpericenToProduct(float moneyInvested)
    {
        //Om MAX-level är uppnådd
        if (lvlProduct == experienceToLvlUp.Count)
        {
            return;
        }
        float randomInt = Random.Range(minXPFromEachMoney, maxXPFromEachMoney);
        Debug.Log("RandomInt:" + randomInt);
        productExpericeneNow += moneyInvested * randomInt;
        if (productExpericeneNow >= experienceToLvlUp[lvlProduct])
        {
            lvlProduct++;
        }
    }

    public void investInGrowth(float moneyInvested)
    {
        float randomInt = Random.Range(minXPFromEachMoneyAmountSold, maxXPFromEachMoneyAmountSold);
        Debug.Log("RandomInt:" + randomInt);
        float additionalAmountSold = moneyInvested * randomInt;
        Debug.Log("Antal fler enheter sålda: " + additionalAmountSold);
        amountSoldNow += Mathf.FloorToInt(additionalAmountSold);
    }

}
