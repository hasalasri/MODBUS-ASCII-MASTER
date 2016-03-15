# MODBUS_ASCII  C# class for MODBUS_ASCII protocol

EXAMLPE USAGE

Write to a Register on RS485 Slave
------------------------------------

Since this program act as MODBUS ascii master, all the other devices should be set as slaves.

First Argument is Slave Address (Should be configured from the PLC). Of cource you can have morethan one PLC or RS485 devices connected in the bus. Each device's slave address should be set inside that device.
Second Argument is the Data Register Address.
Third argument is the value to be written.

String writePacket = modbusFrames.generateWritePacket(1, 500, 1234)
serialPort1.Write(writePacket);

Read a Register/ Block of Registers from RS485 Slave
----------------------------------------------------

generateReadPacket(int slaveAddress, long registerAddress, long numberOfRegistersToRead)

String readPacket = modbusFrames.generateWritePacket(1, 500, 1234)
serialPort1.Write(writePacket);

