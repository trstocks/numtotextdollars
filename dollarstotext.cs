//Sample code to read in test cases:
using System;
using System.IO;

namespace DollarsToText{

    public class Money{
        public string Ones(string num){
            string[] ones =new string[]{"", "One","Two","Three", "Four", "Five", "Six", "Seven", "Eight","Nine"};
            var value = ones[Int32.Parse(num)];
            return value;
        }
        public string Teens(string num){
            string[] teens=new string[]{"Ten","Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen","Seventeen","Eighteen","Nineteen"};
            int stringnum=Int32.Parse(num.Substring(1,1));
            var value = teens[stringnum];
            return value;
        }
        public string Tens(string num){
            string[] tens=new string[]{"","","Twenty","Thirty","Forty","Fifty","Sixty","Seventy","Eighty","Ninety"};
            var value = tens[Int32.Parse(num.Substring(0,1))] + Ones(num.Substring(1,1));
            return value;
        }
        public string Hundreds(string num){
            string value1;
            string value2;
            value1 = Ones(num.Substring(0,1));
            string stringnum= num.Substring(1,0);
            if ( stringnum=="1"){
                value2=Teens(num.Substring(1,2));
            }
            else{
                value2=Tens(num.Substring(1,2));
            }
            if ( value1 != ""){
                return value1+ "Hundred" +value2;
            }
            else{
                return value2;
            }
        }
        public string Thousands(string num){
            string value1;
            string value2;
                value1 = Ones(num.Substring(0,1));
                value2 = Hundreds(num.Substring(1,3));
                if ( value1 != ""){
                    return value1+ "Thousand" +value2;
                }
                else 
                    return value2;
        }
        public string TenThousands(string num){
            string value1;
            string value2;
            if ( Int32.Parse(num.Substring(0,1))==1){
                     value1 = Teens(num.Substring(0,2));
                     value2 = Hundreds(num.Substring(2,3));
                    if ( value1 != ""){
                        return value1+ "Thousand" +value2;
                    }
                    else{
                        return value2;
                    }
                }
                else{
                    value1 = Tens(num.Substring(0,2));
                    value2 = Hundreds(num.Substring(2,3));
                    if ( value1 != ""){
                        return value1+ "Thousand" +value2;
                    }
                    else
                        return value2;
                }
        }
        public string HThousands(string num){
            string value1;
            string value2;
            value1 = Hundreds(num.Substring(0,3));
            value2 = Hundreds(num.Substring(3,3));
            if ( value1 != ""){
                return value1+ "Thousand" +value2;
            }
            else
                return value2;
        }  
        public string Millions(string num){
            string value1;
            string value2; 
            value1 = Ones(num.Substring(0,1));
            value2 = HThousands(num.Substring(1,6));
            if ( value1 != ""){
                return value1+ "Million" +value2;
            }
            else {  
                return value2;
            }
        }
        public string TenMillions(string num){
            string value1;
            string value2;    
            if (Int32.Parse(num.Substring(0,1))==1){
                value1 = Teens(num.Substring(0,2));
                value2 = TenThousands(num.Substring(2,5));
                if ( value1 != ""){
                    return value1+ "Million" +value2;
                }
                else{
                    return value2;
                }
            }
            else{
                value1 = Tens(num.Substring(0,2));
                value2 = TenThousands(num.Substring(2,5));
                if ( value1 != ""){
                    return value1+ "Million" +value2;
                }
                else{
                    return value2;
                }
            }
        }
        public string HMillions(string num){
        string value1;
        string value2;
            value1 = Hundreds(num.Substring(0,3));
            value2 = HThousands(num.Substring(3,6));
            if ( value1 != ""){
                return value1+ "Million" + value2;
            }
            else{
                return value2;
            }
        }
    }

class Convert{
    Money money = new Money();
    public string NumToWord(string number){
        int numbLength = number.Length;
        int stringnum=Int32.Parse(number);
        string dollars;
        switch(numbLength){
            case 1:
            if (stringnum != 0 ){
                dollars = money.Ones(number) + "Dollars";
                return dollars;
            }
            else{
                return "Zero Dollars";
            }
          case 2://above 10 and below 100
            if ( stringnum < 20 && stringnum > 9){
                dollars = money.Teens(number)+"Dollars";
                return dollars;
            }
            else{
                dollars = money.Tens(number)+"Dollars";
                return dollars;
            }
        case 3:
            dollars = money.Hundreds(number)+"Dollars";
            return dollars;
        case 4: 
            dollars = money.Thousands(number)+"Dollars";
            return dollars;
        case 5: 
            dollars = money.TenThousands(number)+"Dollars";
            return dollars;
        case 6:
            dollars = money.HThousands(number)+"Dollars";
            return dollars;
        case 7:
            dollars=money.Millions(number)+"Dollars";
            return dollars; 
        case 8: 
            dollars=money.TenMillions(number)+"Dollars";
            return dollars;
        case 9:
            dollars=money.HMillions(number)+"Dollars";
            return dollars;
        default:
            return "";
        }
    }
}

class Program{
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            while (!reader.EndOfStream)
            {
            string line = reader.ReadLine();
                // do something with line
                Convert convert = new Convert();
                Console.WriteLine(convert.NumToWord(line));
             }
        }
    }
}
