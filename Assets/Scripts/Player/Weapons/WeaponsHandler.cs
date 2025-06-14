using UnityEngine;
using System;

public class WeaponsHandler : MonoBehaviour
{
    private WeaponBase currentWeapon;

    [SerializeField] private GameObject startingWeaponPrefab;

    void Start()
    {
        if (startingWeaponPrefab != null)
        {
            EquipWeapon(startingWeaponPrefab);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && currentWeapon != null)
        {
            //Debug.Log("Shoot");
            currentWeapon.Fire(Vector2.up);
        }
        //Debug.Log(currentWeapon);
    }

    public void EquipWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }

        GameObject temp = Instantiate(weaponPrefab);
        temp.transform.SetParent(this.transform);

        foreach (Renderer r in temp.GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }

        foreach (Collider2D c in temp.GetComponentsInChildren<Collider2D>())
        {
            c.enabled = false;
        }

        currentWeapon = temp.GetComponent<WeaponBase>();

        if (currentWeapon == null)
        {
            //Debug.LogWarning("Weapon prefab missing WeaponBase.");
        }
        else
        {
            currentWeapon.SetOwner(this.transform);

            if (!currentWeapon.IsEquipped())
            {
                currentWeapon.ToggleEquipped();
            }
        }
    }


    public WeaponBase GetCurrentWeapon() //encapsulation
    {
        return currentWeapon;
    }

    public void ActivateMissiles()
    {
        MissileAddon ma = GetComponent<MissileAddon>();
        ma.Initialize(this.transform);
    }
}
