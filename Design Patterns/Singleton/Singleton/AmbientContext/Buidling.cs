using System.Text;

namespace Singleton.AmbientContext
{
    public class Buidling
    {
        public List<Wall> Walls = new List<Wall>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var wall in Walls)
            {
                sb.AppendLine(wall.ToString());
            }
            return sb.ToString();
        }
    }
}
