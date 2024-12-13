using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventAtDifferentEcoClimateManager : MonoBehaviour
{
    //Hanterar vad som h�nder d� h�ndelser slumpas vid olika ekonomiska klimat  

    //Sker vid �rsskifte: 
    //Vid recenssion. 1. Slumpas vilken sektor som p�verkas (olika f�r olika sektorer). 2. Ett av bolagen kommer p�verkas i den sektorn
    //Vid expanssion. 1. Slumpas vilken sektor som p�verkas (olika f�r olika sektorer). 2. Ett av bolagen kommer p�verkas i den sektorn

    [Header("Recenssion")]
    public float negativeImpactOnEPS;
    public List<float> RecenssionListaMedSektornsSannolkhet;
    public float SlhAttUtiValjsRecenssion;
    public float SlhAttTechValjsRecenssion;
    [Header("Expanssion")]
    public float positiveImpactOnEPS;
    public List<float> ExpanssionListaMedSektornsSannolkhet;
    public float SlhAttUtiValjsExpanssion;
    public float SlhAttTechValjsExpanssion;

    [SerializeField] float RecenssionTotalSannolikhet;
    [SerializeField] float ExpanssionTotalSannolikhet;
    [SerializeField] float randomInt;
    [SerializeField] int randomIntCompany;
    public stockMarketManager StockMarketManager;

    private void Start()
    {
        RecenssionListaMedSektornsSannolkhet.Add(SlhAttUtiValjsRecenssion);
        RecenssionListaMedSektornsSannolkhet.Add(SlhAttTechValjsRecenssion);

        ExpanssionListaMedSektornsSannolkhet.Add(SlhAttUtiValjsExpanssion);
        ExpanssionListaMedSektornsSannolkhet.Add(SlhAttTechValjsExpanssion);

        //valAvSektor();
    }

    public void valAvSektor()
    {
        RecenssionTotalSannolikhet = 0;
        ExpanssionTotalSannolikhet = 0;

        // Ber�kna den totala sannolikheten
        foreach (float Slh in RecenssionListaMedSektornsSannolkhet)
        {
            RecenssionTotalSannolikhet += Slh;
        }

        foreach (float Slh in ExpanssionListaMedSektornsSannolkhet)
        {
            ExpanssionTotalSannolikhet += Slh;
        }

        //Ska det ske en negativ eller positiv h�ndelse utifr�n ekonomiskt klimat
        if (GetComponent<economicClimate>().RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Rececssion)
        {
            randomInt = Random.Range(0, RecenssionTotalSannolikhet);
            
            if (randomInt < SlhAttUtiValjsRecenssion)
            {
                randomIntCompany = Random.Range(0, StockMarketManager.StockUtiList.Count);
                //Debug.Log("Uti v�ljs " + StockMarketManager.StockUtiList[randomIntCompany].name);
                StockMarketManager.StockUtiList[randomIntCompany].EPSGrowthMin -= negativeImpactOnEPS;
                StockMarketManager.StockUtiList[randomIntCompany].EPSGrowthMax -= negativeImpactOnEPS;

            }

            else if (randomInt < SlhAttUtiValjsRecenssion + SlhAttTechValjsRecenssion)
            {
                randomIntCompany = Random.Range(0, StockMarketManager.StockTechList.Count);
                //Debug.Log("Tech v�ljs " + StockMarketManager.StockTechList[randomIntCompany].name);
                StockMarketManager.StockTechList[randomIntCompany].EPSGrowthMin -= negativeImpactOnEPS;
                StockMarketManager.StockTechList[randomIntCompany].EPSGrowthMax -= negativeImpactOnEPS;
            }
        }

        if (GetComponent<economicClimate>().RecessionOrExpanssionEnum == recessionOrExpanssionEnum.Expanssion)
        {
            randomInt = Random.Range(0, ExpanssionTotalSannolikhet);
            if (randomInt < SlhAttUtiValjsExpanssion)
            {
               
                randomIntCompany = Random.Range(0, StockMarketManager.StockUtiList.Count);
                //Debug.Log("Uti v�ljs " + StockMarketManager.StockUtiList[randomIntCompany].name);
                StockMarketManager.StockUtiList[randomIntCompany].EPSGrowthMin += positiveImpactOnEPS;
                StockMarketManager.StockUtiList[randomIntCompany].EPSGrowthMax += positiveImpactOnEPS;
            }

            else if (randomInt < SlhAttUtiValjsExpanssion + SlhAttTechValjsExpanssion)
            {
                randomIntCompany = Random.Range(0, StockMarketManager.StockTechList.Count);
                //Debug.Log("Tech v�ljs " + StockMarketManager.StockTechList[randomIntCompany].name);
                StockMarketManager.StockTechList[randomIntCompany].EPSGrowthMin += positiveImpactOnEPS;
                StockMarketManager.StockTechList[randomIntCompany].EPSGrowthMax += positiveImpactOnEPS;
            }


            //Debug.Log("Expanssion" + randomInt);
        }

    }
}
