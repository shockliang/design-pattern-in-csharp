using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace SOLID
{
    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document document);
        void Scna(Document document);
        void Fax(Document document);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document document)
        {
            //
        }

        public void Print(Document document)
        {
            //
        }

        public void Scna(Document document)
        {
            //
        }
    }

    // Only print functionality.
    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document document)
        {
            // implementing
        }

        // Must comment not support in old fashioned print.
        public void Fax(Document document)
        {
            throw new NotImplementedException();
        }

        // Must comment not support in old fashioned print.
        public void Scna(Document document)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
