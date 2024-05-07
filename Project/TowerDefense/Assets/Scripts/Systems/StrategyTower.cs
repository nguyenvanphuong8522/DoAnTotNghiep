using System;

[Serializable]
public class StrategyTower
{
    public DataTower[] table;
    public StrategyTower() { }
    public StrategyTower(int amountColumn, int amountCellInColumn)
    {
        DataTower[] dataTower = new DataTower[amountColumn];
        for(int i = 0; i < amountColumn; i++)
        {
        }
    }
}
