using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnsonAlgoritma
{
    class Istasyon //Kesme ve delme sürelerini aynı liste içerisinde tutabilmek için.
    {
        public int kesme { get; set; }
        public int delme { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Kesme ve delme sürelerinin listesi.
            List<Istasyon> liste = new List<Istasyon>
            {

            new  Istasyon{kesme = 4  ,  delme = 5 },
            new  Istasyon{kesme = 4  ,  delme = 1 },
            new  Istasyon{kesme = 10 ,  delme = 4  },
            new  Istasyon{kesme = 6  ,  delme = 10 },
            new  Istasyon{kesme = 2  ,  delme = 3 },

            };

            int[] siralama = { 0, 0, 0, 0, 0 }; //Sırası belirlenen işler bu diziye eklenecek.
            int bastanSay = 0; //Kesme süresi en küçük olanı başa koymak için kullanılan sayaç.
            int sondanSay = siralama.Length - 1; //Delme süresi en küçük olanı en sona koymak için kullanılan sayaç.
            int kesmeIndex = 0, delmeIndex = 0; //Sırası belirlenen işlerin index'ini yakalamak için kullanılacak.
            for (int j = 0; j < siralama.Length; j++) //Döngüyü sıralanacak iş sayısı kadar devam ettir.
            {
                //En küçük süreleri bulmak istediğimiz için ilk değerleri çok büyük bir sayı belirle.
                int enkKesme = 99999999;
                int enkDelme = 99999999;
                for (int i = 0; i < liste.Count; i++) //Kesmenin en küçüğünü bulmak için
                {
                    if (liste[i].kesme < enkKesme)
                    {
                        enkKesme = liste[i].kesme;
                        kesmeIndex = i;
                    }
                }
                for (int i = 0; i < liste.Count; i++) //Delmenin en küçüğünü bulmak için
                {
                    if (liste[i].delme < enkDelme)
                    {
                        enkDelme = liste[i].delme;
                        delmeIndex = i;
                    }
                }
                if (enkKesme < enkDelme) //Kesme ve delme'nin en küçük sürelerini bulduktan sonra kendi aralarında kıyasla.
                {
                    siralama[bastanSay] = kesmeIndex; //Kesme küçükse sıralamanın en başına koy.
                    bastanSay++; //Bir sonraki en küçük kesme süresini sıralamada bir öncekinin arkasına yerleştirmek için sayacı 1 arttır.
                    //en küçük kesme ve delme sürelerinin ilk değerlerini tekrar çok büyük bir sayı yap.
                    liste[kesmeIndex].kesme = 99999999;
                    liste[kesmeIndex].delme = 99999999;
                }
                else
                {
                    siralama[sondanSay] = delmeIndex; //Delme küçükse sıralamanın en sonuna koy.
                    //en küçük kesme ve delme sürelerinin ilk değerlerini tekrar çok büyük bir sayı yap.
                    liste[delmeIndex].kesme = 99999999;
                    liste[delmeIndex].delme = 99999999;
                    sondanSay--; //Bir sonraki en küçük delme süresini sıralamada bir öncekinin önüne yerleştirmek için sayacı 1 azalt.
                }
            }
            //Döngü tamamlandıktan sonra sıralama sonuçlarını ekrana yazdır.
            for (int i = 0; i < siralama.Length; i++)
            {
                Console.WriteLine(siralama[i] + 1);
            }
            Console.ReadKey();
        }
    }
}
