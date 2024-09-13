using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBiteCooldown : MonoBehaviour
{
    private Animator anim;
    private float timer;
    public float cooldownDuration = 3.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cooldownDuration)
        {
            anim.SetBool("isDone", true);
        }
    }
}
