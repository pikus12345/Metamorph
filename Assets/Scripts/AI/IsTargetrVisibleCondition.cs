using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsTargetrVisible", story: "Is [Target] visible for [Agent]", category: "Conditions", id: "074a12fa94d6925cf2638a79eebcf369")]
public partial class IsTargetrVisibleCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Transform> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    public override bool IsTrue()
    {
        RaycastHit hit;
        Vector3 dir = Quaternion.LookRotation(Agent.Value.position-Target.Value.position).eulerAngles.normalized;

        if (Physics.Raycast(Agent.Value.position, dir, out hit))
        {
            if (hit.collider.gameObject == Target.Value.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
