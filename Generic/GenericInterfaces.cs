namespace Technica.Generic
{
    public interface IDamageable<T>
    {
        void Damage(T obj);
    }
    
    public interface IDebuffable<T>
    {
        void AddDebuff(T obj);
    }

    public interface IBuffable<T>
    {
        void AddBuff(T obj);
    }
}