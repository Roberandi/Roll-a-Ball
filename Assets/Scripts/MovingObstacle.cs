using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float moveDistance = 5f; // Distancia total de movimiento
    public float moveSpeed = 2f;    // Velocidad de movimiento

    private Vector3 startPosition;

    void Start()
    {
        // Guarda la posici�n inicial del obst�culo
        startPosition = transform.position;
    }

    void Update()
    {
        // 1. Calcula el desplazamiento usando un patr�n PingPong (oscilaci�n)
        // Time.time es el tiempo total de ejecuci�n.
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        // 2. Define la nueva posici�n (en este caso, movi�ndose a lo largo del eje X local)
        // Puedes cambiar Vector3.right por Vector3.forward o Vector3.up si quieres otro eje.
        Vector3 newPosition = startPosition + Vector3.right * offset;

        // 3. Aplica la posici�n
        transform.position = newPosition;
    }
}