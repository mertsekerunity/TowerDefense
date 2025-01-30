using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectilePrefab;
    [SerializeField] float range = 25f;

    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
        AimWeapon();
    }

    void AimWeapon()
    {
        if (target == null) return;

        float targetDistance = Vector3.Distance(target.position, transform.position);

        weapon.LookAt(target);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void FindClosestEnemy()
    {
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();

        Transform closestTarget = null;

        float maxDistance = Mathf.Infinity;

        foreach (EnemyController enemy in enemies)
        {
            float targetDistance = Vector3.Distance(enemy.transform.position, transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectilePrefab.emission;
        emissionModule.enabled = isActive;
    }
}
