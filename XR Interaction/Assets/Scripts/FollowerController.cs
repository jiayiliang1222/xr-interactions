using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class FollowerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject follower;
    public float followSpeed = 1.0f;
    public float followRotationSpeed = 1.0f;


    XRRayInteractor rayInteractor;
    public void FollowStart(HoverEnterEventArgs args)

    {
        if (rayInteractor == null)
        {
        rayInteractor = args.interactor as XRRayInteractor;
            if (rayInteractor != null)
            {
                Coroutine handle = StartCoroutine("Follow");
                //stop following
            }
        }
    }

    public void FollowStop()
    {
        StopAllCoroutines();
        //stop following!
        rayInteractor = null;
    }
    IEnumerator Follow()
    {
        while (true)

        {
            if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))

            {
                follower.transform.position = Vector3.MoveTowards(follower.transform.position, hit.point, followSpeed * Time.deltaTime);
                Vector3 targetDir = hit.point - follower.transform.position;
                Vector3 rotationAmount = Vector3.RotateTowards((follower.transform.forward, targetDir, followRotationSpeed * Time.deltaTime, 0.0f);
                follower.transform.rotation = Quaternion.LookRotation(rotationAmount);
            }
            yield return null;
        }
    }
}
