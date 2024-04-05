using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

namespace _GAME_.Scripts.ShowCase.Dissolve
{
    public class DissolvingController : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Components")] [SerializeField]
        private SkinnedMeshRenderer skinnedMeshRenderer;

        [SerializeField] private VisualEffect vfx;
        [SerializeField] private Animator animator;

        [Header("Configurations")] [SerializeField]
        private float dissolveRate = .0125f;

        [SerializeField] private float refreshRate = .25f;

        #endregion

        #region Private Variables

        private Material[] _materials;
        private static readonly int Die = Animator.StringToHash("Die");

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            _materials = skinnedMeshRenderer.materials;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger(Die);
                StartCoroutine(Dissolve());
            }
        }

        #endregion

        #region Private Methods

        private IEnumerator Dissolve()
        {
            vfx.Play();
            if (_materials.Length <= 0) yield break;

            float counter = 0;
            while (_materials[0].GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;
                for (int i = 0; i < _materials.Length; i++)
                {
                    _materials[i].SetFloat("_DissolveAmount", counter);
                }

                yield return new WaitForSeconds(refreshRate);
            }
        }

        #endregion
    }
}