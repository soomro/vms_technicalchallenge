package Gilana.src.gilana;

public abstract class Human {
    private String hairColor;
    private String nationality;
    private int age;

    public Human(String hair, String nation, int a) {
        hairColor = hair;
        nationality = nation;
        age = a;
    }

    public boolean isOlder(Human h) {
        if (age > h.age) return true;
        else return false;
    }

    public String toString() {
        return "HairColor = " + hairColor + ", Nationality = " + nationality + ", age = " + age;
    }

    public abstract String whichReligion();
}
