using CustomAssetEvents;
public interface IHealth
{
    int Health { get;  set; }

    public void Damage(int damage);


}