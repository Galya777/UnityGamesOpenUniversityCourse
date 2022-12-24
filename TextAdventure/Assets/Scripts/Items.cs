using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public string itemName;

    public string description;

    public bool playerCanTake;

    public bool itemEnabled=true;

    public Items target=null;

    public Interaction[] interactions;

    public bool playerCanTalk = false;

    public bool playerCanGive = false;

    public bool playerCanRead = false;

    public bool InteractionWith(GameControler controller, string actionKeyWord, string noun ="")
    {
        foreach(Interaction interaction in interactions)
        {
            if (interaction.action.keyword == actionKeyWord)
            {
                if (noun != "" && noun.ToLower() != interaction.textToMatch.ToLower())
                    continue;


                foreach(Items disabled in interaction.itemsToDisable)
                {
                    disabled.itemEnabled = false;
                }
                foreach (Items enabled in interaction.itemsToEnable)
                {
                    enabled.itemEnabled = true;
                }
                foreach (Connection disabled in interaction.connectionsToDisable)
                {
                    disabled.connectionEnable = false;
                }
                foreach (Connection enabled in interaction.connectionsToEnable)
                {
                    enabled.connectionEnable = true;
                }

                if (interaction.teleportLocation != null)
                {
                    controller.player.Teleport(controller, interaction.teleportLocation);
                }
                controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);
                return true;
            }
        }
        return false;
    }
}
