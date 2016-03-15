public class ModbusASCII
    {

        public String generateWritePacket(int slaveAddress, long registerAddress, long value)
        {
        
            int lrc = 0;
            int sum1, sum2, sum3, sum4, sum5, sum6;
            String packet = ":";

            packet = packet + slaveAddress.ToString("X2") + "06" + registerAddress.ToString("X4") + value.ToString("X4");
            String sub1 = packet.Substring(1, 2); sum1 = Convert.ToInt16(sub1, 16);
            String sub2 = packet.Substring(3, 2); sum2 = Convert.ToInt16(sub2, 16);

            String sub3 = packet.Substring(5, 2); sum3 = Convert.ToInt16(sub3, 16);
            String sub4 = packet.Substring(7, 2); sum4 = Convert.ToInt16(sub4, 16);

            String sub5 = packet.Substring(9, 2); sum5 = Convert.ToInt16(sub5, 16);
            String sub6 = packet.Substring(11, 2); sum6 = Convert.ToInt16(sub6, 16);

            //// Longitudinal redundancy check Caclulation
            lrc = sum1 + sum2 + sum3 + sum4 + sum5 + sum6; //slaveAddress + registerAddress + value;
            lrc = ~lrc; // NOT
            lrc = lrc + 1;
          
            String Output = packet + lrc.ToString("X2").Substring(6, 2) +  "\r\n";
            return Output;
        }

        public String generateReadPacket(int slaveAddress, long registerAddress, long numberOfRegistersToRead)
        {
           
            long value = 1;
            value = numberOfRegistersToRead;
            int lrc = 0;
            int sum1, sum2, sum3, sum4, sum5, sum6;
            String packet = ":";

            packet = packet + slaveAddress.ToString("X2") + "03" + registerAddress.ToString("X4") + value.ToString("X4");
            String sub1 = packet.Substring(1, 2); sum1 = Convert.ToInt16(sub1, 16);// int.TryParse(sub1, out sum1);
            String sub2 = packet.Substring(3, 2); sum2 = Convert.ToInt16(sub2, 16);

            String sub3 = packet.Substring(5, 2); sum3 = Convert.ToInt16(sub3, 16);
            String sub4 = packet.Substring(7, 2); sum4 = Convert.ToInt16(sub4, 16);

            String sub5 = packet.Substring(9, 2); sum5 = Convert.ToInt16(sub5, 16);
            String sub6 = packet.Substring(11, 2); sum6 = Convert.ToInt16(sub6, 16);

            //// Longitudinal redundancy check Caclulation
            lrc = sum1 + sum2 + sum3 + sum4 + sum5 + sum6; //slaveAddress + registerAddress + value;
            lrc = ~lrc; // NOT
            lrc = lrc + 1;
     
 
            String Output = packet + lrc.ToString("X2").Substring(6, 2) + "\r\n";
            return Output;
        }

   
    }
