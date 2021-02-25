usr_input = input("Enter a number: ")
total = 0
while usr_input != "quit":
    total += int(usr_input)
    usr_input = input("Enter another number: ")

print(total)
