using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float moveDistance = 5f; // Distancia total de movimiento
    public float moveSpeed = 2f;    // Velocidad de movimiento

    private Vector3 startPosition;

    void Start()
    {
        // Guarda la posición inicial del obstáculo
        startPosition = transform.position;
    }

    void Update()
    {
        // 1. Calcula el desplazamiento usando un patrón PingPong (oscilación)
        // Time.time es el tiempo total de ejecución.
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        // 2. Define la nueva posición (en este caso, moviéndose a lo largo del eje X local)
        // Puedes cambiar Vector3.right por Vector3.forward o Vector3.up si quieres otro eje.
        Vector3 newPosition = startPosition + Vector3.right * offset;

        // 3. Aplica la posición
        transform.position = newPosition;
    }
}