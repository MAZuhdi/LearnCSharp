using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
        Console.WriteLine("Selamat datang di halaman pembuatan rekening Bank ABC");
        Console.WriteLine("");
        Console.WriteLine("Yang harus anda masukkan ke sistem kami hanya Nama dan PIN");
        Console.WriteLine("Nomor Rekening akan dibuatkan secara sistem");
        Console.WriteLine("");
        Console.WriteLine("======FORM PENGAJUAN======");
        
        Console.Write("Nama:");
        //Terima masukan nama nasabah
        string nameVal = Console.ReadLine();
        //Terima masukan PIN nasabah
        Console.Write("Buat PIN anda:");
        string pinVal = Console.ReadLine();
        Console.WriteLine("==========================");

        //inisiasi objek dari class Rekening
        Rekening rekening = new Rekening(nameVal, pinVal);

        Console.WriteLine("Selamat rekening anda berhasil dibuat, ketik apa saja untuk menggunakan ATM");
        Console.ReadLine();

        bool ATMjalan = false;
        
        Console.Clear();
        Console.WriteLine("Selamat datang di ATM Bareng-bareng");
        while (!ATMjalan){
            Console.Write("Mohon masukkan PIN anda:");
            string pinInput = Console.ReadLine();
            if (rekening.cekPIN(pinInput)){
                ATMjalan = true;
            } else {
                Console.WriteLine("PIN salah, silahkan coba lagi");
                Console.WriteLine("ketik apa saja untuk mengulang");
                Console.ReadLine();
            }

            while (ATMjalan){
                Console.Clear();
                Console.WriteLine("Selamat datang di ATM Bareng-bareng");
                Console.WriteLine("Pilih transaksi:");
                Console.WriteLine("1 > Cek Saldo");
                Console.WriteLine("2 > Tarik tunai");
                Console.WriteLine("3 > Setor tunai");
                Console.WriteLine("4 > Riwayat Transaksi");

                int pilihan1 = int.Parse(Console.ReadLine());
                switch (pilihan1)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Saldo anda sekarang adalah Rp"+rekening.getSaldo());
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Penarikan penarikan = new Penarikan();
                        penarikan.menu();
                        bool cekPecahan = false;
                        while(!cekPecahan){
                            Console.Write("pilihan pecahan: ");
                            int pilihanPecahan = int.Parse(Console.ReadLine());
                            Console.Write("Jumlah penarikan: Rp");
                            int penarikanVal = int.Parse(Console.ReadLine());
                            switch (pilihanPecahan){
                                case 1:
                                    if (penarikan.cekPecahanTarik(20000, penarikanVal, rekening.getSaldo())){
                                        cekPecahan = true;
                                        penarikan.aksi(rekening, penarikanVal);
                                    }
                                    break;
                                case 2:
                                    if (penarikan.cekPecahanTarik(50000, penarikanVal, rekening.getSaldo())){
                                        cekPecahan = true;
                                        penarikan.aksi(rekening, penarikanVal);
                                    }
                                    break;
                                case 3:
                                    if (penarikan.cekPecahanTarik(50000, penarikanVal, rekening.getSaldo())){
                                        cekPecahan = true;
                                        penarikan.aksi(rekening, penarikanVal);
                                    }
                                    break;
                                case 99: 
                                    cekPecahan = true;
                                    break;
                                default:
                                    Console.WriteLine("Tidak ada dalam pilihan");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Penyetoran penyetoran = new Penyetoran();
                        penyetoran.menu();
                        int penyetoranVal = int.Parse(Console.ReadLine());
                        penyetoran.aksi(rekening, penyetoranVal);
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        rekening.cetak();
                        Console.ReadLine();
                        break;
                    case 99:
                        ATMjalan = false;
                        break;
                    default:
                        break;
			    }
            }
        }
	}
}

public class Rekening
{
	//Enkapsulasi
	private string nama, noRek, PIN;
	private int saldo;
	private List<string> riwayatTransaksi;
	
	public Rekening(){
		nama = "Hamba Allah";
		noRek = "245881567";
		PIN = "123";
		riwayatTransaksi = new List<string>();
	}
	//Overloading
	public Rekening(string namaVal, string pinVal){
		nama = namaVal;
		noRek = "245881567";
		PIN = pinVal;
		riwayatTransaksi = new List<string>();
	}
	
