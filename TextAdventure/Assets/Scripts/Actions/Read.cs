using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameControler controller, string noun)
    {
        ///checks items in room
        if (ReadItems(controller, controller.player.currentLocation.items, noun))
            return;

        ///checks item in inventory
        if (ReadItems(controller, controller.player.inventory, noun))
            return;


        controller.currentText.text = "Nothing happens ";
    }
    private bool ReadItems(GameControler controller, List<Items> items, string noun)
    {
        foreach (Items item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanReadItem(controller, item))
                {
                    return true;
                }
                if (item.InteractionWith(controller, "read", noun))
                {
                    return true;
                }
                controller.currentText.text = "There is nothing interesting about the " + noun;
                return true;
            }
        }
        return false;
    }

}