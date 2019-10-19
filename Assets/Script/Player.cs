using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{
    public int wallDammage=1;
    public int pointPerFod = 10;
    public int pointPerSoda = 20;
    public float restarLevelDelay = 1f;

    private Animator animator;
    private int food;
    // Start is called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();

        food = GameManager.instance.playerFoodPoint;

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
