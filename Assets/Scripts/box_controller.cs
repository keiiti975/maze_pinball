using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class box_controller : MonoBehaviour , IPointerClickHandler
{
    private GameObject _parent;
    private GameObject _ball;
    private Transform parent_transform;
    private int process_count;
    private Vector3 process_vector;
    public int initial_process_count = 120;

    void Start(){
        _parent = transform.root.gameObject;
        _ball = GameObject.Find("Ball");
    }

    void Update(){
        parent_transform = _parent.transform;

        if (process_count > 0){
            parent_transform.eulerAngles += process_vector;
            process_count--;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        parent_transform = _parent.transform;

        if (eventData.pointerPress.name == "box_front_wall"){
            process_count = initial_process_count;
            process_vector = new Vector3(-30.0f / (float)initial_process_count, 0.0f, 0.0f);
            _ball.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if (eventData.pointerPress.name == "box_upfront_wall"){
            process_count = initial_process_count;
            process_vector = new Vector3(-30.0f / (float)initial_process_count, 0.0f, 0.0f);
            _ball.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if(eventData.pointerPress.name == "box_left_wall"){
            process_count = initial_process_count;
            process_vector = new Vector3(0.0f, 0.0f, 30.0f / (float)initial_process_count);
            _ball.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if(eventData.pointerPress.name == "box_upleft_wall"){
            process_count = initial_process_count;
            process_vector = new Vector3(0.0f, 0.0f, 30.0f / (float)initial_process_count);
            _ball.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if(eventData.pointerPress.name == "box_back_wall"){
            process_count = initial_process_count;
            process_vector = new Vector3(30.0f / (float)initial_process_count, 0.0f, 0.0f);
            _ball.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if(eventData.pointerPress.name == "box_upback_wall"){
            process_count = initial_process_count;
            process_vector = new Vector3(30.0f / (float)initial_process_count, 0.0f, 0.0f);
            _ball.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if(eventData.pointerPress.name == "box_right_wall"){
            process_count = initial_process_count;
            process_vector = new Vector3(0.0f, 0.0f, -30.0f / (float)initial_process_count);
            _ball.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if(eventData.pointerPress.name == "box_upright_wall"){
            process_count = initial_process_count;
            process_vector = new Vector3(0.0f, 0.0f, -30.0f / (float)initial_process_count);
            _ball.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}
