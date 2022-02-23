using System.Collections;
using UnityEngine;

namespace Prototype
{
    public class PrototypeAttackTrigger : MonoBehaviour
    {
        private SphereCollider sphereCollider = null;

        private PrototypePlayerInput playerInput = null;

        private void Awake()
        {
            sphereCollider = GetComponent<SphereCollider>();
            sphereCollider.enabled = false;

            playerInput = GetComponentInParent<PrototypePlayerInput>();
            playerInput.playerInputs.Land.Attack.performed += _ => TryAttack();
        }

        private void TryAttack()
        {
            StartCoroutine(Attack());
        }

        private void OnTriggerEnter(Collider other)
        {
            PrototypeEntityStats prototypeEntityStats = other.GetComponent<PrototypeEntityStats>();
            if(prototypeEntityStats)
            {
                prototypeEntityStats.RemoveLife(20);
            }
        }

        private IEnumerator Attack()
        {
            yield return new WaitForSeconds(0.2f);
            sphereCollider.enabled = true;
            yield return new WaitForSeconds(0.5f);
            sphereCollider.enabled = false;
        }
    }
}