using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
        List<string> catatanKas = new List<string>();
        int saldo = 0;
        string keterangan = "";
        bool jalan= true;

        while(jalan){
            Console.Clear();
            mainMenu();
            int pilihan = int.Parse(Console.ReadLine());
            switch(pilihan) {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Saldo anda sekarang adalah Rp"+saldo);
                    wait();
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Berapa nominal Debit? Rp");
                    int jmlDebit = int.Parse(Console.ReadLine());
                    Console.WriteLine("Keterangan:");
                    keterangan = Console.ReadLine();
                    saldo+=jmlDebit;
                    catatanKas.Add(stringCatatan("Debit", jmlDebit, keterangan));
                    Console.WriteLine("Transaksi berhasil dan tercatat!");
                    wait();
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Berapa nominal Kredit? Rp");
                    int jmlKredit = int.Parse(Console.ReadLine());
                    Console.WriteLine("Keterangan:");
                    keterangan = Console.ReadLine();
                    if (cekSaldo(saldo, jmlKredit)){
                        saldo-=jmlKredit;
                        catatanKas.Add(stringCatatan("Kredit", jmlKredit, keterangan));
                        Console.WriteLine("Transaksi berhasil dan tercatat!");
                    } else {
                        Console.WriteLine("Gagal! Kredit melebihi jumlah saldo");
                    }
                    wait();
                    break;
                case 4:
                    Console.Clear();
                    cetakCatatan(catatanKas);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Aplikasi berhenti...");
                    jalan=false;
                    break;
                default:
                    break;
            }

        }
            
        }

    public static void mainMenu(){
        Console.WriteLine("Selamat datang di BukuKas-ConsoleVersion");
        Console.WriteLine("Pilihan Menu : ");
        Console.WriteLine("1 > Cek Saldo");
        Console.WriteLine("2 > Debit");
        Console.WriteLine("3 > Kredit");
        Console.WriteLine("4 > Informasi catatan kas");
        Console.WriteLine("5 > Tutup aplikasi");

		Console.Write("Pilih menu : ");
    }


    public static void wait(){
        Console.WriteLine("Tekan tombol apa saja untuk kembali ke menu utama");
		Console.ReadLine();
    }

    public static bool cekSaldo(int saldo, int jmlKredit){
        if (saldo >= jmlKredit){
            return true;
        } else {
            return false;
        }
    }

    public static string stringCatatan(string aksi, int nilai, string keterangan){
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

    public static void cetakCatatan(List<string> catatanKas){
        Console.WriteLine("=====CATATAN KAS=====");
        for (int i=0;i<catatanKas.Count;i++){
            int n = i + 1;
            Console.WriteLine(n+". "+catatanKas[i]);
        }
        Console.WriteLine("=====================");
        wait();
    }
}
