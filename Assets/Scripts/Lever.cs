using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Lever : MonoBehaviour, IUsable
    {
        public string GetName()
        {
            return "Lever";
        }

        public void Use()
        {

            Debug.Log("Je suis un levier");

        }
    }

