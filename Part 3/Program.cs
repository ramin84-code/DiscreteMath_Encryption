using Microsoft.VisualBasic;
using Part3;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Final_Project;
using System.Security.Cryptography.X509Certificates;

namespace Part3;
public class Program{
    public static bool is_Prime(int e){
        if(e<2)return false;
        for(int i =2;i<Math.Sqrt(e)+1;i++){if(e%i==0)return false;}
        return true;
    }
    public static void Main(string [] args){
        string s = File.ReadAllText("max.txt");
        List<int> lists = new List<int>();
        foreach (char sa in s) lists.Add((int)sa);
        string aa="";
        int x = 3;
        while(x>=0){aa += lists[x]; x--;}
        var aes= new AES_RSA(aa,100003,100019);
        int p_n =aes.PHi_n();
        double ch= aes.choose_e();
        int p_k= aes.Private_Key();
        int en_rsa= aes.encrypt(aa);
        int de_rsa = aes.decrypt();
        List<int> ss= aes.Encode();
        string Decoded_message = aes.Decode();
        System.Console.WriteLine("The Decoded message is : "+ Decoded_message);
        
    }
}
public class AES_RSA:RSA_Algorithm {
    public string files{get;}
    private int N{get;}
    public AES_RSA(string Files, int first_number,int second_number):
    base(first_number,second_number){
        if (Program.is_Prime(first_number)&& Program.is_Prime(second_number)){
            this.first_number= first_number;
            this.second_number = second_number;
        }
        this.N = this.first_number*this.second_number;
    }


    

}

