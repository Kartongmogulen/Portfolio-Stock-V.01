using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InvestmentData;  // Se till att referera till InvestmentData

public class InvestmentManager : MonoBehaviour
{
    public List<InvestmentTypeData> availableInvestments;  // Lista �ver ScriptableObject-baserade investeringstyper
    //public List<InvestmentType> availableInvestments = new List<InvestmentType>();  // Lista �ver tillg�ngliga investeringstyper
    public PlayerManager playerManager; // Referens till PlayerManager
    public InvestInfoUI investInfoUI;
    [SerializeField] int investmentIndex; //Aktuell investering
    //public List<InvestmentInstance> activeInvestments = new List<InvestmentInstance>(); // Lista �ver aktiva investeringar (individuella instanser)

    //public float playerCapital = 0f; // Spelarens totala kapital

    void Start()
    {
        chooseProjectIndex(investmentIndex);

        /*
        // Exempel: L�gg till n�gra investeringar till den tillg�ngliga listan
        availableInvestments.Add(new InvestmentType("Investment A", 100, 1f, 1, 0.2f));
        availableInvestments.Add(new InvestmentType("Investment B", 100, 1f, 2, 0.5f));
        availableInvestments.Add(new InvestmentType("Investment C", 100, 1f, 3, 0.1f));
        */

        // Utf�r investeringsprocessen
        //ChooseRandomInvestment();

        // Simulera �ldrande av investeringar och rensa gamla investeringar
        //UpdateInvestments();
    }

    public void createProject(int index)
    {
        availableInvestments.Add(availableInvestments[index]);
        investInfoUI.updateInvestInfo(availableInvestments[index], index);
    }

    public void chooseProjectIndex(int index)
    {
        investInfoUI.updateInvestInfo(availableInvestments[index], index);
    }

    public void investInProject()
    {
        InvestmentTypeData chosenInvestmentType = availableInvestments[investmentIndex];

        if (playerManager.playerCapitalGet() >= chosenInvestmentType.cost)
        {

            Debug.Log("Tillr�ckligt med kapital finns");
            playerManager.playerCapitalSet(-chosenInvestmentType.cost);

            // Slumpa ett tal mellan 0 och 1 f�r att avg�ra om investeringen lyckas
            float randomChance = Random.Range(0f, 1f);

            if (randomChance <= chosenInvestmentType.successProbability)
            {
                // Om investeringen lyckas, skapa en ny individuell investering
                InvestmentInstance newInvestment = new InvestmentInstance(chosenInvestmentType);
                playerManager.AddInvestment(newInvestment); // L�gg till investeringen i spelarens aktiva investeringar

                Debug.Log(chosenInvestmentType.name + " lyckades! Kostnad: " + chosenInvestmentType.cost +
                          ", Potentiell avkastning: " + newInvestment.potentialReturn);
            }
            else
            {
                Debug.Log(chosenInvestmentType.name + " misslyckades.");
            }
        }
        else
        {
            Debug.Log("Inte tillr�ckligt med pengar");
        }

    }

    
        public void ChooseRandomInvestment()
        {
            if (availableInvestments.Count > 0)
            {
                // V�lj ett slumpm�ssigt objekt fr�n listan
                int randomIndex = Random.Range(0, availableInvestments.Count);
                InvestmentTypeData chosenInvestmentType = availableInvestments[randomIndex];

                //Kontrollera om tillr�ckligt med kapital finns
                if (playerManager.playerCapitalGet() >= chosenInvestmentType.cost)
                {
                    Debug.Log("Tillr�ckligt med kapital finns");
                    playerManager.playerCapitalSet(-chosenInvestmentType.cost);
                    // Slumpa ett tal mellan 0 och 1 f�r att avg�ra om investeringen lyckas
                    float randomChance = Random.Range(0f, 1f);

                    if (randomChance <= chosenInvestmentType.successProbability)
                    {
                        // Om investeringen lyckas, skapa en ny individuell investering
                        InvestmentInstance newInvestment = new InvestmentInstance(chosenInvestmentType);
                        playerManager.AddInvestment(newInvestment); // L�gg till investeringen i spelarens aktiva investeringar

                        Debug.Log(chosenInvestmentType.name + " lyckades! Kostnad: " + chosenInvestmentType.cost +
                                  ", Potentiell avkastning: " + newInvestment.potentialReturn);
                    }
                    else
                    {
                        Debug.Log(chosenInvestmentType.name + " misslyckades.");
                    }
                }

                else
                {
                    Debug.Log("Inte tillr�ckligt med pengar");
                }
            }
            else
            {
                Debug.Log("Inga tillg�ngliga investeringar.");
            }
        }
    

    public void investmentIndexChange(int changeValue)
    {
        investmentIndex += changeValue;
        
        //Kontrollerar s� inte v�rdet passerar maxindex
        if(investmentIndex > availableInvestments.Count - 1)
        {
            investmentIndex = availableInvestments.Count - 1;
        }
        //Kontrollerar s� inte v�rdet blir negativt
        else if (investmentIndex < 0)
        {
            investmentIndex = 0;
        }

        investInfoUI.updateInvestInfo(availableInvestments[investmentIndex], investmentIndex);
    }

    /*
   public void UpdateInvestments()
    {
        // �ka �ldern p� alla aktiva investeringar
        foreach (InvestmentInstance inv in activeInvestments)
        {
            inv.IncrementAge();
        }

        // G� igenom listan och samla in avkastningen f�r investeringar som har uppn�tt sin livsl�ngd
        for (int i = activeInvestments.Count - 1; i >= 0; i--)
        {
            if (activeInvestments[i].HasReachedEndOfLifetime())
            {
                CollectReturn(activeInvestments[i]);
                activeInvestments.RemoveAt(i); // Ta bort investeringen fr�n listan
            }
        }

        Debug.Log("Aktiva investeringar uppdaterade. Kvarvarande: " + activeInvestments.Count);
    }

    void CollectReturn(InvestmentInstance investment)
    {
        // L�gg till den potentiella avkastningen till spelarens kapital
        playerCapital += investment.potentialReturn;
        Debug.Log("Avkastning fr�n " + investment.investmentType.name + " samlad in! Spelarens kapital: " + playerCapital);
    }
    */
}

