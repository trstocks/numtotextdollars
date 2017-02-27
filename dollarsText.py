import sys

class Money:
    def ones(num):
        ones=("", "One","Two","Three", "Four", "Five", "Six", "Seven", "Eight","Nine")
        value = ones[int(num)]
        return value
    def teens(num):
        teens=("Ten","Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen","Seventeen","Eighteen","Nineteen")
        value = teens[int(num[1])]
        return value
    def tens(num):
        tens=("","","Twenty","Thirty","Forty","Fifty","Sixty","Seventy","Eighty","Ninety")
        value = tens[int(num[0])] + Money.ones(num[1])
        return value
    def hundreds(num):
        value1 = Money.ones(int(num[0]))
        if num[1]==1:
            value2=Money.teens(num[1:])
        else:
            value2=Money.tens(num[1:])
        if value1 is not "":
            return value1+ "Hundred" +value2
        else:
            return value2
    def thousands(num):
        if len(num) == 4:
            value1 = Money.ones(num[0])
            value2 = Money.hundreds(num[1:])
        elif len(num)== 5:
            if int(num[0])==1:
                value1 = Money.teens(num[0:2])
                value2 = Money.hundreds(num)
            else:
                value1 = Money.tens(num[0:2])
                value2 = Money.hundreds(num[2:])
        elif len(num)== 6:
            value1 = Money.hundreds(num[0:3])
            value2 = Money.hundreds(num[3:])
        if value1 is not "":
            return value1+ "Thousand" +value2
        else:
            return value2
    def millions(num):
        if len(num) == 7:
            value1 = Money.ones(num[0])
            value2 = Money.thousands(num[1:])
        elif len(num)==8:
            if int(num[0])==1:
                value1 = Money.teens(num[0:2])
                value2 = Money.thousands(num[2:])
            else:
                value1 = Money.tens(num[0:2])
                value2 = Money.thousands(num[2:])
        elif len(num)==9:
            value1 = Money.hundreds(num[0:3])
            value2 = Money.thousands(num[3:])

        if value1 is not "":
            return value1+ "Million" +value2
        else:
            return value2
class Convert:
    def num_to_word(number):
        numbLength = len(number)
        if numbLength == 1:#less than 10
            if int(number) is not 0:
                return Money.ones(number)+"Dollars"
            else:
                return "Zero Dollars"
        elif numbLength == 2:#above 10 and below 100
            if int(number) < 20 and int(number) > 9:
                return Money.teens(number)+"Dollars"
            else:
                return Money.tens(number)+"Dollars"
        elif numbLength == 3:
            return Money.hundreds(number)+"Dollars"
        elif numbLength == 4 or numbLength == 5 or numbLength == 6:
            return Money.thousands(number)+"Dollars"
        elif numbLength == 7 or numbLength == 8 or numbLength == 9:
            return Money.millions(number)+"Dollars"
        else:
            return 0
if sys.argv[1:]:
    with open(sys.argv[1], 'r') as lines:
        for line in lines:
            #remove new line input
            line=line.replace('\n', '')
            print(Convert.num_to_word(line))
