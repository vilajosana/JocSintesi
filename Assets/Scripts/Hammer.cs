using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {
    // Método para manejar la colisión con los topos
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Mole")) {
            // Lógica para cuando golpeas un topo
            Debug.Log("Topo golpeado!");
            other.GetComponent<Mole>().Hit();
        }
    }
}
