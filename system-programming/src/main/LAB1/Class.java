package LAB1;

import java.nio.charset.StandardCharsets;

public class Class {
    public static void main(String[] args) {
        byte value = 7; // byte - 8 bit  -> 0000 0111
        int value2 = 5; // byte - 32 bit -> 00000000000000000000000000001001

        System.out.println(value&value2);
    }
}
