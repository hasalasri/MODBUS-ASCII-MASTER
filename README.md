MODBUS_ASCII  C# class for MODBUS_ASCII protocol based on http://www.simplymodbus.ca/ASCII.htm
To undertstand how MODBUS ASCII work use their tool http://www.simplymodbus.ca/SMM803.zip
EXAMLPE USAGE

Write to a Register on RS485 Slave
------------------------------------

generateWritePacket(int slaveAddress, long registerAddress, long value)

Since this program act as MODBUS ascii master, all the other devices should be set as slaves.

First Argument is Slave Address (Should be configured from the PLC). Of cource you can have morethan one PLC or RS485 devices connected in the bus. Each device's slave address should be set inside that device.
Second Argument is the Data Register Address.
Third argument is the value to be written.
Following code write the value 1234 to the Register address 500 of Slave 1.

String writePacket = modbusFrames.generateWritePacket(1, 500, 1234)
serialPort1.Write(writePacket);

Read a Register/ Block of Registers from RS485 Slave
-----------------------------------------------------

generateReadPacket(int slaveAddress, long registerAddress, long numberOfRegistersToRead)

Following code send the read request to read registers 100,101,102,103 from slave one.
String readPacket = modbusFrames.generateReadPacket(1,100,4);
serialPort1.Write(readPacket);

In your serial port's date received event or polling function add this code to decode the incoming register values.
So the variable registerValue0 to registerValue3 contain data register 100 to 103 values.

         String registerdata = serialPort1.ReadLine();
            if (registerdata.Substring(3, 2) == "03")
            {
                    long registerValue0 = Convert.ToInt32(registerdata.Substring(7, 4), 16);
                    long registerValue1 = Convert.ToInt32(registerdata.Substring(11, 4), 16);
                    long registerValue2 = Convert.ToInt32(registerdata.Substring(15, 4), 16);
                    long registerValue3 = Convert.ToInt32(registerdata.Substring(19, 4), 16);
                    // Can be extended depending on how many registers you want to read
              }
              
