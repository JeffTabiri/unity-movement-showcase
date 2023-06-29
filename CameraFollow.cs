using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;

    [SerializeField] private float flipRotationTimeY;

    private Coroutine turnCoroutine;

    private PlayerRun player;

    private bool isFacingRight;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position;
    }

    public void CallTurn()
    {
        turnCoroutine = StartCoroutine(FlipYLerp());
    }

    private  IEnumerator FlipYLerp()
    {
        float startPos = transform.localEulerAngles.y;
        float endPos = DetermineEndPos();
        float yRotation = 0;

        float elapsedTime = 0f;

        while (elapsedTime < flipRotationTimeY)
        {
            elapsedTime += Time.deltaTime;
            yRotation = Mathf.Lerp(startPos, endPos, (elapsedTime / flipRotationTimeY));
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
            yield return 0;
        }

    }

    private float DetermineEndPos()
    {
        isFacingRight = !isFacingRight;

        if (isFacingRight)
        {
            return 180f;
        }
        else
        {
            return 0;
        }
    }
    
    
}
