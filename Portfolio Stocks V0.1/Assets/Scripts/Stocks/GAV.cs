using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAV : MonoBehaviour
{
	//Beräkning av GAV
	public GameObject playerScriptsGO;
	public portfolioStock PortfolioStock;

	public List<float> utiCompanyGAVPlayer;
	public List<float> utiCompanySharesOwned;
	public float[] utiTotalInvest;

	public List<float> techCompanyGAVPlayer;
	public List<float> techCompanySharesOwned;
	public float[] techTotalInvest;

	private void Awake()
	{
		PortfolioStock = playerScriptsGO.GetComponent<portfolioStock>();
	}

	public void utiGAV()
	{
		utiCompanySharesOwned = PortfolioStock.utiCompanySharesOwned;
		utiTotalInvest = PortfolioStock.utiTotalInvest;

		for (int i = 0; i < utiCompanySharesOwned.Count; i++)
		{

			if (utiCompanySharesOwned[i] == 0)
			{
				utiCompanyGAVPlayer[i] = 0;
				PortfolioStock.utiTotalInvest[i] = 0;
			}
			else
			{
				utiCompanyGAVPlayer[i] = utiTotalInvest[i] / utiCompanySharesOwned[i];
			}

		}

		PortfolioStock.utiGAV = utiCompanyGAVPlayer;
	}

	public void techGAV()
	{
		techCompanySharesOwned = PortfolioStock.techCompanySharesOwned;
		techTotalInvest = PortfolioStock.techTotalInvest;

		for (int i = 0; i < techCompanySharesOwned.Count; i++)
		{

			if (techCompanySharesOwned[i] == 0)
			{
				techCompanyGAVPlayer[i] = 0;
				PortfolioStock.techTotalInvest[i] = 0;
			}
			else
			{
				techCompanyGAVPlayer[i] = techTotalInvest[i] / techCompanySharesOwned[i];
			}

		}

		PortfolioStock.techGAV = techCompanyGAVPlayer;
	}

	public void utiGAVSell()
	{
		for (int i = 0; i < utiCompanySharesOwned.Count; i++)
		{

			if (utiCompanySharesOwned[i] == 0)
			{
				utiCompanyGAVPlayer[i] = 0;
				PortfolioStock.utiTotalInvest[i] = 0;
			}
		}
	}

	public void techGAVSell()
	{
		for (int i = 0; i < techCompanySharesOwned.Count; i++)
		{

			if (techCompanySharesOwned[i] == 0)
			{
				techCompanyGAVPlayer[i] = 0;
				PortfolioStock.techTotalInvest[i] = 0;
			}
		}
	}
}