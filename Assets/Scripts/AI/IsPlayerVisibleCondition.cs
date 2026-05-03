using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsPlayerVisible", story: "[Agent] is visible in [ViewDistance] or [OgreViewDistance] on [Distance]", category: "Conditions", id: "6510a73517a608abaad528c768811f05")]
public partial class IsPlayerVisibleCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<float> ViewDistance;
    [SerializeReference] public BlackboardVariable<float> OgreViewDistance;
    [SerializeReference] public BlackboardVariable<float> Distance;

    public override bool IsTrue()
    {
        MorphType type = Agent.Value.GetComponent<MorphManager>().CurrentMorph;
        switch (type)
        {
            case MorphType.Knight:
                {
                    if (Distance < ViewDistance)
                        return true;
                    else
                        return false;
                }
            case MorphType.Lizard:
                {
                    return false;
                }
            case MorphType.Orc:
                {
                    if (Distance < OgreViewDistance)
                        return true;
                    else
                        return false;
                }
            default:
                return false;
        }
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
