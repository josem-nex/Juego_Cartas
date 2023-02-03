using Poker;

public class Simulador{
    private Manager Manager;
    public Simulador(Manager manager){
        Manager = manager;
    }
    public void Simular(){
        Manager.StartRonda();
        Manager.ExecuteRonda();
        Manager.EndRonda();
        System.Console.WriteLine("Everything is ok");
    }
}
