package Gilana.src.gilana;

public class AsianHuman extends Human {
    private int numOfWifes;
    
    public AsianHuman(String hair, String nation, int age, int wifes) {
        super(hair,nation,age);
        numOfWifes = wifes;
    }

    public int getNumOfWifes() {
        return numOfWifes;
    }

    public String whichReligion() {
        return "Islam";
    }
}
