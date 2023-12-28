using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class divPolicyPrefab : MonoBehaviour
{

	[Tooltip("�kning av utdelning om det till�ts")]
	public float divPolicyChangeDiv;
	[Tooltip("Maximal utdelningsandel")]
	public float divPolicyMaxPayouRatio;
	public bool companyPaysDividend;
	public float startPayDividendWhenEPS;
	public float divPayoutPerShare;
	//[SerializeField] float divPayoutTotal;
	public stockInformation StockInformation;

	private void Awake()
	{
		StockInformation = GetComponent<stockInformation>();
	}

	public void changeDividendPayoutTotal(float amount)
	{
		divPayoutPerShare = amount;
		
	}
}
