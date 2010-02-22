package Gilana.src.gilana;

public class EuropeanHuman extends Human {
    public EuropeanHuman(String hair, String nation, int age) {
        super(hair,nation,age);
    }

    public String whichReligion() {
        return "Christian";
    }
}