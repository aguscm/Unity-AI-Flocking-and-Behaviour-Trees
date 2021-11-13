using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to move towards the given goal using a NavMeshAgent.
    /// </summary>
    [Action("Custom/FindGameObjectRandomlyWithTag")]
    [Help("Gets a bee randomly")]
    public class FindGameObjectRandomlyWithTag : GOAction
    {
        [InParam("Tag")]
        [Help("Tag of the gameobject we want to find")]
        public string Tag { get; set; }

        [OutParam("Bee")]
        [Help("Returns the gameobject selected")]
        public GameObject Bee { get; set; }

        public GameObject[] objectsWithThisTag;


        public override void OnStart()
        {
            objectsWithThisTag = GameObject.FindGameObjectsWithTag(Tag);
            var randomIndex = Random.Range(0, objectsWithThisTag.Length + 1);
            Debug.Log("there are " + objectsWithThisTag.Length + " bees and the index is " + randomIndex);
            Bee = objectsWithThisTag[randomIndex];


        }

        /// <summary>Method of Update of MoveToGameObject.</summary>
        /// <remarks>Verify the status of the task, if there is no objective fails, if it has traveled the road or is near the goal it is completed
        /// y, the task is running, if it is still moving to the target.</remarks>
        public override TaskStatus OnUpdate()
        {
            if (Bee == null || objectsWithThisTag.Length == 0)
                return TaskStatus.FAILED;

            return TaskStatus.COMPLETED;
        }


        /// <summary>Abort method of MoveToGameObject </summary>
        /// <remarks>When the task is aborted, it stops the navAgentMesh.</remarks>
        public override void OnAbort()
        {


        }
    }
}