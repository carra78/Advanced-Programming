from calculator import Calculator

mycalc = Calculator()
print('A 10 Function Calculator\n**********************\nPlease use the following symbol:function pairs to perform calculations:\n')
mycalc.printFunction()

uinput = ''

while (mycalc.userinput == False):
    try:
        uinput = input("\n\nEnter a number to start or q to exit: ")
        mycalc.checkQuit(uinput)
        if mycalc.userinput:
            break
        else:
            mycalc.userinput1 = uinput
            uinput = input("Select a function: ")
            mycalc.checkQuit(uinput)
            if (mycalc.userinput):
                break
            else:
                mycalc.userfunction = uinput
                if mycalc.userfunction in mycalc.oneValueSymbols:
                    result = mycalc.selectFunction(mycalc.userfunction,mycalc.userinput1)
                    print(result)
                elif mycalc.userfunction in mycalc.twoValueSymbols:
                    uinput = input('Enter a second number: ')
                    mycalc.checkQuit(uinput)
                    if(mycalc.userinput):
                        break
                    else:
                        mycalc.userinput2 = uinput
                        result = mycalc.selectFunction(mycalc.userfunction,mycalc.userinput1,mycalc.userinput2)
                        print(result)
    except ValueError:
        print("Invalid input - please start again")
else:
    print('Goodbye!')
    
