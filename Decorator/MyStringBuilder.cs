using System;
using System.Runtime.Serialization;
using System.Text;

namespace Decorator
{
    public class MyStringBuilder
    {
        private StringBuilder sb = new StringBuilder();

        public static implicit operator MyStringBuilder(string s)
        {
            var msb = new MyStringBuilder();
            msb.Append(s);
            return msb;
        }

        public static MyStringBuilder operator +(MyStringBuilder msb, string s)
        {
            msb.Append(s);
            return msb;
        }

        public override string ToString()
        {
            return sb.ToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ((ISerializable)sb).GetObjectData(info, context);
        }

        public int EnsureCapacity(int capacity)
        {
            return sb.EnsureCapacity(capacity);
        }

        public string ToString(int startIndex, int length)
        {
            return sb.ToString(startIndex, length);
        }

        public MyStringBuilder Clear()
        {
            sb.Clear();
            return this;
        }

        public MyStringBuilder Append(char value, int repeatCount)
        {
            sb.Append(value, repeatCount);
            return this;
        }

        public MyStringBuilder Append(char[] value, int startIndex, int charCount)
        {
            sb.Append(value, startIndex, charCount);
            return this;
        }

        public MyStringBuilder Append(string value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(string value, int startIndex, int count)
        {
            sb.Append(value, startIndex, count);
            return this;
        }

        public MyStringBuilder AppendLine()
        {
            sb.AppendLine();
            return this;
        }

        public MyStringBuilder AppendLine(string value)
        {
            sb.AppendLine(value);
            return this;
        }

        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            sb.CopyTo(sourceIndex, destination, destinationIndex, count);
        }

        public MyStringBuilder Insert(int index, string value, int count)
        {
            sb.Insert(index, value, count);
            return this;
        }

        public MyStringBuilder Remove(int startIndex, int length)
        {
            sb.Remove(startIndex, length);
            return this;
        }

        public MyStringBuilder Append(bool value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(sbyte value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(byte value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(char value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(short value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(int value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(long value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(float value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(double value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(decimal value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(ushort value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(uint value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(ulong value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(object value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Append(char[] value)
        {
            sb.Append(value);
            return this;
        }

        public MyStringBuilder Insert(int index, string value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, bool value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, sbyte value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, byte value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, short value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, char value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, char[] value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, char[] value, int startIndex, int charCount)
        {
            sb.Insert(index, value, startIndex, charCount);
            return this;
        }

        public MyStringBuilder Insert(int index, int value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, long value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, float value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, double value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, decimal value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, ushort value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, uint value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, ulong value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder Insert(int index, object value)
        {
            sb.Insert(index, value);
            return this;
        }

        public MyStringBuilder AppendFormat(string format, object arg0)
        {
            sb.AppendFormat(format, arg0);
            return this;
        }

        public MyStringBuilder AppendFormat(string format, object arg0, object arg1)
        {
            sb.AppendFormat(format, arg0, arg1);
            return this;
        }

        public MyStringBuilder AppendFormat(string format, object arg0, object arg1, object arg2)
        {
            sb.AppendFormat(format, arg0, arg1, arg2);
            return this;
        }

        public MyStringBuilder AppendFormat(string format, params object[] args)
        {
            sb.AppendFormat(format, args);
            return this;
        }

        public MyStringBuilder AppendFormat(IFormatProvider provider, string format, params object[] args)
        {
            sb.AppendFormat(provider, format, args);
            return this;
        }

        public MyStringBuilder Replace(string oldValue, string newValue)
        {
            sb.Replace(oldValue, newValue);
            return this;
        }

        public bool Equals(MyStringBuilder sb)
        {
            return this.sb.Equals(sb);
        }

        public MyStringBuilder Replace(string oldValue, string newValue, int startIndex, int count)
        {
            sb.Replace(oldValue, newValue, startIndex, count);
            return this;
        }

        public MyStringBuilder Replace(char oldChar, char newChar)
        {
            sb.Replace(oldChar, newChar);
            return this;
        }

        public MyStringBuilder Replace(char oldChar, char newChar, int startIndex, int count)
        {
            sb.Replace(oldChar, newChar, startIndex, count);
            return this;
        }

        public int Capacity
        {
            get => sb.Capacity;
            set => sb.Capacity = value;
        }

        public int MaxCapacity => sb.MaxCapacity;

        public int Length
        {
            get => sb.Length;
            set => sb.Length = value;
        }

        public char this[int index]
        {
            get => sb[index];
            set => sb[index] = value;
        }
    }
}