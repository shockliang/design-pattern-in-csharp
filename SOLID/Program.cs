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

    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScanner
    {
        void Scan(Document document);
    }

    public interface IFaxMachine
    {
        void Fax(Document document);
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document document)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter, IFaxMachine
    {

    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private readonly IPrinter printer;
        private readonly IScanner scanner;
        private readonly IFaxMachine faxMachine;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner, IFaxMachine faxMachine)
        {
            this.printer = printer ?? throw new ArgumentNullException(nameof(printer));
            this.scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
            this.faxMachine = faxMachine ?? throw new ArgumentNullException(nameof(faxMachine));
        }

        public void Fax(Document document) => faxMachine.Fax(document);

        public void Print(Document document) => printer.Print(document);

        public void Scan(Document document) => scanner.Scan(document);
    }



    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
