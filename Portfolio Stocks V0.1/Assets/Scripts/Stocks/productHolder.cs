using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class productHolder : MonoBehaviour
{
    public List<productInfo> Products;

    [Header("Level One Product")]
    public productInfo ProductOne;
    [SerializeField] int lvlProduct_One;
    [SerializeField] List<int> amountSoldList_One;
    [SerializeField] float productExpericeneNow_One; //Produktens nuvarande Xp innan den lvl upp
                                                    
    private void Start()
    {
        amountSoldList_One.Add(ProductOne.amountSoldStart);
    }

    public void addAmountSoldToHistory(int amountSold)
    {
        //Debug.Log(amountSoldList_One[amountSoldList_One.Count - 1]);
        amountSoldList_One.Add(amountSoldList_One[amountSoldList_One.Count-1] + amountSold);
    }
    public void addExpericenToProduct(float moneyInvested, int lvl)
    {
        if (lvl == 0)
        {
            //Om MAX-level är uppnådd
            if (lvlProduct_One == ProductOne.getexperienceToLvlUp_Length())
            {
                return;
            }
            float randomInt = Random.Range(ProductOne.getMinXPFromEachMoney(), ProductOne.getMaxXPFromEachMoney());
            //Debug.Log("RandomInt:" + randomInt);
            productExpericeneNow_One += moneyInvested * randomInt;
            if (productExpericeneNow_One >= ProductOne.getexperienceToLvlUp(lvlProduct_One))
            {
                lvlProduct_One++;
            }
        }
    }

    public void investInGrowth(float moneyInvested, int lvl)
    {
        float randomInt = Random.Range(ProductOne.getMinXPFromEachMoneyAmountSold(), ProductOne.getMaxXPFromEachMoneyAmountSold());
        //Debug.Log("Invest in Growth: " + moneyInvested);
        float additionalAmountSold = moneyInvested * randomInt;
        //Debug.Log("Antal fler enheter sålda: " + additionalAmountSold);
        if(lvl == 0)
        addAmountSoldToHistory(Mathf.FloorToInt(additionalAmountSold));
    }

    public int getAmountSold(int lvl)
    {
        if (lvl == 0)
        {
            return amountSoldList_One[amountSoldList_One.Count-1];
        }

        else
            return 0;
    }


}
