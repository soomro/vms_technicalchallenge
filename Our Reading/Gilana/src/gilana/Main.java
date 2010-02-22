package Gilana.src.gilana;

public class Main {
    public static void main(String[] args) {
        EuropeanHuman y;
        AsianHuman x;
        Human s;

        x = new AsianHuman("Black","Iranina",26,0);
        y = new EuropeanHuman("Brown","Canadian",23);
        s = new AsianHuman("Black","Iran",27,100);

        if (x.isOlder(y)) System.out.println(y);
        else System.out.println(x);
        
        System.out.println("y is " + x.whichReligion());
        System.out.println("x is " + y.whichReligion());
        System.out.println("s is " + s.whichReligion());
    }
}
