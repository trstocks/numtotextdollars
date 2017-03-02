# numtotextdollars
This is a basic example of converting numerical value to text.
##Running the program using Python
1. Using Python3, run the python file with an argument(a path to the text document listing a number for each row).

##Running The progrem using .NET
1. From a commandline/terminal navigate to the project directory.
2. Type "dotnet restore"
3. Then type "dotnet run [filename]"  --In my example, I typed "dotnet run stuff.txt"
For each set of input produce a single line of output which is the english textual representation of that integer. 

The output should be unspaced and in Camelcase. Always assume plural quantities. You can also assume that the numbers are < 1000000000 (1 billion).

In case of ambiguities e.g. 2200 could be TwoThousandTwoHundredDollars or TwentyTwoHundredDollars, always choose the representation with the larger base i.e. TwoThousandTwoHundredDollars. For the examples shown above, the answer would be:

ThreeDollars
TenDollars
TwentyOneDollars
FourHundredSixtySixDollars
OneThousandTwoHundredThirtyFourDollars

From [Code Eval](https://www.codeeval.com/open_challenges/52/)
