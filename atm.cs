using System;
					
public class Program
{
    
	public static void Main()
	{
        List<string> catatanKas = new List<string>();
		Console.WriteLine("Hello World");
		Console.WriteLine("Registrasi Akun");
		Console.Write("Nama : ");
		string nama = Console.ReadLine();
		Console.Write("Setor Perdana : Rp");
		int saldo = int.Parse(Console.ReadLine());
		Console.WriteLine("Halo " + nama);
		wait();
		mainMenu();
	}
	
	public static void mainMenu() {
		Console.Clear();
		Console.WriteLine("Selamat Datang di ATM Bersama");
		Console.WriteLine("Pilihan transaksi");
		Console.WriteLine("1 > Informasi Saldo");
		Console.WriteLine("2 > Setor Tunai");
		Console.WriteLine("3 > Tarik Tunai");
		Console.Write("Pilih transaksi : ");
		int pilihan = int.Parse(Console.ReadLine());
		switch(pilihan) 
			{
			  case 1:
				Console.Clear();
				Console.WriteLine("1 > Informasi Saldo");
				Console.WriteLine("Saldo anda Rp"+saldo);
				wait();
				mainMenu(saldo);
				break;
			  case 2:
				Console.Clear();
				Console.WriteLine("2 > Setor Tunai");
				saldo = saldo + setor();
				Console.WriteLine("Sekarang, saldo anda Rp"+saldo);
				wait();
				mainMenu(saldo);
				break;
			  case 3:
				Console.Clear();
				Console.WriteLine("3 > Tarik Tunai");
				int jumlahTarik = tarik();
				if (cekSaldo(saldo, jumlahTarik)){
					saldo = saldo - jumlahTarik;
				} else {
					Console.WriteLine("Maaf, saldo anda tidak cukup");
				}
				wait();
				mainMenu(saldo);
				break;
			  default:
				Console.Clear();
				mainMenu(saldo);
				break;
			}
	}
	
	public static int setor(){
		Console.Write("Jumlah setor Tunai: Rp");
		int jumlahSetor = int.Parse(Console.ReadLine());
		return jumlahSetor;
	}
	
	public static int tarik(){
		Console.Write("Jumlah tarik Tunai: Rp");
		int jumlahTarik = int.Parse(Console.ReadLine());
		return jumlahTarik;
	}
	
	public static void wait(){
		Console.WriteLine("Tekan tombol apa saja untuk ke menu utama");
		Console.ReadLine();
	}
	
	public static bool cekSaldo(int saldo, int harga){
		if (saldo >= harga){
			return true;
		} else {
			return false;
		}
	}
}