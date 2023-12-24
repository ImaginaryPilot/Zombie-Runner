using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float Range = 50f;
    [SerializeField] float damage = 1f;
    [SerializeField] ParticleSystem MuzzleFlash;
    [SerializeField] GameObject HitFx;
    [SerializeField] Ammo AmmoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timebetweenshots = 2f;
    [SerializeField] TextMeshProUGUI ammoText; 

    bool canshoot = true;

    private void OnEnable()
    {
        canshoot = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canshoot == true)
        {
            StartCoroutine(Shoot());
        }

        int currentammo = AmmoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentammo.ToString();
    }
    IEnumerator Shoot()
    {
        canshoot = false;
        if (AmmoSlot.GetCurrentAmmo(ammoType) > 0)
        {

            MuzzleFlash.Play();
            AmmoSlot.ReduceCurrentAmmo(ammoType);
            ProcessRaycast();
        }
        yield return new WaitForSeconds(timebetweenshots);
        canshoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, Range))
        {
            GameObject Impact = Instantiate(HitFx, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Impact, .05f);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
}
