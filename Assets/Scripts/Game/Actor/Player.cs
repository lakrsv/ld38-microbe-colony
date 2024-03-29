﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public override void OnTick()
    {
        base.OnTick();
    }

    public override void CreateActor()
    {
        gameObject.name = "Player Controller";

        var colonyScript = gameObject.AddComponent<BacteriaColony>();
        colonyScript.IsPlayer = true;

        var startTile = TileRegistry.Instance.GetTile(new Point(25, 25));
        colonyScript.ClaimTile(startTile);

        _colony = colonyScript;
    }

    public override void DestroyActor()
    {
        throw new NotImplementedException();
    }
}
