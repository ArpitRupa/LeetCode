
public class App {
    public static void main(String[] args) {

        // Coin Change
        System.out.println("-----Coin--Change-----");
        CoinChange coin = new CoinChange();
        int[] coins = { 186, 419, 83, 408 };
        System.out.println(coin.coinChange(coins, 6249));
        System.out.println("Expected: 20");

        // LCSS
        System.out.println("-----LCSS-----");
        LongestCommonSubstring lcss = new LongestCommonSubstring();
        String a = "abcdxyz";
        String b = "xyzabcd";
        System.out.println(lcss.longestCommonSubStr(a, b));
        System.out.println("Expected: 4");
        a = "GeeksforGeeks";
        b = "GeeksQuiz";
        System.out.println(lcss.longestCommonSubStr(a, b));
        System.out.println("Expected: 5");

        a = "abc";
        b = "xyz";
        System.out.println(lcss.longestCommonSubStr(a, b));
        System.out.println("Expected: 0");

        a = "";
        b = "asdasdf";
        System.out.println(lcss.longestCommonSubStr(a, b));
        System.out.println("Expected: 0");

        // Integer to Roman
        System.out.println("-----Integer--To--Roman-----");
        IntegerToRoman intToRoman = new IntegerToRoman();
        System.out.println(intToRoman.intToRoman(3));
        System.out.println("Expected: III");
        System.out.println(intToRoman.intToRoman(58));
        System.out.println("Expected: LVIII");
        System.out.println(intToRoman.intToRoman(1994));
        System.out.println("Expected: MCMXCIV");

    }
}
