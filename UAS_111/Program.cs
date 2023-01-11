using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace UAS_111
{
    class Node
    {
        public int Id_Brg;
        public string nama_brg;
        public string jenis_brg;
        public int harga_brg;
        public Node next;
        public Node prev;
    }

    class DoubleLinkList
    {
        Node start;
        public DoubleLinkList()
        {
            start = null;
        }
        
        public void insert()
        {
            int idBrg;
            string nm;
            string jenis;
            int harga;
            Console.WriteLine("\nMasukkan ID Barang: ");
            idBrg = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Barang: ");
            nm = Console.ReadLine();
            Console.Write("\nMasukkan Jenis Barang: ");
            jenis = Console.ReadLine();
            Console.Write("\nMasukkan Harga Barang: ");
            harga = Convert.ToInt32(Console.ReadLine());
            Node newnode = new Node();
            newnode.Id_Brg = idBrg;
            newnode.nama_brg = nm;
            newnode.jenis_brg = jenis;
            newnode.harga_brg = harga;

            if(start == null || idBrg <= start.Id_Brg)
            {
                if ((start != null) && (idBrg == start.Id_Brg))
                {
                    Console.WriteLine("\nID tidak bisa Duplikat");
                    return;
                }
                newnode.next = start;
                if (start != null)
                    start.prev = null;
                start = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = start; current != null && idBrg >= current.Id_Brg; previous = current, current = current.next)
            {
                if (idBrg == current.Id_Brg)
                {
                    Console.WriteLine("\nID tidak bisa Duplikat");
                    return;
                }
            }
            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = current;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }
        public bool listEmpty()
        {
            if (start == null)
                return true;
            else
                return false;
        }
        public void display()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("Data berdasarkan ID barang: \n");
                Node currentNode;
                for(currentNode = start; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.Id_Brg + "\n" + currentNode.nama_brg + "\n" + currentNode.jenis_brg + "\n"+ currentNode.harga_brg + "\n");
            }
        }
        public bool search(string jenisBrg, ref Node previous, ref Node current)
        {
            previous = start;
            current = start;
            while((current != null) && (jenisBrg != current.jenis_brg))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        
    }
        
    
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkList obj = new DoubleLinkList();
            while(true)
            {
                try
                {
                    Console.WriteLine("1. Menambah Data");
                    Console.WriteLine("2. Menampilkan Data");
                    Console.WriteLine("3. Mencari Data");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insert();
                            }
                            break;
                        case '2':
                            {
                                obj.display();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("\nMasukkan Jenis barang yang ingin dicari: ");
                                string jenis = Convert.ToString(Console.ReadLine());
                                if (obj.search(jenis, ref prev ,ref curr) == false)
                                    Console.WriteLine("\nPencarian tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nPencarian ditemukan");
                                    Console.WriteLine("\nId Barang: " + curr.Id_Brg);
                                    Console.WriteLine("\nNama Barang: " + curr.nama_brg);
                                    Console.WriteLine("\nHarga Barang: " + curr.harga_brg);
                                }
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cek ID yang di Masukkan");
                }
            }
        }
    }
}


//2.Doublelinklist karena kita bisa mengurutkan data seperti apa yg indri mau
//3.Rear dan Front
//4.a.5
//  b.preorder (50,48,30,20,15,25,32,31,35,70,65,67,66,69,90,98,94,99)