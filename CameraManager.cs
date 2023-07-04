using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    private Coroutine _coroutine;

    [Header("Controls for lerping the Y damping player during jump/fall")] 
    
    [SerializeField]
    private float fallPanAmount = 0.25f;

    [SerializeField]
    private float fallPanTime = 0.35f;

    public float fallSpeedYDampingChangeTreshold = -0.15f;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
