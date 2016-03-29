using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

    public Transform cat;
    float audioTimer = 0;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioTimer += Time.deltaTime;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 directionToCat = (cat.position - transform.position);
        if(Vector3.Angle(transform.forward, directionToCat) < 90f)
        {
            //Debug.Log("within range");
            Ray mouseRay = new Ray(transform.position, directionToCat);
            RaycastHit mouseRayHitInfo = new RaycastHit();
            Debug.DrawRay(transform.position, transform.forward * 100);
            if(Physics.Raycast(mouseRay, out mouseRayHitInfo, 100f))
            {
                if(mouseRayHitInfo.collider.tag == "Cat" && mouseRayHitInfo.distance < 40f)
                {
                    if(audioTimer > 2f)
                    {
                        audio.Play();
                        audioTimer = 0;
                    }
                    GetComponent<Rigidbody>().AddForce(-directionToCat.normalized * 1000f);
                }
            }
        }

	}
}
