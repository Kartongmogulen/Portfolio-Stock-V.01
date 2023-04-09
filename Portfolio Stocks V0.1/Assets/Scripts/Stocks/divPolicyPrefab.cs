using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class divPolicyPrefab : MonoBehaviour
{

	[Tooltip("Ökning av utdelning om det tillåts")]
	public float divPolicyChangeDiv;
	[Tooltip("Maximal utdelningsandel")]
	public float divPolicyMaxPayouRatio;
	public bool companyPaysDividend;
	public float startPayDividendWhenEPS;
	public float divPayout;
}
