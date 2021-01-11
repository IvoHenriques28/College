using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemoteHunterSpells : MonoBehaviour
{
    public int spellIndex;
    public int health;
    public int maxHealth;
    public int minHealth = 0;
    public float timer;
    public AudioSource ac;
    public AudioClip timeStop;
    bool timeStopped = false;
    public AudioClip timeResume;
    public AudioClip heal;
    public AudioClip FireRelease;
    public AudioClip ElectricRelease;
    public AudioClip UltimateRelease;
    public AudioClip Deflect;

    private Animator anim;

    public GameObject ElectricBall;
    public GameObject UltimateSpawner;
    public GameObject UltimateMove;
    public GameObject FireBall;
    public GameObject ElectricBallSpawner;
    private GameObject client;




    public float[] time;

    public bool deflectable;


    // Start is called before the first frame update
    void Start()
    {
        PlayerStateMachine._timeStop += CastTimeStop;
        PlayerStateMachine._electricBall += CastElectricBall;
        PlayerStateMachine._heal += CastHealSpell;
        PlayerStateMachine._block += CastBlock;
        PlayerStateMachine._ultimate += CastUltimate;
        ac = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        client = GameObject.FindGameObjectWithTag("Client");
    }

    private void CastUltimate()
    {
        ac.clip = UltimateRelease;
        ac.Play();
        anim.SetTrigger("Ultimate");
    }

    private void SummonUltimate()
    {

        Instantiate(UltimateMove, UltimateSpawner.transform.position, Quaternion.identity);
    }

    private void CastBlock()
    {
        anim.SetTrigger("Blocking");
    }

    private void CastHealSpell()
    {
        ac.clip = heal;
        ac.Play();
        health = health + 30;
    }

    private void CastElectricBall()
    {
        anim.SetTrigger("Shooting");
    }

    private void SpawnElectricBall()
    {
        if (spellIndex == 2)
        {
            ac.clip = ElectricRelease;
            ac.Play();
            Instantiate(ElectricBall, ElectricBallSpawner.transform.position, transform.rotation);
        }
        else if (spellIndex == 3)
        {
            ac.clip = FireRelease;
            ac.Play();
            Instantiate(FireBall, ElectricBallSpawner.transform.position, transform.rotation);
        }
        anim.ResetTrigger("Shooting");
    }

    private void CastTimeStop()
    {
        ac.clip = timeStop;
        ac.Play();
        Time.timeScale = 0;
        timeStopped = true;
    }



    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < time.Length; i++)
        {
            time[i] = time[i] - Time.unscaledDeltaTime;
            if (time[i] <= 0)
            {
                time[i] = 0;
            }
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= minHealth)
        {
            client.GetComponent<HunterClient>().youWon = true;
            client.GetComponent<HunterClient>().Disconnect();
            SceneManager.LoadScene(4);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Cast(spellIndex);
        }
        if (timeStopped == true)
        {
            timer += Time.unscaledDeltaTime;
            if (timer > 6f)
            {
                timer = 0;
                ac.clip = timeResume;
                ac.Play();
                Time.timeScale = 1;
                timeStopped = false;
            }
        }
    }

    public void Cast(int spellIndex)
    {
      
        if (spellIndex == 1 && timeStopped == false)
        {
            if (time[0] > 0)
            {

            }
            else
            {
                time[0] = 20f;
                PlayerStateMachine.RaiseOnTimeStop();
            }

        }
        if (spellIndex == 2)
        {
            if (time[1] > 0)
            {

            }
            else
            {
                time[1] = 5f;
                PlayerStateMachine.RaiseOnElectricBall();

            }
        }
        if (spellIndex == 3)
        {
            if (time[2] > 0)
            {

            }
            else
            {
                time[2] = 5f;
                PlayerStateMachine.RaiseOnElectricBall();

            }
        }
        if (spellIndex == 4)
        {
            if (time[3] > 0)
            {

            }
            else
            {
                time[3] = 10f;
                PlayerStateMachine.RaiseOnHeal();
            }
        }
        if (spellIndex == 5)
        {
            if (time[4] > 0)
            {

            }
            else
            {
                time[4] = 15f;
                PlayerStateMachine.RaiseOnBlock();
            }
        }
        if (spellIndex == 6)
        {
            if (time[5] > 0)
            {

            }
            else
            {
                time[5] = 40f;
                PlayerStateMachine.RaiseOnUltimate();
            }
        }
    }

    void DeflectObject()
    {
        ac.clip = Deflect;
        ac.Play();
        deflectable = true;
        StartCoroutine(Undeflect());
    }
    IEnumerator Undeflect()
    {
        yield return new WaitForSeconds(0.1f);
        deflectable = false;
    }

    public void TakeDmg(int dmg)
    {
        health = health - dmg;
    }
}
