using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

namespace _GAME_.Scripts.ShowCase.PowerUp
{
    public class PowerUpController : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private VisualEffect vfx;

        #endregion
        #region Private Variables

        private Animator _animator;
        private bool _levelingUp;
        private static readonly int Up = Animator.StringToHash("PowerUp");

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H) && !_levelingUp)
            {
                _animator.SetTrigger(Up);
                vfx.Play();
                _levelingUp = true;
                StartCoroutine(ResetBool());
            }
        }

        #endregion

        #region Private Methods

        private IEnumerator ResetBool(float delay = .1f)
        {
            yield return new WaitForSeconds(delay);
            _levelingUp = !_levelingUp;
        }

        #endregion
    }
}