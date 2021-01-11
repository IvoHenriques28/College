using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public delegate void OnTimeStop();
    public static event OnTimeStop _timeStop;

    public delegate void OnElectricBall();
    public static event OnElectricBall _electricBall;

    public delegate void OnHeal();
    public static event OnHeal _heal;

    public delegate void OnBlock();
    public static event OnBlock _block;

    public delegate void OnUltimate();
    public static event OnUltimate _ultimate;

    public static void RaiseOnUltimate()
    {
        _ultimate?.Invoke();
    }

    public static void RaiseOnBlock()
    {
        _block?.Invoke();
    }

    public static void RaiseOnHeal()
    {
        _heal?.Invoke();
    }

    public static void RaiseOnElectricBall()
    {
        _electricBall?.Invoke();
    }

    public static void RaiseOnTimeStop()
    {
        _timeStop?.Invoke();
    }
}
