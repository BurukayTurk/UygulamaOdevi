namespace Uygulamaödev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Kaç öğrenci kaydetmek istiyorsunuz?: ");
                int ogrenciSayisi = int.Parse(Console.ReadLine());

                List<Student> students = new List<Student>();

                for (int i = 0; i < ogrenciSayisi; i++)
                {
                    Console.WriteLine($"{i + 1}. Öğrencinin bilgilerini giriniz:");

                    Console.Write("Numarası: ");
                    int numara = int.Parse(Console.ReadLine());

                    Console.Write("Adı: ");
                    string ad = Console.ReadLine();

                    Console.Write("Soyadı: ");
                    string soyad = Console.ReadLine();

                    int vizeNotu;
                    do
                    {
                        Console.Write("Vize Notu (0-100): ");
                        vizeNotu = int.Parse(Console.ReadLine());
                    } while (vizeNotu < 0 || vizeNotu > 100);

                    int finalNotu;
                    do
                    {
                        Console.Write("Final Notu (0-100): ");
                        finalNotu = int.Parse(Console.ReadLine());
                    } while (finalNotu < 0 || finalNotu > 100);

                    double ortalama = (vizeNotu * 0.4) + (finalNotu * 0.6);
                    string harfNotu = HarfNotuHesapla(ortalama);

                    students.Add(new Student(numara, ad, soyad, vizeNotu, finalNotu, ortalama, harfNotu));
                }

                double sinifOrtalamasi = 0;
                double enDusukNot = double.MaxValue;
                double enYuksekNot = double.MinValue;

                Console.WriteLine("\nNumara\tAd\tSoyad\tVize\tFinal\tOrtalama\tHarf Notu");
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Numara}\t{student.Ad}\t{student.Soyad}\t{student.VizeNotu}\t{student.FinalNotu}\t{student.Ortalama}\t\t{student.HarfNotu}");
                    sinifOrtalamasi += student.Ortalama;
                    if (student.Ortalama < enDusukNot) enDusukNot = student.Ortalama;
                    if (student.Ortalama > enYuksekNot) enYuksekNot = student.Ortalama;
                }

                sinifOrtalamasi /= ogrenciSayisi;

                Console.WriteLine($"\nSınıf Ortalaması: {sinifOrtalamasi:F2}");
                Console.WriteLine($"En düşük not: {enDusukNot:F2}");
                Console.WriteLine($"En yüksek not: {enYuksekNot:F2}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Hatalı giriş yaptınız: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bir hata oluştu: {ex.Message}");
            }
        }

        static string HarfNotuHesapla(double ortalama)
        {
            if (ortalama >= 85) return "AA";
            else if (ortalama >= 75) return "BA";
            else if (ortalama >= 60) return "BB";
            else if (ortalama >= 50) return "CB";
            else if (ortalama >= 40) return "CC";
            else if (ortalama >= 30) return "DC";
            else if (ortalama >= 20) return "DD";
            else if (ortalama >= 10) return "FD";
            else return "FF";
        }
    }

    class Student
    {
        public int Numara { get; }
        public string Ad { get; }
        public string Soyad { get; }
        public int VizeNotu { get; }
        public int FinalNotu { get; }
        public double Ortalama { get; }
        public string HarfNotu { get; }

        public Student(int numara, string ad, string soyad, int vizeNotu, int finalNotu, double ortalama, string harfNotu)
        {
            Numara = numara;
            Ad = ad;
            Soyad = soyad;
            VizeNotu = vizeNotu;
            FinalNotu = finalNotu;
            Ortalama = ortalama;
            HarfNotu = harfNotu;
        }
    }
}