	public bool cekPIN(string masukan){
		if (PIN == masukan){
			return true;
		} else {
			return false;
		}
	}

	//Enkapsulasi
	public void setNama(string value){
		if (value != ""){
			nama = value;
		}
	}
	
	public string getNama(){
		return nama;
	}

    public string getNoRek(){
		return noRek;
	}
	
	
	public List<string> getRiwayat(){
		return riwayatTransaksi;
	}
	
	public void addRiwayat(string isi){
		riwayatTransaksi.Add(isi);
	}
	
	public int getSaldo(){
		return saldo;
	}
	
	public bool cekSaldo(int nilaiKredit){
		if (saldo >= nilaiKredit){
			return true;
		} else {
			return false;
		}
	}
	
	public void tambahSaldo(int value){
		saldo+=value;
	}
	
	public void kurangSaldo(int value){
		saldo-=value;
	}
	
	public void cetak(){
		Console.Clear();
        Console.WriteLine("Nama nasabah: "+nama);
        Console.WriteLine("Nomor rekening: "+noRek);
        Console.WriteLine("============================");
		for (int i = 0; i < riwayatTransaksi.Count; i++)
		{
			int n = i + 1;
            Console.WriteLine(riwayatTransaksi[i]);
		}
		Console.WriteLine("============================");
	}
}

public abstract class Transaksi
{
	public string namaTrx, deskripsi;
	
	public abstract void menu();
	public abstract void aksi(Rekening rek, int nilai);
	
	public Transaksi(){
		namaTrx = "Transaksi tanpa nama";
		namaTrx = "Transaksi tanpa deskripsi";
	}
	
	public string stringCatatan(int nilai){
       return DateTime.Now.ToString("d-M-yyyy")+" | "+namaTrx+" | sebesar Rp"+nilai;
	}
}

class Penyetoran : Transaksi
{
	public Penyetoran(){
		namaTrx = "Setor Tunai";
		deskripsi = "Menabung ke rekening dengan mudah di ATM setor tunai, gratis biaya admin";
	}
	//Overriding
	public override void menu(){
		Console.WriteLine(namaTrx);
		Console.WriteLine(deskripsi);

        Console.WriteLine("Masukkan jumlah setor tunai");
	}
	
	public override void aksi(Rekening rek, int nilai){
		rek.tambahSaldo(nilai);
        rek.addRiwayat(stringCatatan(nilai));
        Console.WriteLine("Berhasil melakukan setor tunai sebesar Rp"+nilai);
	}
}

class Penarikan : Transaksi
{
	public Penarikan(){
		namaTrx = "Tarik Tunai";
		deskripsi = "Tarik uang dari rekening anda di ATM ini, gratis biaya admin";
	}

    //Overriding
	public override void menu(){
        Console.Clear();
        Console.WriteLine(namaTrx);
        Console.WriteLine(deskripsi);
        Console.WriteLine("Penarikan bisa dengan beberapa pecahan: ");
        Console.WriteLine("1 > Rp20.000");
        Console.WriteLine("2 > Rp50.000");
        Console.WriteLine("3 > Rp100.000");
        Console.WriteLine("99 > kembali");
    }

    public bool cekPecahanTarik(int pecahan, int nilai, int saldo){
        if ((nilai % pecahan) == 0){
            if (saldo >= pecahan){
                Console.WriteLine("Pecahan Rp"+ pecahan + "x" + (nilai / pecahan));
                Console.ReadLine();
                return true;
            } else {
                Console.WriteLine("Penarikan gagal, jumlah penarikan kurang dari pecahan");
                return false;
            }
        } else {
            Console.WriteLine("Penarikan gagal, pecahan tidak sesuai");
            return false;
        }
    }
	
	public override void aksi(Rekening rek, int nilai){
		if (rek.cekSaldo(nilai)){
			rek.kurangSaldo(nilai);
			Console.WriteLine("Tarik tunai berhasil");
            rek.addRiwayat(stringCatatan(nilai));
		} else {
			Console.WriteLine("Tarik tunai gagal, saldo tidak mencukupi");
		}
	}
}