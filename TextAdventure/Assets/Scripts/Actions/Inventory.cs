using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(GameControler controller, string verb)
    {
        if(controller.player.inventory.Count == 0)
        {
            controller.currentText.text = "You have nothing!";
            return;
        }

        string result = "You have ";


        bool first = true;
        foreach(Items itemm in controller.player.inventory) 
        {
            if (first)
            {
                result += ", a " + itemm.itemName;
                first = false;
            }
            else
            {
                result+= "and a " + itemm.itemName;
            }
        }
        controller.currentText.text = result;
    }
}
