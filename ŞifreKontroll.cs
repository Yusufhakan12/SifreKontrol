using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10

{
    static class Sifre

    {
        static int kucukHarfPuan;
        static int buyukHarfPuan;
        static int RakamPuan;
        static string GirilenString;
        static int sembolPuan;
        static int toplamSonuc;

        //buyuk harfleri diziye atayan metot
        public static void BuyukHarf()
        {
            //string degeri char dizisine atıyor
            char[] dizi = GirilenString.ToCharArray();


            int sayac = 0;
            //dizideki tum elemanlari geziyor
            for (int i = 0; i < dizi.Length; i++)
            {   //buyuk harf kontrolu yapıyor
                if (dizi[i] >= 'A' && dizi[i] <= 'Z' )
                {
                    sayac++;

                }
            }
            // math.min kutuphanesi ile maximum 2  buyuk harf karakterine puan veriyor 
            buyukHarfPuan = Math.Min(2, sayac) * 10;


        }
        public static void KucukHarf()

        {

            char[] dizi = GirilenString.ToCharArray();
            int sayac = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i] >= 'a' && dizi[i] <= 'z')
                {
                    sayac++;
                }
            }

            kucukHarfPuan = Math.Min(2, sayac) * 10;


        }
        public static void Rakam()
        {
            char[] dizi = GirilenString.ToCharArray();
            int sayac = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i] >= '0' && dizi[i] <= '9')
                {
                    sayac++;
                }
            }
            RakamPuan = Math.Min(2, sayac) * 10;
        }
        public static void Sembol()
        {
            char[] dizi = GirilenString.ToCharArray();
            int sayac = 0;
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i] >= 'A' && dizi[i] <= 'Z')
                {
                    sayac = 0;
                }
                else if (dizi[i] >= 'a' && dizi[i] <= 'z')
                {
                    sayac = 0;
                }
                else if (dizi[i] >= '0' && dizi[i] <= '9')
                {
                    sayac = 0;
                }
                else
                    sayac++;
            }
            sembolPuan = Math.Min(dizi.Length, sayac) * 10;
        }
        public static void PuanHesaplayıcı()
        {


            Sifre.BuyukHarf();
            Sifre.KucukHarf();
            Sifre.Rakam();
            Sifre.Sembol();
            // 9 karatker ise +10 puan ekliyor 
            if (GirilenString.Length == 9)
            {
                toplamSonuc = kucukHarfPuan + buyukHarfPuan + RakamPuan + sembolPuan + 10;
            }
            else
                toplamSonuc = kucukHarfPuan + buyukHarfPuan + RakamPuan + sembolPuan;


        }
        public static void SifreKontrol()
        {

            //sifrenin kosullarıni kontrol ediyor
            do
            {

                Console.WriteLine("Şifre kuralları:");
                Console.WriteLine("1.Türkçe karakter içeremez");
                Console.WriteLine("2.Min 9 karakter Max 10 karakter girilebilir");
                Console.WriteLine("3.Toplam puan 70 ten küçük olamaz ");
                Console.WriteLine("*******************");
                Console.WriteLine(" Şifre giriniz");

                GirilenString = Console.ReadLine();

                Sifre.PuanHesaplayıcı();
            } while (RakamPuan == 0 || buyukHarfPuan == 0 || kucukHarfPuan == 0 || sembolPuan == 0 || toplamSonuc < 70 || GirilenString.Length < 9 || GirilenString.Length > 10 || GirilenString.Contains(" "));



            if (toplamSonuc < 70)
            {
                Console.WriteLine("Toplam puan 70 ten küçük olamaz");
                Console.WriteLine("*******************");
                Sifre.SifreAnaliz();
            }



            else if (toplamSonuc > 70 && toplamSonuc < 90)
            {
                Console.WriteLine(" Şifre kabul edilebilir");
                Console.WriteLine("puanınz= " + toplamSonuc);
                Console.WriteLine("şifreniz: " + GirilenString);
                Console.WriteLine("*******************");
                Sifre.SifreAnaliz();
            }
            else
            {
                Console.WriteLine("Şifre çok güçlü.Toplam puanınız= " + toplamSonuc);
                Console.WriteLine("Şifreniz: " + GirilenString);
                Console.WriteLine("*******************");
                Sifre.SifreAnaliz();


            }


        }
        //Şifredeki karakterlerin sayisini veriyor
        public static void SifreAnaliz()
        {
            Console.WriteLine("Girlen rakam sayısı= " + RakamPuan / 10);
            Console.WriteLine("Girilen büyük harf sayısı= " + buyukHarfPuan / 10);
            Console.WriteLine("Girilen küçük harf sayısı= " + kucukHarfPuan / 10);
            Console.WriteLine("Girilen sembol sayısı= " + sembolPuan / 10);
        }

    }
    internal class Program

    {
        static void Main(string[] args)
        {

            
            Sifre.SifreKontrol();


        }
    }
}

