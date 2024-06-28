using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Text;

namespace Final_Project;

public static class Program
{
    public static bool IsPrime(int x){
        if(x<2)return false;
        for (int i = 2;i<Math.Sqrt(x)+1;i++){
            if(x%i == 0)return false;
        }
        return true;    
    }
    public static int GCd(int a, int b){
        int x = 1;
        for(int i =1;i<a+1;i++){
            if(a%i ==0 && b%i ==0){
                x = i;
            }
        }
        return x;
        
    }
    public static  void Main(string[] args)
    {
        string ascii = (Convert.ToChar(65)).ToString();
        System.Console.WriteLine(ascii);
        System.Console.WriteLine(string.Format("{0:F6}",65));
        //System.Console.WriteLine(GCd(0,3));
        //string s = "abc";
        //UnicodeEncoding unicode = new UnicodeEncoding();
        //byte[] x = unicode.GetBytes(s);
        //System.Console.WriteLine("Welcome");
        //string ss= Console.ReadLine();
        //int a = int.Parse(ss);
        //string bb = Console.ReadLine();
        //int b = int.Parse(bb);
        //var rsa = new RSA_Algorithm(a,b);
        //System.Console.WriteLine( rsa.PHi_n());
        //System.Console.WriteLine(rsa.choose_e());
        //System.Console.WriteLine(rsa.Private_Key());
        //foreach(byte xx in x) System.Console.WriteLine(xx);
        //System.Console.WriteLine(Math.Pow(2,3));
        //int a = 123;
        //string b = "";
        //while(a>0){
        //    int current = a%10;
        //    a = a/10;
        //    if(current ==0) current =10;
        //    b = (char)('A'+(current-1))+ b;
        //}
        //bool aa = IsPrime(3);
        //bool bb = IsPrime(5);
        //System.Console.WriteLine(aa);
        //System.Console.WriteLine(bb);
        //System.Console.WriteLine(b);
    }

}
public class RSA_Algorithm{
    private int encoding_number;
    protected int n;
    public int first_number{get;set;}
    public int second_number{get;set;}
    public RSA_Algorithm(int First_Number, int Second_Number){
        if (Program.IsPrime(First_Number) && Program.IsPrime(Second_Number )==true)
        {   this.first_number = First_Number;
            this.second_number = Second_Number;}
        this.n = first_number*second_number;
    }
    public int PHi_n()=> (this.first_number-1)*(this.second_number-1);
    public double  choose_e(){
        for (int e = 0;e<this.n+1;e++){
            if(Program.GCd(e,this.PHi_n())==1) {
                if (e!=0 && e!=1)
                return e;
            }
        }
        return 1;
    }
    public int Private_Key(){
        for(int j = 0;j<this.n+1;j++){
            if (j*choose_e() % this.PHi_n() == 1) return j;
        }
        return 1;
    }
    public int encrypt(string message){
        string s ="";
        foreach(char word in message) s+= (int)word;
        int new_number =  int.Parse(s);
        double encoded_number = Math.Pow(new_number,(double)choose_e());
        string encoded_numbers = encoded_number.ToString();
        int encrypted_nums = int.Parse(encoded_numbers);
        this.encoding_number= encrypted_nums%this.n;
        return encoding_number ;
    }
    public int decrypt(){
        double m = Math.Pow(this.encoding_number,Private_Key());
        int m1 = (int)(m%this.n);
        
        return m1;
    }
    public List<int> Encode(){
        string s = this.encoding_number.ToString();
        List<int> encoded = new List<int>();
        foreach(char letter in s) encoded.Add((int)letter);
        return encoded;
        }
    public string Decode(){
        List<int>s = Encode();
        string strings = "";
        foreach(int number in s) strings += (char)decrypt();
        return strings;
    }
    
}

