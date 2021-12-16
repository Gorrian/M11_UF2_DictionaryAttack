# M11_UF2_DictionaryAttack
 Welcome to my game where your objective is to crack the password the program may generate and altough it generates the user information and the password information based of a list there is a small chance the program will just randomly select letters and words for a password, you may modify the code to modify that list if you wish, you should find the 2 lists as global variables.
## How to play the game
To play the game you have 2 options to insert the username and password you wish to insert.
The first one would be to directly insert this information by just writing the word "Direct" and the argument which would be the word you want the program to try separated by a =, an example would be:
- M11_UF2_DictionaryAttack.exe Direct=Username Direct=Password

The other one is to insert all the usernames and/or passwords in a file and instead of using "Direct" use "File" as shown in the following example:
- M11_UF2_DictionaryAttack.exe File=UserFile.txt File=PassFile.txt

## Other things I need to explain
This code was developed for a school project altough it can be used to play a game to see if you can succesfully make a dictionary attack at the end it may contain some bugs that may have sliped by while testing the code but as long as I've seen everything is in working except for a small issue which shouldn't happen if you follow everything "EXACTLY" as I explained before.
The self-contained program should be at output and it's compatible with windows systems of 64bits