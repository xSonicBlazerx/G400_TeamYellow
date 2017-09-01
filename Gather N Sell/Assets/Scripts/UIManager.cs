using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    //player script
    Player player;

    //prices
    public int wCost = 0;
    public int bCost = 0;
    public int cCost = 0;

    //text objects
    public Text woodNum;
    public Text berryNum;
    public Text coalNum;

    public Text woodPrice;
    public Text berryPrice;
    public Text coalPrice;

    public Text coins;

	public Image item;
	public Text amount;

	public Sprite wood;
	public Sprite berries;
	public Sprite coal;

	public LineManager line;


    

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (SceneManager.GetActiveScene ().name == "Day") {
			//inventory
			woodNum.text = player.LumberSupply.ToString ();
			berryNum.text = player.BerrySupply.ToString ();
			coalNum.text = player.CoalSupply.ToString ();

			//prices
			woodPrice.text = wCost.ToString ();
			berryPrice.text = bCost.ToString ();
			coalPrice.text = cCost.ToString ();

			//total coins
			coins.text = player.MoneySupply.ToString ();

			//Customer request
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
    }

    // increases the price of wood
    public void woodUp()
    {
        wCost++;
    }

    //increases the price of Berries
    public void berryUp()
    {
        bCost++;
    }

    //increases the price of coal
    public void coalUp()
    {
        cCost++;
    }

    // decreases price of wood
    public void woodDown()
    {
        if (wCost > 0)
        { 
            wCost--;
        }
    }

    //decreases the price of Berries
    public void berryDown()
    {
        if (bCost > 0)
        {
            bCost--;
        }
    }

    //increases the price of coal
    public void coalDown()
    {
        if (cCost > 0)
        {
            cCost--;
        }
    }


}
