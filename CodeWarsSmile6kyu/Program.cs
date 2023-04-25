namespace CodeWarsSmile6kyu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountSmileys(new string[] { ":)", ";(", ";}", ":-D" }));
        }

        public static int CountSmileys(string[] smileys)
        {
            int smileCount = 0;
            foreach (var face in smileys)
            {
                if (face.Length > 3 && face.Length < 2)
                    continue;
                else if (face.Length == 2 && (face[0] == ':' || face[0] == ';') && (face[1] == ')' || face[1] == 'D'))
                    smileCount++;
                else if (face.Length == 3 && (face[0] == ':' || face[0] == ';') && (face[1] == '-' || face[1] == '~') && (face[2] == ')' || face[2] == 'D'))
                    smileCount++;
                else
                    continue;
            }
            return smileCount;
        }
    }
}