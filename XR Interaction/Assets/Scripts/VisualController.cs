using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VisualController : MonoBehaviour
{
    public GameObject handVisual;
    public XRBaseInteractor interactor;

    private void Awake()
    {
        interactor = GetComponent<XRBaseInteractor>();
    }

    private void OnEnable()
    {
        interactor.selectEntered.AddListener(HideHand);
        interactor.selectExited.AddListener(ShowHand);
    }
    void HideHand(SelectEnterEventArgs args)
    {
        handVisual.SetActive(false);
    }
    void ShowHand(SelectExitEventArgs args)
    {
        handVisual.SetActive(true);
    }
}
