using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{
    public override void RespondToInput(GameControler controller, string noun)
    {
        ///checks items in room
        if (CheckItems(controller, controller.player.currentLocation.items, noun))
            return;

        ///checks item in inventory
        if (CheckItems(controller, controller.player.inventory, noun))
            return;


        controller.currentText.text = "You can't see a "+noun;
    }
    private bool CheckItems(GameControler controller, List<Items> items, string noun)
    {
        foreach(Items item in items)
        {
            if (item.itemName == noun)
            {
                if (item.InteractionWith(controller, "examine", noun))
                {
                    return true;
                }
                controller.currentText.text = "There is nothing interesting about the "+noun;
                return true;
            }
        }
        return false;
    }

 }
