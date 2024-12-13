using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketTrendManager : MonoBehaviour
{
    public List<sectorNameEnum> HotSectors = new List<sectorNameEnum>(); // Lista med heta sektorer
    public List<sectorNameEnum> allowedHotSectorsAtStart_1850 = new List<sectorNameEnum> { sectorNameEnum.Mine, sectorNameEnum.Railroad, sectorNameEnum.Industri };
    public Dictionary<GameObject, float> HotCompanies = new Dictionary<GameObject, float>(); // Bolag och deras "heta"-multiplikator
    public float HotDuration; // Hur l�nge en trend varar i spelrundor
    [SerializeField] float HotDurationTimerNow; //Hur m�nga rundor som nuvarande sektor varit het

    [Tooltip("Procent i prispremium (heltal)")]
    [SerializeField] private float _pricePremium;    

    private Dictionary<GameObject, float> _hotCompanyTimers = new Dictionary<GameObject, float>();
    //[SerializeField] sectorNameEnum sectors;

    [Header("Aktiv sektor")]
    public sectorNameEnum currentHotSector;

    private void Start()
    {
        //SetSectorHot(sectorNameEnum);
        randomiseHotSector();
    }

    // Publik get och privat set
    public float PricePremium
    {
        get => _pricePremium;
        private set => _pricePremium = value;
    }

    public void SetSectorHot(sectorNameEnum sector)
    {
        if (!HotSectors.Contains(sector))
        {
            HotSectors.Add(sector);
            Debug.Log($"[MarketTrendManager] Sektor '{sector}' �r nu het!");
        }
    }

    //Hanterar hur l�nge nuvarande sektor varit het
    public void sectorTempTimer()
    {
        HotDurationTimerNow++;
        if (HotDurationTimerNow == HotDuration)
        {
            //�terst�ller timer
            HotDurationTimerNow = 0;

            //Rensar lista f�r heta sektorer
            HotSectors.Clear();

            //V�ljer ny sektor som �r het
            randomiseHotSector();

            //Debug.Log($"[MarketTrendManager] Sektor '{HotSectors[0]}' �r nu het!");

        }
    }


    public void randomiseHotSector()
    {
        // Slumpa fram en sektor fr�n enum
        //currentHotSector = (sectorNameEnum)Random.Range(0, System.Enum.GetValues(typeof(sectorNameEnum)).Length);

        currentHotSector = allowedHotSectorsAtStart_1850[Random.Range(0, allowedHotSectorsAtStart_1850.Count)];
        //Debug.Log($"Ny het sektor: {currentHotSector}");

        if (!HotSectors.Contains(currentHotSector))
        {
            HotSectors.Add(currentHotSector);
            //Debug.Log($"[MarketTrendManager] Sektor '{currentHotSector}' �r nu het!");
        }
    }

    public void SetCompanyHot(GameObject company, float multiplier)
    {
        if (!HotCompanies.ContainsKey(company))
        {
            HotCompanies[company] = multiplier;
            _hotCompanyTimers[company] = HotDuration;
            Debug.Log($"[MarketTrendManager] F�retaget '{company.name}' �r nu hett med en multiplikator p� {multiplier}x!");
        }
    }

    public void UpdateTrends()
    {
        // Minska timers f�r heta f�retag
        List<GameObject> companiesToRemove = new List<GameObject>();
        foreach (var company in _hotCompanyTimers.Keys)
        {
            _hotCompanyTimers[company] -= 1; // 1 enhet per spelrunda
            if (_hotCompanyTimers[company] <= 0)
            {
                companiesToRemove.Add(company);
            }
        }

        // Ta bort utg�ngna heta f�retag
        foreach (var company in companiesToRemove)
        {
            HotCompanies.Remove(company);
            _hotCompanyTimers.Remove(company);
            Debug.Log($"[MarketTrendManager] F�retaget '{company.name}' �r inte l�ngre hett.");
        }

        // Minska heta sektorer efter samma logik om �nskas
    }

    public bool IsSectorHot(sectorNameEnum sector) => HotSectors.Contains(sector);

    public float GetCompanyMultiplier(GameObject company) =>
        HotCompanies.ContainsKey(company) ? HotCompanies[company] : 1f;
}
