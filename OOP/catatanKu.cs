using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		bool jalan = true;
		while (jalan)
		{
			Console.WriteLine("Selamat datang di CatatanKu-ConsoleVersion");
			Console.WriteLine("Pilih mode buku:");
			Console.WriteLine("1 > Buku Diary");
			Console.WriteLine("2 > Buku Kas");
			Console.WriteLine("3 > Tutup aplikasi");

			int pilihan1 = int.Parse(Console.ReadLine());
			switch (pilihan1)
			{
				case 1:
					diaryMain();
					break;
				case 2:
                    kasMain();
					break;
				case 3:
					jalan = false;
					Console.WriteLine("Memberhentikan aplikasi...");
					break;
				default:
					break;
			}
		}
	}

	public static void diaryMain()
	{
		bool jalanDiary = true;

		Diary diary = new Diary();
		while (jalanDiary)
		{
			diary.cetak();
			diary.mainMenu();
			int pilihanD = int.Parse(Console.ReadLine());
			switch (pilihanD)
			{
				case 1:
					Console.Clear();
					Console.WriteLine("1 > Tulis");
					Console.WriteLine("Ingin menulis apa hari ini?");
					string isi = Console.ReadLine();
					diary.tulis(DateTime.Now.ToString("d-M-yyyy") + " | " + isi);
					Console.WriteLine("Tulisan baru sudah tersimpan!");
					wait();
					break;
				case 2:
					Console.Clear();
					Console.WriteLine("2 > Ubah judul diary");
					Console.Write("Judul diary: ");
					string judulVal = Console.ReadLine();
					diary.setJudul(judulVal);
					Console.WriteLine("Berhasil mengganti judul!");
					wait();
					break;
				case 3:
					Console.Clear();
					Console.WriteLine("3 > Ubah penulis diary");
					Console.Write("Penulis diary: ");
					string penulisVal = Console.ReadLine();
					diary.setPenulis(penulisVal);
					Console.WriteLine("Berhasil mengganti nama penulis!");
					wait();
					break;
				case 4:
                    Console.WriteLine("Anda yakin?");
                    Console.WriteLine("1 > Ya");
                    Console.WriteLine("2 > Tidak");
                    int pilihanD1 = int.Parse(Console.ReadLine());
                    if (pilihanD1 == 1){
                        diary.kosongkan();
                    }
					break;
				case 5:
					Console.Clear();
					jalanDiary = false;
					break;
			}
		}
	}

    public static void kasMain(){
        Kas kas = new Kas();
        string keterangan = "";

        bool kasJalan = true;
        while(kasJalan){
            Console.Clear();
            kas.mainMenu();
            int pilihanK = int.Parse(Console.ReadLine());
            switch(pilihanK) {
                case 1:
                    Console.Clear();
                    Console.Write("Berapa nominal Debit? Rp");
                    int jmlDebit = int.Parse(Console.ReadLine());
                    Console.WriteLine("Keterangan:");
                    keterangan = Console.ReadLine();
                    kas.setSaldo(kas.getSaldo() + jmlDebit);
                    kas.tulis(kas.stringCatatan("Debit", jmlDebit, keterangan));
                    Console.WriteLine("Transaksi berhasil dan tercatat!");
                    wait();
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Berapa nominal Kredit? Rp");
                    int jmlKredit = int.Parse(Console.ReadLine());
                    Console.WriteLine("Keterangan:");
                    keterangan = Console.ReadLine();
                    if (kas.cekSaldo(jmlKredit)){
                        kas.setSaldo(kas.getSaldo() - jmlKredit);
                        kas.tulis(kas.stringCatatan("Kredit", jmlKredit, keterangan));
                        Console.WriteLine("Transaksi berhasil dan tercatat!");
                    } else {
                        Console.WriteLine("Gagal! Kredit melebihi jumlah saldo");
                    }
                    wait();
                    break;
                case 3:
                    Console.Clear();
                    kas.cetak();
                    wait();
                    break;
                case 4:
                    Console.Clear();
                    kasJalan=false;
                    break;
                default:
                    break;
            }
        }

    }

	public static void wait()
	{
		Console.WriteLine("Tekan tombol apa saja untuk ke kembali");
		Console.ReadLine();
	}
}

