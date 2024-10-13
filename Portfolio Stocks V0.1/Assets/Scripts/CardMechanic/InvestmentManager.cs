using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InvestmentData;  // Se till att referera till InvestmentData

public class InvestmentManager : MonoBehaviour
{
    public List<InvestmentTypeData> availableInvestments;  // Lista över ScriptableObject-baserade investeringstyper
    //public List<InvestmentType> availableInvestments = new List<InvestmentType>();  // Lista över tillgängliga investeringstyper
    public PlayerManager playerManager; // Referens till PlayerManager
    public InvestInfoUI investInfoUI;
    [SerializeField] int investmentIndex; //Aktuell investering
    //public List<InvestmentInstance> activeInvestments = new List<InvestmentInstance>(); // Lista över aktiva investeringar (individuella instanser)

    //public float playerCapital = 0f; // Spelarens totala kapital

    void Start()
    {
        chooseProjectIndex(investmentIndex);

        /*
        // Exempel: Lägg till några investeringar till den tillgängliga listan
        availableInvestments.Add(new InvestmentType("Investment A", 100, 1f, 1, 0.2f));
        availableInvestments.Add(new InvestmentType("Investment B", 100, 1f, 2, 0.5f));
        availableInvestments.Add(new InvestmentType("Investment C", 100, 1f, 3, 0.1f));
        */

        // Utför investeringsprocessen
        //ChooseRandomInvestment();

        // Simulera åldrande av investeringar och rensa gamla investeringar
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

            Debug.Log("Tillräckligt med kapital finns");
            playerManager.playerCapitalSet(-chosenInvestmentType.cost);

            // Slumpa ett tal mellan 0 och 1 för att avgöra om investeringen lyckas
            float randomChance = Random.Range(0f, 1f);

            if (randomChance <= chosenInvestmentType.successProbability)
            {
                // Om investeringen lyckas, skapa en ny individuell investering
                InvestmentInstance newInvestment = new InvestmentInstance(chosenInvestmentType);
                playerManager.AddInvestment(newInvestment); // Lägg till investeringen i spelarens aktiva investeringar

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
            Debug.Log("Inte tillräckligt med pengar");
        }

    }

    
        public void ChooseRandomInvestment()
        {
            if (availableInvestments.Count > 0)
            {
                // Välj ett slumpmässigt objekt från listan
                int randomIndex = Random.Range(0, availableInvestments.Count);
                InvestmentTypeData chosenInvestmentType = availableInvestments[randomIndex];

                //Kontrollera om tillräckligt med kapital finns
                if (playerManager.playerCapitalGet() >= chosenInvestmentType.cost)
                {
                    Debug.Log("Tillräckligt med kapital finns");
                    playerManager.playerCapitalSet(-chosenInvestmentType.cost);
                    // Slumpa ett tal mellan 0 och 1 för att avgöra om investeringen lyckas
                    float randomChance = Random.Range(0f, 1f);

                    if (randomChance <= chosenInvestmentType.successProbability)
                    {
                        // Om investeringen lyckas, skapa en ny individuell investering
                        InvestmentInstance newInvestment = new InvestmentInstance(chosenInvestmentType);
                        playerManager.AddInvestment(newInvestment); // Lägg till investeringen i spelarens aktiva investeringar

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
                    Debug.Log("Inte tillräckligt med pengar");
                }
            }
            else
            {
                Debug.Log("Inga tillgängliga investeringar.");
            }
        }
    

    public void investmentIndexChange(int changeValue)
    {
        investmentIndex += changeValue;
        
        //Kontrollerar så inte värdet passerar maxindex
        if(investmentIndex > availableInvestments.Count - 1)
        {
            investmentIndex = availableInvestments.Count - 1;
        }
        //Kontrollerar så inte värdet blir negativt
        else if (investmentIndex < 0)
        {
            investmentIndex = 0;
        }

        investInfoUI.updateInvestInfo(availableInvestments[investmentIndex], investmentIndex);
    }

    /*
   public void UpdateInvestments()
    {
        // Öka åldern på alla aktiva investeringar
        foreach (InvestmentInstance inv in activeInvestments)
        {
            inv.IncrementAge();
        }

        // Gå igenom listan och samla in avkastningen för investeringar som har uppnått sin livslängd
        for (int i = activeInvestments.Count - 1; i >= 0; i--)
        {
            if (activeInvestments[i].HasReachedEndOfLifetime())
            {
                CollectReturn(activeInvestments[i]);
                activeInvestments.RemoveAt(i); // Ta bort investeringen från listan
            }
        }

        Debug.Log("Aktiva investeringar uppdaterade. Kvarvarande: " + activeInvestments.Count);
    }

    void CollectReturn(InvestmentInstance investment)
    {
        // Lägg till den potentiella avkastningen till spelarens kapital
        playerCapital += investment.potentialReturn;
        Debug.Log("Avkastning från " + investment.investmentType.name + " samlad in! Spelarens kapital: " + playerCapital);
    }
    */
}

