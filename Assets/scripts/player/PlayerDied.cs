﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDied : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform barPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scaleBar = barPlayer.localScale;
        
    }
}
