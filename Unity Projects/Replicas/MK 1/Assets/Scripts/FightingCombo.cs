using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum AttackType { backwards = 0, punch = 1, kick = 2, down = 3, uppercut = 4};
public class FightingCombo : MonoBehaviour
{
    public KeyCode punchKey;
    public KeyCode kickKey;
    public KeyCode backwardsKey;
    public KeyCode crouchKey;
    public KeyCode uppercutKey;

    public Attack punchAttack;
    public Attack kickAttack;
    public Attack backwardsMove;
    public Attack Crouch;
    public Attack Uppercut;
    public List<Combo> combos;
    public float comboLeeway = 0.2f;

    public Animator anim;

    Attack curAttack = null;
    float timer = 0;
    float leeway = 0;
    bool skip = false;
    ComboInput lastInput;
    List<int> currentCombos = new List<int>();

    void Start()
    {
        anim = GetComponent<Animator>();
        PrimeCombos();
    }

    void PrimeCombos()
    {
        for(int i = 0; i < combos.Count; i++)
        {
            Combo c = combos[i];
            c.onInputted.AddListener(() =>
            {
                skip = true;
                Attack(c.comboAttack);
                ResetCombos();

            });
        }
    }

    
    void Update()
    {
        if(transform.localScale.x == 1)
        {
            backwardsKey = KeyCode.A;
        }
        if(transform.localScale.x == -1)
        {
            backwardsKey = KeyCode.D;
        }
        if (curAttack != null)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                curAttack = null;
            }
            return;
        }

        if(currentCombos.Count > 0)
        {
            leeway += Time.deltaTime;
            if(leeway >= comboLeeway)
            {
                if(lastInput != null)
                {
                    Attack(getAttackfromType(lastInput.type));
                    lastInput = null;
                }

                ResetCombos();

            }
        }
        else
        {
            leeway = 0;
        }

        ComboInput input = null;
        if (Input.GetKeyDown(punchKey))
        {
            input = new ComboInput(AttackType.punch);
        }
        if (Input.GetKeyDown(backwardsKey))
        {
            input = new ComboInput(AttackType.backwards);
        }
        if (Input.GetKeyDown(kickKey))
        {
            input = new ComboInput(AttackType.kick);
        }
        if (Input.GetKeyDown(crouchKey)){
            input = new ComboInput(AttackType.down);
            comboLeeway = 300;
        }
        if (Input.GetKeyUp(crouchKey))
        {
            comboLeeway = 0.2f;
        }

        if (Input.GetKeyDown(uppercutKey))
        {
            input = new ComboInput(AttackType.uppercut);
        }
        if (input == null) return;
        lastInput = input;

        List<int> remove = new List<int>();

        for(int i = 0; i<currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            if (c.continueCombo(input))
            {
                leeway = 0;
            }
            else
            {
                remove.Add(i);
            }
        }

        if (skip)
        {
            skip = false;
            return;
        }

        for(int i = 0; i < combos.Count; i++)
        {
            if (currentCombos.Contains(i)) continue;
            if (combos[i].continueCombo(input))
            {
                currentCombos.Add(i);
                leeway = 0;
            }
        }

        foreach(int i in remove)
        {
            currentCombos.RemoveAt(i);
        }
        if(currentCombos.Count <= 0)
        {
            Attack(getAttackfromType(input.type));
        }
    }

    void ResetCombos()
    {
        leeway = 0;
        for(int i = 0; i < currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            c.ResetCombo();
        }

        currentCombos.Clear();
    }

    void Attack(Attack att)
    {
        curAttack = att;
        timer = att.length;
        anim.Play(att.name, -1, 0);
    }

    Attack getAttackfromType(AttackType t)
    {
        if(t == AttackType.backwards)
        {
            return backwardsMove;
        }
        if (t == AttackType.punch)
        {
            return punchAttack;
        }
        if(t == AttackType.kick)
        {
            return kickAttack;
        }
        if(t == AttackType.down)
        {
            return Crouch;
        }
        if(t == AttackType.uppercut)
        {
            return Uppercut;
        }
        return null;
    }
}

[System.Serializable]
public class Attack
{
    public string name;
    public float length;

}

[System.Serializable]
public class ComboInput
{
    public AttackType type;

    public ComboInput(AttackType t)
    {
        type = t;
    }

    public bool IsSameAs (ComboInput test)
    {
        return ( type == test.type);
    }
}

[System.Serializable]
public class Combo
{
    public string name;
    public List<ComboInput> Inputs;
    public Attack comboAttack;
    public UnityEvent onInputted;
    int curInput = 0;

    public bool continueCombo(ComboInput i)
    {
        if (Inputs[curInput].IsSameAs(i))
        {
            curInput++;
            if(curInput >= Inputs.Count)
            {
                onInputted.Invoke();
                curInput = 0;
            }
            return true;
        }
        else
        {
            curInput = 0;
            return false;
        }
    }

    public ComboInput currentComboInput()
    {
        if (curInput >= Inputs.Count) return null;
        return Inputs[curInput];
       
    }

    public void ResetCombo()
    {
        curInput = 0;
    }
}

