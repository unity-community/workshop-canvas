using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float velocidad = 10F;
	public float salto = 5F;
    public Text numeroDiamantes;

	private Animator animator;
	private Rigidbody rigidbody;
	private bool saltando;
    private bool mover;
    private bool saltar2;
    private int diamantes = 0;

	void Start() {
		animator = GetComponent<Animator> ();
		rigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {
        if (mover) {
            transform.Translate(transform.worldToLocalMatrix.MultiplyVector(transform.forward) * Time.deltaTime * 20);
            animator.SetFloat("velocidad", 1F);
        }

		if (saltar2 && !saltando) {
            saltar2 = false;
			saltando = true;
			animator.SetTrigger ("saltar");
			rigidbody.AddRelativeForce (Vector3.up * salto, ForceMode.Impulse);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("piso")) {
			saltando = false;
		}
        if (other.gameObject.CompareTag("diamante")) {
            diamantes++;
            Destroy(other.gameObject);
            if (numeroDiamantes != null)
                numeroDiamantes.text = diamantes.ToString();
        }
	}

    public void caminarArriba() {
        transform.rotation = Quaternion.Euler(0, -90, 0);
        mover = true;
    }

    public void caminarAbajo() {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        mover = true;
    }

    public void caminarIzquierda() {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        mover = true;
    }
    public void caminarDerecha() {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        mover = true;
    }

    public void detenerMovimiento() {
        mover = false;
        animator.SetFloat("velocidad", 0F);
    }

    public void saltar() {
        saltar2 = true;
    }

}
