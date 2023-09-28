
public class App {
    public static void main(String[] args) throws Exception {

        System.out.println("-----Coin--Change-----");
        CoinChange coin = new CoinChange();
        int[] coins = { 186, 419, 83, 408 };
        System.out.println(coin.coinChange(coins, 6249));
        System.out.println("Expected: 20");

    }
}
