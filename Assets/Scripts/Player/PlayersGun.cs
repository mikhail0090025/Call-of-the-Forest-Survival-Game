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
    void Start()
    {
        holdsGun = false;
        gunID = -1;
    }

    public void OnBeforeSerialize()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
    private void ActivateCurrentGunObject()
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
        if (ItemsManager.IMinstance.Items.Find(item => item.ID == ID).ItemType != ItemType.Gun)
        {
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
    }
}
