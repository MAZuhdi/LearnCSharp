	using System;
	using System.Collections.Generic;
						
	public class Program
	{
		public static void Main()
		{
			string nama ="Agung";
			int umur = 21;
			string nim ="J3D118098";
			Double IPK = hitungIPK(18);
			
			string[] universitas = new string[3] {"UI", "BINUS", "Tel-U"};
			universitas[0] = "IPB";
			
			for (int i=0;i<3;i++){
				Console.WriteLine(universitas[i]);
			}

			List<int> hargaList = new List<int>();
			hargaList.Add(200);
			hargaList.Add(300);
			hargaList.Add(400);
			hargaList.Add(500);

			foreach(int h in hargaList){
				Console.WriteLine(h);
			}

			for (int i=0;i<hargaList.count();i++){
				Console.WriteLine(hargaList[i]);
			}
			
			cetakMahasiswa(nama, umur, nim, IPK);
		}
		
		public static void cetakMahasiswa(string nama, int umur, string nim, Double IPK){
			Console.WriteLine("Nama =" + nama);
			Console.WriteLine("Umur =" + umur);
			Console.WriteLine("Nim =" + nim);
			Console.WriteLine("SKS =" + IPK);
		}
		
		public static Double hitungIPK(Double sks){
			Double ipk = sks/4;
			return ipk;
		}
	}