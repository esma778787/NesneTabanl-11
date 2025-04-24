using System;


class Kisi : IComparable<Kisi>
{
    private TreeNode kok;

    public string Ad { get; set; }
    public string Soyad { get; set; }
    public string TCKimlik { get; set; }

    public Kisi(string ad, string soyad)
    {
        Ad = ad;
        Soyad = soyad;
    }


    public void Goster()
    {
        Console.WriteLine($"Ad: {Ad}, Soyad: {Soyad}");
        Console.Write("TC Kimlik: ");
        TCKimlik = Console.ReadLine();
    }
    public int CompareTo(Kisi other)
    {
        int soyadKarsilastirma = string.Compare(this.Soyad, other.Soyad, StringComparison.Ordinal);

        if (soyadKarsilastirma != 0)
        {
            return soyadKarsilastirma;
        }
        else
        {
            return string.Compare(this.Ad, other.Ad, StringComparison.Ordinal);
        }
    }
}



class TreeNode
{
    public Kisi Kisi { get; set; }
    public TreeNode Sol { get; internal set; }
    public TreeNode Sag { get; internal set; }
    public string Soyad { get; private set; }
    public string Ad { get; private set; }

    public TreeNode(Kisi kisi)
    {
        Kisi = kisi;
        Sol = null;
        Sag = null;
    }
    public int CompareTo(Kisi other)
    {
        int soyadKarsilastirma = string.Compare(this.Soyad, other.Soyad, StringComparison.Ordinal);

        if (soyadKarsilastirma != 0)
        {
            return soyadKarsilastirma;
        }
        else
        {
            return string.Compare(this.Ad, other.Ad, StringComparison.Ordinal);
        }
    }
}

class BinaryTree
{
    private TreeNode kok;

    public void Ekle(Kisi kisi)
    {
        kok = EkleRec(kok, kisi);
    }

    private TreeNode EkleRec(TreeNode node, Kisi kisi)
    {
        if (node == null)
        {
            return new TreeNode(kisi);
        }

        int soyadKarsilastirma = string.Compare(kisi.Soyad, node.Kisi.Soyad, StringComparison.Ordinal);

        if (soyadKarsilastirma < 0)
        {
            node.Sol = EkleRec(node.Sol, kisi);
        }
        else if (soyadKarsilastirma > 0)
        {
            node.Sag = EkleRec(node.Sag, kisi);
        }
        else 
        {
            int adKarsilastirma = string.Compare(kisi.Ad, node.Kisi.Ad, StringComparison.Ordinal);

            if (adKarsilastirma < 0)
            {
                node.Sol = EkleRec(node.Sol, kisi);
            }
            else if (adKarsilastirma > 0)
            {
                node.Sag = EkleRec(node.Sag, kisi);
            }
            else
            {
              
            }
        }

        return node;
    }
    public void GorselGoster()
    {
        GorselGosterRec(kok, 0, "Kök");
    }

    private void GorselGosterRec(TreeNode node, int depth, string side)
    {
        if (node != null)
        {
            GorselGosterRec(node.Sag, depth + 1, "Sağ");
            Console.WriteLine($"{new string(' ', depth * 4)}{side} - {node.Kisi.Ad} {node.Kisi.Soyad}");
            GorselGosterRec(node.Sol, depth + 1, "Sol");
        }
    }


    public void InOrder()
    {
        InOrderRec(kok);
    }

    private void InOrderRec(TreeNode node)
    {
        if (node != null)
        {
            InOrderRec(node.Sol);
            node.Kisi.Goster();
            InOrderRec(node.Sag);
        }
    }
}

class Program
{
    static void Main()
    {
        BinaryTree agac = new BinaryTree();


        agac.Ekle(new Kisi("Ahmet", "Yılmaz"));
        agac.Ekle(new Kisi("Mehmet", "Yıldız"));
        agac.Ekle(new Kisi("Ayşe", "Yılmaz"));
        agac.Ekle(new Kisi("Fatma", "Demir"));
        agac.Ekle(new Kisi("Mustafa", "Kula"));
        agac.Ekle(new Kisi("Yusuf", "Yılmaz"));
        agac.Ekle(new Kisi("Seda", "Copur"));
        agac.Ekle(new Kisi("Ayşe", "Güçlü"));
        agac.Ekle(new Kisi("Fatma", "Kara"));
        agac.Ekle(new Kisi("Mehmet", "Beyaz"));
        agac.Ekle(new Kisi("Esma", "Duman"));
        agac.Ekle(new Kisi("Ali", "Ongel"));
        agac.Ekle(new Kisi("Elif", "Fatih"));
        agac.Ekle(new Kisi("Olcay", "Damla"));
        agac.Ekle(new Kisi("Murat", "Sarp"));
        agac.Ekle(new Kisi("Yasemin", "Moussa"));
        agac.Ekle(new Kisi("Emine", "Copur"));
        agac.Ekle(new Kisi("Selda", "Gemi"));
        agac.Ekle(new Kisi("Fatih", "San"));
        agac.Ekle(new Kisi("Mahmut", "Budak"));
        agac.Ekle(new Kisi("Aykut", "Polat"));
        agac.Ekle(new Kisi("Meryem", "Altın"));
        agac.Ekle(new Kisi("Aylin", "Karahan"));
        agac.Ekle(new Kisi("Fatma", "Emre"));
        agac.Ekle(new Kisi("Deniz", "Aslan"));
        agac.Ekle(new Kisi("Yeliz", "Kaplan"));
        agac.Ekle(new Kisi("Sema", "Can"));
        agac.Ekle(new Kisi("Aysu", "Getir"));
        agac.Ekle(new Kisi("Salih", "Kolus"));
        agac.Ekle(new Kisi("Mert", "Kavak"));
        agac.Ekle(new Kisi("Tolga", "Tunc"));
        agac.Ekle(new Kisi("Halime", "Yıldız"));


        
        Console.WriteLine("Ağaçtaki Kişiler (Soyad ve Ad'a Göre Sıralı):");
        agac.InOrder();
        agac.GorselGoster();

        Console.ReadLine();

        Console.ReadLine();
    }
}
