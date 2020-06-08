using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotazione : MonoBehaviour
{
    private const int PULSANTE_MOUSE_SX = 0;
    private const int PULSANTE_MOUSE_DX = 1;
    private const int PULSANTE_MOUSE_CX = 2;

    private static Vector3 ZERO = new Vector3(0,0,0);

    private bool trascinamentoMouse = false;
    private Vector3 inizioPosizioneMouse = ZERO;
    private Vector3 spostramentoMouse = ZERO;

    [SerializeField] float velocita = 10.0f;// velocità naturale di rotazione

    void Start(){
    }
    

    void Update(){
       
        // intercetta eventi
        bool mousePremuto = Input.GetMouseButtonDown(PULSANTE_MOUSE_SX) || 
                            Input.GetMouseButtonDown(PULSANTE_MOUSE_DX) || 
                            Input.GetMouseButtonDown(PULSANTE_MOUSE_CX);
        

        bool mouseRilasciato =  Input.GetMouseButtonUp(PULSANTE_MOUSE_SX) || 
                                Input.GetMouseButtonUp(PULSANTE_MOUSE_DX) || 
                                Input.GetMouseButtonUp(PULSANTE_MOUSE_CX);


        if(mousePremuto && !this.trascinamentoMouse){ // inizio trascinamento
            this.inizioPosizioneMouse = Input.mousePosition;
            this.trascinamentoMouse = true;
            Debug.Log("inizio");
        
        }else if(mouseRilasciato && this.trascinamentoMouse){ // fine trascinamento
            this.trascinamentoMouse = false;
            Debug.Log("fine");
        }
        
        if(this.trascinamentoMouse){
            // calcola spostamento
            this.spostramentoMouse = Input.mousePosition - this.inizioPosizioneMouse;
            transform.Rotate(this.spostramentoMouse.x*0.005f, 0, this.spostramentoMouse.y*0.005f, Space.Self);
 
        }else{
            this.inizioPosizioneMouse = ZERO;
             // rotazione naturale del pianeta Terra
            transform.Rotate(0, velocita*Time.deltaTime, 0, Space.Self);

        }
        
    }
}
