namespace Abstraction
{
    public interface IMove
    {
        public float MoveSpeed { get; set; }
        public void Move();
    }
}