using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveElements : MonoBehaviour
{
    //增强参数
    public float Intensify = 1.2f;

    //减弱参数
    public float Less = 0.8f;

    public enum FiveElementsType
    {
        Null,
        Gold,//金
        Wood,//木
        Water,//水
        Fire,//火
        Soil,//土
    }

    //克制关系
    public enum FiveElementsRestraint
    {
        Null,
        Intensify1,
        Intensify2,
        Less1,
        Less2,
    }

    public FiveElementsRestraint JudgeElements(FiveElementsType beforeType,
      FiveElementsType afterType)
    {
        if (afterType == beforeType)
        {
            return FiveElementsRestraint.Null;
        }

        return FiveElementsRestraint.Intensify1;
    }

    //判断五行相生相克逻辑
    public void JudgeElements(FiveElementsType beforeType, ref float beforeTypeValue,
    FiveElementsType afterType, ref float afterTypeValue)
    {
        //前者无属性后者有属性 （无属性 攻击带属性 会被削弱数据）
        if (beforeType == FiveElementsType.Null && afterType != FiveElementsType.Null)
        {
            //减弱前者
            beforeTypeValue *= Less;
        }
        else if (afterType == FiveElementsType.Null && beforeType != FiveElementsType.Null)
        {
            //减弱后者
            afterTypeValue *= Less;
        }
        else if (beforeType == FiveElementsType.Gold)//前者金
        {
            //后者状态
            switch (afterType)
            {
                case FiveElementsType.Gold://后者金 无效果
                    break;
                case FiveElementsType.Wood://后者木
                    afterTypeValue *= Less;
                    break;
                case FiveElementsType.Water://后者水
                    afterTypeValue *= Intensify;
                    break;
                case FiveElementsType.Fire://后者火
                    beforeTypeValue *= Less;
                    break;
                case FiveElementsType.Soil://后者土
                    beforeTypeValue *= Intensify;
                    break;
                default:
                    break;
            }
        }
        else if (beforeType == FiveElementsType.Wood)//前者木
        {
            //后者状态
            switch (afterType)
            {
                case FiveElementsType.Gold://后者金
                    beforeTypeValue *= Less;
                    break;
                case FiveElementsType.Wood://后者木 无效果
                    break;
                case FiveElementsType.Water://后者水
                    beforeTypeValue *= Intensify;
                    break;
                case FiveElementsType.Fire://后者火
                    afterTypeValue *= Intensify;
                    break;
                case FiveElementsType.Soil://后者土
                    afterTypeValue *= Less;
                    break;
                default:
                    break;
            }
        }
        else if (beforeType == FiveElementsType.Water)//前者水
        {
            //后者状态
            switch (afterType)
            {
                case FiveElementsType.Gold://后者金
                    beforeTypeValue *= Intensify;
                    break;
                case FiveElementsType.Wood://后者木
                    afterTypeValue *= Intensify;
                    break;
                case FiveElementsType.Water://后者水 无效果                    
                    break;
                case FiveElementsType.Fire://后者火
                    afterTypeValue *= Less;
                    break;
                case FiveElementsType.Soil://后者土
                    beforeTypeValue *= Less;
                    break;
                default:
                    break;
            }
        }
        else if (beforeType == FiveElementsType.Fire)//前者火
        {
            //后者状态
            switch (afterType)
            {
                case FiveElementsType.Gold://后者金
                    afterTypeValue *= Less;
                    break;
                case FiveElementsType.Wood://后者木
                    beforeTypeValue *= Intensify;
                    break;
                case FiveElementsType.Water://后者水
                    beforeTypeValue *= Less;
                    break;
                case FiveElementsType.Fire://后者火 无效果               
                    break;
                case FiveElementsType.Soil://后者土
                    afterTypeValue *= Intensify;
                    break;
                default:
                    break;
            }
        }
        else if (beforeType == FiveElementsType.Soil)//前者土
        {
            //后者状态
            switch (afterType)
            {
                case FiveElementsType.Gold://后者金
                    afterTypeValue *= Intensify;
                    break;
                case FiveElementsType.Wood://后者木
                    beforeTypeValue *= Less;
                    break;
                case FiveElementsType.Water://后者水
                    afterTypeValue *= Less;
                    break;
                case FiveElementsType.Fire://后者火
                    beforeTypeValue *= Intensify;
                    break;
                case FiveElementsType.Soil://后者土 无效果                    
                    break;
                default:
                    break;
            }
        }

    }
}
