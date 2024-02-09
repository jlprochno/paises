namespace paises;

using System;
using System.Collections.Generic;

class Pais
{
    private string codigoISO;
    private string nome;
    private long populacao;
    private double dimensaoKm2;
    private List<Pais> paisesVizinhos;

    // Construtor
    public Pais(string codigoISO, string nome, long populacao, double dimensaoKm2)
    {
        this.codigoISO = codigoISO;
        this.nome = nome;
        this.populacao = populacao;
        this.dimensaoKm2 = dimensaoKm2;
        this.paisesVizinhos = new List<Pais>();
    }

    // Métodos de acesso (getter/setter)
    public string CodigoISO
    {
        get { return codigoISO; }
        set { codigoISO = value; }
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public long Populacao
    {
        get { return populacao; }
        set { populacao = value; }
    }

    public double DimensaoKm2
    {
        get { return dimensaoKm2; }
        set { dimensaoKm2 = value; }
    }

    public List<Pais> PaisesVizinhos
    {
        get { return paisesVizinhos; }
        set { paisesVizinhos = value; }
    }

    // Método para verificar se dois países são iguais
    public bool SaoIguais(Pais outroPais)
    {
        return this.codigoISO == outroPais.codigoISO;
    }

    // Método para verificar se um país é vizinho do país que recebeu a mensagem
    public bool EVizinho(Pais outroPais)
    {
        return paisesVizinhos.Contains(outroPais);
    }

    // Método para calcular a densidade populacional
    public double DensidadePopulacional()
    {
        return populacao / dimensaoKm2;
    }

    // Método para obter a lista de vizinhos comuns a dois países
    public List<Pais> VizinhosComuns(Pais outroPais)
    {
        List<Pais> vizinhosComuns = new List<Pais>();

        foreach (var vizinho in paisesVizinhos)
        {
            if (outroPais.PaisesVizinhos.Contains(vizinho))
            {
                vizinhosComuns.Add(vizinho);
            }
        }

        return vizinhosComuns;
    }
}

class Program
{
    static void Main()
    {
        // Exemplo de uso da classe Pais
        Pais brasil = new Pais("BRA", "Brasil", 210147125, 8515767.049);
        Pais argentina = new Pais("ARG", "Argentina", 44938712, 2780400);
        Pais paraguai = new Pais("PRY", "Paraguai", 7152703, 406752);
        
        brasil.PaisesVizinhos.Add(argentina);
        brasil.PaisesVizinhos.Add(paraguai);
        argentina.PaisesVizinhos.Add(brasil);
        paraguai.PaisesVizinhos.Add(brasil);

        Console.WriteLine("Densidade Populacional do Brasil: " + brasil.DensidadePopulacional() + " pessoas por Km²");

        if (brasil.EVizinho(argentina))
        {
            Console.WriteLine("Brasil faz fronteira com Argentina.");
        }

        Pais uruguai = new Pais("URY", "Uruguai", 3449299, 176215);
        argentina.PaisesVizinhos.Add(uruguai);
        uruguai.PaisesVizinhos.Add(argentina);

        List<Pais> vizinhosComuns = brasil.VizinhosComuns(argentina);

        Console.WriteLine("Vizinhos comuns entre Brasil e Argentina:");
        foreach (var vizinho in vizinhosComuns)
        {
            Console.WriteLine(vizinho.Nome);
        }

        // Aguardando entrada do usuário para fechar o console
        Console.ReadLine();
    }
}

