using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBall : MonoBehaviour
{
    public float mass;
    public Vector3 initVelocity;
    public float density;

    Vector3 acceleration;
    Vector3 velocity;

    [SerializeField]
    private GameObject lineGeneratorPrefab;
    private List<Vector3> drawPoints;

    public float trailLength;

    GameObject newLineGen;
    LineRenderer lr;
    Rigidbody rb;

    public bool test;




    void Awake (){
        this.Init();
        newLineGen = Instantiate(lineGeneratorPrefab);
        lr = newLineGen.GetComponent<LineRenderer>();
    }


    public void Init () {

        rb = GetComponent<Rigidbody>();

        velocity = initVelocity;
        float volume = mass/density;
        float radius = (float)Mathf.Pow((3 * volume) / (4 * 3.14f), (1 / 3f));
        this.transform.localScale = new Vector3(radius, radius, radius);

        rb.mass = mass;
        rb.AddForce(velocity, ForceMode.VelocityChange);

        drawPoints = new List<Vector3>(){};
        drawPoints.Add(rb.position);
    }

    public void Force(FloatBall[] allBodies, float gravityConstant)
    {
        Vector3 force = new Vector3(0,0,0);
        foreach (var otherBody in allBodies)
        {
            if (otherBody != this)
            {
                float sqrDist = (otherBody.rb.position - rb.position).sqrMagnitude;
                Vector3 dir = (otherBody.rb.position - rb.position).normalized;
                force += dir * mass * gravityConstant * otherBody.mass / sqrDist;
            }
            rb.AddForce(force);
            DrawPosition();
            Test();
        }
    }

    public void Test()
    {
        if (test && Mathf.Abs(rb.velocity.x) < .1)
        {
            print(Time.time);
        }
    }



    public void UpdateAcceleration (FloatBall[] allBodies, float gravityConstant)
    {
        acceleration = new Vector3(0,0,0);
        foreach (var otherBody in allBodies)
        {
            if (otherBody != this)
            {
                float sqrDist = (otherBody.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position).sqrMagnitude;
                Vector3 dir = (otherBody.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position).normalized;
                acceleration += dir * gravityConstant * otherBody.mass / sqrDist;
            }
        }
    }

    public void UpdateVelocity(float timeStep)
    {
        velocity += acceleration * timeStep;
    }

    public void UpdatePosition (float timeStep)
    {
        Vector3 moveAmount = velocity * timeStep;
        transform.Translate(moveAmount);
        //Push to array for draw
        Vector3 newPosition = GetComponent<Rigidbody>().position;
        drawPoints.Add(newPosition);
        if (Time.fixedTime > trailLength)
        {
            drawPoints.RemoveAt(0);
        }
        Line(drawPoints);


        // Draw.Line(oldPosition, newPosition, Color.red);
    }

    public void DrawPosition()
    {
        drawPoints.Add(rb.position);
        if (Time.fixedTime > trailLength)
        {
            drawPoints.RemoveAt(0);
        }
    Line(drawPoints);
    }

    public void Line(List<Vector3> points)
    {


        lr.positionCount = points.Count;
        lr.SetPositions(points.ToArray());


    }
}
