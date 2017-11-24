﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuffs : MonoBehaviour {

    public GameObject debuff;
    Idebuff myCurrentStrategy;
    Idebuff myCurrentStrategyDecrepify;
    Idebuff myCurrentStrategyDisarm;
    Idebuff myCurrentStrategyBurn;



	void Awake () {

        myCurrentStrategyBurn = new Burn (transform);
        myCurrentStrategyDecrepify = new Decrepify (transform);
        myCurrentStrategyDisarm = new Disarm(transform);

    }
	
	
	void Update () {
        if ()
            myCurrentStrategy = myCurrentStrategyBurn;
        if ()
            myCurrentStrategy = myCurrentStrategyDecrepify;
        if ()
            myCurrentStrategy = myCurrentStrategyDisarm;



    }
}
