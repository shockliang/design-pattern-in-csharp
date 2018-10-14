using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Exercises
{
    public class CodeBuilder
    {
        private readonly string className;
        private const int indent = 2;

        private class Property
        {
            public string Name, Type;
        }

        private List<Property> properties = new List<Property>();

        public CodeBuilder(string className)
        {
            this.className = className;
        }

        public CodeBuilder AddField(string propertyName, string propertyType)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(paramName: nameof(propertyName));
            if (string.IsNullOrEmpty(propertyType))
                throw new ArgumentNullException(paramName: nameof(propertyType));

            properties.Add(new Property() { Name = propertyName, Type = propertyType });
            return this;
        }

        public override string ToString()
        {
            var indentSpace = new string(' ', indent);
            var sb = new StringBuilder();
            sb.AppendLine($"public class {className}");
            sb.AppendLine("{");
            foreach (var p in properties)
            {
                sb.AppendLine($"{indentSpace}public {p.Type} {p.Name};");
            }
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}