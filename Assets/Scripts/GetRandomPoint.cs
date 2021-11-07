using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore.Tasks;
using Pada1.BBCore;

namespace BBUnity.Actions
{

    [Action("CustomActions/GetRandomPoint")]
    [Help("Gets a random point for the agent to go to")]

    public class GetRandomPoint : GOAction
    {

        public Vector3 randomPosition { get; set; }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
