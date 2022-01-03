using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Transform closePoint;
    [SerializeField] private Transform openPoint;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float speed;
    private Animator anim;
    private bool aridActivate = false;
    private bool mossyActivate = false;

    private void Awake()
    {
        MossySlotController.onMossyActivate += OnMossyActivateHandler;
        MossySlotController.onMossyDeactivate += OnMossyDeactivateHandler;
        AridSlotController.onAridActivate += OnAridActivateHandler;
        AridSlotController.onAridDeactivate += OnAridDeactivateHandler;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (aridActivate && mossyActivate)
            OpenDoor();
    }

    private void OpenDoor()
    {
        this.gameObject.SetActive(false);
    }

    private void OnMossyActivateHandler()
    {
        Debug.Log("entro");
        mossyActivate = true;
    }

    private void OnMossyDeactivateHandler()
    {
        Debug.Log("Salio");
        mossyActivate = false;
    }

    private void OnAridActivateHandler()
    {
        Debug.Log("entro");
        aridActivate = true;
    }

    private void OnAridDeactivateHandler()
    {
        Debug.Log("Salio");
        aridActivate = false;
    }

    private void OnDestroy()
    {
        MossySlotController.onMossyActivate -= OnMossyActivateHandler;
        MossySlotController.onMossyDeactivate -= OnMossyDeactivateHandler;
        AridSlotController.onAridActivate -= OnAridActivateHandler;
        AridSlotController.onAridDeactivate -= OnAridDeactivateHandler;
    }
}
