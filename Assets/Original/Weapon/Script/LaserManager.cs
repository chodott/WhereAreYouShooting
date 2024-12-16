using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;
    private List<Laser> _laserList = new List<Laser>();
    private int _reflectCount = 3;
    protected void Start()
    {
        for (int i = 0; i < 5; ++i)
        {
            _laserList.Add(Instantiate(_laserPrefab).GetComponent<Laser>());
            _laserList[i].Manager = this;
        }
    }

    protected void Update()
    {
        Vector3 startPositon = transform.position + transform.forward * 1.0f + transform.up * 0.5f;
        Vector3 startDirection = transform.forward;
        int maxActiveCnt = 0;
        for(int i=0; i<=_reflectCount; ++i)
        {
            Laser laser = _laserList[i];
            if (i < maxActiveCnt)
            {
                laser.gameObject.SetActive(false);
                continue;
            }
            RaycastHit hit;
            bool bHit = laser.Reflect(out hit, startPositon, startDirection);
            if(bHit)
            {
                startPositon = hit.point;
                startDirection = Vector3.Reflect(startDirection, hit.normal);
                maxActiveCnt++;
            }
        }
    }
}
