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
    //[SerializeField] GameObject healthAndAmmo;

    // Start is called before the first frame update
    void Start()
    {
        //welcome Screen
        myText.text = "Drücke W um vorwärts zu gehen";
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
           myText.text = "Um die Einführung zu wiederholen, begebe dich links zum Protal. Wenn du weiter mit dem Spiel fortsetzten willst, dann begebe dich rechts.";
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
                myText.text = "Drücke S um rückwärts zu gehen.";
                Ukeys[0] = true;
            }
            
            if (Ukeys[0] && !Ukeys[1] && Input.GetKey(KeyCode.S))
            {
                myText.text = "Drücke A für links.";
                Ukeys[1] = true;
            }

            if (Ukeys[0] && Ukeys[1] && !Ukeys[2] && Input.GetKey(KeyCode.A))
            {
                myText.text = "Drücke D für rechts.";
                Ukeys[2] = true;
            }

            if (Ukeys[0] && Ukeys[1] && Ukeys[2] && !Ukeys[3] && Input.GetKey(KeyCode.D))
            {
                myText.text = "Drücke Space zum springen.";
                Ukeys[3] = true;
            }
            
            if (Ukeys[0] && Ukeys[1] && Ukeys[2] && Ukeys[3] && !Ukeys[4] && Input.GetKey(KeyCode.Space))
            {
                myText.text = "Glückwunsch, jetzt begebe dich weiter.";
                Ukeys[4] = true;
            } 
        }   
    }

    void Room2(){
        //headerText.enabled = false;
        visited = true;
        HUD.SetActive (true);
        myText.text = "Das sind deine Indikatoren";
    }

    void Room3()
    {
        myText.text = "Das Rote ist deine Gesundheitsanzeige. Das Grüne ist deine Gift Anzeige." +
        " Das Gift vermehrt sich in deinem Körper, vorallem wenn du dich bewegst, vermehrt sich der Girftinhalt in deinem Körper.";
    }

    void Room4()
    {
        myText.text = "Du hast ein Sturmgewehr zu Verfügung. Mit der linken Maustaste kannst du ballern. Mit der rechten Maustaste kannst du Zielen. Verschwende keine Munition. Mit der Taste R kannst du nachladen.";
    }

    void Room6()
    {
        myText.text = "Dein erster Test. Töte deine Feinde und kassiere Punkte. ";
    }
    
    void Room7()
    {
        myText.text = "Jeder kill ist 100 Punkte wert. Drücke M um in den Shop zu erlangen und kaufe dir Healthpacks oder Munitionen. " + 
        "Wenn du fertig bist, töte die weiteren zwei Gegner aber Achtung, die schießen auch zurück. Gegner können durch Wände sehen und schießen. Anschließend schieße auf die Türe.";
    }

    void Room8()
    {
        myText.text = "Deine Giftanzeige erhöht sich und wenn die kommplett auf 100% ist, dann stirbst du. Nehme die grünen Pickups, um den Giftgehalt zu verringern. Nehme die roten Pickups um deine Gesundheitsanzeige zu vergrößern. In den Boxen sind Munitionen enthaletn.";
    }

    void Room9()
    {
        myText.text = "Munitionen, Medizinpacks und Healthpacks sind in den räumer verteilt. Es kann sein das die nicht ausreichen, daher kannst du dir im shop auch welche kaufen.";
    }

    void Room10()
    {
        myText.text = "";
    }

    void Room11()
    {
        myText.text = "Du hast den Turtorial erfolgreich absolviert. Jetzt bist du bereit für das Spiel.";
    }

}