public abstract class Buku
{
	public string judul, penulis;
	private List<string> isiBuku = new List<string>();
    
	public abstract void cetak();
	public abstract void mainMenu();

	public Buku(string judulVal, string penulisVal)
	{
		judul = judulVal;
		penulis = penulisVal;
	}

	public Buku()
	{
		judul = "buku tanpa judul";
		penulis = "anonim";
	}

	public void setJudul(string judulVal)
	{
		judul = judulVal;
	}

	public void setPenulis(string penulisVal)
	{
		penulis = penulisVal;
	}

	public List<string> getIsiBuku()
	{
		return isiBuku;
	}

	public void tulis(string isi)
	{
		isiBuku.Add(isi);
	}

	public void kosongkan()
	{
		isiBuku.Clear();
	}
}

public class Diary : Buku
{
	public override void cetak()
	{
		Console.Clear();
		Console.WriteLine("===========DIARY============");
		Console.WriteLine("Judul: " + judul);
		Console.WriteLine("Penulis: " + penulis);
		Console.WriteLine("============ISI=============");
		for (int i = 0; i < getIsiBuku().Count; i++)
		{
			Console.WriteLine(getIsiBuku()[i]);
		}

		Console.WriteLine("============================");
	}

	public override void mainMenu()
	{
		Console.WriteLine("Pilihan Menu : ");
		Console.WriteLine("1 > Tulis");
		Console.WriteLine("2 > Ubah judul buku");
		Console.WriteLine("3 > Ubah penulis buku");
		Console.WriteLine("4 > Kosongkan");
		Console.WriteLine("5 > Kembali ke menu utama");
		Console.Write("Pilih menu : ");
	}
}

public class Kas : Buku
{
    private int saldo;

    public int getSaldo(){
        return saldo;
    }

    public void setSaldo(int value){
        saldo = value;
    }

	public override void cetak()
	{
		Console.Clear();
		Console.WriteLine("============KAS=============");
		Console.WriteLine(judul);
		Console.WriteLine("Admin: " + penulis);
		Console.WriteLine("============ISI=============");
		for (int i = 0; i < getIsiBuku().Count; i++)
		{
			int n = i + 1;
            Console.WriteLine(n+". "+getIsiBuku()[i]);
		}

		Console.WriteLine("============================");
        Console.WriteLine("Saldo kas saat ini Rp"+saldo);
	}

	public override void mainMenu()
	{
		Console.WriteLine("====Mode : Kas=====");
        Console.WriteLine("Saldo kas saat ini Rp"+saldo);
        Console.WriteLine("Pilihan Menu : ");
        Console.WriteLine("1 > Debit");
        Console.WriteLine("2 > Kredit");
        Console.WriteLine("3 > Informasi catatan kas");
        Console.WriteLine("4 > Kembali ke menu utama");

		Console.Write("Pilih menu : ");
	}

    public bool cekSaldo(int jmlKredit){
        if (getSaldo() >= jmlKredit){
            return true;
        } else {
            return false;
        }
    }

    public string stringCatatan(string aksi, int nilai, string keterangan){
        if (keterangan == ""){
            return DateTime.Now.ToString("d-M-yyyy")+" | "+aksi+" | sebesar Rp"+nilai;
        } else {
            if (aksi == "Kredit"){
                return DateTime.Now.ToString("d-M-yyyy")+" | "+aksi+" | sebesar Rp"+nilai+" untuk keperluan "+ keterangan;
            }
            else {
                return DateTime.Now.ToString("d-M-yyyy")+" | "+aksi+" | sebesar Rp"+nilai+" dari "+ keterangan;
            }
        }
        
    }
}