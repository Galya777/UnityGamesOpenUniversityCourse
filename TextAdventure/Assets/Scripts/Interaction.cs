using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    public Action action;

    [TextArea]
    public string response;

    public string textToMatch;

    public List<Items> itemsToDisable = new List<Items>();
    public List<Items> itemsToEnable = new List<Items>();

    public List<Connection> connectionsToDisable = new List<Connection>();
    public List<Connection> connectionsToEnable = new List<Connection>();

    public Location teleportLocation = null;
}

