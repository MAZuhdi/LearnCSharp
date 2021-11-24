using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		Console.WriteLine("Registrasi Akun");
		Console.Write("Nama : ");
		string nama = Console.ReadLine();
		Console.Write("Saldo Perdana : Rp");
		int saldo = int.Parse(Console.ReadLine());
		Console.WriteLine("Halo " + nama);
		wait();
		mainMenu(saldo);
	}
	
	public static void mainMenu(int saldo) {
		Console.Clear();
		Console.WriteLine("Selamat Datang di Console-Cinema");
		Console.WriteLine("Pilihan transaksi");
		Console.WriteLine("1 > Informasi Saldo");
		Console.WriteLine("2 > Top Up Saldo");
		Console.WriteLine("3 > Pembelian tiket");
        Console.WriteLine("4 > Menu Admin");
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
				Console.WriteLine("3 > Pembelian tiket");
                menuBeliTiket(saldo);
				break;
			  default:
				Console.Clear();
				mainMenu(saldo);
				break;
			}
	}

    public static void menuBeliTiket(){
        Console.WriteLine("Silahkan pilih judul film");
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