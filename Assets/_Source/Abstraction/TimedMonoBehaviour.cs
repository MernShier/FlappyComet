using System.Collections;
using UnityEngine;

namespace Abstraction
{
    public abstract class TimedMonoBehaviour : MonoBehaviour
    {
        [SerializeField] private float lifeTime;
        
        protected virtual void OnEnable()
        {
            StartCoroutine(StartLifeTimer());
        }
        
        private IEnumerator StartLifeTimer()
        {
            yield return new WaitForSeconds(lifeTime);
            Death();
        }

        protected virtual void Death()
        {
            gameObject.SetActive(false);
        }
    }
}