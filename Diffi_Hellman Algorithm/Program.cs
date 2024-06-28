namespace Diffi_Hellman_Algorithm;

public static class Program
{
    public static bool IsPrime(int number){
        if (number<2) return false;
        for(int i =2;i<Math.Sqrt(number)+1;i++){
            if (number%i ==0)return false;
        }
        return true;
    }
    static void Main(string[] args)
    {
        var difii = new Diffie_Hellman(23,9);
        System.Console.WriteLine("The prime Key is : "+ difii.Prime_Key1);
        System.Console.WriteLine("The mod of the Algorithm is : " +difii.Public_Key2);
        int a = difii.Set_Modes_a();
        System.Console.WriteLine(a);
        int b = difii.Set_Modes_b();
        System.Console.WriteLine(b);
        int c = difii.Encrypt_a();
        System.Console.WriteLine(c);

        int d = difii.Encrypt_b();
        System.Console.WriteLine(d);
        
    }
}

public class Diffie_Hellman{
    public int Prime_Key1{get;set;}
    public int Public_Key2{get;set;}
    private int mod_A{get;}
    private int mod_B{get;}
    public Diffie_Hellman(int Prime_public_key, int second_public_key){
        if(Program.IsPrime(Prime_public_key))
        {this.Prime_Key1 = Prime_public_key;}
        this.Public_Key2 = second_public_key;
    }
    public int Set_Modes_a(){
        Random random = new Random();
        int s = random.Next(1,10);
        return s  ;
    }
    public int Set_Modes_b(){
        Random randint = new Random();
        int a = randint.Next(1,10);
        return a;
    }
    public int Encrypt_a(){
        double a = Math.Pow(this.Public_Key2,Set_Modes_a());
        return ((int) a)%this.Prime_Key1;}
    public int Encrypt_b(){
        double b  = Math.Pow(this.Public_Key2,Set_Modes_b());
        return ((int) b)%this.Prime_Key1;}
    public int Decript_a(){
        double x = Math.Pow(Math.Pow(this.Public_Key2,Set_Modes_a()),Set_Modes_b());
        return ((int) x)%this.Prime_Key1;
    }
    public int Decript_b(){
        double y = Math.Pow(Math.Pow(this.Public_Key2,Set_Modes_b()),Set_Modes_a());
        return ((int)y)% this.Prime_Key1;
    }

    
}
