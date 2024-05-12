using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReactOnPlayersHit : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void Start();
    public abstract void OnPlayersHit();
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PlayersGun")
        {
            var clipName = collision.collider.gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name; // Getting clip name in order to get, is player hitting or no
            if(clipName == "Hit")
            OnPlayersHit();
        }
    }
}
