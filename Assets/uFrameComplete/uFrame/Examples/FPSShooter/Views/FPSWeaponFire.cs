using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(FPSWeaponView))]
public partial class FPSWeaponFire
{

    public Transform _MuzzleTransform;
    public GameObject _BulletPrefab;
    private Vector3 _StartPosition;
    private Quaternion _StartRotation;


    public override void Bind(ViewBase view)
    {
        base.Bind(view);

        view.BindInputButton(() => FPSWeapon.BeginFire, "Fire1", InputButtonEventType.ButtonDown)
            .When(() => FPSWeapon.State == FPSWeaponState.Active).Subscribe(Fire);

        view.BindInputButton(() => FPSWeapon.EndFire, "Fire1", InputButtonEventType.ButtonUp)
            .When(() => FPSWeapon.State == FPSWeaponState.Firing);
    }

    protected IEnumerator FireWeapon()
    {

        var bulletsToFire = Math.Min(FPSWeapon.BurstSize, FPSWeapon.Ammo);
        for (var i = 0; i < bulletsToFire; i++)
        {
            FireBullet();
            yield return new WaitForSeconds(FPSWeapon.BurstSpeed);
            FPSWeapon.Spread += FPSWeapon.SpreadMultiplier;
          
        }
        yield return new WaitForSeconds(FPSWeapon.FireSpeed);

        if (FPSWeapon.State == FPSWeaponState.Firing && FPSWeapon.BurstSize < 2)
        StartCoroutine("FireWeapon");

    }

    public void FireBullet()
    {
        var bullet = Instantiate(_BulletPrefab) as GameObject;
        FPSWeapon.Ammo -= 1;
        FPSWeapon.Spread += FPSWeapon.SpreadMultiplier;

        //// Apply some backfire
        //this.transform.localPosition -=
        //    (-transform.forward * Model.RecoilSpeed * (Model.Spread * 17f));

        Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f));

        var ray = Camera.main.ViewportPointToRay(
            new Vector3(
                Random.Range(-FPSWeapon.Spread, FPSWeapon.Spread) + 0.5f,
                Random.Range(-FPSWeapon.Spread, FPSWeapon.Spread) + 0.5f, 0f));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            targetPoint = hit.point;
            var damageable = hit.collider.gameObject.GetView<FPSDamageableViewBase>();
            if (damageable != null)
                damageable.ExecuteApplyDamage(10);
        }
        else
            targetPoint = ray.GetPoint(100f);

        var finalPoint = new Vector3(
            targetPoint.x,
            targetPoint.y,
            targetPoint.z
            );

        bullet.transform.parent = null;

        bullet.transform.position = _MuzzleTransform.position;

        bullet.gameObject.transform.LookAt(finalPoint);
    }

    public IEnumerator SpreadDown()
    {

        while (FPSWeapon.Spread > FPSWeapon.MinSpread)
        {
            yield return new WaitForSeconds(FPSWeapon.RecoilSpeed);
            FPSWeapon.Spread -= FPSWeapon.RecoilSpeed;
        }
        FPSWeapon.Spread = FPSWeapon.MinSpread;
    }
  
    public void Fire()
    {
        StartCoroutine("FireWeapon");
    }

    public void StopFiring()
    {
        StartCoroutine(SpreadDown());
        StopCoroutine("FireWeapon");
    }
}