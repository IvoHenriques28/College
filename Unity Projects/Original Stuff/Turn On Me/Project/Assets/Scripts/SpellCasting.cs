using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellCasting : MonoBehaviour
{
   
    public int spellIndex;
    public GameObject meteor;
    public GameObject zombieHorde;
    public GameObject MeleeWizard;
    public GameObject RangedWizard;
    public GameObject meteorSpawner;
    public GameObject wolfPack;
    public GameObject troll;
    public GameObject player;

    public TextMeshProUGUI[] cooldown;

    public float[] time;

    private HunterClient client;

    public bool canSummon = true;

    private void Start()
    {
        SpellStateMachine._instantiateMeteor += CastMeteor;
        SpellStateMachine._instantiateHorde += CastHorde;
        SpellStateMachine._instantiateWizard1 += CastMeleeWizard;
        SpellStateMachine._instantiateWizard2 += CastRangedWizard;
        SpellStateMachine._instantiateTroll += CastTroll;
        SpellStateMachine._instantiateWolfPack += CastWolfPack;

        client = GameObject.FindGameObjectWithTag("Client").GetComponent<HunterClient>();
    }
    void Update()
    {
        for (int i = 0; i < cooldown.Length; i++)
        {
            time[i] = time[i] - Time.unscaledDeltaTime;
            if (time[i] <= 0)
            {
                time[i] = 0;
            }
            cooldown[i].text = time[i].ToString("00") + "s";
        }
        if (Input.GetMouseButtonDown(1))
        {        
            Cast(spellIndex);
        }
    }

    void Cast(int index)
    { 
        if(canSummon == true)
        {
            if (index == 1)
            {
                if (time[0] > 0)
                {

                }
                else
                {
                    time[0] = 30;
                    SpellStateMachine.RaiseMeteorSummonChange(meteorSpawner.transform.position, meteorSpawner.transform.rotation.eulerAngles, meteor);
                }
            }
            if (index == 2)
            {
                if (time[1] > 0)
                {

                }
                else
                {
                    time[1] = 15;
                    SpellStateMachine.RaiseHordeSummonChange(new Vector3(player.transform.position.x, 0, player.transform.position.z), player.transform.rotation.eulerAngles, zombieHorde);
                }
            }
            if (index == 3)
            {
                if (time[2] > 0)
                {

                }
                else
                {
                    time[2] = 10;
                    SpellStateMachine.RaiseMeleeWizardSummon(player.transform.position, player.transform.rotation.eulerAngles, MeleeWizard);
                }

            }
            if (index == 4)
            {
                if (time[3] > 0)
                {

                }
                else
                {
                    time[3] = 10;
                    SpellStateMachine.RaiseRangedWizardSummon(player.transform.position, player.transform.rotation.eulerAngles, RangedWizard);
                }
            }
            if (index == 5)
            {
                if (time[4] > 0)
                {

                }
                else
                {
                    time[4] = 30;
                    SpellStateMachine.RaiseTrollSummon(new Vector3(player.transform.position.x, 0, player.transform.position.z), player.transform.rotation.eulerAngles, troll);
                }
            }
            if (index == 6)
            {
                if (time[5] > 0)
                {

                }
                else
                {
                    time[5] = 10;
                    SpellStateMachine.RaiseWolfPackSummon(new Vector3(player.transform.position.x, 0, player.transform.position.z), player.transform.rotation.eulerAngles, wolfPack);
                }
            }
        }
 
    }
    private void CastMeteor(Vector3 position, Vector3 rotation, GameObject _meteor)
    {
        Instantiate(_meteor, position, Quaternion.Euler(rotation));
        client.SendMobPacket(position, rotation, "Meteor");
    }
    private void CastHorde(Vector3 position, Vector3 rotation, GameObject _horde)
    {
        Debug.Log(player.transform.rotation.eulerAngles);
        Instantiate(_horde, position, Quaternion.Euler(rotation));
        client.SendMobPacket(position, rotation, "Horde");
    }
    private void CastRangedWizard(Vector3 position, Vector3 rotation, GameObject wizard)
    {
        Instantiate(wizard, position, Quaternion.Euler(rotation));
        client.SendMobPacket(position, rotation, "RangedWizard");
    }
    private void CastMeleeWizard(Vector3 position, Vector3 rotation, GameObject wizard)
    {
        Instantiate(wizard, position, Quaternion.Euler(rotation));
        client.SendMobPacket(position, rotation, "MeleeWizard");
    }
    private void CastTroll(Vector3 position, Vector3 rotation, GameObject troll)
    {
       
        Instantiate(troll, position, Quaternion.Euler(rotation));
        client.SendMobPacket(position, rotation, "Troll");
    }
    private void CastWolfPack(Vector3 position, Vector3 rotation, GameObject wolfPack)
    {
        Instantiate(wolfPack, position, Quaternion.Euler(rotation));
        client.SendMobPacket(position, rotation, "WolfPack");
    }


}
