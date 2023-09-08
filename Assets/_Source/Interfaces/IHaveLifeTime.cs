using System.Collections;

public interface IHaveLifeTime 
{
    public float LifeTime { get; set; }
    public IEnumerator StartLifeTimer(float lifeTime);
}