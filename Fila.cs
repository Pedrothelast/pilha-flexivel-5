class Fila
{
    private Celula frente;
    private Celula tras;

    public Fila()
    {
        frente = new Celula(0); // Célula de início sem valor real
        tras = frente;
    }

    public void Enfileirar(int elemento)
    {
        Celula novaCelula = new Celula(elemento);
        tras.Proxima = novaCelula;
        tras = novaCelula;
    }

    public int Desenfileirar()
    {
        if (EstaVazia())
        {
            throw new InvalidOperationException("A fila está vazia.");
        }

        Celula celulaRemovida = frente.Proxima;
        frente.Proxima = celulaRemovida.Proxima;

        if (tras == celulaRemovida)
        {
            tras = frente;
        }

        return celulaRemovida.Elemento;
    }

    public int ObterFrente()
    {
        if (EstaVazia())
        {
            throw new InvalidOperationException("A fila está vazia.");
        }

        return frente.Proxima.Elemento;
    }

    static int Count()
    {
        int count = 0;

        foreach (var item in fila)
        {
            count++;
        }

        return count;
    }

    public bool EstaVazia()
    {
        return frente == tras;
    }

    public void Imprimir()
    {
        Celula atual = frente.Proxima;
        while (atual != null)
        {
            Console.Write(atual.Elemento + " ");
            atual = atual.Proxima;
        }
        Console.WriteLine();
    }

    static void InverterFila(Fila fila)
    {
        Pilha pilha = new Pilha();

        while (fila.Count > 0)
        {
            pilha.Inserir(fila.Desenfileirar());
        }

        while (pilha.Count > 0)
        {
            fila.Enfileirar(pilha.Remover());
        }
    }
}