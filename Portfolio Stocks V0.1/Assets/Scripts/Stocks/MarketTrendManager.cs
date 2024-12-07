using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketTrendManager : MonoBehaviour
{
    public List<sectorNameEnum> HotSectors = new List<sectorNameEnum>(); // Lista med heta sektorer
    public List<sectorNameEnum> allowedHotSectorsAtStart_1850 = new List<sectorNameEnum> { sectorNameEnum.Mine, sectorNameEnum.Railroad, sectorNameEnum.Industri };
    public Dictionary<GameObject, float> HotCompanies = new Dictionary<GameObject, float>(); // Bolag och deras "heta"-multiplikator
    public float HotDuration; // Hur länge en trend varar i spelrundor
    [SerializeField] float HotDurationTimerNow; //Hur många rundor som nuvarande sektor varit het

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
            Debug.Log($"[MarketTrendManager] Sektor '{sector}' är nu het!");
        }
    }

    //Hanterar hur länge nuvarande sektor varit het
    public void sectorTempTimer()
    {
        HotDurationTimerNow++;
        if (HotDurationTimerNow == HotDuration)
        {
            //Återställer timer
            HotDurationTimerNow = 0;

            //Rensar lista för heta sektorer
            HotSectors.Clear();

            //Väljer ny sektor som är het
            randomiseHotSector();

            //Debug.Log($"[MarketTrendManager] Sektor '{HotSectors[0]}' är nu het!");

        }
    }


    public void randomiseHotSector()
    {
        // Slumpa fram en sektor från enum
        //currentHotSector = (sectorNameEnum)Random.Range(0, System.Enum.GetValues(typeof(sectorNameEnum)).Length);

        currentHotSector = allowedHotSectorsAtStart_1850[Random.Range(0, allowedHotSectorsAtStart_1850.Count)];
        //Debug.Log($"Ny het sektor: {currentHotSector}");

        if (!HotSectors.Contains(currentHotSector))
        {
            HotSectors.Add(currentHotSector);
            //Debug.Log($"[MarketTrendManager] Sektor '{currentHotSector}' är nu het!");
        }
    }

    public void SetCompanyHot(GameObject company, float multiplier)
    {
        if (!HotCompanies.ContainsKey(company))
        {
            HotCompanies[company] = multiplier;
            _hotCompanyTimers[company] = HotDuration;
            Debug.Log($"[MarketTrendManager] Företaget '{company.name}' är nu hett med en multiplikator på {multiplier}x!");
        }
    }

    public void UpdateTrends()
    {
        // Minska timers för heta företag
        List<GameObject> companiesToRemove = new List<GameObject>();
        foreach (var company in _hotCompanyTimers.Keys)
        {
            _hotCompanyTimers[company] -= 1; // 1 enhet per spelrunda
            if (_hotCompanyTimers[company] <= 0)
            {
                companiesToRemove.Add(company);
            }
        }

        // Ta bort utgångna heta företag
        foreach (var company in companiesToRemove)
        {
            HotCompanies.Remove(company);
            _hotCompanyTimers.Remove(company);
            Debug.Log($"[MarketTrendManager] Företaget '{company.name}' är inte längre hett.");
        }

        // Minska heta sektorer efter samma logik om önskas
    }

    public bool IsSectorHot(sectorNameEnum sector) => HotSectors.Contains(sector);

    public float GetCompanyMultiplier(GameObject company) =>
        HotCompanies.ContainsKey(company) ? HotCompanies[company] : 1f;
}
