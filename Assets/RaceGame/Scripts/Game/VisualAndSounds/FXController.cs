using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FXController : Singleton<FXController>
{
    [Header("Particles settings")]
    [SerializeField] ParticleSystem AsphaltSmokeParticles;

    [Header("Trail settings")]
    [SerializeField] TrailRenderer TrailRef;
    [SerializeField] Transform TrailsHolder;


    protected override void AwakeSingleton()
    {
        TrailRef.gameObject.SetActive(false);
    }

    public ParticleSystem GetAspahaltParticles { get { return AsphaltSmokeParticles; } }

    Queue<TrailRenderer> FreeTrails = new Queue<TrailRenderer>();

    public TrailRenderer GetTrail(Vector3 startPos)
    {
        TrailRenderer trail = null;
        if (FreeTrails.Count > 0)
        {
            trail = FreeTrails.Dequeue();
        }
        else
        {
            trail = Instantiate(TrailRef, TrailsHolder);
        }

        trail.transform.position = startPos;
        trail.gameObject.SetActive(true);

        return trail;
    }

    public void SetFreeTrail(TrailRenderer trail)
    {
        StartCoroutine(WaitVisibleTrail(trail));
    }

    private IEnumerator WaitVisibleTrail(TrailRenderer trail)
    {
        trail.transform.SetParent(TrailsHolder);
        yield return new WaitForSeconds(trail.time);
        trail.Clear();
        trail.gameObject.SetActive(false);
        FreeTrails.Enqueue(trail);
    }
}
