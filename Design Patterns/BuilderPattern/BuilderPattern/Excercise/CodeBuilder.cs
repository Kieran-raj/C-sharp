using System.Text;

namespace BuilderPattern.Excercise
{
    public class CodeBuilder
    {
        private Dictionary<string, string> _Fields = new Dictionary<string, string>();
        private int _IndentSize = 2;
        private string _ClassName;

        public CodeBuilder(string className)
        {
            this._ClassName = className;
        }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            if (!this._Fields.ContainsKey(fieldName))
            {
                this._Fields.Add(fieldName, fieldType);
            }

            return this;
        }

        public override string ToString()
        {
            return this.ImplementToString();
        }

        private string ImplementToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {this._ClassName}");
            sb.AppendLine("{");
            foreach (var field in this._Fields)
            {
                sb.Append(new string(' ', this._IndentSize));
                sb.AppendLine($"public {field.Value} {field.Key};");
            }
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
