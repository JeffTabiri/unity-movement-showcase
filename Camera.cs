using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Camera : MonoBehaviour
{

    [SerializeField] private PlayerRun playerRunObject;

    private Vector3 positiveOffset;

    private Vector3 negativeOffset;

    private BoxCollider2D cameraBox;

    private bool isFacingRight;


    [SerializeField] private float t;

    // Start is called before the first frame update
    void Start()
    {
        cameraBox = GetComponent<BoxCollider2D>();
        positiveOffset = playerRunObject.Rb.position + new Vector2(1, 0);
        negativeOffset = playerRunObject.Rb.position + new Vector2(-1, 0);
        cameraBox.transform.position = positiveOffset;
    }

    // Update is called once per frame
    void Update()
    {
        positiveOffset = playerRunObject.Rb.position + new Vector2(1, 0);
        negativeOffset = playerRunObject.Rb.position + new Vector2(-1, 0);
        CheckDirection();
    }

    private void CheckDirection()
    {
        if (playerRunObject.IsFacingRight)
        {
            cameraBox.transform.position = Vector3.Lerp(cameraBox.transform.position, positiveOffset, 0.1f);
        }
        else if (!playerRunObject.IsFacingRight)
        {
            cameraBox.transform.position = Vector3.Lerp(cameraBox.transform.position, negativeOffset, 0.1f);
        }
    }

    public void PositiveOffsetLerp()
    {
        cameraBox.transform.position = Vector3.Lerp(cameraBox.transform.position, positiveOffset, 0.1f);
    }

    public void NegativeOffsetLerp()
    {
        cameraBox.transform.position = Vector3.Lerp(cameraBox.transform.position, negativeOffset, 0.1f);
    }

}
