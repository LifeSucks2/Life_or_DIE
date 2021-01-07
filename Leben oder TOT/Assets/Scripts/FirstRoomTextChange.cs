using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FirstRoomTextChange : MonoBehaviour
{
    public GameObject door;
    public GameObject player;
    public GameObject HUD;

    bool visited = false;
    public Text headerText;
    public Text myText;

    private bool[] Ukeys = new bool[8];
    private bool[] rooms = new bool[12];

    // Start is called before the first frame update
    void Start()
    {
        //welcome Screen
        myText.text = "Press W to Move Foreward";
        rooms[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!visited)
        headerText.enabled = true;
        else 
        headerText.enabled = false;

       CheckWhereUserIsAt();
    }

    void CheckWhereUserIsAt()
    {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        float playerZ = player.transform.position.z;
        if (rooms[0] && playerX <= -37.5f && playerX >= -85f && playerY >= -64f && playerZ >= 59f)  // 1stRoom
            Room1();
        if (rooms[1] && playerX <= -57f && playerY >= -64f && playerZ >= 103f){
            Room2();
        }
           

        if (playerX <= -76f && playerY >= -64f && playerZ >= 130f){
            rooms[1] = false;
            Room3();
        }

        if (playerX >= -55f && playerY >= -64f && playerZ >= 160f && playerZ >= 144f){
            rooms[2] = false;
            Room4();
        }

       if (playerX >= -22f && playerY >= -64f && playerZ >= 139f)
       {
            rooms[3] = false;
            Room6();
        }

       if (playerX >= 15f && playerY >= -64f && playerZ >= 88f)
       {
            rooms[4] = false;
            Room7();
        }

       if (playerX >= 79f && playerY >= -64f && playerZ >= 79f)
       {
            rooms[5] = false;
            Room8();
        }

       if (playerX >= 115f && playerY >= -64f && playerZ >= 121f)
       {
            rooms[7] = false;
            Room9();
        }

       if (playerX >= 115f && playerY >= -64f && playerZ >= 170f)
       {
            rooms[8] = false;
            Room10();
        }

       if (playerX >= 112f && playerY >= -64f && playerZ >= 226f)
       {
            rooms[9] = false;
            Room11();
        }

       if (playerX >= 115f && playerY >= -64f && playerZ >= 265f)
       {
           rooms[10] = false;
           myText.text = "To repeat the tutorial go to the left portal. If you want to start the game go to the right one.";
       }
    }

    void Room1()
    {
        if (Ukeys[0] && Ukeys[1] && Ukeys[2] && Ukeys[3] && Ukeys[4]){
            Destroy(door);
            // Make headertext invisible
            

            rooms[0] = false;
            rooms[1] = true;
        }
        else
        {
           if (!Ukeys[0] && Input.GetKey(KeyCode.W))
            {
                myText.text = "Press S to Backwards";
                Ukeys[0] = true;
            }
            
            if (Ukeys[0] && !Ukeys[1] && Input.GetKey(KeyCode.S))
            {
                myText.text = "Press A to Left";
                Ukeys[1] = true;
            }

            if (Ukeys[0] && Ukeys[1] && !Ukeys[2] && Input.GetKey(KeyCode.A))
            {
                myText.text = "Press D to Right";
                Ukeys[2] = true;
            }

            if (Ukeys[0] && Ukeys[1] && Ukeys[2] && !Ukeys[3] && Input.GetKey(KeyCode.D))
            {
                myText.text = "Press Space to Jump";
                Ukeys[3] = true;
            }
            
            if (Ukeys[0] && Ukeys[1] && Ukeys[2] && Ukeys[3] && !Ukeys[4] && Input.GetKey(KeyCode.Space))
            {
                myText.text = "Congratulations. Proceed to the next room";
                Ukeys[4] = true;
            } 
        }   
    }

    void Room2(){
        //headerText.enabled = false;
        visited = true;
        HUD.SetActive (true);
        myText.text = "These are your indicators";
    }

    void Room3()
    {
        myText.text = "You have 500 HP. The green one will rise slowly." +
        " It shows the amount of poison you have in your system. Be careful you dont want it to be at max level";
    }

    void Room4()
    {
        myText.text = "As you may have already noticed: You have a weapon. To shoot use your left key on your Mouse."
        + "Dont waste your ammo. If you run out of ammo you may be in danger. To reload your weapon press R";
    }

    void Room6()
    {
        myText.text = "Here is your first test. Kill the enemies. They will give you Points .. ";
    }
    
    void Room7()
    {
        myText.text = "Each enemy will give 100 Points. Spend them wisely. What can you buy ? Press M. " + 
        "If you are ready shoot the door.";
    }

    void Room8()
    {
        myText.text = "Kill the enemies or walk past them. But there is the risk of not getting the ammo / healthpack which are hidden in the room. Your call..";
    }

    void Room9()
    {
        myText.text = "Dont rely on the ammo / healthpack you may find in the rooms. They might not be enough for your survival.";
    }

    void Room10()
    {
        myText.text = "To escape from a room, you need to kill the enemies and the door will open. If the door is already open you can leave the room straight away" + 
        " but will it be a good strategy ?";
    }

    void Room11()
    {
        myText.text = "Congratulations you finished the tutorial which means that you are fully prepared and ready.";
    }

}
