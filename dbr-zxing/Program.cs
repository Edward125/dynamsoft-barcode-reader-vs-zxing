using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZXing;
using Dynamsoft.Barcode;
using ZXing.Common;
using System.Diagnostics;
using System.IO;

namespace dbr_zxing
{
    class Program
    {
        static void ZXing_Test(string directory)
        {
            ZXing.MultiFormatReader multiFormatReader = new ZXing.MultiFormatReader();
            ZXing.Multi.GenericMultipleBarcodeReader multiBarcodeReader = new ZXing.Multi.GenericMultipleBarcodeReader(multiFormatReader);

            string[] files = Directory.GetFiles(directory);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                Bitmap bitmap = (Bitmap)Image.FromFile(file);
                LuminanceSource source = new BitmapLuminanceSource(bitmap);
                ZXing.BinaryBitmap bBitmap = new ZXing.BinaryBitmap(new HybridBinarizer(source));
                Stopwatch swZXing = Stopwatch.StartNew();
                ZXing.Result[] zResults = multiBarcodeReader.decodeMultiple(bBitmap);
                swZXing.Stop();

                if (zResults != null)
                {
                    Console.WriteLine("ZXing time: " + swZXing.Elapsed.TotalMilliseconds + "ms" + ", result count: " + zResults.Length);
                }
                else
                {
                    Console.WriteLine("ZXing time: " + swZXing.Elapsed.TotalMilliseconds + "ms" + ", result count: failed");
                }

                if (zResults != null)
                {
                    //foreach (ZXing.Result zResult in zResults)
                    //{
                    //    Console.WriteLine("ZXing result: " + zResult.Text);
                    //}
                }

                Console.WriteLine("\n");
            }
        }

        static void Dynamsoft_Barcode_Reader_Test(string directory)
        {
            Dynamsoft.Barcode.BarcodeReader reader = new Dynamsoft.Barcode.BarcodeReader();
            reader.LicenseKeys = "t0068NQAAAJx5X8TaH/zQIy0Mm3HHIypzFTL+DQTIQah1eCiNcZygsi6sFa0cZiJVv+rRTyU29TpFsLA6hWiz+GAlQlGrRRg=";

            string[] files = Directory.GetFiles(directory);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                Bitmap barcodeBitmap = (Bitmap)Image.FromFile(file);
                try
                {
                    Stopwatch swDBR = Stopwatch.StartNew();
                    TextResult[] results = reader.DecodeBitmap(barcodeBitmap, "");
                    swDBR.Stop();

                    if (results != null)
                    {
                        Console.WriteLine("DBR time: " + swDBR.Elapsed.TotalMilliseconds + "ms" + ", result count: " + results.Length);
                    }
                    else
                    {
                        Console.WriteLine("DBR time: " + swDBR.Elapsed.TotalMilliseconds + "ms" + ", result count: failed");
                    }

                    if (results != null)
                    {
                        //foreach (TextResult result in results)
                        //{
                        //    Console.WriteLine(result.BarcodeFormat);
                        //    Console.WriteLine(result.BarcodeText);
                        //}
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Console.WriteLine("\n");
            }
        }

        static void Dynamsoft_Barcode_Reader_Test_Single(string file, Dynamsoft.Barcode.BarcodeReader reader)
        {
            Bitmap barcodeBitmap = (Bitmap)Image.FromFile(file);
            try
            {
                Stopwatch swDBR = Stopwatch.StartNew();
                TextResult[] results = reader.DecodeBitmap(barcodeBitmap, "");
                swDBR.Stop();

                if (results != null)
                {
                    //Console.WriteLine("DBR\t time: " + swDBR.Elapsed.TotalMilliseconds + "ms" + ",\t result count: " + results.Length);
                    Console.WriteLine("{0, -10}{1, -20}{2, -20}", "DBR", "time: " + swDBR.Elapsed.TotalMilliseconds + "ms", " result count: " + results.Length);
                }
                else
                {
                    //Console.WriteLine("DBR\t time: " + swDBR.Elapsed.TotalMilliseconds + "ms" + ",\t result count: failed");
                    Console.WriteLine("{0, -10}{1, -20}{2, -20}", "DBR", "time: " + swDBR.Elapsed.TotalMilliseconds + "ms", " result count: failed");
                }

                if (results != null)
                {
                    //foreach (TextResult result in results)
                    //{
                    //    Console.WriteLine(result.BarcodeFormat);
                    //    Console.WriteLine(result.BarcodeText);
                    //}
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void ZXing_Test_Single(string file, ZXing.Multi.GenericMultipleBarcodeReader multiBarcodeReader)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(file);
            LuminanceSource source = new BitmapLuminanceSource(bitmap);
            ZXing.BinaryBitmap bBitmap = new ZXing.BinaryBitmap(new HybridBinarizer(source));
            Stopwatch swZXing = Stopwatch.StartNew();
            ZXing.Result[] zResults = multiBarcodeReader.decodeMultiple(bBitmap);
            swZXing.Stop();

            if (zResults != null)
            {
                //Console.WriteLine("ZXing\t time: " + swZXing.Elapsed.TotalMilliseconds + "ms" + ",\t result count: " + zResults.Length);
                Console.WriteLine("{0, -10}{1, -20}{2, -20}", "ZXing", "time: " + swZXing.Elapsed.TotalMilliseconds + "ms", " result count: " + zResults.Length);
            }
            else
            {
                //Console.WriteLine("ZXing\t time: " + swZXing.Elapsed.TotalMilliseconds + "ms" + ",\t result count: failed");
                Console.WriteLine("{0, -10}{1, -20}{2, -20}", "ZXing", "time: " + swZXing.Elapsed.TotalMilliseconds + "ms", " result count: failed");
            }

            if (zResults != null)
            {
                //foreach (ZXing.Result zResult in zResults)
                //{
                //    Console.WriteLine("ZXing result: " + zResult.Text);
                //}
            }
        }

        static void ZXing_DBR_Test(string directory)
        {
            Dynamsoft.Barcode.BarcodeReader reader = new Dynamsoft.Barcode.BarcodeReader();
            reader.LicenseKeys = "t0068NQAAAJx5X8TaH/zQIy0Mm3HHIypzFTL+DQTIQah1eCiNcZygsi6sFa0cZiJVv+rRTyU29TpFsLA6hWiz+GAlQlGrRRg=";

            ZXing.MultiFormatReader multiFormatReader = new ZXing.MultiFormatReader();
            ZXing.Multi.GenericMultipleBarcodeReader multiBarcodeReader = new ZXing.Multi.GenericMultipleBarcodeReader(multiFormatReader);

            string[] files = Directory.GetFiles(directory);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                Console.BackgroundColor = ConsoleColor.Blue;
                ZXing_Test_Single(file, multiBarcodeReader);
                Console.ResetColor();

                Console.BackgroundColor = ConsoleColor.Red;
                Dynamsoft_Barcode_Reader_Test_Single(file, reader);
                Console.ResetColor();
                Console.WriteLine("\n");
            }
        }

        static void Main(string[] args)
        {
            string directory = null;
            if (args.Length < 1)
            {
                directory = @"E:\Program Files (x86)\Dynamsoft\Barcode Reader 6.1\Images";
            }
            else
                directory = args[0];

            if (!Directory.Exists(directory))
            {
                Console.WriteLine("Directory does not exist");
            }

            //ZXing_Test(directory);
            //Dynamsoft_Barcode_Reader_Test(directory);

            // Mixed
            try
            {
                ZXing_DBR_Test(directory);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ResetColor();
            }
            
        }
    }
}
