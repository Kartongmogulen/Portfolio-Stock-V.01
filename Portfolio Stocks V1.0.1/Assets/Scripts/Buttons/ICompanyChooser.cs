using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Gr�nssnitt f�r att hantera val av f�retag
public interface ICompanyChooser
{
    void ChooseCompany(int cityIndex, int sectorIndex);
}
