using System;

[Serializable]
public class DataTower
{
    public bool unLocked;
    public bool dame;
    public bool range;
    public bool rate;
    public DataTower() { }

    public DataTower(bool unLocked, bool dame, bool range, bool rate)
    {
        this.unLocked = unLocked;
        this.dame = dame;
        this.range = range;
        this.rate = rate;
    }
}
