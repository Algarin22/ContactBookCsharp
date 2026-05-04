namespace ContactBook;

public class Program
{
    public static void Main()
    {
        Contact c1 = new Contact();
        Contact c2 = new Contact("Axel");
        Contact c3 = new Contact("Axel", "Algarin");
        Contact c4 = new Contact("Axel", "Algarin", "123-456-7890");
        Contact c5 = new Contact("Axel", "Algarin", "123-456-7890", "axel10algarin@gmail.com");    
        Contact c6 = new Contact(lname: "Algarin", phone: "123-456-7890", email:"axel10algarin@gmail.com");
    }
}
