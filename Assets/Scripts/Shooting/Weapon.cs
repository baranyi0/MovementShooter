using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public float damage = 10;
    public int range = 15;

    public GameObject defaultParticle;
    public Camera cam;
    public PlayerMovement playerMovement;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        anim.Play("idle");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("FireAnim");
        }
    }

    // Ez az IEnumerator csak az animációért felelős!
    IEnumerator FireAnim()
    {
        anim.SetTrigger("fire");
        Fire();
        yield return new WaitForSeconds(0.3f);
    }

    //Ez a metódus maga a lővést valósítja meg raycastal!
    void Fire()
    {
        RaycastHit hit;

        // Raycast, egy vonalat kilövök egy irányba, ha eltalál valamit akkor információt ad vissza! (hit-be fogjuk tárolni az infot)
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log("Eltaláltam: " + hit.collider.name);

            GameObject particle = (GameObject)Instantiate(defaultParticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(particle, 3f); // Destroyolom ezt a particle effectet 3 másodperc múlva!

            if (hit.collider.CompareTag("Target"))
            {
                Destroy(hit.collider.gameObject);

                int point = 0;

                // Ha a player az égben lövi le a targetet akkor plussz pontot adunk!
                if(playerMovement.isGrounded == false)
                {
                    point = 3;
                }
                else
                {
                    point = 1;
                }

                PointCounter.Instance.AddPoint(point);
            }
        }
    }
}
