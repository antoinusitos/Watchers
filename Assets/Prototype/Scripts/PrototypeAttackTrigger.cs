using System.Collections;
using UnityEngine;

namespace Prototype
{
    public class PrototypeAttackTrigger : MonoBehaviour
    {
        private SphereCollider sphereCollider = null;

        private PrototypePlayerInput playerInput = null;

        private PrototypePlayer prototypePlayer = null;

        public Animator animator = null;

        private bool isSwordOut = false;
        private bool changingSwordState = false;

        private bool isAttacking = false;

        public Transform weaponHandSlot = null;
        public Transform weaponRackSlot = null;
        public Transform weapon = null;

        private void Awake()
        {
            sphereCollider = GetComponent<SphereCollider>();
            sphereCollider.enabled = false;

            prototypePlayer = GetComponentInParent<PrototypePlayer>();
        }

        private void Start()
        {
            playerInput = GetComponentInParent<PrototypePlayerInput>();
            playerInput.playerInputs.Land.Attack.performed += _ => TryAttack();
        }

        private void TryAttack()
        {
            if (changingSwordState)
                return;

            if (isAttacking)
                return;

            if (!isSwordOut)
            {
                changingSwordState = true;
                SetSwordOut(true);
            }
            else
            {
                isAttacking = true;

                prototypePlayer.playerState = PlayerState.ATTACKING;
                StartCoroutine(Attack());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            PrototypeEntityStats prototypeEntityStats = other.GetComponent<PrototypeEntityStats>();
            if (prototypeEntityStats)
            {
                prototypeEntityStats.RemoveLife(prototypePlayer.GetBaseAttackDamage() + prototypePlayer.GetAttackBonusPerLevel() * prototypePlayer.GetAttackLevel());
            }
        }
        
        public void SetSwordOut(bool state)
        {
            if (state && isSwordOut)
                return;

            StartCoroutine(SwordOut(state));
        }


        private IEnumerator SwordOut(bool state)
        {
            if (state)
            {
                animator.SetTrigger("SwordDraw");
                yield return new WaitForSeconds(0.40f);
                weapon.transform.parent = weaponHandSlot;
                weapon.localPosition = Vector3.zero;
                weapon.localRotation = Quaternion.identity;
                yield return new WaitForSeconds(1.00f);
                animator.SetBool("HasSword", true);
                isSwordOut = true;
                changingSwordState = false;
            }
            else
            {
                animator.SetTrigger("SwordSheat");
                animator.SetBool("HasSword", false);
                yield return new WaitForSeconds(1.14f);
                weapon.transform.parent = weaponRackSlot;
                weapon.localPosition = Vector3.zero;
                weapon.localRotation = Quaternion.identity;
                yield return new WaitForSeconds(0.46f);
                isSwordOut = false;
                changingSwordState = false;
            }
        }

        private IEnumerator Attack()
        {
            animator.SetTrigger("Attack");
            sphereCollider.enabled = true;
            yield return new WaitForSeconds(prototypePlayer.GetBaseAgility() - prototypePlayer.GetAgilityLevel() * prototypePlayer.GetAgilityBonusPerLevel());
            sphereCollider.enabled = false;
            prototypePlayer.playerState = PlayerState.IDLE;
            isAttacking = false;

        }
    }
}