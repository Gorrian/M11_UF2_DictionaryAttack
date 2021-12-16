using System;
using System.IO;
using System.Collections.Generic;

namespace M11_UF2_DictionaryAttack
{
    
    public class Program
    {
        private static readonly ConsoleColor color = Console.ForegroundColor;
        private static Random random = new Random();
        private static char Random_character(){
            String characters="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            characters+=characters.ToLower()+"1234567890";
            int Pick=random.Next(0,characters.Length);
            return characters.ToCharArray()[Pick];
        }
        private static String RandomPassword(int Size){
            String Password="";
            for(int i=1;i<=Size;i++){
                Password+=Random_character();
            }
            return Password;
        }
        //List of users so the program can pick one randomly, I won't let you win so easily
        private static readonly String [] UserList=new String []{"User","Olaf","Admin","Me","Gorrian","Someone","Oriol"};
        //Another list for the passwords but to even make it harder there is a chance the programa will pick a random generated one
        //if the program does that, not even I will know what the program will pick as a password and it will change everytime you run the program
        //You can modify both of these lists if you wish
        private static readonly String [] PasswordList=new string[]{"123457890","aA123456789!","count123","Password","06102001",RandomPassword(random.Next(1,17))};
        
        private static String SearchType(String arg){
            char []Words=arg.ToCharArray();
            String Type="";
            for(int i=0;i<Words.Length;i++){
                if(Words[i]=='='){
                    return Type;
                }
                Type+=Words[i];
            }
            return "=?";
        }
        private static String SearchName(String arg){
            char []Words=arg.ToCharArray();
            String Type="";
            bool Añadir=false;
            for(int i=0;i<Words.Length;i++){
                if(Añadir){
                    Type+=Words[i];
                }else if(Words[i]=='='){
                    Añadir=true;
                }
            }
            if(Type==""){
                return "=?";
            }else{
                return Type;
            }
        }
        private static Boolean Execute(String arg){
            if(SearchName(arg)=="=?"){
                return false;
            }
            return true;
        }
        private static String[] ExtractContent(String arg){
            if(SearchType(arg)=="Direct"){
                return new String[]{SearchName(arg)};
            }else{
                return File.ReadAllLines(SearchName(arg));
            }
        }
        private static void drawLine(){
            //I have to thanks TheMineWay for showing me this function that allows me to get the width
            //of the console window
            for(int i=0;i<Console.WindowWidth;i++){
                Console.Write("*");
            }
        }
        private static void ArgErrorMess(){
                Console.WriteLine("To use this program in the argumetn you have to write 2 arguments with each one indicating");
                Console.WriteLine("if it refers to the word you want to use or a file");
                Console.WriteLine("Exameple: M11_UF2_DictionaryAttack.exe Direct=Username File=File.txt");
                Console.WriteLine("The first argument makes reference to the username and the second one the password");
        }
        static void Main (string[] args){
            //args=new String[]{"File=diccionari.txt","File=diccionari.txt"};
            if(args.Length<=1){
                ArgErrorMess();
            }else{
                String UserAttackArg=SearchType(args[0]);
                String PasswordAttackArg=SearchType(args[1]);
                try{
                    if((UserAttackArg!="=?" && PasswordAttackArg!="=?") && ((UserAttackArg=="Direct" || UserAttackArg=="File") && (PasswordAttackArg=="Direct" || PasswordAttackArg=="File"))){
                        String[] UserAttack=ExtractContent(args[0]);;
                        String[] PasswordAttack=ExtractContent(args[1]);;
                        String User=UserList[random.Next(0,UserList.Length-1)];
                        String Password=PasswordList[random.Next(0,PasswordList.Length)];
                        Console.WriteLine("The game will begin, we will soon see if your combination is right");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        //Let's asume that the only thing the form we are trying to break just says failed, regardless if you got the user or password right
                        for(int i=0;i<UserAttack.Length;i++){
                            for(int i2=0;i2<PasswordAttack.Length;i2++){
                                
                                drawLine();
                                if(User==UserAttack[i] && Password==PasswordAttack[i2]){
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Congratulations, your combination was right");
                                    Console.WriteLine("The combination was:");
                                    Console.WriteLine("- User: "+UserAttack[i]);
                                    Console.WriteLine("- Password: "+PasswordAttack[i2]);
                                    Console.ForegroundColor= color;
                                    drawLine();
                                    return;
                                }else{
                                    Console.WriteLine("This combination failed");
                                    Console.WriteLine("- User: "+UserAttack[i]);
                                    Console.WriteLine("- Password: "+PasswordAttack[i2]);
                                }
                            }
                        }
                        drawLine();
                    }else{
                        ArgErrorMess();
                    }
                }catch(FileNotFoundException e){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("One of the files you were looking was not found for more information read the exception that was triggered");
                    Console.WriteLine(e);
                    Console.ForegroundColor = color;
                }
            }
        }
    }
}