using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class historicEventManager : MonoBehaviour
{
    //[SerializeField] int yearsBetweenEvents;
    [SerializeField] int eventFrequencyYear;
    public List <historicEvent> historicEvents;
    public Text nameEvent;
    public Text eventDescription;
    public Text eventEffect;
    public stockMarketManager StockMarketManager;
    public timeManager TimeManager;

    public void newEventHappened()
    {
        int randomInt = Random.Range(0, historicEvents.Count); //Slumpar vilken händelse som ska ske
        //int randomInt = 1;

        //Kontrollera om en händelse ska ske
        if (TimeManager.year % eventFrequencyYear == 0)
        {

           

            Debug.Log(historicEvents[randomInt].getEventName());
            displayEventInfo(randomInt);

            if (historicEvents[randomInt].getEventName() == "First commercial oilwell")
            {
                Debug.Log("Första oljekällan");
                changeOilCompaniesEarnings(historicEvents[randomInt]);
                displatEventEffect(historicEvents[randomInt], "Oil");
            }

            //Tar bort händelsen som blir vald
            historicEvents.RemoveAt(randomInt);

        }
    }

    public void displayEventInfo(int eventInt)
    {
        nameEvent.text = historicEvents[eventInt].getEventName();
        eventDescription.text = historicEvents[eventInt].getEventDescription();
    }

    public void displatEventEffect(historicEvent HistoricEvent, string effectedSector)
    {
        eventEffect.text = "Earnings change: " + HistoricEvent.OilCompaniesEarningsChange + "% " + effectedSector;
    }

    public void changeOilCompaniesEarnings(historicEvent HistoricEvent)
    {
        Debug.Log("Antal oljebolag: " + StockMarketManager.StockPrefabOilList.Count);
        for (int i = 0; StockMarketManager.StockPrefabOilList.Count > i; i++)
        {
            Debug.Log("Går igenom alla oljebolag");
            StockMarketManager.StockPrefabOilList[i].GetComponent<stock>().EPSGrowthMax += HistoricEvent.OilCompaniesEarningsChange;
            StockMarketManager.StockPrefabOilList[i].GetComponent<stock>().EPSGrowthMin += HistoricEvent.OilCompaniesEarningsChange;
        }
    }
}
