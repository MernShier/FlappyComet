using System.Collections;

namespace Interfaces
{
    public interface IHaveLifeTime 
    {
        public float LifeTime { get; set; }
        public IEnumerator StartLifeTimer(float lifeTime);
    }
}