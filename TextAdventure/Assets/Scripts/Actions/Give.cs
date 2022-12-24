using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Give")]
public class Give : Action
{
    public override void RespondToInput(GameControler controller, string noun)
    {
        if (controller.player.HasByItemName(noun))
        {
            if (GiveToItem(controller, controller.player.currentLocation.items, noun))
                return;
            
            controller.currentText.text = "Nothing takes the "+noun;
        }
        controller.currentText.text = "You do not have " + noun;
    }

    private bool GiveToItem(GameControler controller, List<Items> items, string noun)
    {
        foreach (Items item in items)
        {
            if (item.itemEnabled)
            {
                if (controller.player.CanGiveToItem(controller, item))
                {
                    if (item.InteractionWith(controller, "give", noun))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
