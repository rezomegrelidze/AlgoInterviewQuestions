public static class SolutionToQuestion2
{
    public class Song
    {
        public void Play()
        {
            // this is a toy example so the method is left empty
        }
    }

    public static void Shuffle(Song[] songs)
    {
        var rand = new Random();
        for (int i = 0; i < songs.Length; i++)
        {
            int j = rand.Next(i+1);
            (songs[i], songs[j]) = (songs[j], songs[i]); // swap
        }
    }
}