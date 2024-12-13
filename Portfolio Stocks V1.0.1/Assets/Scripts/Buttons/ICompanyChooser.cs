using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Gränssnitt för att hantera val av företag
public interface ICompanyChooser
{
    void ChooseCompany(int cityIndex, int sectorIndex);
}
