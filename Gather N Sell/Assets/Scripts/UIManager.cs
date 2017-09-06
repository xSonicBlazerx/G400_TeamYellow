﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    //player script
    private Player player;
	public GameManager gameManager;

	public GameObject BLACK;

    //prices
    public int wCost = 0;
    public int bCost = 0;
    public int cCost = 0;
    
    //text objects
    public Text woodNum;
    public Text berryNum;
    public Text coalNum;

    public InputField woodPrice;
    public InputField berryPrice;
    public InputField coalPrice;

    public Text coins;

	public Image item;
	public Text amount;

	public Sprite wood;
	public Sprite berries;
	public Sprite coal;

	public LineManager line;

    public Slider slider;
    

    

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        //prices
        woodPrice.text = wCost.ToString();
        berryPrice.text = bCost.ToString();
        coalPrice.text = cCost.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (SceneManager.GetActiveScene ().name == "Day") {

			//inventory
			woodNum.text = Player.LumberSupply.ToString ();
			berryNum.text = Player.BerrySupply.ToString ();
			coalNum.text = Player.CoalSupply.ToString ();
            

			//total coins
			coins.text = Player.MoneySupply.ToString ();

			//Customer request
			if (GameManager.customersLeft > 0) {
				amount.text = "" + line.line [0].GetComponent<Customer> ().amount;
				switch (line.line [0].GetComponent<Customer> ().resource) {
				case "wood":
					item.GetComponent<Image> ().sprite = wood;
					break;
				case "berries":
					item.GetComponent<Image> ().sprite = berries;
					break;
				default:
					item.GetComponent<Image> ().sprite = coal;
					break;
				}
			}

            //set slider
            slider.value = line.customersLeft;
		}
    }

    // increases the price of wood
    public void woodUp()
    {
        wCost++;
        woodPrice.text = wCost.ToString();
    }

    //increases the price of Berries
    public void berryUp()
    {
        bCost++;
        berryPrice.text = bCost.ToString();
    }

    //increases the price of coal
    public void coalUp()
    {
        cCost++;
        coalPrice.text = cCost.ToString();
    }

    // decreases price of wood
    public void woodDown()
    {
        if (wCost > 0)
        {
            wCost--;
            woodPrice.text = wCost.ToString();
        }
    }

    //decreases the price of Berries
    public void berryDown()
    {
        if (bCost > 0)
        {
            bCost--;
            berryPrice.text = bCost.ToString();
        }
    }

    //increases the price of coal
    public void coalDown()
    {
        if (cCost > 0)
        {
            cCost--;
            coalPrice.text = cCost.ToString();
        }
    }

    public void woodSet(string cost)
    {
        wCost = int.Parse(cost);
    }


    public void berrySet(string cost)
    {
        bCost = int.Parse(cost);
    }


    public void coalSet(string cost)
    {
        cCost = int.Parse(cost);
    }

	public void CompleteSceneDay(){
		BLACK.SetActive (true);
		Player.LumberSupply.ToString ();
		Player.BerrySupply.ToString ();
		Player.CoalSupply.ToString ();
		Player.LumberSold.ToString ();
		Player.BerrySold.ToString ();
		Player.CoalSold.ToString ();
		Player.MoneyMade.ToString ();
		Player.CustomersServed.ToString ();
		while (true) {
			if (Input.GetKeyDown (KeyCode.Space))
				break;
		}
		gameManager.ManagerNight ();
	}
}
