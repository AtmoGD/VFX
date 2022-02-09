using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[ExecuteAlways]
public class VFXLoop : MonoBehaviour
{
    [SerializeField] VisualEffect vfx;
    [SerializeField] bool worldPostion = false;
    [SerializeField] float duration = 1f;
    [SerializeField] float delay = 2f;
    [SerializeField] float speed = 1f;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;
    [SerializeField] float threshold = 0.1f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > duration)
        {
            vfx.enabled = false;
            if (worldPostion)
                transform.position = startPosition;
            else
                transform.localPosition = startPosition;

            if (timer > (delay + duration)) {
                vfx.enabled = true;
                timer = 0;
            }
        }
        else
        {
            vfx.enabled = true;
            float distance = Vector3.Distance(endPosition, worldPostion ? transform.position : transform.localPosition);
            if(distance > threshold)
            {
                if (worldPostion)
                    transform.position = (endPosition - transform.position).normalized * speed * Time.deltaTime;
                else
                    transform.localPosition = (endPosition - transform.localPosition).normalized * speed * Time.deltaTime;
            }
            // if (worldPostion)
            //     transform.position = (endPosition - transform.position).normalized * speed * Time.deltaTime;// Vector3.Lerp(transform.position, endPosition, speed * Time.deltaTime);
            // else
            //     transform.localPosition = (endPosition - transform.localPosition).normalized * speed * Time.deltaTime;// Vector3.Lerp(transform.localPosition, endPosition, speed * Time.deltaTime);
        }
    }
}
