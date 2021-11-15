using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Actions
{
    /// <summary>
    /// It is an action to destroy the associated game object.
    /// </summary>
    [Action("Custom/DestroyAndResortArray")]
    [Help("Destroys the gameobject")]
    public class DestroyAndResortArray : GOAction
    {
        ///<value>Input Game object to be destroyed Parameter.</value>
        [InParam("game object")]
        [Help("Game object to be destroyed, if no assigned the game object of this behavior will be destroyed")]
        public GameObject targetGameobject;

        [InParam("flock manager")]
        [Help("Game object to be destroyed, if no assigned the game object of this behavior will be destroyed")]
        public FlockManager flockManager;

        /// <summary>Initialization Method of Destroy.</summary>
        /// <remarks>Destroy the associated Gameobject.</remarks>
        public override void OnStart()
        {
            if (targetGameobject == null)
                targetGameobject = gameObject;
            GameObject.Destroy(targetGameobject);
            flockManager.ResortArray();

        }

        /// <summary>Method of Update of Destroy.</summary>
        /// <remarks>Complete the task.</remarks>
        public override TaskStatus OnUpdate()
        {
            return TaskStatus.COMPLETED;
        }
    }
}
