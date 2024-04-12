using Avalonia.Controls;
using Avalonia.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Avalonia.Media.Imaging;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Collections;
using System.Xml.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace ListBoxNew 
{
    public class Changing 
    {
        public string NameV { get; set; }
        public string PriceV { get; set; }
        public int del { get; set; }
        public int id { get; set; }
        public int edit{ get; set; }
        public  TextBox DobProd { get; set; }
       public float Sum { get; set; }
        public int idKol { get; set; }
        public int idKolM { get; set; } 
        public string fileName {  get; set; }
        public string NameDob {  get; set; }
        public Bitmap ProductImage
        {
            get
            {
                return new Bitmap(fileName);
            }
            set { }
        }
       

    }
    
    public  class Shop
    {
        public  List<Changing> shop =  new List<Changing>();
    }
}