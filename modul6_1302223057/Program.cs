using System.Diagnostics;

namespace modul6_1302223057
{
    // deklarasi class raqndom untuk membuat 5 digit id random
    class random
    {
        public int idRandom()
        {
            Random id = new Random();
            return id.Next(10000,99999);
        }
    }

    // membuat class SayaTubeVideo
    class SayaTubeVideo
    {
        private int id;
        private int playCount;
        private String title;


        // Konstruktor sayatubeVideo berparameter judul
        public SayaTubeVideo(String judul)
        {
            random random = new random();

            // memastikan judul memiliki panjang diabwah 200 dan tidak boleh kosong
            Debug.Assert(judul.Length <= 200 && judul != "", "Nama Judul terlalu panjang atau judul kosong");
            {
                this.title = judul;
                this.id = random.idRandom();
                this.playCount = 0;

            }
        }

        // method untuk menambah playcount sesuai input
        public void IncreasePlayCount(int input)
        {
            // memastikan input tidak negatif dan kurang dari 25 juta
            Debug.Assert(input <= 25000000 && input > 0,"Jumlah playCount melebihi batas");
            try
            {
                checked
                {
                    this.playCount += input;
                }
            }
            // input melebihi batas dan overflow
            catch (OverflowException) 
            {
                Console.WriteLine("Overflow");
            }

        }

        // nmethod untuk menampilkan id, title, playcount
        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID : {id}");
            Console.WriteLine($"Title : {title}");
            Console.WriteLine($"PlayCount : {playCount}");
        }

        // method untuk mengembalikan nilai dari playcount
        public int GetPlayCount()
        {
            return this.playCount;
        }
        // method untuk mengembalikan nlai dari judul
        public String GetTitle()
        { 
            return this.title;
        }
    }


    // membuat class sayatubeuser
    class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public String Username;


        // konstruktor berparameter nama
        public SayaTubeUser(String nama)
        {
            // memastkan usernmae memiliki panjang kurang dari 100 dan tidak boleh kosong
            Debug.Assert(nama.Length <= 100 && nama != "", "Nama Username terlalu panjang atau nama kosong");
            try
            {
                checked
                {
                    this.Username = nama;
                    this.uploadedVideos = new List<SayaTubeVideo>();
                }
            }
            // input tidak sesuai dan menampilakn  overflow
            catch (OverflowException)
            {
                Console.WriteLine("Overflow");
            }
            

        }

        // method untuk menjumlahkan total playcount pada list
        // dan mengembalikan nilai total
        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                 total += uploadedVideos[i].GetPlayCount();
            }
            return total;
        }

        // method untuk menambahkan video
        public void addVideoSaya(SayaTubeVideo video)
        {
            // memastikan video tidak kosong, dan jumlah playcount kurang dari batas int maksimal
            Debug.Assert(video != null && video.GetPlayCount() < int.MaxValue, "Nama Video Kosong");
            try
            {
                checked
                {
                    uploadedVideos.Add(video);
                }
            }
            // input tidak sesuai dan menampilkan overflow
            catch
            {
                Console.WriteLine("Overflow");
            }
        }

        // method untuk menampilakn nama user beserta koleksi videonya secara keseluruhan.
        public void PrintAllVideoCount()
        {
            Console.WriteLine($"User : {Username}");
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                Console.WriteLine($"Video {i+1} judul : {this.uploadedVideos[i].GetTitle()}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SayaTubeUser objUser = new SayaTubeUser("Revan");
            objUser.addVideoSaya(new SayaTubeVideo("ExHuma"));
            objUser.addVideoSaya(new SayaTubeVideo("Avatar"));
            objUser.addVideoSaya(new SayaTubeVideo("The Medium"));
            objUser.addVideoSaya(new SayaTubeVideo("Pengabdi Setan"));
            objUser.addVideoSaya(new SayaTubeVideo("Pengabdi Setan 2"));
            objUser.addVideoSaya(new SayaTubeVideo("The Conjuring"));
            objUser.addVideoSaya(new SayaTubeVideo("The Conjuring 2"));
            objUser.addVideoSaya(new SayaTubeVideo("Incantation"));
            objUser.addVideoSaya(new SayaTubeVideo("Insidious"));
            objUser.addVideoSaya(new SayaTubeVideo("Insidious the Last Key"));
            objUser.PrintAllVideoCount();
        }
    }
}
