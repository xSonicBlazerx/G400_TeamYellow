using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //amount in inventory
    public int woodCount = 0;
    public int berryCount = 0;
    public int coalCount = 0;

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
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        woodNum.text = woodCount.ToString();
        berryNum.text = berryCount.ToString();
        coalNum.text = coalCount.ToString();

        woodPrice.text = wCost.ToString();
        berryPrice.text = bCost.ToString();
        coalPrice.text = cCost.ToString();
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
