using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPuzzle : MonoBehaviour
{
    private Vector3 _buttonStatus;
    public Vector3 TrueRot;
    public bool _trueRotStatus=false;
    public GameObject[] ButtonList;
    public int sayac=0;
    public bool status=false;
    private GameObject door;

    public void Awake()
    {
        door = DoorController.Instance.Door(1);
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.tag);
        if(gameObject.tag=="WallKey"){
            SoundManager.Instance.Audio(0);
            transform.Rotate(0,0,72);
            _buttonStatus=transform.rotation.eulerAngles;
            if(TrueRot.y <= _buttonStatus.y &&  _buttonStatus.y<=TrueRot.y+1){
                _trueRotStatus=true;
            }
            else{
                _trueRotStatus=false;
            }
        }
        if(gameObject.tag=="WallPuzzleButton"){
            sayac=0;
            for(int i=0; i<ButtonList.Length;i++){
                if(ButtonList[i].GetComponent<WallPuzzle>()._trueRotStatus){
                    sayac++;
                }
            }
            if(sayac==ButtonList.Length && status==false){
                SoundManager.Instance.Audio(10);
                status=true;
                door.GetComponent<Animator>().SetBool("DoorStatus", true);
                Debug.Log("kapı açıldı");
            }
            else{
                SoundManager.Instance.Audio(2);
            }
        }
    }
}
