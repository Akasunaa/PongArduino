using System;
using System.IO.Ports;
using UnityEngine;

public class SerialSuperHandler : MonoBehaviour
{
    
    private SerialPort _serial;

    // Common default serial device on a Windows machine
    [SerializeField] private string serialPort = "COM11";
    [SerializeField] private int baudrate = 9600;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private PlayerMovement player2;

    // Start is called before the first frame update
    void Start()
    {
        _serial = new SerialPort(serialPort,baudrate);
        // Guarantee that the newline is common across environments.
        _serial.NewLine = "\n";
        // Once configured, the serial communication must be opened just like a file : the OS handles the communication.
        _serial.Open();
       
    }

    // Update is called once per frame
    void Update()
    {
        // Prevent blocking if no message is available as we are not doing anything else
        // Alternative solutions : set a timeout, read messages in another thread, coroutines, futures...
        if (_serial.BytesToRead <= 0) return;
        
        var message = _serial.ReadLine();
        message = message.Trim();
        string[] splitArray = message.Split(char.Parse(":"));

            var message1 = splitArray[0];
            message1 = message1.Replace('.', ',');
            float val = float.Parse(message1);
            val = Mathf.Clamp(val, 5f, 30f);
            float t = Mathf.InverseLerp(5, 30, val);
            player.setVertical(Mathf.Lerp(-3.5f, 3.5f, t));
 
            var message2 = splitArray[1];
            message2 = message2.Replace('.', ',');
            float val2 = float.Parse(message2);
            val2 = Mathf.Clamp(val2, 5f, 30f);
            float t2 = Mathf.InverseLerp(5, 30, val2);
            player2.setVertical(Mathf.Lerp(-3.5f, 3.5f, t2));
        


    }

    public void SetLed(bool newState)
    {
        _serial.WriteLine(newState ? "LED ON" : "LED OFF");
    }
    
    private void OnDestroy()
    {
        _serial.Close();
    }
}
