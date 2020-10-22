using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCharacter : MonoBehaviour
{
    public RuntimeAnimatorController[] characters;
    public Animator anim;
    public int characterIndex;
    public Placeholder selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        selectedCharacter = GameObject.FindGameObjectWithTag("Placeholder").GetComponent<Placeholder>();
    }

    // Update is called once per frame
    void Update()
    {
        characterIndex = selectedCharacter.currentCharacter;
        anim.runtimeAnimatorController = characters[characterIndex];
    }
}
