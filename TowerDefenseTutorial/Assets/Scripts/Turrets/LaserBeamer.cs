using UnityEngine;

public class LaserBeamer : Turret
{
    [Header("Use Laser")]
    public int damageOverTime = 50;
    public float slowAmount = 0.5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    private AudioSource myaudio;


    /* Start()
     *
     * calls base Start and sets myaudio to audio component
     *
     */
    public override void Start()
    {
        base.Start();
        myaudio = GetComponent<AudioSource>();
    }


    /* Update()
     *
     * Updates and lock on target, determines (and controls) when laser is on/off
     *
     */
    override public void Update()
    {
        base.UpdateTarget();
        // if  there is no target - do nothing
        if (target == null)
        {
            if (lineRenderer.enabled)
            {
                // turns off the laser once out of range
                impactLight.enabled = false;
                lineRenderer.enabled = false;
                impactEffect.Stop();
            }
            return;
        }
        // if there is a target - lock on and laser
        base.LockOnTarget();
        Laser();
    }


    /* Laser()
     *
     * turns on and updates the laser and all its elements
     *
     */
    void Laser()
    {
        myaudio.Play();

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime, 0f);
        targetEnemy.Slow(slowAmount);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;

        }
        // sets the first point on the line rendered as the firepoint
        lineRenderer.SetPosition(0, firePoint.position);

        // sets the second point on the line rendered as the enemy
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        // sets the laser in the proper rotation and position
        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
}
