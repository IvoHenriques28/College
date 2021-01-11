using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellStateMachine
{
    public delegate void OnMeteorSummon(Vector3 position, Vector3 rotation, GameObject meteor);
    public static event OnMeteorSummon _instantiateMeteor;

    public delegate void OnHordeSummon(Vector3 position, Vector3 rotation, GameObject horde);
    public static event OnMeteorSummon _instantiateHorde;

    public delegate void OnMeleeWizardSummon(Vector3 position, Vector3 rotation, GameObject wizard);
    public static event OnMeleeWizardSummon _instantiateWizard1;

    public delegate void OnRangedWizardSummon(Vector3 position, Vector3 rotation, GameObject wizard);
    public static event OnRangedWizardSummon _instantiateWizard2;

    public delegate void OnTrollSummon(Vector3 position, Vector3 rotation, GameObject troll);
    public static event OnTrollSummon _instantiateTroll;

    public delegate void OnWolfPackSummon(Vector3 position, Vector3 rotation, GameObject wolfPack);
    public static event OnWolfPackSummon _instantiateWolfPack;


    public static void RaiseMeteorSummonChange(Vector3 position, Vector3 rotation, GameObject meteor)
    {
        _instantiateMeteor?.Invoke(position, rotation, meteor);
    }

    public static void RaiseHordeSummonChange(Vector3 position, Vector3 rotation, GameObject horde)
    {
        _instantiateHorde?.Invoke(position, rotation, horde);
    }

    public static void RaiseMeleeWizardSummon(Vector3 position, Vector3 rotation, GameObject wizard)
    {
        _instantiateWizard1?.Invoke(position, rotation, wizard);
    }
    public static void RaiseRangedWizardSummon(Vector3 position, Vector3 rotation, GameObject wizard)
    {
        _instantiateWizard2?.Invoke(position, rotation, wizard);
    }

    public static void RaiseTrollSummon(Vector3 position,   Vector3 rotation, GameObject troll)
    {
        _instantiateTroll?.Invoke(position, rotation, troll);
    }

    public static void RaiseWolfPackSummon(Vector3 position, Vector3 rotation, GameObject wolfPack)
    {
        _instantiateWolfPack?.Invoke(position, rotation, wolfPack);
    }
}
