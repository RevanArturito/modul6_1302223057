namespace modul6_1302223057
{
    class random
    {
        public int idRandom()
        {
            Random id = new Random();
            return id.Next(10000,99999);
        }
    }
    class SayaTubeVideo
    {
        private int id;
        private int playCount;
        private String title;


        public SayaTubeVideo(String judul)
        {
            random random = new random();

            this.title = judul;
            this.id = random.idRandom();
            this.playCount = 0;

        }

        public void IncreasePlayCount(int input)
        {
            this.playCount += input;
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID : {id}");
            Console.WriteLine($"Title : {title}");
            Console.WriteLine($"PlayCount : {playCount}");
        }
        public int GetPlayCount()
        {
            return this.playCount;
        }
        public String GetTitle()
        { 
            return this.title;
        }
    }

    class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public String Username;


        public SayaTubeUser(String nama)
        {
            this.Username = nama;
            this.uploadedVideos = new List<SayaTubeVideo>();

        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                 total += uploadedVideos[i].GetPlayCount();
            }
            return total;
        }

        public void addVideoSaya(SayaTubeVideo video)
        {
            uploadedVideos.Add(video);
        }

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
