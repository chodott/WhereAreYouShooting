using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LaserManager _laserManager;
    public LaserManager Manager
    {
        get; set;
    }
    
    public bool Reflect(out RaycastHit hit, Vector3 position, Vector3 direction)
    {
        transform.position = position;
        transform.LookAt(position + direction);
        if (Physics.Raycast(position, direction, out hit, 100.0f))
        {
            float length = hit.distance;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, length / 2);
            return true;
        }

        return false;
    }
}
