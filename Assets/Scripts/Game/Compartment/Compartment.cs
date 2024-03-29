﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Compartment : MonoBehaviour, IUpdateable
{
    public CompartmentType Type { get; protected set; }
    public int AdjacencyCount { get; protected set; }

    protected ResourceRequirement _resourceRequirement;
    protected Color _compartmentColor;

    private void Start()
    {
        //Register with a Compartment Updater or so
        var compartmentName = GetType().ToString();
        var type = compartmentName.Replace("Compartment", "");

        gameObject.name = compartmentName;
        Type = (CompartmentType)Enum.Parse(typeof(CompartmentType), type);

        _resourceRequirement = ResourceRequirement.GetRequirements(Type);

        EntityTickUpdater.Instance.RegisterCompartment(this);
    }

    public virtual void OnTick()
    {
        Debug.Log(string.Format("Updated Compartment {0} of Type {1}", gameObject.name, Type));
    }

    public abstract bool Upgrade();
    public abstract bool Destroy();
}
