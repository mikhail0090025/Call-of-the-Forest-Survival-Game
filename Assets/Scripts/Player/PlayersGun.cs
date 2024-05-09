using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersGun : MonoBehaviour
{
    [SerializeField]
    private bool holdsGun;
    [SerializeField]
    private List<GunParameters> gunsParameters;
    public bool HoldsGun => holdsGun;
    [SerializeField]
    private int gunID;
    public int GunID => gunID;
    [SerializeField]
    PlayerInventory inventory;
    [SerializeField]
    void Start()
    {
        holdsGun = false;
        gunID = -1;
        ActivateCurrentGunObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gunID != -1)
        {
            var gun = GunObjectById(gunID);
            gun.animator.SetTrigger("Hit");
        }
    }
    private GunParameters GunObjectById(int id)
    {
        foreach (var gun in gunsParameters)
        {
            if (gun.ID == id)
                return gun;
        }
        Debug.LogException(new Exception("ID of not existing gun was given!"));
        return null;
    }

    public void ReturnGun()
    {
        inventory.AddItem(gunID, 1);
        inventory.GunCell_.Reset();
        holdsGun = false;
        gunID = -1;
        inventory.RefreshInventoryUI();
        ActivateCurrentGunObject();
    }
    public void ActivateCurrentGunObject()
    {
        if (gunID == -1)
        {
            foreach (var gun in gunsParameters)
            {
                gun.GunObject.SetActive(false);
            }
        }
        else
        {
            foreach (var gun in gunsParameters)
            {
                if(gun.ID == gunID)
                    gun.GunObject.SetActive(true);
                else gun.GunObject.SetActive(false);
            }
        }
    }

    public void TakeGun(int ID, bool FromInventory)
    {
        if (ID <= -1) Debug.LogException(new Exception($"Invalid ID {ID}"));
        if (ItemsManager.IMinstance.FindByID(ID).ItemType != ItemType.Gun)
        {
            Debug.Log(ItemsManager.IMinstance.Items.Find(item => item.ID == ID).ItemType);
            Debug.LogException(new System.Exception("Given item is not gun!"));
        }
        if(FromInventory)
        {
            inventory.RemoveItem(ID, 1, out bool WasRemoved);
            if(WasRemoved)
            {
                holdsGun = true;
                gunID = ID;
                inventory.GunCell_.Reset();
                inventory.GunCell_.Add(ID, 1);
            }
        }
        else
        {
            holdsGun = true;
            gunID = ID;
            inventory.GunCell_.Reset();
            inventory.GunCell_.Add(ID, 1);
        }
        inventory.RefreshInventoryUI();
        ActivateCurrentGunObject();
    }
    [Serializable]
    class GunParameters
    {
        public int ID;
        public GameObject GunObject;
        public float MinDamage;
        public float MaxDamage;
        public float HitRate; // Per second
        public Animator animator;
    }
}
