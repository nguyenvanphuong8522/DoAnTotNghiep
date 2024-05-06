using System.Collections;
using UnityEngine;
public class ConvertTypeToSprite
{
    public static Sprite CellTypeToSprite(CellType type, int indexColumn, int indexCell)
    {
        Sprite newSprite;
        IconsCellScriptable data = PopupUpgrade.instance.iconsCellData;
        switch (type)
        {
            case CellType.TOWER:
                newSprite = data.towerSprites[indexColumn].array[indexCell];
                break;
            case CellType.UPGRADE:
                newSprite = data.optionSprites[indexCell];
                break;
            default:
                newSprite = data.abilitySprites[indexColumn].array[indexCell];
                break;
        }
        return newSprite;
    }
}
