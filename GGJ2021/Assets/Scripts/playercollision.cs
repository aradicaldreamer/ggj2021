using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercollision : MonoBehaviour
{
void OnCollisionEnter (Collision collisionInfo)
{
  Debug.Log(collisionInfo.collider.tag);
}
}
